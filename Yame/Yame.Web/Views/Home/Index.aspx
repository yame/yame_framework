<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="<%= Url.Content("~/Scripts/jquery.js") %>"></script>
    <script type="text/javascript">
        $(function() {
            $("#test").click(function() {
                $.post("/Work/Create", {
                    Id: 'A0601D89-48DC-443E-B18B-F2D7393B1A17',
                    Category: 'Categor0000y'
                },
                function(data) {
                    console.dir(data);
                });
            });
        });
        
    </script>
    <h2>
        <%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
    </p>
    <input id="test" type="button" value="test" />
</asp:Content>
