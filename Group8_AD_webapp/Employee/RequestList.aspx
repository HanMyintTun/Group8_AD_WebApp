<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RequestList.aspx.cs" Inherits="Group8_AD_webapp.RequestList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

        <link href="../css/employee-style.css" rel="stylesheet" />
            <script>
            $(function() {
              $('a[href*=#]').on('click', function(e) {
                e.preventDefault();
                $('html, body').animate({ scrollTop: $($(this).attr('href')).offset().top}, 1500, 'linear');
              });
            });
        </script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main">
        


        <asp:UpdatePanel ID="udpCart" runat="server">
        <ContentTemplate>
            <script type="text/javascript">
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(toastr_message);
            </script>
        <div class="row">
        <div class="col-xs-12 col-lg-6">
       <div class="subtitletext">Request List <a href="#bookmarks" class="viewbmkarea btn btn-bookmark" style = '<%=IsNotSubmitted ? "" : "display: none;" %>'>VIEW <i class="fa fa-bookmark"></i></a> </div> 
        STATUS: <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        <!-- Cart List -->
       <div class="listview"> 
        <asp:ListView runat="server" ID="lstCart" OnPagePropertiesChanged="lstCatalogue_PagePropertiesChanged">
        <LayoutTemplate>
            <table runat="server" class="table">
                <thead><tr id="grdHeader" runat="server">
                        <th scope="col" style="display:none;">Item Code</th>
                        <th scope="col">Product Description</th>
                        <th scope="col">Request Qty</th>
                        <th runat="server" id="thdRemove">Remove</th>
                        <th runat="server" id="thdFulfQty">Fulfilled Qty</th>
                        <th runat="server" id="thdBalQty">Balance Qty</th>
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
                <td><div class="btn btn-bookmark" style = '<%=IsNotSubmitted ? "" : "display: none;" %>'><i class="fa fa-bookmark"></i></div>
                    <asp:Label ID="lblDescription" runat="server" Text='<%#String.Format("{0:C}",Eval("Description"))%>' /></td>
                <td style = '<%=IsEditable ? "display: none;" : "" %>'> <asp:Label ID="txtQty" runat="server" Text='<%# Eval("Balance") %>'></asp:Label></td>
                <td style = '<%=IsEditable ? "" : "display: none;" %>'> <asp:TextBox ID="spnQty" type="number" Cssclass="p-2" runat="server" min="0"  Value='<%# Eval("Balance") %>' Width="60px" /></td>
                <td style = '<%=IsEditable ? "" : "display: none;" %>'><asp:LinkButton runat="server" ID="btnRemove" CssClass="btn-remove" OnClick="btnRemove_Click"><i class="fa fa-times-circle"></i></asp:LinkButton></td>
                <td style = '<%=IsApproved ? "" : "display: none;" %>'><asp:Label ID="lblFulfilledQty" runat="server" Text='<%# Eval("Balance") %>'></asp:Label></td>
                <td style = '<%=IsApproved ? "" : "display: none;" %>'><asp:Label ID="lblBalanceQty" runat="server" Text='<%# Eval("Balance") %>'></asp:Label></td>
                <td style = '<%=IsApproved ? "" : "display: none;" %> <%#(Convert.ToInt32(Eval("Balance")) == 50) ? "border:none" : "display: none;" %>'><div class="btn-fulfilled"><i class="fa fa-check-circle"></i></div></td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <span class="noresult">Sorry! There are no items in your cart!.</span>
        </EmptyDataTemplate>
        </asp:ListView>
           </div>

            <div class="row">
        <div class="col-xs-3 backarea">
            <asp:Button ID="btnReqList" Cssclass="btn btn-back" runat="server" Text="Back" OnClick ="btnReqList_Click" />
        </div>
        <div class="col-xs-9  buttonarea"  style = '<%=IsApproved ? "display: none;" : "" %>'>
            <asp:Button ID="btnCancel" Cssclass="btn btn-cancel" runat="server" Text="Cancel Request" />
            <asp:Button ID="btnSubmit" Cssclass="btn btn-success" runat="server" Text="Submit" />
            <asp:Button ID="btnUpdate" Cssclass="btn btn-success" runat="server" Text="Update" />
        </div></div>
        </div>

        <div class="col-xs-12 col-lg-4 col-lg-offset-1"> 
        <div class="showbookmarks" style = '<%=IsNotSubmitted ? "" : "display: none;" %>'>
        <a id="bookmarks"></a>
        <div class="subtitletext ml-5">Bookmark List</div>

        <!-- Bookmark List -->
        
        <asp:ListView runat="server" ID="lstBookmark" OnPagePropertiesChanged="lstCatalogue_PagePropertiesChanged">
        <LayoutTemplate>
            <table runat="server" class="table">
                <thead><tr id="grdHeader" runat="server">
                        <th scope="col" style="display:none;">Item Code</th>
                        <th></th>
                        <th scope="col">Product Description</th>
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
                <td><asp:Button ID="btnBookmark" CssClass="btn-bookmark mt-2 btn" runat="server" Text="ADD" OnClick="btnBookmark_Click"/></td>
                <td><asp:Label ID="lblDescription" runat="server" Text='<%#String.Format("{0:C}",Eval("Description"))%>' /></td>
                <!-- <td> <asp:TextBox ID="spnQty" type="number" Cssclass="p-2" runat="server" min="0"  Value='<%# Eval("Balance") %>' Width="60px" /></td> -->
               <td><asp:LinkButton runat="server" ID="btnRemove" CssClass="btn-remove" OnClick="btnRemove_Click"><i class="fa fa-times-circle"></i></asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <span class="noresult">Your Bookmarks List is empty. Add some bookmarks!</span>
        </EmptyDataTemplate>
        </asp:ListView>
           </div>



        </div>

        </ContentTemplate>
        </asp:UpdatePanel>
        
        </div>
</asp:Content>
