<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ADProjGroup08_WebApp.Login" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Lumino - Login</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/datepicker3.css" rel="stylesheet">
    <link href="css/styles.css" rel="stylesheet">
</head>

<body>
    <nav class="navbar navbar-custom navbar-fixed-top" role="navigation">
        <div class="container-fluid">
            <div class="navbar-header">

                <a class="navbar-brand desktop" runat="server" href="#"><span><strong>Logic</strong></span>University</a>
                <a class="navbar-brand mobile" runat="server" href="#"><span>L</span>U</a>
            </div>
        </div>
    </nav>

    <div class="row">
        <div class="col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4" style="margin-top:10%;">
            <div class="login-panel panel panel-default">
                <div class="panel-heading"><strong>Log in</strong></div>
                <div class="panel-body">
                    <form role="form" runat="server">

                        <fieldset>
                            <div class="form-group">
                                <p>Employee Number :</p>
                                <asp:TextBox ID="txtLoginId" class="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="txtLoginId" Display="Dynamic" ID="rfv1" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <p>Password :</p>
                                <asp:RequiredFieldValidator ControlToValidate="txtPwd" ID="rfv2" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtPwd" class="form-control" Display="Dynamic" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnLogin" class="btn btn-primary btn-lg" runat="server" Text="Login" CausesValidation="true" OnClientClick="return BtnClick();" OnClick="btnLogin_Click" />


                        </fieldset>
                    </form>


                </div>
            </div>
        </div>
        <!-- /.col-->
    </div>
    <!-- /.row -->

    <script type="text/javascript">
        function BtnClick() {
            //var v1 = "#<%= rfv1.ClientID %>";
            //var v2 = "#<%= rfv2.ClientID %>";
            var val = Page_ClientValidate();
            if (!val) {
                var i = 0;
                for (; i < Page_Validators.length; i++) {
                    if (!Page_Validators[i].isvalid) {
                        $("#" + Page_Validators[i].controltovalidate)
                            .css("border-color", "#dc3545");
                    }
                }
            }
            return val;
        }
    </script>
    <script src="js/jquery-1.11.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
