<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="Group8_AD_webapp.Notifications" EnableEventValidation="False"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="<%=ResolveClientUrl("~/css/manager-style.css")%>" rel="stylesheet" />
    <link href="<%=ResolveClientUrl("~/css/employee-style.css")%>" rel="stylesheet" />
        <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js" type="text/javascript" ></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main"><div id="centermain">
        <div class="subtitletext">Notifications</div>
        <asp:GridView ID="lstFullNof" CssClass="display" runat="server" AutoGenerateColumns="False">
           <Columns>
               <asp:TemplateField Visible="True"><ItemTemplate><asp:Label ID="lblNofId" runat="server" Text='<%#Eval("NotificationId")%>'/></ItemTemplate></asp:TemplateField>
               <asp:TemplateField><HeaderTemplate>Notification Date</HeaderTemplate><ItemTemplate><asp:Label runat="server" Text='<%# ((DateTime)Eval("NotificationDateTime")).ToString("yyyy-MM-dd") %>'/></ItemTemplate></asp:TemplateField>
                       <asp:BoundField DataField="FromEmpName" HeaderText="From" SortExpression="FromEmpName" />
                       <asp:BoundField DataField="Type" HeaderText="Notification" SortExpression="Type" />
                       <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" />
               <asp:TemplateField><HeaderTemplate>Read</HeaderTemplate> <ItemTemplate><asp:LinkButton runat="server" CommandArgument='<%#Eval("NotificationId")%>' id="btnRow" OnClick="btnRow_Click" style= "width:100%; height:100%;">
                   <asp:Label style = '<%#(bool)Eval("IsRead") ? "" : "display: none;" %>' runat="server"><div class="btn-fulfilled"><i class="fa fa-check-circle"></i></div></asp:Label>
                   <asp:Label style = '<%#(bool)Eval("IsRead") ? "display: none;" : "" %>' runat="server"><div style="color:var(--color-btn-danger);"><i class="fa fa-times-circle"></i></div></asp:Label>
                   <span style="display:none;"><%#(bool)Eval("IsRead")%></span>
</asp:LinkButton></ItemTemplate></asp:TemplateField>
               <asp:TemplateField> <ItemTemplate><asp:Button ID="btnReq" CssClass="btn btn-primary" OnClick="btnReq_Click" CommandArgument='<%#Eval("NotificationId")%>' runat="server" Text="Requests"></asp:Button></ItemTemplate></asp:TemplateField>
          </Columns>
    </asp:GridView>
     <div class="row">
        <div class="col-xs-3 backarea">
            <asp:Button ID="btnReqList" Cssclass="btn btn-back" OnClick="btnBack_Click" runat="server" Text="Dashboard"  />
        </div></div>

    </div></div>
    <script>
        $('#<%= lstFullNof.ClientID %>').prepend($("<thead></thead>").append($('#<%= lstFullNof.ClientID %>').find("tr:first"))).dataTable(
             {
                "order": [[0, "desc"]]
            });
    </script>
</asp:Content>
