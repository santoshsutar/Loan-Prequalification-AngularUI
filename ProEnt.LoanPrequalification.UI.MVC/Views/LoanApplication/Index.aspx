<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProEnt.LoanPrequalification.UI.MVC.LoanApplicationService.LoanApplicationSummaryView>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Loan Applications Submitted
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Loan Applications Submitted</h2>
    
    <p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean ultricies mi vitae est. Mauris placerat eleifend leo.</p>

    <table>
        <tr>
            <th></th>            
            <th>
                Id
            </th>            
            <th>
                LoanAmount
            </th>            
            <th>
                Status
            </th>
            <th>
                Print Letter
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>                
                <%= Html.ActionLink("Details", "Details", new { id = item.Id })%>
            </td>                      
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.LoanAmount.ToString("C"))%>
            </td>            
            <td>
                <%= Html.Encode(item.Status) %>
            </td>
            <td>
                <% if (item.HasOffer == true)
                   {%>
                 <%= Html.ActionLink("Print Offer Letter", "OfferLetter", new { id = item.Id }, new {target="_blank"} )%>
                <% }
                   else 
                   { 
                %>
                No Offer Generated
                <%
                   }
                %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

