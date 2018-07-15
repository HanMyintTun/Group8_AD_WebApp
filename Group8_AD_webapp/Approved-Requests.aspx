<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Approved-Requests.aspx.cs" Inherits="Group8_AD_webapp.Approved_Requests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <ol class="breadcrumb">
                <li><a href="#">
                    <em class="fa fa-home"></em>
                </a></li>
                <li class="active"></li>
            </ol>
        </div>
        <!--/.row-->
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">Approved Requests</h3>
            </div>
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="panel-body">
                            <asp:ListView runat="server" ID="lstOrder">
                                <LayoutTemplate>
                                    <table runat="server" class="table">
                                        <thead>
                                            <tr id="Tr1" runat="server">
                                                <th scope="col">Order ID</th>
                                                <th scope="col">Name</th>
                                                <th scope="col" class="desktop">Submitted Date</th>
                                                 <th scope="col">Approved Date</th>
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

                                        <td>
                                            <asp:Label runat="server" ID="Label3" Text='<%# Eval("OrderID") %>' />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label4" Text='<%# Eval("Name") %>' />
                                        </td>
                                        <td class="desktop"> 
                                            <asp:Label runat="server" ID="Label5" Text='<%# Eval("SubmittedDate") %>' />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label6" Text='<%# Eval("SubmittedDate") %>' />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnOrderDetail" class="btn btn-primary" data-toggle="modal" data-target=".bd-example-modal-lg" runat="server" Text="Details" />
                                        </td>
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
    <%-- modal content--%>
    <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="panel panel-default">

                    <div class="panel-heading">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true" style="font-size: 32px;"><strong>&times;</strong></span>
                        </button>
                        <h3 class="detail-subtitle">Approved Request Details</h3>

                    </div>
                    <div class="panel-body">
                        <div class="detail-info">
                            <div class="detail-info-left">
                                <table class="detail-info-col">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Employee Name : "></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblEmployeeName" runat="server" Text="Employee 1"></asp:Label></td>
                                    </tbody>
                                </table>


                            </div>
                            <div class="detail-info-right">

                                <div>
                                    <table class="detail-info-col">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Order ID : "></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblOrderID" runat="server" Text="O0001"></asp:Label></td>
                                                
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="label13" runat="server" Text="Submitted Date : "></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblSubmittedDate" runat="server" Text="12/06/1992"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Approved Date : "></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblApprovedDate" runat="server" Text="15/06/1992"></asp:Label></td>
                                            </tr>
                                        </tbody>
                                    </table>


                                </div>
                            </div>
                        </div>


                         <div class="detail-item">
                            <table class="table table-detail">
                                <thead>
                                    <tr>
                                        <th scope="col" style="display:none">Item Code</th>
                                        <th scope="col">Item Name</th>
                                        <th scope="col">Quantity</th>
                                        <th scope="col"></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="display:none">001</td>
                                        <td>2B pen</td>
                                        <td>12</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="display:none">001</td>
                                        <td>2B pen</td>
                                        <td>12</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="display:none">001</td>
                                        <td>2B pen</td>
                                        <td>12</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="display:none">001</td>
                                        <td>2B pen</td>
                                        <td>12</td>
                                        <td></td>
                                    </tr>

                                </tbody>
                            </table>
                        </div>
                       
                    </div>

                </div>
            </div>
        </div>

    </div>
</asp:Content>
