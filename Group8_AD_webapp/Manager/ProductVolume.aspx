<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductVolume.aspx.cs" Inherits="Group8_AD_webapp.ProductVolume" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
            <link href="../css/manager-style.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js" type="text/javascript" ></script>
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
                    <asp:TextBox ID="txtStartDate" ClientIDMode="Static" placeholder="from: dd/mm/yyyy" autocomplete="off" runat="server" CssClass="form-control controlheight"></asp:TextBox>
                    <span class="input-group-addon controlheight"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                </div> 
            </div> 
        </div>
        <div class="col-xs-12 col-lg-4 text-left">
            <div class="form-group"> 
                <div class="input-group">
                    <asp:TextBox ID="txtEndDate" ClientIDMode="Static" placeholder="to: dd/mm/yyyy" autocomplete="off" runat="server" CssClass="form-control controlheight"></asp:TextBox>
                    <span class="input-group-addon controlheight"><i class="fa fa-calendar" aria-hidden="true"></i></span>

                </div><asp:Button ID="btnSearch" runat="server" CssClass="btnSearch btn btn-add button" Text="Search" OnClick="btnSearch_Click" />

            </div>
        </div>
        </div>

        <div id="centermain">
            <asp:hiddenfield id="IsDesc" ClientIDMode="Static" runat="server"/>
            <div class=" form-inline"> Sort Direction: 
           <asp:DropDownList ID="ddlSortDirection" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSortDirection_SelectedIndexChanged">
                           <asp:listitem text="Ascending" value="asc" />
                           <asp:listitem text="Descending" value="desc" />
           </asp:DropDownList>
            <asp:Label ID="lblDateRange" class="ml-10 bold" runat="server" Text=""></asp:Label></div>
    <asp:GridView ID="lstProductVolume" CssClass="display" runat="server" AutoGenerateColumns="False">
        <%--CssClass="table" PagerStyle-CssClass="pager"--%>
<%--        AllowPaging="True" OnPageIndexChanging="lstProductVolume_PageIndexChanging" PageSize="20"> --%>
        <%--AllowSorting="True" OnSorting ="grdSupplier_Sorting" >--%>
                   <Columns>
                       <asp:BoundField DataField="ItemCode" HeaderText="Item Code" SortExpression="ItemCode" />
                       <asp:BoundField DataField="Desc" HeaderText="Description" SortExpression="Desc" />
                       <asp:BoundField DataField="TempQtyReq" HeaderText="Quantity" SortExpression="TempQtyReq" />
                       <asp:BoundField DataField="SuppCode1" HeaderText="Supplier 1" SortExpression="SuppCode1" />
                       <asp:BoundField DataField="Price1" HeaderText="Price" SortExpression="Price1" />
            </Columns>
    </asp:GridView>
     <div class="row">
        <div class="col-xs-3 backarea">
            <asp:Button ID="btnReqList" Cssclass="btn btn-back" OnClick="btnBack_Click" runat="server" Text="Back"  />
        </div></div>
    </div>
</ContentTemplate></asp:UpdatePanel></div>
    <script>
        //$(document).ready(function () {

        //});

        $(document).ready(start);

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(start);

        function start() {
              var dp1 = $('#<%=txtEndDate.ClientID%>');
                    dp1.datepicker({
                        changeMonth: true,
                        changeYear: true,
                        format: "dd/mm/yyyy",
                        language: "tr"
                    }).on('changeDate', function (ev) {
                        $(this).blur();
                        $(this).blur();
                        $(this).datepicker('hide');
                    });
                    var dp = $('#<%=txtStartDate.ClientID%>');

                    dp.datepicker({
                        changeMonth: true,
                        changeYear: true,
                        format: "dd/mm/yyyy",
                        language: "tr"
                    }).on('changeDate', function (ev) {
                        $(this).blur();
                        $(this).datepicker('hide');
                });

            if ($('#IsDesc').val() == "false") {
                $('#<%= lstProductVolume.ClientID %>').prepend($("<thead></thead>").append($('#<%= lstProductVolume.ClientID %>').find("tr:first"))).dataTable(
                    {
                        "order": [[2, "asc"]]
                    });
            }
            else {
               $('#<%= lstProductVolume.ClientID %>').prepend($("<thead></thead>").append($('#<%= lstProductVolume.ClientID %>').find("tr:first"))).dataTable(
                    {
                        "order": [[2, "desc"]]
                    });
            }
        }

    </script>
</asp:Content>
