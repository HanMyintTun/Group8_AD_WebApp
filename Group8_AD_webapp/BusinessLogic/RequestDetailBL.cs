﻿using Group8_AD_webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group8AD_WebAPI.BusinessLogic
{
    public static class RequestDetailBL
    {
        //add RequestDetail with empId , reqDet and status

        public static RequestDetailVM AddReqDet(int empId, string itemCode, int reqQty, string status)
        {

            RequestDetailVM reqDetail = new RequestDetailVM();
            using (SA46Team08ADProjectContext entities = new SA46Team08ADProjectContext())
            {
                List<RequestVM> requestlists = RequestBL.GetReq(empId, status);

                List<RequestDetailVM> rdList = new List<RequestDetailVM>();

                foreach (RequestVM r in requestlists)
                {
                    List<RequestDetailVM> rrdlist = entities.RequestDetails.Where(rd => rd.ReqId == r.ReqId).Select(rd => new RequestDetailVM()
                    {
                        ReqId = rd.ReqId,
                        ReqLineNo = rd.ReqLineNo,
                        ItemCode = rd.ItemCode,
                        ReqQty = rd.ReqQty,
                        AwaitQty = rd.AwaitQty,
                        FulfilledQty = rd.FulfilledQty
                    }).ToList<RequestDetailVM>();

                    rdList.AddRange(rrdlist);


                    foreach (RequestDetailVM rd in rdList)
                    {
                        string ICode = "";                        
                        foreach (RequestDetailVM reqd in rdList)
                        {
                            if (reqd.ItemCode.Equals(itemCode))
                            {
                                ICode = reqd.ItemCode;
                            }
                        }
                        if (status == "Unsubmitted")
                        { 
                            if (ICode.Equals(itemCode))                              
                            {
                                reqDetail = rdList.Where(x => x.ItemCode.Equals(itemCode)).First();
                                reqDetail.ItemCode = itemCode;
                                reqDetail.ReqQty += reqQty;
                                UpdateReqDet(r.ReqId, reqDetail);
                                return reqDetail;
                            }
                            else if(!ICode.Equals(itemCode))                            
                            {
                                reqDetail.ReqId = r.ReqId;
                                reqDetail.ItemCode = itemCode;
                                reqDetail.ReqQty = reqQty;
                                reqDetail.ReqLineNo = rdList.OrderByDescending(x => x.ReqLineNo).Select(x => x.ReqLineNo).First() + 1;
                                AddReqDet(r.ReqId, reqDetail);//create reqDet
                                return reqDetail;
                            }
                        }
                        if (status == "Bookmarked")
                        {
                            if (!ICode.Equals(itemCode))
                                //rdList.Find(rq => rq.ItemCode.Equals(itemCode)).ItemCode.Equals(itemCode))//if reqDet does not exist  with itemCode
                            {
                                reqDetail.ReqId = r.ReqId;
                                reqDetail.ItemCode = itemCode;
                                reqDetail.ReqQty = reqQty;
                                reqDetail.ReqLineNo = rdList.OrderByDescending(x => x.ReqLineNo).Select(x => x.ReqLineNo).First() + 1;
                                AddReqDet(r.ReqId, reqDetail);//create reqDet
                                return reqDetail;
                            }
                        }
                    }
                }                             

                if (requestlists.Count == 0)
                {
                    //RequestDetailVM reqDetail = new RequestDetailVM();
                    RequestBL.AddReq(empId, status);
                }

            }
            return reqDetail;
        }

        //add RequestDetail with reqId and reqDet
        public static RequestDetailVM AddReqDet(int reqId, RequestDetailVM reqDet)
        {
            RequestDetailVM request = new RequestDetailVM();
            using (SA46Team08ADProjectContext entities = new SA46Team08ADProjectContext())
            {
                RequestDetail req = new RequestDetail();
                req.ReqId = reqId;
                req.ReqLineNo = reqDet.ReqLineNo;
                req.ItemCode = reqDet.ItemCode;
                req.ReqQty = reqDet.ReqQty;
                req.AwaitQty = reqDet.AwaitQty;
                req.FulfilledQty = reqDet.FulfilledQty;
                entities.RequestDetails.Add(req);
                entities.SaveChanges();

                List<RequestDetail> lst = entities.RequestDetails.ToList();
                RequestDetail r = lst[lst.Count - 1];
                request.ReqId = r.ReqId;
                request.ReqLineNo = r.ReqLineNo;
                request.ItemCode = r.ItemCode;
                request.ReqQty = r.ReqQty;
                request.AwaitQty = r.AwaitQty;
                request.FulfilledQty = r.FulfilledQty;
            }

            return request;

        }

        //update RequestDetail with reqId and reqDet
        public static RequestDetailVM UpdateReqDet(int reqId, RequestDetailVM reqDet)
        {
            RequestDetailVM ReqDetailVM = new RequestDetailVM();
            using (SA46Team08ADProjectContext entities = new SA46Team08ADProjectContext())
            {
                RequestDetail updateReqDetail = entities.RequestDetails.Where(r => r.ReqId == reqId && r.ItemCode.Equals(reqDet.ItemCode)).First();

                updateReqDetail.ReqId = reqId;
                updateReqDetail.ItemCode = reqDet.ItemCode;
                updateReqDetail.ReqQty = reqDet.ReqQty;
                updateReqDetail.AwaitQty = reqDet.AwaitQty;
                updateReqDetail.FulfilledQty = reqDet.FulfilledQty;
                entities.SaveChanges();

                List<RequestDetail> lst = entities.RequestDetails.ToList();
                RequestDetail rd = lst[lst.Count - 1];
                ReqDetailVM.ReqId = rd.ReqId;
                ReqDetailVM.ItemCode = rd.ItemCode;
                ReqDetailVM.ReqQty = rd.ReqQty;
                ReqDetailVM.AwaitQty = rd.AwaitQty;
                ReqDetailVM.FulfilledQty = rd.FulfilledQty;
            }
            return ReqDetailVM;
        }
        //remove removeReqDet by empId and reqId 
        public static void removeReqDet(int empId, string itemCode, string status)
        {
            using (SA46Team08ADProjectContext entities = new SA46Team08ADProjectContext())
            {
                List<RequestDetail> reqDetlist = entities.RequestDetails.Where(r => r.ItemCode == itemCode).ToList();
                if (reqDetlist.Count > 0)
                {
                    for (int i = 0; i < reqDetlist.Count; i++)
                    {
                        entities.RequestDetails.Remove(reqDetlist[i]);
                        entities.SaveChanges();
                    }
                }
            }
        }

        //remove ReqDet
        public static void removeReqDet(int reqId, string itemCode)
        {
            using (SA46Team08ADProjectContext entities = new SA46Team08ADProjectContext())
            {
                RequestDetail request = entities.RequestDetails.Where(r => r.ReqId == reqId && r.ItemCode == itemCode).FirstOrDefault();
                if (request != null)
                {
                    entities.RequestDetails.Remove(request);
                    entities.SaveChanges();
                }
            }
        }

        //remove All
        public static void removeAllReqDet(int reqId)
        {
            using (SA46Team08ADProjectContext entities = new SA46Team08ADProjectContext())
            {
                RequestDetail request = entities.RequestDetails.Where(r => r.ReqId == reqId).FirstOrDefault();
                if (request != null)
                {
                    entities.RequestDetails.Remove(request);
                    entities.SaveChanges();
                }
            }
        }

        //get ReqDetList
        public static List<RequestDetailVM> GetReqDetList(int reqId)
        {
            List<RequestDetailVM> reqDetlists = new List<RequestDetailVM>();
            List<RequestDetail> lst = new List<RequestDetail>();
            using (SA46Team08ADProjectContext entities = new SA46Team08ADProjectContext())
            {
                lst = entities.RequestDetails.Where(r => r.ReqId == reqId).ToList();
            }
            for (int i = 0; i < lst.Count; i++)
            {
                RequestDetailVM req = new RequestDetailVM();
                req.ReqId = lst[i].ReqId;
                req.ItemCode = lst[i].ItemCode;
                req.ReqLineNo = lst[i].ReqLineNo;
                req.ReqQty = lst[i].ReqQty;
                req.AwaitQty = lst[i].AwaitQty;
                req.FulfilledQty = lst[i].FulfilledQty;
                reqDetlists.Add(req);
            }
            return reqDetlists;

        }

        //update Await
        public static void UpdateAwait(int reqId, int awaitQty)
        {
            using (SA46Team08ADProjectContext entities = new SA46Team08ADProjectContext())
            {
                RequestDetail await = entities.RequestDetails.Where(r => r.ReqId == reqId).First<RequestDetail>();
                if (await != null)
                {
                    await.AwaitQty = awaitQty;
                }
                entities.SaveChanges();
            }
        }

        //GetDeptCode
        public static string GetDeptCode(RequestDetail reqDet)
        {
            using (SA46Team08ADProjectContext entities = new SA46Team08ADProjectContext())
            {
                string deptcode = entities.RequestDetails.Select(r => r.Request.Employee.DeptCode).FirstOrDefault();
                return deptcode;
            }
        }

        //Update Fulfilled
        public static void UpdateFulfilled(int reqId, int fulfilledQty)
        {
            using (SA46Team08ADProjectContext entities = new SA46Team08ADProjectContext())
            {
                RequestDetail fulfilled = entities.RequestDetails.Where(r => r.ReqId == reqId).First<RequestDetail>();
                //RequestDetail fulfilled = entities.RequestDetails.Where(r => r.ReqId == reqId).First<RequestDetail>();
                if (fulfilled != null)
                {
                    fulfilled.FulfilledQty = fulfilledQty;
                    entities.SaveChanges();
                }
            }
        }

    }
}