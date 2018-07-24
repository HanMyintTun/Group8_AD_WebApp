<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RestockLevel.aspx.cs" Inherits="Group8_AD_webapp.Manager.RestockLevel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="../css/employee-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main">

        <div class="form-group form-inline m-2 text-center col-12">
            <div>
                <div style="display: inline-block;">
                    <span class="lbl-inherit">Threshold :</span>
                    <asp:DropDownList ID="ddlThreshold" CssClass="form-control mx-2" runat="server" AppendDataBoundItems="True" AutoPostBack="True">
                        <asp:ListItem Text="All" Value="0" />
                    </asp:DropDownList>
                </div>
                <div style="display: inline-block;">
                    <span class="lbl-inherit">Category :</span>
                    <asp:DropDownList ID="ddlCategory" CssClass="form-control mx-2" runat="server" AppendDataBoundItems="True" AutoPostBack="True">
                        <asp:ListItem Text="All" Value="0" />
                    </asp:DropDownList>
                    <div style="display: inline-block;">
                        <asp:TextBox ID="txtSearch" CssClass="txtSearch form-control mx-2" runat="server" OnTextChanged="txtSearch_Changed" AutoPostBack="True"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" CssClass="btnSearch btn btn-success button" Text="Search" OnClick="btnSearch_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="subtitletext" style="margin-top:0px;">Change Restock Level and Quantity</div>

         <asp:UpdatePanel ID="udpRestock" runat="server"><ContentTemplate>
         <asp:GridView ID="grdRestockItem" runat="server" CssClass="table table-bordered" >
                   <Columns>
                <asp:TemplateField HeaderText="Product">
                    <ItemTemplate>
                        <table class="table borderless">
                                    <tr>
                                        <td style="text-align:left;padding:0px;">
                                            <asp:Label CssClass="item-info" ID="lblItemCode" runat="server" Text='<%# Bind("ItemCode") %>' Visible="True" />
                                            <span class="product-stock" style="float: right">
                                                <asp:Label ID="lblBalance" runat="server" Text='<%# Bind("ItemCode") %>' /></span>
                                            <br />
                                            <span class="product-desc">
                                                <asp:Label ID="lblDescription" runat="server" Text='<%#Bind("Description")%>' /></span><br />
                                        </td>
                                    </tr>
                         </table>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Restock Level">
                    <ItemTemplate>
                        <asp:Label CssClass="restock-content" ID="lblRestockLevel" runat="server" Text='<%# Bind("Balance") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Recommended Restock Level">
                    <ItemTemplate>
                        <asp:Label CssClass="restock-content" ID="lblRecomLevel" runat="server" Text='<%# Bind("Balance") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                       <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                         <asp:Button ID="btnReLevel" OnClick="btnReLevel_Click" CssClass="btn btn-primary restock-content" runat="server" Text="use" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Change Restock Level">
                    <ItemTemplate>
                        <asp:TextBox ID="txtChangeRestocklvl" runat="server" type="number" CssClass="p-2 restock-content"  min="0" Value=" " Width="50px" Height="34px" />
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Restock Qty">
                    <ItemTemplate>
                        <asp:Label ID="lblRestockQty" CssClass="restock-content" runat="server" Text='<%# Bind("Balance") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Recommended Restock Level">
                    <ItemTemplate>
                        <asp:Label ID="lblRecomQty"  CssClass="restock-content" runat="server" Text='<%# Bind("Balance") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                       <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                         <asp:Button ID="btnReLevelQty" CssClass="btn btn-primary restock-content" runat="server" Text="use" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Change Restock Level">
                    <ItemTemplate>
                        <asp:TextBox ID="txtChangeRestockQty" type="number" CssClass="p-2 restock-content" runat="server" min="0" Value=" " Width="50px" Height="34px" />
                    </ItemTemplate>
                </asp:TemplateField>
              
            </Columns>
    </asp:GridView>
             </ContentTemplate></asp:UpdatePanel>
        <div class="row">
        
    <div class="buttonarea">
        
        <asp:Button ID="btnUpdate" Cssclass="btn btn-success" runat="server" Text="Update" />
    </div>
    </div>
</asp:Content>
