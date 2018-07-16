<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RequestList.aspx.cs" Inherits="Group8_AD_webapp.RequestList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

        <link href="../css/employee-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main">
     <div class="subtitletext">Request List </div>
        STATUS: <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>

        <asp:UpdatePanel ID="udpCart" runat="server">
        <ContentTemplate>
            <script type="text/javascript">
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(toastr_message);
            </script>
        <!-- Cart List -->
       <div class="listview"> 
        <asp:ListView runat="server" ID="lstCart" OnPagePropertiesChanged="lstCatalogue_PagePropertiesChanged">
        <LayoutTemplate>
            <table runat="server" class="table">
                <thead><tr id="grdHeader" runat="server">
                        <th scope="col" style="display:none;">Item Code</th>
                        <th scope="col">Product Description</th>
                        <th scope="col">Request Qty</th>
                        <th runat="server" id="thdBookmark">Save For Later</th>
                        <th runat="server" id="thdRemove">Remove</th>
                        <th runat="server" id="thdFulfQty">Fulfilled Qty</th>
                        <th runat="server" id="thdFulf" style="border:none;"></th>
                </tr></thead>
                <tbody>
                    <tr id="itemPlaceholder" runat="server"></tr>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td style="display:none;"><asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'/></td>
                <td><asp:Label ID="lblDescription" runat="server" Text='<%#String.Format("{0:C}",Eval("Description"))%>' /></td>
                <td style = '<%=IsEditable ? "display: none;" : "" %>'> <asp:Label ID="txtQty" runat="server" Text='<%# Eval("Balance") %>'></asp:Label></td>
                <td style = '<%=IsEditable ? "" : "display: none;" %>'> <asp:TextBox ID="spnQty" type="number" Cssclass="p-2" runat="server" min="0"  Value='<%# Eval("Balance") %>' Width="60px" /> 
                    <asp:Button ID="btnUpdate" CssClass="btn btn-update" runat="server" Text="UPDATE" OnClick="btnUpdate_Click"/></td>
                <td style = '<%=IsEditable ? "" : "display: none;" %>'><asp:Button ID="btnBookmark" CssClass="btn btn-bookmark" runat="server" Text="BOOKMARK" OnClick="btnBookmark_Click"/></td>
                <td style = '<%=IsEditable ? "" : "display: none;" %>'><asp:LinkButton runat="server" ID="btnRemove" CssClass="btn-remove" OnClick="btnRemove_Click"><i class="fa fa-times-circle"></i></asp:LinkButton></td>
                <td style = '<%=IsApproved ? "" : "display: none;" %>'><asp:Label ID="lblFulfilledQty" runat="server" Text='<%# Eval("Balance") %>'></asp:Label></td>
                <td style = '<%#(Convert.ToInt32(Eval("Balance")) == 50) ? "border:none" : "display: none;" %>'><div class="btn-fulfilled"><i class="fa fa-check-circle"></i></div></td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <span class="noresult">Sorry! There are no items matching your search.</span>
        </EmptyDataTemplate>
        </asp:ListView>
           </div>

            <div class="row">
         <div class="col-md-5  backarea">
            <asp:Button ID="btnReqList" Cssclass="btn btn-primary" runat="server" Text="Request List" OnClick ="btnReqList_Click" />
        </div>
        <div class="col-md-6  buttonarea"  style = '<%=IsApproved ? "display: none;" : "" %>'>
            <asp:Button ID="btnCancel" Cssclass="btn btn-cancel" runat="server" Text="Cancel Request" />
            <asp:Button ID="btnSubmit" Cssclass="btn btn-success" runat="server" Text="Submit" />
            <asp:Button ID="btnUpdate" Cssclass="btn btn-success" runat="server" Text="Update" />
        </div></div>

        <div class="showbookmarks" style = '<%=IsNotSubmitted ? "" : "display: none;" %>'>
        <div class="subtitletext ml-5">Bookmark List</div>
        <!-- Bookmark List -->
        <div class="m-4"> 
        <asp:ListView runat="server" ID="lstBookmark" OnPagePropertiesChanged="lstCatalogue_PagePropertiesChanged">
        <LayoutTemplate>
            <table runat="server" class="table">
                <thead><tr id="grdHeader" runat="server">
                        <th scope="col" style="display:none;">Item Code</th>
                        <th scope="col">Product Description</th>
                        <th scope="col">Balance</th>
                        <th scope="col">Quantity</th>
                        <th scope="col">Order</th>
                        <th scope="col">Remove</th>
                </tr></thead>
                <tbody>
                    <tr id="itemPlaceholder" runat="server"></tr>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td style="display:none;"><asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'/></td>
                <td><asp:Label ID="lblDescription" runat="server" Text='<%#String.Format("{0:C}",Eval("Description"))%>' /></td>
                <td><asp:Label ID="lblBalance" runat="server" Text='<%# Eval("Balance") %>' /></td>
                <td> <asp:TextBox ID="spnQty" type="number" Cssclass="p-2" runat="server" min="0"  Value='<%# Eval("Balance") %>' Width="60px" /> 
                    <asp:Button ID="btnUpdate" CssClass="btn-update mt-2 btn" runat="server" Text="UPDATE" OnClick="btnUpdate_Click"/></td>
                  <td><asp:Button ID="btnBookmark" CssClass="btn-bookmark mt-2 btn" runat="server" Text="MOVE TO ORDER" OnClick="btnBookmark_Click"/></td>
               <td><asp:LinkButton runat="server" ID="btnRemove" CssClass="btn-remove" OnClick="btnRemove_Click"><i class="fa fa-times-circle"></i></asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <span class="noresult">Sorry! There are no items matching your search.</span>
        </EmptyDataTemplate>
        </asp:ListView>
           </div></div>

        </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        
</asp:Content>
