<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="StoreDashboard.aspx.cs" Inherits="Group8_AD_webapp.StoreDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
        <link href="../css/manager-style.css" rel="stylesheet" />
        <link href="../css/monthpicker.css" rel="stylesheet" />
    <link href="https://code.jquery.com/ui/1.12.1/themes/ui-lightness/jquery-ui.css" rel="stylesheet" />
    <link href="../css/month-picker-style.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id ="main">
    <div id="centermain">
                 <div class="form-group form-inline formstyle2 text-center">
                <div class="col-md-4 text-left">
                    <span class="subtitletext">Dashboard</span>
             </div>
                <div class="col-xs-12 col-md-3">
            <div class="form-group">
                <div class="input-group">
                    <asp:TextBox ID="txtMonthPick" ClientIDMode="Static" placeholder="Month - Year" runat="server" CssClass="form-control controlheight" AutoPostBack="true" OnTextChanged="txtMonthPick_TextChanged"></asp:TextBox>
                    <span class="input-group-addon controlheight"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                </div> 
            </div> 
        </div></div>

    <div class ="phtrend"><span class="subtitletext">Charge-Back    </span></div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtMonthPick" />
            </Triggers>
            <ContentTemplate>
                <div class="listtitletext"><asp:Label ID="lblDateRange" runat="server" Text="Label"></asp:Label></div>

        
    <div class ="row">
    <div class="col-md-6 tablepad">
        <div class="listtitletext">Top 10 Products By Request Quantity
            <asp:Button ID="btnMore" CssClass="btn btn-primary btnbold" runat="server" Text="See More" OnClick="btnMore_Click" />
        </div>
        <asp:GridView ID="grdTopProducts" runat="server" CssClass="table table-striped" AutoGenerateColumns="False"> 
            <Columns>
        <asp:TemplateField HeaderText="Item Code" SortExpression="ItemCode" ItemStyle-Width="100px">
            <ItemTemplate>
                <asp:Label ID="lblItemCode" runat="server" Text='<%# Bind("ItemCode") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Desc") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("TempQtyReq") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
            </Columns>
    </asp:GridView></div>
    <div class="col-md-6 tablepad">
        <div class="listtitletext">Bottom 10 Products By Request Quantity
                    <asp:Button ID="btnMore2" CssClass="btn btn-primary btnbold" runat="server" Text="See More" OnClick="btnMore2_Click" />
        </div>
        <asp:GridView ID="grdBotProducts" runat="server" CssClass="table table-striped" AutoGenerateColumns="False"> 
            <Columns>
        <asp:TemplateField HeaderText="Item Code" SortExpression="ItemCode" ItemStyle-Width="100px">
            <ItemTemplate>
                <asp:Label ID="lblItemCode" runat="server" Text='<%# Bind("ItemCode") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Description" SortExpression="Description">
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Desc") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("TempQtyReq") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
            </Columns>
    </asp:GridView></div>
    </div>
         </ContentTemplate>
        </asp:UpdatePanel>
    </div></div>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
        <script src="<%=ResolveClientUrl("~/js/monthpicker.js")%>"></script>
    <script>
        $('#txtMonthPick').MonthPicker({
            Button: false, MonthFormat: 'MM yy',
            OnAfterChooseMonth: function () {$("#txtMonthPick").trigger("change");}});



    </script>
</asp:Content>
