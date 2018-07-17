<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RequestHistory.aspx.cs" Inherits="Group8_AD_webapp.Employee.RequestHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
            <link href="../css/employee-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="main"> <!-- col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 -->
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="subtitletext">Request History</div>
                        <asp:ListView runat="server" ID="lstRequests">
                            <LayoutTemplate>
                                <table runat="server" class="table">
                                    <thead>
                                        <tr id="thdReqHistory" runat="server">
                                            <th scope="col">Submitted Date</th>
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
                                    <td><asp:Label runat="server" ID="lblReqDate" Text='<%# Eval("ReqDateTime","{0:dd-MMM-yyyy}") %>' /></td>
                                    <td><asp:Label runat="server" ID="lblStatus" Text='<%# Eval("Status") %>' /></td>
                                    <td><asp:LinkButton ID="btnReqDetail" CssClass="btn btn-primary" href='<%# "RequestList.aspx?reqid="+Eval("ReqId") %>' runat="server">DETAILS</asp:LinkButton> </td>
                                </tr>
                            </ItemTemplate>
                            </asp:ListView>
                        </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>


        </div>
    </div>


</asp:Content>
