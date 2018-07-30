<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Group8_AD_webapp.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .chartjs-render-monitor {
            width: 1000px !important;
            height: 450px !important;
        }

        @media (max-width: 768px) {
            .chartjs-render-monitor {
                width: 385px !important;
                height: 215px !important;
            }
        }
    </style>
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

                            <div class="panel panel-default">

                                <div class="col-md-2">
                                    <div class="form-group">


                                        <asp:DropDownList CssClass="form-control combo-a" ID="ddlMonth" runat="server" AutoPostBack="true"></asp:DropDownList>

                                        <br>
                                        <asp:RadioButtonList ID="rblChartType" runat="server" RepeatDirection="Horizontal" CellSpacing="20">
                                            <asp:ListItem Text="Bar" Value="1" Selected="True" />
                                            <asp:ListItem Text="Pie" Value="2" />
                                            <asp:ListItem Text="Doughnut" Value="3" />
                                        </asp:RadioButtonList>

                                    </div>
                                </div>

                            </div>
                            <!--/.panel-->
                        </div>
                        <div class="canvas-wrapper col-sm-offset-1">
                            <div id="dvChart">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!--/.row-->

        <div class="row">
            <%--<div class="col-lg-12">
                <div class="panel-heading">
                    Settings
                </div>
            </div>--%>


            <div class="col-md-8">
                <div class="panel panel-primary">
                    <div class="panel-heading">Assign Delegate</div>
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
                                <asp:UpdatePanel ID="updatepanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <asp:LinkButton runat="server" id="btnRemoveDelegate" class="btn btn-danger btn-remove" onserverclick="RemoveDelegate">
                                                <i class="fa fa-times" aria-hidden="true"></i>
                                            </asp:LinkButton>
                                           
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>

                        </div>
                        <div class="box-2nd-child row">
                            <div class="col-lg-3">
                                <div class="form-group">

                                    <asp:DropDownList ID="ddlDelegate" runat="server" AppendDataBoundItems="True" CssClass="form-control combo-a">
                                        <asp:ListItem Value="0">Select Employee</asp:ListItem>

                                    </asp:DropDownList>
                                </div>

                                <asp:CompareValidator ID="delegate" runat="server" Display="Dynamic" ControlToValidate="ddlDelegate" ValueToCompare="0" ForeColor="red" Operator="NotEqual" ValidationGroup="addDel" ErrorMessage="Please Select Employee"></asp:CompareValidator>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">

                                    <div class="input-group">

                                        <asp:TextBox ID="txtFromDate" ClientIDMode="Static" placeholder="dd/mm/yyyy" runat="server" CssClass="form-control" require="true"></asp:TextBox>
                                        <span class="input-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>

                                    </div>
                                </div>
                                <asp:RequiredFieldValidator ControlToValidate="txtFromDate" Display="Dynamic" ID="rftxtFromDate" runat="server" ForeColor="red" ValidationGroup="addDel" ErrorMessage="Please Select Date"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">

                                    <div class="input-group">

                                        <asp:TextBox ID="txtToDate" ClientIDMode="Static" placeholder="dd/mm/yyyy" runat="server" CssClass="form-control" require="true"></asp:TextBox>
                                        <span class="input-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>

                                    </div>
                                </div>
                                <asp:RequiredFieldValidator ControlToValidate="txtToDate" Display="Dynamic" ID="rftxtToDate" runat="server" ForeColor="red" ValidationGroup="addDel" ErrorMessage="Please Select Date"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">

                                    <div class="input-group">
                                        <asp:UpdatePanel ID="updatepanel2" runat="server">
                                            <ContentTemplate>

                                                <button runat="server" id="btnAddDelegate" causesvalidation="true" class="btn btn-success btn-remove" validationgroup="addDel" onserverclick="AddDelegate">
                                                    <i class="fa fa-check" aria-hidden="true"></i>
                                                </button>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <div class="col-md-4">
                <div class="panel panel-primary">
                    <div class="panel-heading">Assign Representative</div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" class="delegate-name" Text="Current Representative :"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-6">


                                <div class="form-group" style="display: inline">
                                    <div style="display: inline-block">
                                        <asp:TextBox CssClass="form-control" ID="txtRep" runat="server" Text="" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>


                            </div>
                        </div>
                        <div class="box-2nd-child row">
                            <div class="col-lg-6" style="margin-top: 14px;">
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlRep" runat="server" AppendDataBoundItems="True" CssClass="form-control combo-a">
                                        <asp:ListItem Text="Select Employee" Value="0" />
                                    </asp:DropDownList>
                                </div>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ControlToValidate="ddlRep" ValueToCompare="0" ForeColor="red" Operator="NotEqual" ValidationGroup="addRep" ErrorMessage="Please Select Employee"></asp:CompareValidator>
                            </div>
                            <div class="col-lg-6" style="margin-top: 14px;">
                                <div class="form-group">
                                    <asp:UpdatePanel ID="updatepanel3" runat="server">
                                        <ContentTemplate>
                                            <button runat="server" causesvalidation="true" validationgroup="addRep" id="btnAddRep" class="btn btn-success btn-remove" onserverclick="AddRep">
                                                <i class="fa fa-check" aria-hidden="true"></i>
                                            </button>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="mdlDeleRemove" class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg confirm-modal">
            <div class="modal-content">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <button type="button" id="btnClose" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true" style="font-size: 3.2rem"><strong>&times;</strong></span></button>
                        <h3 class="detail-subtitle">Delegate Removal!</h3>
                    </div>
                    <div class="panel-body">
                        You are about to remove <span style="font-weight: bold;">
                            <asp:Label runat="server" ID="lblCurrentDel"></asp:Label></span> from being your delegate. Are you sure?<br />
                        <div class="action-btn" style="text-align: center; float: none;">

                            <asp:Button ID="btnRemovDelNo" class="btn btn-danger btn-msize" OnClick="btnRemovDelNo_Click" runat="server" Text="No" />
                            <asp:Button ID="btnRemovDelYes" class="btn btn-success btn-msize" OnClick="btnRemovDelYes_Click" runat="server" Text="Yes" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="mdlDeleSet" class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg confirm-modal">
            <div class="modal-content">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true" style="font-size: 3.2rem"><strong>&times;</strong></span></button>
                        <h3 class="detail-subtitle">Delegate Addition!</h3>
                    </div>
                    <div class="panel-body">
                        You are about to add <span style="font-weight: bold;">
                            <asp:Label runat="server" ID="Label1"></asp:Label></span> to your delegate. Are you sure?<br />
                        <div class="action-btn" style="text-align: center; float: none;">

                            <asp:Button ID="Button2" class="btn btn-danger btn-msize" OnClick="btnSetDelNo_Click" runat="server" Text="No" />
                            <asp:Button ID="Button1" class="btn btn-success btn-msize" OnClick="btnSetDelYes_Click" runat="server" Text="Yes" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="mdlRepSet" class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg confirm-modal">
            <div class="modal-content">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true" style="font-size: 3.2rem"><strong>&times;</strong></span></button>
                        <h3 class="detail-subtitle">Representative Addition!</h3>
                    </div>
                    <div class="panel-body">
                        You are about to add <span style="font-weight: bold;">
                            <asp:Label runat="server" ID="Label3"></asp:Label></span> to your representative. Are you sure?<br />
                        <div class="action-btn" style="text-align: center; float: none;">

                            <asp:Button ID="Button4" class="btn btn-danger btn-msize" OnClick="btnSetRepNo_Click" runat="server" Text="No" />
                            <asp:Button ID="Button3" class="btn btn-success btn-msize" OnClick="btnSetRepYes_Click" runat="server" Text="Yes" />
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
                                ticks:
                                    {
                                        beginAtZero: true,
                                        fontSize: 14
                                    },
                                scaleLabel: {
                                    display: true,
                                    labelString: 'ChargeBack (SGD)',
                                    fontStyle: 'bold',
                                    fontFamily: "'Raleway', 'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                                    fontSize: 14
                                }
                            }],
                            xAxes: [{
                                gridLines: {
                                    display: true

                                },
                                ticks:
                                    {
                                        beginAtZero: true,
                                        fontSize: 14
                                    }
                            }]
                        }
                    };
                    var data1 = {
                        labels: aLabels,

                        datasets: [{
                            label: 'Months',
                            data: aValues,

                            //backgroundColor: aColor,
                            backgroundColor: [

                                'rgba(75, 192, 192, 0.2)',
                                'rgba(153, 102, 255, 0.2)',
                                'rgba(255, 159, 64, 0.2)',
                                'rgba(255, 99, 132, 0.2)',
                                'rgba(54, 162, 235, 0.2)',
                                'rgba(255, 206, 86, 0.2)'
                            ],
                            // borderColor: aColor,
                            borderColor: [
                                'rgba(75, 192, 192, 0.2)',
                                'rgba(153, 102, 255, 0.2)',
                                'rgba(255, 159, 64, 0.2)',
                                'rgba(255, 99, 132, 0.2)',
                                'rgba(54, 162, 235, 0.2)',
                                'rgba(255, 206, 86, 0.2)',
                                'rgba(255,99,132,1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(255, 206, 86, 1)',
                                'rgba(75, 192, 192, 1)',
                                'rgba(153, 102, 255, 1)',
                                'rgba(255, 159, 64, 1)',
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
                            //  userStrengthsChart = new Chart(ctx).Bar(data1);
                            userStrengthsChart = new Chart(ctx, { type: 'bar', data: data1, options: barOptions })
                            break;
                        case 2:
                            //userStrengthsChart = new Chart(ctx).Pie(data);
                            userStrengthsChart = new Chart(ctx, { type: 'pie', data: data1 })
                            break;
                        case 3:
                            //userStrengthsChart = new Chart(ctx).Doughnut(data);
                            userStrengthsChart = new Chart(ctx, { type: 'doughnut', data: data1 })
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
                startDate: '0',
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
                startDate: '0',
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
        function removeemptydelwarning() {
            swal("Warning!", "Sorry, there is no current delegate to remove.", "warning");
        }
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
