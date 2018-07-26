<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="Group8_AD_webapp.Notifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="<%=ResolveClientUrl("~/css/manager-style.css")%>" rel="stylesheet" />
        <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js" type="text/javascript" ></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main"><div id="centermain">
        <asp:GridView ID="lstFullNof" CssClass="display" runat="server" AutoGenerateColumns="False">
           <Columns>
                       <asp:BoundField DataField="NotificationDateTime" HeaderText="Notification Date" SortExpression="NotificationDateTime" />
                       <asp:BoundField DataField="FromEmpName" HeaderText="From" SortExpression="FromEmpName" />
                       <asp:BoundField DataField="Type" HeaderText="Notification" SortExpression="Type" />
                       <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" />
               <asp:TemplateField><HeaderTemplate>Read</HeaderTemplate> <ItemTemplate><asp:Label style = '<%#(bool)Eval("IsRead") ? "" : "display: none;" %>' runat="server"><div class="btn-fulfilled"><i class="fa fa-check-circle"></i><span style="display:none;"><%#(bool)Eval("IsRead")%></span></div></asp:Label></ItemTemplate></asp:TemplateField>
            </Columns>
    </asp:GridView>
     <div class="row">
        <div class="col-xs-3 backarea">
            <asp:Button ID="btnReqList" Cssclass="btn btn-back" OnClick="btnBack_Click" runat="server" Text="Back"  />
        </div></div>

    </div></div>
    <script>
        $('#<%= lstFullNof.ClientID %>').prepend($("<thead></thead>").append($('#<%= lstFullNof.ClientID %>').find("tr:first"))).dataTable();
    </script>
</asp:Content>
