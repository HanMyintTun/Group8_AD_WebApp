<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RequestHistory.aspx.cs" Inherits="Group8_AD_webapp.RequestHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
            <link href="../css/employee-style.css" rel="stylesheet" />
            <link href="../css/datepicker3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


             <div class="form-group form-inline formstyle text-center">
        <div class="col-lg-3">
        <span class="subtitletext mt-5 ml-5"><asp:Label ID="lblCatTitle" runat="server" Text="Request History"></asp:Label></span>
        </div>
        <div class="col-lg-2">
        <asp:DropDownList ID="ddlStatus" CssClass="ddlStatus form-control" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="True">
            <asp:listitem text="All" value="0" />
        </asp:DropDownList>
         </div>
        <div class="col-xs-12 col-lg-3">
            <div class="form-group">
                <div class="input-group">
                    <asp:TextBox ID="txtStartDate" ClientIDMode="Static" placeholder="from: dd/mm/yyyy" runat="server" CssClass="form-control controlheight"></asp:TextBox>
                    <span class="input-group-addon controlheight"><i class="fa fa-calendar" aria-hidden="true"></i></span>
                </div> 
            </div> 
        </div>
        <div class="col-xs-12 col-lg-4">
            <div class="form-group"> 
                <div class="input-group">
                    <asp:TextBox ID="txtEndDate" ClientIDMode="Static" placeholder="to: dd/mm/yyyy" runat="server" CssClass="form-control controlheight"></asp:TextBox>
                    <span class="input-group-addon controlheight"><i class="fa fa-calendar" aria-hidden="true"></i></span>

                </div><asp:Button ID="btnSearch" runat="server" CssClass="btnSearch btn btn-add button" Text="Search" OnClick="btnSearch_Click" />

            </div>
        </div>
        </div>


    <div id="main"> <!-- col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 -->
        <div id="centermain">
            <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:ListView runat="server" ID="lstRequests">
                            <LayoutTemplate>
                                <table runat="server" class="table">
                                    <thead>
                                        <tr id="thdReqHistory" runat="server">
                                            <th scope="col">Submitted Date</th>
                                            <th scope="col">Status</th>
                                            <th scope="col"></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr id="itemPlaceholder" runat="server"></tr>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><asp:Label runat="server" ID="lblReqDate" Text='<%# Eval("ReqDateTime","{0:dd-MMM-yyyy}") %>' /></td>
                                    <td><asp:Label runat="server" ID="lblStatus" Text='<%# Eval("Status") %>' /></td>
                                    <td><asp:LinkButton ID="btnReqDetail" CssClass="btn btn-primary" href='<%# "RequestList.aspx?reqid="+Eval("ReqId") %>' runat="server">DETAILS</asp:LinkButton> </td>
                                </tr>
                            </ItemTemplate>
                            </asp:ListView>
                        </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>


        </div>
    </div>
        </div>


      <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
                $(document).ready(function () {
                    var dp1 = $('#<%=txtEndDate.ClientID%>');
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
                    var dp = $('#<%=txtStartDate.ClientID%>');

                    dp.datepicker({
                        changeMonth: true,
                        changeYear: true,
                        format: "dd/mm/yyyy",
                        language: "tr"
                    }).on('changeDate', function (ev) {
                        $(this).blur();
                        $(this).datepicker('hide');
                    });
                });
    </script>
</asp:Content>
