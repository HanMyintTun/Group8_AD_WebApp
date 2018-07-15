<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Collection-Point.aspx.cs" Inherits="Group8_AD_webapp.Collection_Point" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
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
            <div class="col-lg-12">
                <h3 class="page-header">Collection Point</h3>
            </div>
        </div>
        <!--/.row-->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                  
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" class="" Text="Current Collection Point :"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-3">

                                <div class="form-group">

                                    <asp:TextBox CssClass="form-control" ID="txtCurrentCollection" runat="server" Text="" ReadOnly="true"> Medical School</asp:TextBox>


                                </div>


                            </div>
                        </div>
                        <div class="box-2nd-child row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control combo-a">
                                        <asp:ListItem Value="0">Select Collection Point</asp:ListItem>
                                        <asp:ListItem Value="01">Eng Dept</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <button runat="server" id="btnAddColPt" class="btn btn-success btn-remove" onserverclick="AddColPt">
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

    <script>function successalertcol() {
            swal("Collection Point Changed!", "Eng Dept is added", "success");
        }</script>
</asp:Content>
