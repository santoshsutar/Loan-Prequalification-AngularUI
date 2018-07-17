<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProEnt.LoanPrequalification.UI.MVC.ProductService.ProductView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details for <%= Html.Encode(Model.Name) %></h2>
    
    <p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean ultricies mi vitae est. Mauris placerat eleifend leo. Quisque sit amet est et sapien ullamcorper pharetra. Vestibulum erat wisi, condimentum sed, commodo vitae, ornare sit amet, wisi. Aenean fermentum, elit eget tincidunt condimentum, eros ipsum rutrum orci, sagittis tempus lacus enim ac dui. Donec non enim in turpis pulvinar facilisis. Ut felis. Praesent dapibus, neque id cursus faucibus, tortor neque egestas augue, eu vulputate magna eros eu erat. Aliquam erat volutpat. Nam dui mi, tincidunt quis, accumsan porttitor, facilisis luctus, metus</p>

    <fieldset>
        <legend><%= Html.Encode(Model.Name) %></legend>        
        <p>
            InterestRate:
            <%= Html.Encode(Model.InterestRate.ToString("0.00"))%>
        </p>
        <p>
            MaximumLTV:
            <%= Html.Encode(Model.MaximumLTV) %>
        </p>
        <p>
            MaximumLoan:
            <%= Html.Encode(Model.MaximumLoan.ToString("C")) %>
        </p>
        <p>
            MaximumLoanTerm:
            <%= Html.Encode(Model.MaximumLoanTerm) %>
        </p>        
    </fieldset>
    <p>        
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>
