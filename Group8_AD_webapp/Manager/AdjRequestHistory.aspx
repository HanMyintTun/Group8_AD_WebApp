<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdjRequestHistory.aspx.cs" Inherits="Group8_AD_webapp.Manager.AdjRequestHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="../css/employee-style.css" rel="stylesheet" />
            <link href="../css/datepicker3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="form-group form-inline formstyle2 text-center">
        <div class="col-lg-3">
        <span class="subtitletext mt-5 ml-5"><asp:Label ID="lblCatTitle" runat="server" Text="Stock Adjustment Request"></asp:Label></span>
        </div>
        <div class="col-xs-12 col-lg-2">
        <asp:DropDownList ID="ddlStatus" CssClass="ddlStatus form-control" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="True">
            <asp:listitem text="All" value="All" />
        </asp:DropDownList>
         </div>
        </div>
        <div id="main"> <!-- col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 -->
        
        <div id="centermain2">
            <div class="row">
            <div class="col-xs-12">
                <div ID="divAlert" class="alert alert-success alert-dismissible" role="alert" runat="server">
                  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                  <strong><asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label></strong>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:ListView runat="server" ID="lstRequests"  OnItemCommand="lstRequests_ItemCommand">
                            <LayoutTemplate>
                                <table runat="server" class="table">
                                    <thead>
                                        <tr id="thdReqHistory" runat="server">

                                            <th scope="col">Submitted Date</th>
                                            <th scope="col">Voucher No.</th>
                                            <th scope="col">Status</th>
                                            <th scope="col"></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr id="itemPlaceholder" runat="server"></tr>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><asp:Label runat="server" ID="lblReqDate" Text='<%# Eval("DateTimeIssued","{0:dd-MMM-yyyy}") %>' /></td>
                                    <td><asp:Label runat="server" ID="lblVoucher" Text='<%# Eval("VoucherNo") %>' /></td>
                                    <td><asp:Label runat="server" ID="lblStatus" Text='<%# Eval("Status") %>' /></td>
                                    <td><asp:LinkButton ID="btnReqDetail" CssClass="btn btn-primary" CommandName="Detail" CommandArgument='<%#Eval("VoucherNo")%>' runat="server">Details</asp:LinkButton> </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <span class="noresult showsearch">Sorry! No requests found within those search parameters!</span>
                                <!-- Add Back Button here -->
                            </EmptyDataTemplate>
                            </asp:ListView>
                        </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>


        </div>
    </div>
        </div>

    <%-- modal content--%>
    <div id="myModal" class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true" style="font-size: 32px;"><strong>&times;</strong></span>
                        </button>
                       <h3 class="detail-subtitle">Stock Adjustment Request</h3>
                    </div>

                    <div class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="detail-info">
                                     
                                    <div class="detail-info-left">
                                        <table class="detail-info-col">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="label1" runat="server" Text="Status : "></asp:Label> <asp:Label ID="lblstatus" runat="server"></asp:Label></td>
                                                    
                                            </tbody>

                                        </table>


                                    </div>

                                    <%--<div class="detail-info-right">

                                        <div>
                                            <table class="detail-info-col">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="label2" runat="server" Text="Item ID : "></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblReqid" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="label3" runat="server" Text="Submitted date : "></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblSubmitteddate" runat="server"></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>


                                        </div>
                                    </div>--%>
                                </div>
                                <div class="detail-item">

                                    <asp:ListView runat="server" ID="lstShow">

                                        <LayoutTemplate>
                                            <table runat="server" class="table table-detail">
                                                <thead>
                                                    <tr id="grdHeader" runat="server">
                                                        <th scope="col" style="display: none">Item Code</th>
                                                        <th scope="col">Item Description</th>
                                                        <th scope="col">Discrepancy</th>
                                                        <th scope="col">Reason</th>
                                                        <%--<th scope="col">Quantity</th>
                                                        <th scope="col"></th>--%>

                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr id="itemPlaceholder" runat="server"></tr>
                                                </tbody>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="display: none">
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("ItemCode") %>' /></td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Desc") %>' /></td>
                                                
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("QtyChange") %>' /></td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Reason") %>' /></td>
                                               <%-- <td>
                                               <%-- <td>
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%#String.Format("{0:C}",Eval("Desc"))%>' /></td>
                                                <td>
                                                    <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ReqQty") %>' /></td>
                                                <td></td>--%>
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <span class="noresult">Sorry! There are no items in your cart!.<br />
                                                Go back to <a href="CatalogueDash.aspx">Catalogue</a>.
                                            </span>
                                        </EmptyDataTemplate>
                                    </asp:ListView>

                                </div>

                                <div>
                                    <div class="align-bottom-left">
                                        <p>Comments (Optional)</p>

                                        <asp:TextBox ID="txtComments" TextMode="multiline" Columns="50" Rows="5" runat="server" class="txt-area" />
                                    </div>
                                    <div class="action-btn">

                                        <asp:Button ID="btnReject" class="btn btn-danger btn-msize" OnClick="btnReject_Click" runat="server" Text="Reject" />
                                        <asp:Button ID="btnAccept" class="btn btn-success btn-msize" OnClick="btnAccept_Click" runat="server" Text="Accept" />
                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>

            </div>
        </div>
    </div>

  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
</asp:Content>
