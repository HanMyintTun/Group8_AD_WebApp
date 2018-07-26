<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Group8_AD_webapp.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

    <script src="../js/chart.min.js"></script>
    <script src="../js/chart-data.js"></script>
<%--    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/easypiechart.js"></script>
    <script src="../js/easypiechart-data.js"></script>
    <script src="../js/bootstrap-datepicker.js"></script>
    <script src="../js/custom.js"></script>--%>
    <link href="../css/manager-style.css" rel="stylesheet" />
    <link href="../css/monthpicker.css" rel="stylesheet" />
    <link href="https://code.jquery.com/ui/1.12.1/themes/ui-lightness/jquery-ui.css" rel="stylesheet" />
    <link href="../css/month-picker-style.css" rel="stylesheet" />
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
            <div class="col-lg-6">
                <h3 class="page-header">Reports</h3>
            </div>
            <div class="col-lg-6">
                <asp:Button ID="btnExport" runat="server" Text="Export" CssClass="btn btn-primary btn-export" />

            </div>
        </div>
        <!--/.row-->
        <!--/.row-->

        <div class="col-md-12">
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Label ID="lblReportTitle"  style="font-size:2.4rem;" runat="server" Text="Label"></asp:Label>
					
                    </div>
                    <div class="panel-body">
                        <div class="canvas-wrapper" style="height: 500px;">
                            <canvas id="myChart"> </canvas>
                        </div>
                        <div class="text-center">
                        <asp:Label ID="lblSubtitle" style="font-size:1.8rem;" runat="server" Text=""></asp:Label></div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-lg-8">
                <div class="panel panel-default">
                    <div class="panel-body tabs">
                        <ul class="nav nav-tabs">
                            <li class="active"><asp:LinkButton runat="server" id="ByDept" ClientIDMode="Static"  href="#tab1" data-toggle="tab">By Department</asp:LinkButton></li>
                            <li><asp:LinkButton runat="server" id="BySupp" ClientIDMode="Static"  href="#tab2" data-toggle="tab">By Supplier</asp:LinkButton></li>

                        </ul>
                        <div class="tab-content tab-box">
                            <div class="tab-pane fade in active" id="tab1">
                                <div>


                                    <div style="padding-left: 15px;">
                                        <div class="form-group">
                                            <asp:Label ID="lblDept" runat="server" class="" Text="Department"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="col-md-12">
                                        <asp:DropDownList ID="ddlDepartment1" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                            <asp:ListItem Value="0">Select Department</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div style="clear: both; padding-top: 20px;">
                                    <div style="padding-left: 15px;">
                                        <div class="form-group">
                                            <asp:Label ID="Label3" runat="server" class="" Text="Department"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="col-md-12">
                                        <asp:DropDownList ID="ddlDepartment2" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                            <asp:ListItem Value="0">Select Department</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>


                            </div>
                            <div class="tab-pane fade" id="tab2">

                                <div>

                                    <div style="padding-left: 15px;">
                                        <div class="form-group">
                                            <asp:Label ID="lblSupplier" runat="server" class="" Text="Supplier"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="col-md-12">
                                        <asp:DropDownList ID="ddlSupplier1" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                            <asp:ListItem Value="0">Select Supplier</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div style="clear: both; padding-top: 20px;">
                                    <div style="padding-left: 15px;">
                                        <div class="form-group">
                                            <asp:Label ID="Label4" runat="server" class="" Text="Supplier"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="col-md-12">
                                        <asp:DropDownList ID="ddlSupplier2" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                            <asp:ListItem Value="0">Select Supplier</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div></div>
                <!--/.panel-->

                       <div class="col-lg-4">
                             <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab1" data-toggle="tab">Options</a></li>

                        </ul>
                                    <div>
                                        <div>
                                            <div class="form-group mt-15"><asp:hiddenfield id="IsDept" Value="true" ClientIDMode="Static" runat="server"/>
                                                <asp:Label ID="lblCategory" runat="server" class="" Text="Category"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="">
                                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                <asp:ListItem Value="All">All</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                         <div>
                                            <div class="form-group form-inline mt-15" >
                                                <asp:Label ID="lblOutputType" runat="server" Text="Output Type"></asp:Label>
                                            </div>
                                        </div>
                                        <div style="padding-left: 18px;">

                                            <asp:RadioButtonList ID="rdbChart" ClientIDMode="Static" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True"> Bar</asp:ListItem>
                                                <asp:ListItem> List</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>

                                </div>
                </div>

            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-body tabs">
                        <ul class="nav nav-tabs">
                            <li class="active"><asp:LinkButton runat="server" href="#tabMonth"  id="ByMonth" data-toggle="tab" ClientIDMode="Static" >By Month</asp:LinkButton></li>
                            <li><asp:LinkButton runat="server" href="#tabDate" data-toggle="tab"  id="ByDate" ClientIDMode="Static" >By Date Range</asp:LinkButton></li>

                        </ul>
                        <div class="tab-content tab-box">
                            <div class="tab-pane fade in active" id="tabMonth">
                                    <div class="col-lg-6">
                                         <div class="input-group"><asp:hiddenfield id="IsMonth" Value="true" ClientIDMode="Static" runat="server"/>
                                            <asp:TextBox ID="txtMonthPick" ClientIDMode="Static" autocomplete="off" OnTextChanged="txtMonthPick_TextChanged" AutoPostBack="true" placeholder="Month-Year" runat="server" CssClass="form-control calendar-db"></asp:TextBox>
                                            <span class="input-group-addon calendar-db"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                         </div>
                                        <div class="text-right mt-15">
                                        <%--<asp:Button ID="btnAddToList" CssClass="btn btn-success" OnClick="btnAdd_Click" runat="server" Text=" Add To List" />--%></div>

                                    </div>
                                    <div class="col-lg-6">
                                        <asp:UpdatePanel ID="udpMonths" runat="server">
    
                                            <ContentTemplate>
                                            <div class="montharea">
                                                <asp:ListView ID="lstMonths" runat="server"><ItemTemplate>
                                                <asp:Label runat="server" ID="lblMonths" CssClass="monthareali" Text='<%# ((DateTime)Container.DataItem).ToString("MMM-yyyy") %>'></asp:Label><asp:LinkButton ID="btnRemove" OnClick="btnRemove_Click" runat="server"><span style="color:var(--color-btn-danger); margin-left:10px;"><i class="fa fa-times-circle"></i></span></asp:LinkButton> <br />
                                                </ItemTemplate></asp:ListView>
                                            </div></ContentTemplate></asp:UpdatePanel>
                                        <div  class="text-right">
                                        <div class="report-btn mt-15">
                                                <asp:Button ID="btnMonth" CssClass="btn btn-primary" OnClick="btnMonth_Click" runat="server" Text="Generate By Month" />
                                            </div> </div> 
                                    </div>
                            </div>
                            <div class="tab-pane fade" id="tabDate">
                                <div class="col-md-6">
                                         <div class="input-group">
                                            <asp:TextBox ID="txtFromDate" ClientIDMode="Static" autocomplete="off" placeholder="dd/mm/yyyy" runat="server" CssClass="form-control calendar-db"></asp:TextBox>
                                            <span class="input-group-addon calendar-db"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                        </div>
                                    </div>
                                 <div class="col-md-6">
                                         <div class="input-group">
                                            <asp:TextBox ID="txtToDate" ClientIDMode="Static" autocomplete="off" placeholder="dd/mm/yyyy" runat="server" CssClass="form-control calendar-db"></asp:TextBox>
                                            <span class="input-group-addon calendar-db"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                                        </div>
                                </div>
                                <div class="col-md-12 text-right">
                                          <div class="report-btn mt-15 text-right">
                                            <asp:Button ID="btnRange" OnClick="btnRange_Click" CssClass="btn btn-primary" runat="server" Text="Generate By Range" />
                                        </div>
                                </div>
                            </div></div>
                    </div>
                </div></div>

        </div>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js"></script>
        <script src="<%=ResolveClientUrl("~/js/monthpicker.js")%>"></script>
    </div>
    <script>
        $(document).ready(function () {
    var dp1 = $('#<%=txtFromDate.ClientID%>');
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
        });

        $(document).ready(MonthPick);
        function MonthPick() {
            $('#txtMonthPick').MonthPicker({
                Button: false, MonthFormat: 'MM yy',
                OnAfterChooseMonth: function () { $("#txtMonthPick").trigger("change"); }
            });
        }

