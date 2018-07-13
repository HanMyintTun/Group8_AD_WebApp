<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Group8_AD_webapp.DepartmentHead.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<div class="row">
			<ol class="breadcrumb">
				<li><a href="#">
					<em class="fa fa-home"></em>
				</a></li>
				<li class="active">Dashboard</li>
			</ol>
		</div><!--/.row-->
		
		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Dashboard</h1>
			</div>
		</div><!--/.row-->
		
	
		<div class="row">
			<div class="col-md-12">
				<div class="panel panel-default">
					<div class="panel-heading">
						Charge-back
						<span class="pull-right clickable panel-toggle panel-button-tab-left"><em class="fa fa-toggle-up"></em></span></div>
					<div class="panel-body">
					<div class="col-md-12">
				<div class="panel panel-default">
					<div class="panel-body tabs">
						<ul class="nav nav-tabs">
							<li class="active"><a href="#tab1" data-toggle="tab">July</a></li>
							<li><a href="#tab2" data-toggle="tab">June</a></li>
							<li><a href="#tab3" data-toggle="tab">May</a></li>
						</ul>
						<div class="tab-content">
							<div class="tab-pane fade in active" id="tab1">
								<h4>Tab 1</h4>
								<div class="canvas-wrapper">
							<canvas class="main-chart" id="bar-chart" height="250" width="600"></canvas>
						</div>
							</div>
							<div class="tab-pane fade" id="tab2">
								<h4>Tab 2</h4>
								
							</div>
							<div class="tab-pane fade" id="tab3">
								<h4>Tab 3</h4>
								
							</div>
						</div>
					</div>
				</div><!--/.panel-->
			</div>
						
					</div>
				</div>
			</div>
		</div><!--/.row-->
		
		<div class="row">
			<div class="col-lg-12">
				<div class="panel-heading">
				    Settings
				</div>
			</div>
			
			<div class="col-md-4">
				<div class="panel panel-primary">
					<div class="panel-heading">Delegate</div>
					<div class="panel-body">
						<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ut ante in sapien blandit luctus sed ut lacus. Phasellus urna est, faucibus nec ultrices placerat, feugiat et ligula. Donec vestibulum magna a dui pharetra molestie. Fusce et dui urna.</p>
					</div>
				</div>
			</div>
			<div class="col-md-4">
				<div class="panel panel-primary">
					<div class="panel-heading">Representative</div>
					<div class="panel-body">
						<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ut ante in sapien blandit luctus sed ut lacus. Phasellus urna est, faucibus nec ultrices placerat, feugiat et ligula. Donec vestibulum magna a dui pharetra molestie. Fusce et dui urna.</p>
					</div>
				</div>
			</div>
			<div class="col-md-4">
				<div class="panel panel-primary">
					<div class="panel-heading">Collection</div>
					<div class="panel-body">
						<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ut ante in sapien blandit luctus sed ut lacus. Phasellus urna est, faucibus nec ultrices placerat, feugiat et ligula. Donec vestibulum magna a dui pharetra molestie. Fusce et dui urna.</p>
					</div>
				</div>
			</div>
			
		</div><!-- /.row -->
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
</asp:Content>
