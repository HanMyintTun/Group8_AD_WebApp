<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditSupplierPrice.aspx.cs" Inherits="Group8_AD_webapp.EditSupplierPrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="../css/employee-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main">

    <div class="form-group form-inline formstyle m-2 text-center col-12">
        <asp:DropDownList ID="ddlCategory" CssClass="form-control mx-2" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="True">
            <asp:listitem text="Select All" value="0" />
        </asp:DropDownList>
        <asp:TextBox ID="txtSearch" CssClass="txtSearch form-control mx-2" runat="server" OnTextChanged="txtSearch_Changed" AutoPostBack ="True"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" CssClass="btnSearch btn btn-success button" Text="Search" OnClick="btnSearch_Click" />
    </div>

        <div class="subtitletext">Edit Supplier/Price</div>
    <asp:GridView ID="grdSupplier" runat="server" CssClass="table" PagerStyle-CssClass="pager" 
        AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdSupplier_PageIndexChanging" PageSize="4" 
        AllowSorting="True" OnSorting ="grdSupplier_Sorting" >
                   <Columns>
                <asp:TemplateField HeaderText="Item Code" SortExpression="ItemCode">
                    <ItemTemplate>
                        <asp:Label ID="lblItemCode" runat="server" Text='<%# Bind("ItemCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category" SortExpression="Category">
                    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier1" SortExpression="Supplier1">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlSupplier1" runat="server"></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price1" SortExpression="Price1">
                    <ItemTemplate>
                        <asp:TextBox ID="txtPrice1" runat="server" Text='<%# Bind("Price1") %>' Width="60px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier2" SortExpression="Supplier2">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlSupplier2" runat="server"></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price2" SortExpression="Price2">
                    <ItemTemplate>
                        <asp:TextBox ID="txtPrice2" runat="server" Text='<%# Bind("Price2") %>' Width="60px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier3" SortExpression="Supplier3">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlSupplier3" runat="server"></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price3" SortExpression="Price3">
                    <ItemTemplate>
                        <asp:TextBox ID="txtPrice3" runat="server" Text='<%# Bind("Price3") %>' Width="60px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
    </asp:GridView>

     <div class="row">
        <div class="col-xs-3 backarea">
            <asp:Button ID="btnReqList" Cssclass="btn btn-back" runat="server" Text="Back"  />
        </div>
    <div class="col-xs-9  buttonarea">
        <asp:Button ID="btnCancel" Cssclass="btn btn-cancel" runat="server" Text="Cancel Request" />
        <asp:Button ID="btnSubmit" Cssclass="btn btn-success" runat="server" Text="Submit" />
    </div></div>
    </div>
</asp:Content>
