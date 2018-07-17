<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProEnt.LoanPrequalification.UI.MVC.LoanApplicationService.LoanApplicationDetailView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details for Loan Application <%= Html.Encode(Model.Id) %></h2>

    <p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean ultricies mi vitae est. Mauris placerat eleifend leo. Quisque sit amet est et sapien ullamcorper pharetra. Vestibulum erat wisi, condimentum sed, commodo vitae, ornare sit amet, wisi. Aenean fermentum, elit eget tincidunt condimentum, eros ipsum rutrum orci, sagittis tempus lacus enim ac dui. Donec non enim in turpis pulvinar facilisis. Ut felis. Praesent dapibus, neque id cursus faucibus, tortor neque egestas augue, eu vulputate magna eros eu erat. Aliquam erat volutpat. Nam dui mi, tincidunt quis, accumsan porttitor, facilisis luctus, metus</p>

    <fieldset>
        <legend>Loan Application</legend>
         <p>
            LoanAmount:
            <%= Html.Encode(Model.LoanAmount.ToString("C"))%>
        </p>
        <p>
            LoanTerm:
            <%= Html.Encode(Model.LoanTerm) %>
        </p>
        <p>
            Deposit:
            <%= Html.Encode(Model.Deposit.ToString("C"))%>
        </p>             
        <p>
            Product:
            <%= Html.Encode(Model.ProductName) %>
        </p>        
        <p>
            PropertyStreet:
            <%= Html.Encode(Model.PropertyStreet) %>
        </p>
        <p>
            PropertyTown:
            <%= Html.Encode(Model.PropertyTown) %>
        </p>
        <p>
            PropertyValue:
            <%= Html.Encode(Model.PropertyValue.ToString("C"))%>
        </p>
        <p>
            PropertyCity:
            <%= Html.Encode(Model.PropertyCity) %>
        </p>
        <p>
            PropertyPostCode:
            <%= Html.Encode(Model.PropertyPostCode) %>
        </p>
        <p>
            Status:
            <%= Html.Encode(Model.Status) %>
        </p>
        
        <fieldset>
            <legend>Borrowers</legend>
                <table>
                <tr>                   
                    <th>
                        FirstName
                    </th>            
                    <th>
                        LastName
                    </th>                            
                </tr>
                 <% foreach (var item in Model.Borrowers)
                      { %>
                 <tr>
                    <td><%= Html.Encode(item.FirstName) %></td>
                    <td><%= Html.Encode(item.LastName) %></td>                
                 </tr>          
                 <% } %>
                 </table>
        </fieldset>      
        
        <% if (Model.Assets.Count() > 0 ) {%>
        <fieldset>
            <legend>Assets</legend>
                <table>
                <tr>                   
                    <th>
                        Description
                    </th>            
                    <th>
                        Balance
                    </th>                            
                </tr>
                 <% foreach (var item in Model.Assets)
                      { %>
                 <tr>
                    <td><%= Html.Encode(item.Description) %></td>
                    <td><%= Html.Encode(item.Balance.ToString("C")) %></td>                
                 </tr>          
                 <% } %>
                 </table>
        </fieldset>   
        <% } %> 
        
        <% if (Model.Debts.Count() > 0 ) {%>
        <fieldset>
            <legend>Debts</legend>
                <table>
                <tr>                   
                    <th>
                        Description
                    </th>            
                    <th>
                        Balance Owed
                    </th>                            
                </tr>
                 <% foreach (var item in Model.Debts)
                      { %>
                 <tr>
                    <td><%= Html.Encode(item.Description) %></td>
                    <td><%= Html.Encode(item.BalanceOwed.ToString("C"))%></td>                
                 </tr>          
                 <% } %>
                 </table>
        </fieldset>    
        <% } %> 
    </fieldset>
    
    <p>        
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

