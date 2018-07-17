<%@ Page Title="" Language="C#"  Inherits="System.Web.Mvc.ViewPage<ProEnt.LoanPrequalification.UI.MVC.LoanApplicationService.OfferLetterView>" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ViewPage1</title>
</head>
<body>
    <div>
    
    <table align="center" bgcolor="#ffffcc" width="500" cellspacing="10" cellpadding="25" border="0">
<tr>
<td>
 
</p><p><font face="times" size="2" color="Black">
 
</p>
 
</p><p><font size="2">
 
</p><p>
</p><p><p align="left">
<br>
<%= DateTime.Now.ToLongDateString()  %><br>
</p>
 
</p>
<p>
    <table>
        <tr>
            <td>
                <%= Html.Encode(Model.RecipientName) %><br />
                <%= Html.Encode(Model.RecipientStreet) %><br />
                <%= Html.Encode(Model.RecipientTown ) %><br />
                <%= Html.Encode(Model.RecipientCity) %><br />
                <%= Html.Encode(Model.RecipientPostCode) %>
            </td>
            <td>
                <% if (Model.HasSecondBorrower) { %>
                
                <%= Html.Encode(Model.Recipient2Name) %><br />
                <%= Html.Encode(Model.Recipient2Street) %><br />
                <%= Html.Encode(Model.Recipient2Town ) %><br />
                <%= Html.Encode(Model.Recipient2City) %><br />
                <%= Html.Encode(Model.Recipient2PostCode) %>
                
                <% } %>
            </td>
       </tr>        
    </table>                
    </p>
 
</p><p>Dear  <%= Html.Encode(Model.RecipientName) %><% if (Model.HasSecondBorrower) { %>, <%= Html.Encode(Model.Recipient2Name)%><% }%>  
:<br>
 
</p><p><center><b>Re: Loan Application <%= Html.Encode(Model.LoanApplicationId) %></b></center>

<p>Pellentesque erat tellus, placerat at imperdiet interdum, volutpat eget ipsum. Duis nec neque ac felis aliquet convallis id eu sem. Donec hendrerit porta nibh ut egestas. Aliquam auctor fermentum sodales. Proin vulputate vestibulum volutpat. Morbi posuere interdum ligula at interdum. Vestibulum pellentesque fermentum risus, vel tincidunt quam porttitor eu. Suspendisse feugiat augue vitae dolor consequat vel egestas elit aliquam. Quisque sed urna ligula. Suspendisse id sapien magna, id vestibulum eros. Proin ut libero et risus congue fringilla vitae at elit. Aenean metus ante, scelerisque ut fermentum non, consectetur ac libero. Aenean volutpat pellentesque nulla vitae dapibus. In volutpat tincidunt posuere. Nullam eleifend mauris est, et facilisis dui. Morbi eget augue eros, sit amet consequat lorem.</p>

<table>
    <tr>
        <td>Offer Expires</td>
        <td>Loan Amount</td>
        <td>Loan Term</td>
    </tr>
    <tr>
        <td><%= Html.Encode(Model.ExpirationDate.ToShortDateString()) %></td>
        <td><%= Html.Encode(Model.LoanAmount.ToString("C"))%></td>
        <td><%= Html.Encode(Model.LoanTerm) %> Years</td>
    </tr>
</table>

<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed at purus orci. Suspendisse potenti. Sed lacus odio, vulputate in sagittis a, lacinia ut velit. Donec aliquet dignissim semper. Mauris placerat lectus vitae libero eleifend in tincidunt leo rutrum. Ut hendrerit nulla quis eros egestas nec accumsan purus bibendum. Phasellus vitae aliquet ligula. Donec vel urna tortor, sed venenatis leo. Donec ac risus vitae arcu semper ultrices vel id urna. Maecenas sit amet magna imperdiet augue sollicitudin congue sed nec dolor. </p>
Very sincerely,<br>
<br><br>
 
</p><p>David James<br>
Loans Inc.<br>
 
</p><p></font>
</td>
</tr>
</table>

    </div>
</body>
</html>



