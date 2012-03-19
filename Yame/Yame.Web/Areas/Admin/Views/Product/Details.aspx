<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Yame.Models.Domain.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details</h2>
    <fieldset>
        <legend>Fields</legend>
        <div class="display-label">
            Id</div>
        <div class="display-field">
            <%= Html.Encode(Model.Id) %></div>
        <div class="display-label">
            Name</div>
        <div class="display-field">
            <%= Html.Encode(Model.Name) %></div>
        <div class="display-label">
            Category</div>
        <div class="display-field">
            <%= Html.Encode(Model.Category) %></div>
        <div class="display-label">
            Discontinued</div>
        <div class="display-field">
            <%= Html.Encode(Model.Discontinued) %></div>
    </fieldset>
    <p>
        <%= Html.ActionLink("Edit", "Edit", new {  id=Model.Id}) %>
        |
        <%= Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>
