<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Restock-Quantity.aspx.cs" Inherits="Group8_AD_webapp.Manager.Restock_Quantity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="../css/employee-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main">
        <div class="col-md-12">
            <!-- Listview -->
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
            <asp:ListView ID="grdCatalogue" runat="server">
                <LayoutTemplate>
                    <table id="table_id" class="restok-table display nowrap dataTable collapsed dtr-inline" style="width: 100%;" role="grid" aria-describedby="example_info">

                        <thead>
                            <tr id="Tr1" runat="server">
                                <th>Product</th>
                                <th>
                                    <div class="">
                                        <div class="stock-lvl">
                                            Restock<br />
                                            Level
                                        </div>
                                        <div class="stock-lvl">
                                            Recommended<br />
                                            Restock Level
                                        </div>
                                        <div class="stock-lvl">
                                        </div>
                                        <div class="stock-lvl qty-value">
                                            Change Restock
                                            <br />
                                            Level
                                        </div>
                                    </div>
                                </th>
                                <th>
                                    <div class="">
                                        <div class="stock-lvl">
                                            Restock<br />
                                            Level
                                        </div>
                                        <div class="stock-lvl">
                                            Recommended<br />
                                            Restock Level
                                        </div>
                                        <div class="stock-lvl">
                                        </div>
                                        <div class="stock-lvl qty-value">
                                            Change Restock
                                            <br />
                                            Level
                                        </div>
                                    </div>
                                </th>


                            </tr>

                        </thead>

                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </tbody>


                    </table>
                </LayoutTemplate>
                <ItemTemplate>



                    <tr>
                        <td>
                            <div class="product-info col-md-1">
                                <table class="table borderless">
                                    <tr>
                                        <td rowspan="2">
                                            <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>' Visible="True" />
                                            <span class="product-stock" style="float: right">
                                                <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("ItemCode") %>' /></span>
                                            <br />
                                            <span class="product-desc">
                                                <asp:Label ID="lblDescription" runat="server" Text='<%#String.Format("{0:C}",Eval("Description"))%>' /></span><br />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td>
                            <div class="product-info col-md-2">
                                <div class="stock-lvl">
                                    <asp:Label ID="lblRecomLevel" runat="server" Text='<%# Eval("Balance") %>' />
                                </div>
                                <div class="stock-lvl">
                                    <asp:Label ID="lblReLevel" runat="server" Text='<%# Eval("Balance") %>' />
                                </div>
                                <div class="stock-lvl">
                                    <asp:Button ID="btnUseLevel" CssClass="btn btn-primary" runat="server" Text="use" />
                                </div>
                                <div class="stock-lvl qty-value">
                                    <asp:TextBox ID="txtChangeRestocklvl" type="number" CssClass="p-2" runat="server" min="0" Value=" " Width="50px" />
                                </div>
                            </div>
                        </td>
                        <td>
                            <div class="product-info col-md-2">
                                <div class="stock-lvl">
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Balance") %>' />
                                </div>
                                <div class="stock-lvl">
                                    <asp:Label ID="lblReQty" runat="server" Text='<%# Eval("Balance") %>' />
                                </div>
                                <div class="stock-lvl">
                                    <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="use" />
                                </div>
                                <div class="stock-lvl">
                                    <asp:TextBox ID="txtChangeReLvl" type="number" CssClass="p-2" runat="server" min="0" Value=" " Width="50px" />
                                </div>
                            </div>
                        </td>
                    </tr>


                </ItemTemplate>
                <EmptyDataTemplate>
                    <span class="noresult">Sorry! There are no items matching your search.</span>
                </EmptyDataTemplate>
            </asp:ListView>
                </ContentTemplate></asp:UpdatePanel>
        </div>
    </div>
   
    <script type="text/javascript">


     

            $("#btnUseLevel").click(function () {
                alert("hi");
                var lbl = document.getElementById("lblReLevel").value;
                console.log(lbl);
              

                txtChangeRestocklvl.innerHTML = lbl;

            });



 

    </script>
</asp:Content>
