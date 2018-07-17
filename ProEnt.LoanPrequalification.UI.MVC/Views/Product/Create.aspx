<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProEnt.LoanPrequalification.UI.MVC.ProductService.ProductView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create a loan product
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create a Loan Product</h2>
    
    <p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean ultricies mi vitae est. Mauris placerat eleifend leo. Quisque sit amet est et sapien ullamcorper pharetra. Vestibulum erat wisi, condimentum sed, commodo vitae, ornare sit amet, wisi. Aenean fermentum, elit eget tincidunt condimentum, eros ipsum rutrum orci, sagittis tempus lacus enim ac dui. Donec non enim in turpis pulvinar facilisis. Ut felis. Praesent dapibus, neque id cursus faucibus, tortor neque egestas augue, eu vulputate magna eros eu erat. Aliquam erat volutpat. Nam dui mi, tincidunt quis, accumsan porttitor, facilisis luctus, metus</p>
    
    <%= Html.ValidationSummary("The creation of the loan application was unsuccessful. Please correct the errors and try again.") %>
    
    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>            
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name") %>               
            </p>
            <p>
                <label for="InterestRate">InterestRate:</label>
                <%= Html.TextBox("InterestRate") %>                
            </p>
            <p>
                <label for="MaximumLTV">MaximumLTV:</label>
                <%= Html.TextBox("MaximumLTV") %>                
            </p>
            <p>
                <label for="MaximumLoan">MaximumLoan:</label>
                <%= Html.TextBox("MaximumLoan") %>                
            </p>
            <p>
                <label for="MaximumLoanTerm">MaximumLoanTerm:</label>
                <%= Html.TextBox("MaximumLoanTerm") %>                
            </p>            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to Product List", "Index") %>
    </div>

</asp:Content>

