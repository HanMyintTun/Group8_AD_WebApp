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
                                                <canvas class="main-chart" id="bar-chart" height="250" width="600"></canvas>
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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
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
                                            <asp:DropDownList ID="ddlDelegate" runat="server" AppendDataBoundItems="True"  CssClass="form-control combo-a">
                                                <asp:ListItem Value="0">Select Employee</asp:ListItem>
                                                
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-lg-3">
                                        <div class="form-group">

                                            <div class="input-group">
                                                <asp:TextBox ID="txtStartDate" ClientIDMode="Static" placeholder="dd/mm/yyyy" runat="server" CssClass="form-control"></asp:TextBox>
                                                <span class="input-group-addon"><i class="fa fa-calendar" aria-hidden="true"></i></span>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">

                                            <div class="input-group">
                                                <asp:TextBox ID="txtEndDate" ClientIDMode="Static" placeholder="dd/mm/yyyy" runat="server" CssClass="form-control"></asp:TextBox>
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

                </ContentTemplate>
            </asp:UpdatePanel>
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

                                <div class="form-group" style="display: inline">
                                    <div style="display: inline-block">
                                        <asp:TextBox CssClass="form-control" ID="txtRep" runat="server" Text="" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="box-2nd-child row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlRep" runat="server"  AppendDataBoundItems="True" CssClass="form-control combo-a" >
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
            <script>
                window.onload = function () {
                    var chart2 = document.getElementById("bar-chart").getContext("2d");
                    window.myBar = new Chart(chart2).Bar(barChartData, {
                        responsive: true,
                        scaleLineColor: "rgba(0,0,0,.2)",
                        scaleGridLineColor: "rgba(0,0,0,.05)",
                        scaleFontColor: "#c5c7cc"
                    });
                };
            </script>
            <script type="text/javascript">
                $(document).ready(function () {
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
