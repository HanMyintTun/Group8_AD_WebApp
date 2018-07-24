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
                    <asp:TextBox ID="txtMonthPick" ClientIDMode="Static" placeholder="Month - Year" autocomplete="off" runat="server" CssClass="form-control controlheight" AutoPostBack="true" OnTextChanged="txtMonthPick_TextChanged"></asp:TextBox>
                    <span class="input-group-addon controlheight"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                </div> 
            </div> 
        </div></div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtMonthPick" />
            </Triggers>
            <ContentTemplate>
                <div class="phtrend">
            <canvas id="myChart" width="800" height="450"> </canvas>
        </div>

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
            OnAfterChooseMonth: function () { $("#txtMonthPick").trigger("change"); }
        });

         $(function () {
        var ctx = document.getElementById("myChart").getContext('2d');
        $.ajax({
            url: "StoreDashboard.aspx/getChartData",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var chartLabel = eval(response.d[0]); //Labels
                var chartData = eval(response.d[1]); //Data
                var myChart = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: chartLabel, 
                        datasets: [{
                            label: 'ChargeBack (SGD)',
                            data: chartData, 
                            backgroundColor: [
                                'rgba(255, 99, 132, 0.2)',
                                'rgba(54, 162, 235, 0.2)',
                                'rgba(255, 206, 86, 0.2)',
                                'rgba(75, 192, 192, 0.2)',
                                'rgba(153, 102, 255, 0.2)',
                                'rgba(255, 159, 64, 0.2)',
                                 'rgba(70, 240, 240, 0.2)',
                                 'rgba(128, 0, 0, 0.2)',
                                 'rgba(210, 245, 60, 0.2)',
                                'rgba(230, 190, 255, 0.2)'
                            ],
                            borderColor: [
                                'rgba(255,99,132,1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(255, 206, 86, 1)',
                                'rgba(75, 192, 192, 1)',
                                'rgba(153, 102, 255, 1)',
                                'rgba(255, 159, 64, 1)',
                                'rgba(70, 240, 240, 1)',
                                 'rgba(128, 0, 0, 1)',
                                 'rgba(210, 245, 60, 1)',
                                'rgba(230, 190, 255, 1)'
                            ],
                            borderWidth: 1
                        }]
                    },
                    options:
                        {
                            maintainAspectRatio: false,
                            scales:
                                {
                                    yAxes:
                                        [{
                                            ticks:
                                                {
                                                    beginAtZero: true
                                                }
                                        }]
                                }
                        }
                })
            }
        })
        }
        );
    </script>
</asp:Content>