$(document).ready(function () {
    var dp1 = $('#<%=txtToDate.ClientID%>');
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

    $('#ByDept').click(function () {
        $('#IsDept').val("true");
    });
    $('#BySupp').click(function () {
        $('#IsDept').val("false");
    });

     $('#ByMonth').click(function () {
        $('#IsMonth').val("true");
    });
    $('#ByDate').click(function () {
        $('#IsMonth').val("false");
    });
        });

        $(document).ready(drawChart);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(drawChart);
        $(document).ready(checkDept);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(checkDept);

        function checkDept() {
            if ($('#IsDept').val() == "false") {
                $('#BySupp').trigger("click");
            }
            if ($('#IsMonth').val() == "false") {
                $('#ByDate').trigger("click");
            }
        }

        function drawChart() {
        var ctx = document.getElementById("myChart").getContext('2d');
        $.ajax({
            url: "Reports.aspx/getChartData",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var chartLabel = eval(response.d[0]); //Labels
                var chartData = eval(response.d[1]); //Data
                var chartData2 = eval(response.d[2]); //Data
                var label1 = response.d[3];
                var label2 = response.d[4];
                var label3 = response.d[5];
                var myChart = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: chartLabel, 
                        datasets: [{
                            label: label1,
                            data: chartData,  
                            backgroundColor: 'rgba(255, 165, 0, 0.2)',
                            borderColor: 'rgba(255, 165, 0, 1)', 
                            borderWidth: 1
                        },
                        {
                            label: label2,
                            data: chartData2, 
                            backgroundColor: 'rgba(54, 162, 235, 0.2)',
                            borderColor: 'rgba(54, 162, 235, 1)', 
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
                                                    beginAtZero: true,
                                                    fontSize: 15
                                                },
                                            scaleLabel: {
                                                display: true,
                                                labelString: label3,
                                                fontStyle: 'bold',
                                                fontFamily: "'Raleway', 'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                                                fontSize: 18
                                              }
                                        }],
                                    xAxes:
                                        [{
                                            ticks:
                                                {
                                                    fontSize: 14
                                                },
                                            scaleLabel: {
                                                display: false,
                                                labelString: 'Dates',
                                                fontStyle: 'bold',
                                                fontFamily: "'Raleway', 'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                                                fontSize: 18
                                              }
                                        }]
                                }
                        }
                })
            }
        })
        }

    </script>

</asp:Content>
