<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductVolume.aspx.cs" Inherits="Group8_AD_webapp.Manager.ProductVolume" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
            <link href="../css/manager-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main">
            <asp:UpdatePanel ID="udpProductVol" runat="server"><ContentTemplate>
        <div class="form-group form-inline formstyle2 text-center row">
        <div class="col-lg-3">
        <span class="subtitletext mt-5 ml-5"><asp:Label ID="lblCatTitle" runat="server" Text="Product Order Volume"></asp:Label></span>
        </div>
        <div class="col-xs-12 col-lg-2">
                    <asp:DropDownList ID="ddlCategory" CssClass="ddlsearch form-control" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="True">
            <asp:listitem text="All" value="All" />
        </asp:DropDownList>
         </div>
        <div class="col-xs-12 col-lg-2">
            <div class="form-group">
                <div class="input-group">
                    <asp:TextBox ID="txtStartDate" ClientIDMode="Static" placeholder="from: dd/mm/yyyy" runat="server" CssClass="form-control controlheight"></asp:TextBox>
                    <span class="input-group-addon controlheight"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                </div> 
            </div> 
        </div>
        <div class="col-xs-12 col-lg-4 text-left">
            <div class="form-group"> 
                <div class="input-group">
                    <asp:TextBox ID="txtEndDate" ClientIDMode="Static" placeholder="to: dd/mm/yyyy" runat="server" CssClass="form-control controlheight"></asp:TextBox>
                    <span class="input-group-addon controlheight"><i class="fa fa-calendar" aria-hidden="true"></i></span>

                </div><asp:Button ID="Button1" runat="server" CssClass="btnSearch btn btn-add button" Text="Search" OnClick="btnSearch_Click" />

            </div>
        </div>
        </div>

        <div id="centermain">

          <asp:Label ID="lblPageCount" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="lstProductVolume" runat="server" CssClass="table" PagerStyle-CssClass="pager"
        AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="lstProductVolume_PageIndexChanging" PageSize="20"> 
        <%--AllowSorting="True" OnSorting ="grdSupplier_Sorting" >--%>
                   <Columns>
                <asp:TemplateField HeaderText="Item Code" SortExpression="ItemCode">
                    <ItemTemplate>
                        <asp:Label ID="lblItemCode" runat="server" Text='<%# Bind("ItemCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Desc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="lblQty" runat="server" Text='<%# Bind("TempQtyReq") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier1" SortExpression="Supplier1">
                    <ItemTemplate>
                        <asp:Label ID="lblSupplier1" runat="server" Text='<%# Bind("SuppCode1") %>' Width="60px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price1" SortExpression="Price1">
                    <ItemTemplate>
                        <asp:Label ID="lblPrice1" runat="server" Text='<%# Bind("Price1") %>' Width="60px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
    </asp:GridView>

     <div class="row">
        <div class="col-xs-3 backarea">
            <asp:Button ID="btnReqList" Cssclass="btn btn-back" runat="server" Text="Back"  />
        </div></div>
    </div>
</ContentTemplate></asp:UpdatePanel></div>

</asp:Content>
