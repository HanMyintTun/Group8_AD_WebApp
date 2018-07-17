<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Group8_AD_webapp.Manager.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/chart.min.js"></script>
    <script src="../js/chart-data.js"></script>
    <script src="../js/easypiechart.js"></script>
    <script src="../js/easypiechart-data.js"></script>
    <script src="../js/bootstrap-datepicker.js"></script>
    <script src="../js/custom.js"></script>

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
                <h3 class="page-header">Dashboard</h3>
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
                        Radar Chart
					
                    </div>
                    <div class="panel-body">
                        <div class="canvas-wrapper">
                            <canvas class="chart" id="radar-chart"></canvas>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Radar Chart
					
                    </div>
                    <div class="panel-body tabs">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab1" data-toggle="tab">By Department</a></li>
                            <li><a href="#tab2" data-toggle="tab">By Supplier</a></li>

                        </ul>
                        <div class="tab-content tab-box">
                            <div class="tab-pane fade in active" id="tab1">
                                <div>


                                    <div style="padding-left: 15px;">
                                        <div class="form-group">
                                            <asp:Label ID="Label1" runat="server" class="" Text="Department"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlDepartment1" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">Select Department</asp:ListItem>
                                            <asp:ListItem Value="01">finance</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div style="clear: both; padding-top: 20px;">
                                    <div style="padding-left: 15px;">
                                        <div class="form-group">
                                            <asp:Label ID="Label3" runat="server" class="" Text="Department"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlDepartment2" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">Select Department</asp:ListItem>
                                            <asp:ListItem Value="01">finance</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>


                            </div>
                            <div class="tab-pane fade" id="tab2">

                                <div>

                                    <div style="padding-left: 15px;">
                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" class="" Text="Supplier"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">Select Supplier</asp:ListItem>
                                            <asp:ListItem Value="01">finance</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div style="clear: both; padding-top: 20px;">
                                    <div style="padding-left: 15px;">
                                        <div class="form-group">
                                            <asp:Label ID="Label4" runat="server" class="" Text="Supplier"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlSupplier1" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">Select Supplier</asp:ListItem>
                                            <asp:ListItem Value="01">1</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <!--/.panel-->
            </div>
            <!--/.col-->

        </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="col-md-12">

                    <div class="col-md-6" style="float: right;">
                        <div class="panel panel-default">

                            <div class="panel-body">
                                <div class="col-lg-6">
                                    <div>
                                        <div>
                                            <div class="form-group">
                                                <asp:Label ID="Label5" runat="server" class="" Text="Category"></asp:Label>
                                            </div>
                                        </div>


                                        <div class="">
                                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="0">Select Category</asp:ListItem>
                                                <asp:ListItem Value="01">1</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div style="padding-left: 18px;">

                                            <asp:RadioButtonList ID="rdbChart" runat="server">
                                                <asp:ListItem class="radio">Bar</asp:ListItem>
                                                <asp:ListItem class="radio">List</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-9">


                                        <div class="input-group">
                                            <asp:TextBox ID="txtDate" ClientIDMode="Static" placeholder="dd/mm/yyyy" runat="server" CssClass="form-control calendar-db"></asp:TextBox>
                                            <span class="input-group-addon calendar-db"><i class="fa fa-calendar" aria-hidden="true"></i></span>

                                        </div>

                                    </div>
                                    <div class="col-md-3">

                                        <div class="form-group">

                                            <asp:Button ID="btnAdd" runat="server" Text="Add" class="btn btn-primary" OnClick="btnAdd_Click" />
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <asp:Panel runat="server" ID="pnlForm">
                                        <asp:DataGrid ID="ItemsGrid"
                                            BorderColor="Black"
                                            BorderWidth="1px"
                                            CellPadding="3"
                                            AutoGenerateColumns="False"
                                            runat="server"
                                            OnRowDeleting="OnRowDeleting"
                                            CssClass="table tbl-date">

                                            <HeaderStyle BackColor="#f2f3f2"></HeaderStyle>

                                            <Columns>

                                                <asp:BoundColumn DataField="date"
                                                    HeaderText="Selected Date" />
                                                <asp:TemplateColumn HeaderText="">

                                                    <ItemTemplate>

                                                        <asp:LinkButton runat="server" CommandName="delete" ID="btnRemove" CssClass="btn-remove-sm"><i class="fa fa-times-circle"></i></asp:LinkButton>

                                                    </ItemTemplate>

                                                </asp:TemplateColumn>
                                            </Columns>

                                        </asp:DataGrid>
                                    </asp:Panel>

                                </div>
                            </div>
                        </div>
                        <div class="report-btns">
                            <div class="report-btn">
                                <asp:Button ID="btnRange" CssClass="btn btn-primary" runat="server" Text="Generate By Range" />
                            </div>
                            <div class="report-btn">
                                <asp:Button ID="btnMonth" CssClass="btn btn-primary" runat="server" Text="Generate By Month" />
                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


    <script>
        window.onload = function () {
            var chart2 = document.getElementById("radar-chart").getContext("2d");
            window.myBar = new Chart(chart2).Bar(barChartData, {
                responsive: true,
                scaleLineColor: "rgba(0,0,0,.2)",
                scaleGridLineColor: "rgba(0,0,0,.05)",
                scaleFontColor: "#c5c7cc"
            });
        };
    </script>
    <script>

        $(document).ready(function () {
            var dp1 = $('#<%=txtDate.ClientID%>');
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
    </script>

</asp:Content>
