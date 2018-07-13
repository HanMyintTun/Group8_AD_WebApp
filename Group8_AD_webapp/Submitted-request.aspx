<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Submitted-request.aspx.cs" Inherits="Group8_AD_webapp.Submitted_request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <div class="col-lg-12">


                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Submitted request</h3>
                    </div>
                    <div class="panel-body">

                        <asp:ListView runat="server" ID="list">
                            <LayoutTemplate>
                                <table id="table_id" class="display">

                                    <thead>
                                        <tr id="Tr1" runat="server">
                                            <th>Order ID</th>
                                            <th>Name</th>
                                            <th>Submitted Date</th>
                                            <th></th>
                                        </tr>

                                    </thead>

                                    <tbody>
                                        <asp:PlaceHolder id="itemPlaceholder" runat="server"></asp:PlaceHolder>
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
                                    <td>
                                        <asp:Label runat="server" ID="Label5" Text='<%# Eval("SubmittedDate") %>' />
                                    </td>
                                    <td>

                                       <asp:Button ID="btnOrderDetail" class="btn btn-primary" runat="server" Text="Order Detail" />
                                    </td>
                                </tr>

                            </ItemTemplate>
                        </asp:ListView>

                    </div>
                </div>



            </div>


        </div>
    </div>
    

</asp:Content>
