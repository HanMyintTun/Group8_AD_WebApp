<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestingBLBySai.aspx.cs" Inherits="Group8_AD_webapp.TestingBL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </div>
        <br />
        <br />
         <div>
            <asp:Button ID="Button2" runat="server" Text="Create PDF" OnClick="Button2_Click" />
        </div>
          <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Tally" ShowHeader="True" Text="Tally" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
