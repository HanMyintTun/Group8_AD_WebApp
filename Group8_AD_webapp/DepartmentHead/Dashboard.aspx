<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Group8_AD_webapp.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <ol class="breadcrumb">
                <li><a href="#">
                    <em class="fa fa-home"></em>
                </a></li>
                <li class="active">Dashboard</li>
            </ol>
        </div>
        <!--/.row-->
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">Dashboard</h3>
            </div>
        </div>
        <!--/.row-->
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Charge-back
						<span class="pull-right clickable panel-toggle panel-button-tab-left"><em class="fa fa-toggle-up"></em></span>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            <div id="dvChart">
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-body tabs">
                                    <ul class="nav nav-pills">
                                        <li class="active"><a href="#pilltab1" data-toggle="tab">JUL</a></li>
                                        <li><a href="#pilltab2" data-toggle="tab">JUN</a></li>
                                        <li><a href="#pilltab3" data-toggle="tab">MAY</a></li>
                                        <li><a href="#pilltab1" data-toggle="tab">APR</a></li>
                                        <li><a href="#pilltab2" data-toggle="tab">MAR</a></li>
                                        <li><a href="#pilltab3" data-toggle="tab">FEB</a></li>
                                    </ul>
                                    <div class="tab-content">
                                        <div class="tab-pane fade in active" id="pilltab1">
                                            <h4>Tab 1</h4>
                                            <div class="canvas-wrapper">
                                                <asp:RadioButtonList ID="rblChartType" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Pie" Value="1" Selected="True" />
                                                    <asp:ListItem Text="Doughnut" Value="2" />
                                                    <asp:ListItem Text="Bar" Value="3" />
                                                </asp:RadioButtonList>
                                                <asp:DropDownList CssClass="form-group" ID="ddlMonth" runat="server" AutoPostBack="true"></asp:DropDownList>

                                            </div>

                                        </div>
                                        <div class="tab-pane fade" id="pilltab2">
                                            <h4>Tab 2</h4>

                                        </div>
                                        <div class="tab-pane fade" id="pilltab3">
                                            <h4>Tab 3</h4>
                                        </div>
                                        <div class="tab-pane fade" id="pilltab4">
                                            <h4>Tab 2</h4>
                                        </div>
                                        <div class="tab-pane fade" id="pilltab5">
                                            <h4>Tab 3</h4>
                                        </div>
                                        <div class="tab-pane fade" id="pilltab6">
                                            <h4>Tab 2</h4>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <!--/.panel-->
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/.row-->

        <div class="row">
            <div class="col-lg-12">
                <div class="panel-heading">
                    Settings
                </div>
            </div>
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                       </ContentTemplate>
            </asp:UpdatePanel>--%>
            <div class="col-md-8">
                <div class="panel panel-primary">
                    <div class="panel-heading">Delegate</div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblCurDelegate" runat="server" class="delegate-name" Text="Current Delegate :"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-3">

                                <div class="form-group">
                                    <div style="display: inline-block">
                                        <asp:TextBox CssClass="form-control" ID="txtCurDelegate" runat="server" Text="" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">

                                <div class="form-group">
                                    <button runat="server" id="btnRemoveDelegate" class="btn btn-danger btn-remove" onserverclick="RemoveDelegate">
                                        <i class="fa fa-times" aria-hidden="true"></i>
                                    </button>
                                </div>

                            </div>

                        </div>
                        <div class="box-2nd-child row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlDelegate" runat="server" AppendDataBoundItems="True" CssClass="form-control combo-a">
                                        <asp:ListItem Value="0">Select Employee</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">

                                    <div class="input-group">
                                        <asp:TextBox ID="txtFromDate" ClientIDMode="Static" placeholder="dd/mm/yyyy" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>

                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">

                                    <div class="input-group">
                                        <asp:TextBox ID="txtToDate" ClientIDMode="Static" placeholder="dd/mm/yyyy" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>

                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">

                                    <div class="input-group">
                                        <button runat="server" id="btnAddDelegate" class="btn btn-success btn-remove" onserverclick="AddDelegate">
                                            <i class="fa fa-check" aria-hidden="true"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>


            <div class="col-md-4">
                <div class="panel panel-primary">
                    <div class="panel-heading">Representative</div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" class="delegate-name" Text="Current Representative :"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group" style="display: inline">
                                            <div style="display: inline-block">
                                                <asp:TextBox CssClass="form-control" ID="txtRep" runat="server" Text="" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                        <div class="box-2nd-child row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlRep" runat="server" AppendDataBoundItems="True" CssClass="form-control combo-a">
                                        <asp:ListItem Text="Select Employee" Value="0" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <button runat="server" id="btnAddRep" class="btn btn-success btn-remove" onserverclick="AddRep">
                                        <i class="fa fa-check" aria-hidden="true"></i>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- /.row -->
    <script type="text/javascript">
        $(function () {
            LoadChart();
            $("[id*=ddlMonth]").bind("change", function () {
                LoadChart();
            });
            $("[id*=rblChartType] input").bind("click", function () {
                LoadChart();
            });
        });
        function LoadChart() {
            var chartType = parseInt($("[id*=rblChartType] input:checked").val());
            $.ajax({
                type: "POST",
                url: "Dashboard.aspx/GetChart",
                data: "{month: '" + $("[id*=ddlMonth]").val() + "'}",
                //labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    $("#dvChart").html("");
                    $("#dvLegend").html("");
                    var data = eval(r.d);
                    // alert(data);
                    var aLabels = [];
                    var aValues = [];
                    var aColor = [];
                    var aDatasets1 = eval(r.d);

                    for (var i = 0; i < data.length; i++) {
                        aLabels.push(data[i].Label);
                        aValues.push(data[i].Val1);
                        aColor.push(data[i].color);
                    };

                    // alert(aLabels);
                    //alert(aValues);
                    var barOptions = {
                        responsive: true,
                        maintainAspectRatio: true,
                        scales: {
                            yAxes: [{

                                gridLines: {
                                    display: true
                                },
                                scaleLabel: {
                                    display: true,
                                    labelString: 'Millions'
                                }
                            }],
                            xAxes: [{
                                gridLines: {
                                    display: true
                                }
                            }]
                        }
                    };
                    var data1 = {
                        labels: aLabels,
                        datasets: [{
                            // label: '# of Votes',
                            data: aValues,
                            //backgroundColor: aColor,
                            backgroundColor: [
                                'rgba(255, 99, 132, 0.2)',
                                'rgba(54, 162, 235, 0.2)',
                                'rgba(255, 206, 86, 0.2)',
                                'rgba(75, 192, 192, 0.2)',
                                'rgba(153, 102, 255, 0.2)',
                                'rgba(255, 159, 64, 0.2)'
                            ],
                            // borderColor: aColor,
                            borderColor: [
                                'rgba(255,99,132,1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(255, 206, 86, 1)',
                                'rgba(75, 192, 192, 1)',
                                'rgba(153, 102, 255, 1)',
                                'rgba(255, 159, 64, 1)',
                                'rgba(255, 99, 132, 0.2)',
                                'rgba(54, 162, 235, 0.2)',
                                'rgba(255, 206, 86, 0.2)',
                                'rgba(75, 192, 192, 0.2)',
                                'rgba(153, 102, 255, 0.2)',
                                'rgba(255, 159, 64, 0.2)'
                            ],
                            borderWidth: 1
                        }]

                    };


                    var el = document.createElement('canvas');
                    $("#dvChart")[0].appendChild(el);

                    //Fix for IE 8
                    //if ($.browser.msie && $.browser.version == "8.0") {
                    //    G_vmlCanvasManager.initElement(el);
                    //}
                    var ctx = el.getContext('2d');



                    var userStrengthsChart;

                    switch (chartType) {
                        case 1:
                            //userStrengthsChart = new Chart(ctx).Pie(data);
                            userStrengthsChart = new Chart(ctx, { type: 'pie', data: data1 })
                            break;
                        case 2:
                            //userStrengthsChart = new Chart(ctx).Doughnut(data);
                            userStrengthsChart = new Chart(ctx, { type: 'doughnut', data: data1 })
                            break;
                        case 3:
                            //  userStrengthsChart = new Chart(ctx).Bar(data1);
                            userStrengthsChart = new Chart(ctx, { type: 'bar', data: data1, options: barOptions })
                            break;
                    }

                    for (var i = 0; i < data.length; i++) {
                        var div = $("<div />");
                        div.css("margin-bottom", "10px");
                        div.html("<span style = 'display:inline-block;height:10px;width:10px;background-color:" + data[i].color + "'></span> " + data[i].text);
                        $("#dvLegend").append(div);
                    }
                },
                failure: function (response) {
                    alert('There was an error.');
                }
            });
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var dp1 = $('#<%=txtToDate.ClientID%>');
            dp1.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd-mm-yyyy",
                language: "tr"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).blur();
                $(this).datepicker('hide');
            });

            var dp = $('#<%=txtFromDate.ClientID%>');

            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd-mm-yyyy",
                language: "tr"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
        });

    </script>

    <script type="text/javascript">

        function removewarning() {
            swal({
                title: "Delegate Removal!",
                text: "You are about to remove “Employee 4” from being your delegate. Are you sure?",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        swal("Removed", {
                            icon: "success",
                        });
                    } else {
                        swal("Cancelled");
                    }
                });
        }

        function successalert() {
            swal("Delegate Added!", "Employee 2 is added", "success");
        }
        function successalertrep() {
            swal("Representative Added!", "Employee 2 is added", "success");
        }
    </script>
  
</asp:Content>
