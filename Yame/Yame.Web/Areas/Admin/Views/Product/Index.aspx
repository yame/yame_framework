<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Yame.Models.Domain.Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        $(function() {
            $('.delete').click(function(e) {
                if (confirm('您确定要删除该产品吗？')) {
                    $.ajax({
                        type: 'POST',
                        url: this.href,
                        success: function(result) {
                            if (result.result) {
                                alert("删除成功！")
                            }
                            else {
                                alert(result.message);
                            }
                        }
                    });
                }
                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <table>
        <tr>
            <th>
            </th>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                Category
            </th>
            <th>
                Discontinued
            </th>
        </tr>
        <% foreach( var item in Model )
           { %>
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id = item.Id })%>
                |
                <%= Html.ActionLink("Details", "Details", new { id = item.Id })%>
                |
                <%= Html.ActionLink("Delete", "Delete", new { id = item.Id },new { @class="delete"})%>
            </td>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.Category) %>
            </td>
            <td>
                <%= Html.Encode(item.Discontinued) %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>
