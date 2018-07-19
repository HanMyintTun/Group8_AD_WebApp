<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CatalogueDash.aspx.cs" Inherits="Group8_AD_webapp.CatalogueDash" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
     <link href="../css/employee-style.css" rel="stylesheet" />
    <link href="../css/add-style.css" rel="stylesheet" />

    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <div class="form-group form-inline formstyle m-2 text-center">
        <span class="titletext mt-5 ml-5"><asp:Label ID="lblCatTitle" runat="server" Text="Label"></asp:Label></span>
        <asp:LinkButton ID="btnGrid" Cssclass="listbutton active" runat="server" Text="Button" OnClick="btnGrid_Click"><i class="fa fa-th-large"></i></asp:LinkButton>
        <asp:LinkButton ID="btnList" Cssclass="listbutton" runat="server" Text="Button" OnClick="btnList_Click"><i class="fa fa-list"></i></asp:LinkButton>

        <asp:DropDownList ID="ddlCategory" CssClass="ddlSearch form-control mx-2" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="True">
            <asp:listitem text="All" value="0" />
        </asp:DropDownList>
             <div class="dd-search">
        <asp:TextBox ID="txtSearch" CssClass="txtSearch form-control controlheight" runat="server" OnTextChanged="txtSearch_Changed" AutoPostBack ="True"></asp:TextBox>

         <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtSearch" />
        </Triggers>
        <ContentTemplate>
            <div ID="ddlsearchcontent" class="ddlsearchcontent showsearch" runat="server">
                 <ul class="dd-searchcontent dropdown-alerts showsearch" runat="server">
            <asp:ListView ID="lstSearch" runat="server" OnPagePropertiesChanged="lstSearch_PagePropertiesChanged">
            <ItemTemplate>
                <li class="showsearch"><a runat="server" href="#">
                <table>
                <tr>
                    <td style="display:none;"><asp:Label ID="lstSearchlblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'/></td>
                    <td style="width:50px;" class="showsearch"><img src="../images/pencils.png" width="50"></td>
                    <td class="sidedesc searchdesc showsearch"><asp:Label ID="lstSearchlblDescription" runat="server" Text='<%#String.Format("{0:C}",Eval("Desc"))%>' /></td>
                </tr>
                 <tr>
                    <td colspan="3" class="bmkright showsearch"> <asp:TextBox ID="lstSearchspnQty" type="number" Cssclass="vertalign movedownside showsearch" runat="server" min="0"  Value="1" Width="60px" />
                   <asp:Button ID="btnAdd" CssClass="btn-add-list vertalign btn showsearch" runat="server" Text="ADD TO CART" OnClick="btnAdd_Click"/></td>
                </tr>
                </table>
                </a></li>
            </ItemTemplate>
            <EmptyDataTemplate>
                <span class="noresult showsearch">No suggestions available!</span>
                <!-- Add Back Button here -->
            </EmptyDataTemplate>
        </asp:ListView>
            <li class="showsearch" style="text-align:right;">
                <a href="RequestList.aspx" class="btn btn-add" OnClick="lstSearchbtnAdd_Click" runat="server">GO TO CART</a>
            </li>
                 </ul></div>
        </ContentTemplate></asp:UpdatePanel></div>
            
        <asp:Button ID="btnSearch" runat="server" CssClass="btnSearch btn btn-add button" Text="Search" OnClick="btnSearch_Click" />
        </div>


        <div id="main">

        <div id="centermain">
        <asp:UpdatePanel ID="udpCatalogue" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtSearch" />
            <asp:AsyncPostBackTrigger ControlID="btnGrid" />
            <asp:AsyncPostBackTrigger ControlID="btnList" />
        </Triggers>
        <ContentTemplate>
            <script type="text/javascript">
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(toastr_message);
            </script>
          <%--<asp:Button ID="Button1" runat="server" Text="Example Toast" OnClick="Button1_Click" />--%>
            Items Per Page: <asp:DropDownList ID="ddlPageCount" runat="server" OnSelectedIndexChanged="ddlPageCount_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            <asp:Label ID="lblPageCount" CssClass="lblPage" runat="server" Text="Label"></asp:Label>

    <div class="row">
    <div class="col-xs-12 col-md-8">
    <div id="showgrid" class="showgrid" runat="server">
    <div class="dpager col-12"><br />
    <asp:DataPager ID="dpgGrdCatalogue" runat="server" PageSize="9" PagedControlID="grdCatalogue" OnPreRender="ListPager_PreRender">
         <Fields>
            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="true"   ShowLastPageButton="false" ShowNextPageButton="false" PreviousPageText="Prev" ButtonCssClass="pagingbutton" />
            <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="pagingbutton" ButtonType="Button" CurrentPageLabelCssClass="currentpg" PreviousPageText="..." NextPreviousButtonCssClass="pagingbutton" />
            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="false" ButtonCssClass="pagingbutton" />
      </Fields>
    </asp:DataPager></div>

     <!-- Listview -->
       <asp:ListView ID="grdCatalogue" runat="server" OnPagePropertiesChanging="lstCatalogue_PagePropertiesChanging" OnPagePropertiesChanged="lstCatalogue_PagePropertiesChanged">
        <ItemTemplate>

          <div class="col-xs-12 col-sm-6 col-lg-4 p-3">
         <table class="product-wrapper2" >
            <tr><td class="p-3"><div class="imagewrapper">
                <asp:LinkButton ID="btnBookmark" CssClass="btn-bookmark btn btn-warning" OnClick="btnBookmark_Click" runat="server"><i class="fa fa-bookmark"></i> </asp:LinkButton>
                <img src="../images/pencils.png" class="img-responsive"></div>
                </td></tr>                
            <tr><td class="item-description smalldesc">
                <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>' Visible="False" />
                <div class="" ><asp:Label ID="lblDescription" runat="server" CssClass="blank" Text='<%#Eval("Desc") %>'></asp:Label></div></td></tr>
            <tr><td class="form-inline lblQty movedown">
               <span class=""> Qty: 
                   <asp:TextBox ID="spnQty" type="number" Cssclass="form-control controlheight" runat="server" min="0"  Value="1" Width="80px" /></span><br />
                 </td></tr>
            <tr><td class="p-1 m-auto">
                <asp:Button ID="btnAdd" CssClass="btn-add btn-add2  btn" runat="server" Text="ADD TO CART" OnClick="btnAdd_Click"/>
                </td></tr></table>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            <span class="noresult">Sorry! There are no items matching your search.</span>
            <!-- Add Back Button here -->
        </EmptyDataTemplate>
        </asp:ListView>


        <div class="dpager col-xs-12"><br />
        <asp:DataPager ID="dpgGrdCatalogue2" runat="server" PageSize="9" PagedControlID="grdCatalogue">
             <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="true"   ShowLastPageButton="false" ShowNextPageButton="false" PreviousPageText="Prev" ButtonCssClass="pagingbutton" />
                <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="pagingbutton" ButtonType="Button" CurrentPageLabelCssClass="currentpg" PreviousPageText="..." NextPreviousButtonCssClass="pagingbutton" />
                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="false" ButtonCssClass="pagingbutton" />
          </Fields>
        </asp:DataPager></div>
    </div>

        <div id="showlist" class="showlist" runat="server">
        <div class="dpager col-xs-12"><br />
        <asp:DataPager ID="dpgLstCatalogue" runat="server" PageSize="9" PagedControlID="lstCatalogue" OnPreRender="ListPager_PreRender">
             <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="true"   ShowLastPageButton="false" ShowNextPageButton="false" PreviousPageText="Prev" ButtonCssClass="pagingbutton" />
                <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="pagingbutton" ButtonType="Button" CurrentPageLabelCssClass="currentpg" PreviousPageText="..." NextPreviousButtonCssClass="pagingbutton" />
                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="false" ButtonCssClass="pagingbutton" />
          </Fields>
        </asp:DataPager></div>

       <div class=" col-xs-12"> 
        <asp:ListView runat="server" ID="lstCatalogue" OnPagePropertiesChanged="lstCatalogue_PagePropertiesChanged">
        <LayoutTemplate>
            <table runat="server" class="table list-table">
                <thead><tr id="grdHeader" runat="server">
                        <th scope="col" style="display:none;">Item Code</th>
                        <th scope="col">Product Description</th>
                        <th scope="col">Quantity</th>
                        <th scope="col"></th>
                </tr></thead>
                <tbody>
                    <tr id="itemPlaceholder" runat="server"></tr>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td style="display:none;"><asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'/></td>
                <td><asp:Label ID="lblDescription" runat="server" Text='<%#String.Format("{0:C}",Eval("Desc"))%>' /></td>
                <td> <asp:TextBox ID="spnQty" type="number" Cssclass="vertalign controlheight" runat="server" min="0"  Value="1" Width="60px" /></td>
                <td><asp:Button ID="btnAdd" CssClass="btn-add-list vertalign btn" runat="server" Text="ADD TO CART" OnClick="btnAdd_Click"/></td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <span class="noresult">Sorry! There are no items matching your search.</span>
        </EmptyDataTemplate>
        </asp:ListView>
           </div>

        <div class="dpager col-xs-12"><br />
        <asp:DataPager ID="dpgLstCatalogue2" runat="server" PageSize="9" PagedControlID="lstCatalogue">
             <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="true"   ShowLastPageButton="false" ShowNextPageButton="false" PreviousPageText="Prev" ButtonCssClass="pagingbutton" />
                <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="pagingbutton" ButtonType="Button" CurrentPageLabelCssClass="currentpg" PreviousPageText="..." NextPreviousButtonCssClass="pagingbutton" />
                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="false" ButtonCssClass="pagingbutton" />
          </Fields>
        </asp:DataPager></div>

        </div>
    </div>
    <div class="sidepanelarea col-md-4">
        <div class="bookmark-panel-top">
            <ul class="nav nav-tabss">
              <li class="active"><a data-toggle="tab" href="#home">Bookmarks</a></li>
              <li><a data-toggle="tab" href="#menu1">Popular</a></li>
            </ul>
            </div>
            <div class="bookmark-panel">
            <div class="tab-content panelcontent">
               <asp:ListView ID="lstBookmarks" runat="server" OnPagePropertiesChanged="lstBookmarks_PagePropertiesChanged">
                <ItemTemplate>
                <div class="bmkwrapper">
                <table>
                <tr>
                    <td style="display:none;"><asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'/></td>
                    <td style="width:50px;"><img src="../images/pencils.png" width="50" class=""></td>
                    <td class="sidedesc"><asp:Label ID="lblDescription" runat="server" Text='<%#String.Format("{0:C}",Eval("Desc"))%>' /></td>
                </tr>
                 <tr>
                    <td colspan="3" class="bmkright"> <asp:TextBox ID="TextBox2" type="number" Cssclass="vertalign movedownside" runat="server" min="0"  Value="1" Width="60px" />
                   <asp:Button ID="btnAdd" CssClass="btn-add-list vertalign btn" runat="server" Text="ADD TO CART" OnClick="btnAdd_Click"/></td>
                </tr>
                </table>
                </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <span class="noresult">Sorry! There are no items matching your search.</span>
                    <!-- Add Back Button here -->
                </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>

        </div>
        </ContentTemplate>
        </asp:UpdatePanel>

    </div></div>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
     <script>
         $(document).on('keyup', '.txtSearch', function () {
            $(".txtSearch").blur();
             $(".txtSearch").focus();
         });

         //$(".ddlsearchcontent").focusout(function () {
         //        $('.ddlsearchcontent').hide();
         //});

             $(document).on("click" , function(event){
                if( !($(event.target).hasClass('showsearch')))
                {
                $('.ddlsearchcontent').hide();
                }
            });
    </script>
</asp:Content>
