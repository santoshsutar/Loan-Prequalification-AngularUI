<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProEnt.LoanPrequalification.UI.MVC.LoanApplicationService.LoanApplicationCreateView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Submit a Loan Application for Prequalification
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        
    <script type="text/javascript">
            
        $(document).ready(function() {
            if ($("input#HasSecondBorrower").val() == 'true')
            {
                showSecondBorrower()
            }
            else
            {
                hideSecondBorrower();
            }
        });
                      
                                      
        $(document).ready(function() {
          $('#hideh1').click(function() {
            if ($("input#HasSecondBorrower").val() == 'true')
            {
                hideSecondBorrower();
            }
            else
            {
               showSecondBorrower()
            }
                                    
          });
        });
        
        function hideSecondBorrower()
        {
            $('#BorrowerDetails2').hide();
            $('#BorrowerDetailsTitle2').hide();
            $('#EmployerDetails2').hide();
            $('#EmployerDetailsTitle2').hide();
            $('#BankDetails2').hide();     
            $('#BankDetailsTitle2').hide();          
            $("input#HasSecondBorrower").val('false');      
            $("#hideh1").val('Enter a second borrowers details');
        }
        
        function showSecondBorrower()
        {
             $('#BorrowerDetails2').show();
             $('#BorrowerDetailsTitle2').show();
             $('#EmployerDetails2').show();
             $('#EmployerDetailsTitle2').show();
             $('#BankDetails2').show();     
             $('#BankDetailsTitle2').show();
             $("input#HasSecondBorrower").val('true');
             $("#hideh1").val('Remove a second borrowers details');
        }
    
        $().ready(function()
        {                                       
            $("form.wizard").wizard({
                show: function(element) {                    
                }
            });
        });
        
    </script>
    
    <style type="text/css">
    .wizard-nav
    {
    padding: 10px 0;
    border: 1px solid #ddd;
    width: 650px;
    margin: 10px auto;
    }
    .wizard-nav a
    {
    background: #eee;
    border-right: 1px solid #ddd;
    border-left: 1px solid #ddd;
    text-decoration: none;
    padding: 10px;
    width: 162.5px;
    display: inline;
    margin: 0;
    }
    .wizard-nav a.active { background: #dfd; }

    .wizardcontrols .wizardnext { margin-left: 76%; width: 12%; }
    .wizardcontrols .wizardprev { width: 12%; }
    #LoanDetails .wizardcontrols .wizardnext { margin-left: 88%; }
    </style>
    
           
    <h2>Submit a Loan Application for Prequalification</h2>

    <%= Html.ValidationSummary("The creation of the loan application was unsuccessful. Please correct the errors and try again.") %>

    <form class="wizard" action="#" method="post">
    
       <%= Html.Hidden("HasSecondBorrower") %>       
                    
        <div id="LoanDetails" class="wizardpage">                          
            <p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean ultricies mi vitae est. Mauris placerat eleifend leo. Quisque sit amet est et sapien ullamcorper pharetra. Vestibulum erat wisi, condimentum sed, commodo vitae, ornare sit amet, wisi. Aenean fermentum, elit eget tincidunt condimentum, eros ipsum rutrum orci, sagittis tempus lacus enim ac dui. Donec non enim in turpis pulvinar facilisis. Ut felis. Praesent dapibus, neque id cursus faucibus, tortor neque egestas augue, eu vulputate magna eros eu erat. Aliquam erat volutpat. Nam dui mi, tincidunt quis, accumsan porttitor, facilisis luctus, metus</p>
            <fieldset>
                <legend>Loan Details</legend>
                <p>
                    <label for="Deposit">Deposit:</label>
                    <%= Html.TextBox("Deposit") %>
                    <%= Html.ValidationMessage("Deposit", "*") %>
                </p>                  
                <p>
                    <label for="LoanAmount">Loan Amount:</label>
                    <%= Html.TextBox("LoanAmount") %>
                    <%= Html.ValidationMessage("LoanAmount", "*") %>
                </p>
                <p>
                    <label for="LoanTerm">Loan Term In Years:</label>
                    <%= Html.TextBox("LoanTerm") %>
                    <%= Html.ValidationMessage("LoanTerm", "*") %>
                </p>
                <p>
                    <label for="PropertyValue">Property Value:</label>
                    <%= Html.TextBox("PropertyValue") %>
                    <%= Html.ValidationMessage("PropertyValue", "*") %>
                </p>
                <p>
                    <label for="Product">Product</label>
                    <%= Html.DropDownList("ProductId", (SelectList)ViewData["ProductList"])%>                        
                </p>                        
            </fieldset>
        </div>
        
        <div id="PropertyDetails" class="wizardpage">
            Please enter the following details about the property the applicant(s) wish to buy
            <fieldset>
                <legend>Property Details</legend>
                 <p>
                    <label for="Street">Street</label>
                    <%= Html.TextBox("PropertyStreet")%>
                    <%= Html.ValidationMessage("PropertyStreet", "*")%>  
                 </p>
                 <p>
                    <label for="Town">Town</label>
                    <%= Html.TextBox("PropertyTown")%>
                    <%= Html.ValidationMessage("PropertyTown", "*")%>  
                 </p>
                 <p>
                    <label for="City">City</label>
                    <%= Html.TextBox("PropertyCity")%>
                    <%= Html.ValidationMessage("PropertyCity", "*")%>  
                 </p>
                 <p>
                    <label for="PostCode">PostCode</label>
                    <%= Html.TextBox("PropertyPostCode")%>
                    <%= Html.ValidationMessage("PropertyPostCode", "*")%>  
                 </p>                         
            </fieldset>
         </div>
        
        <div id="BorrowerDetails" class="wizardpage">
            The details you give us here will be used to generate your Personal Illustration
            <fieldset>
                <legend>Borrower Details</legend>
                     <table>
                        <tr>
                            <td valign=top>Borrower 1</td>
                            <td><div id="BorrowerDetailsTitle2">Borrower 2</div>
                            <input type="button" name="hideh1" value="Enter a second borrowers details" id="hideh1" />                            
                            </td>
                        </tr>
                        <tr>
                            <td valign=top>
                                <p>
                                    <label for="PersonalDetails">
                                    <b>Personal Details:</b></label>
                                </p>
                                <p>
                                    <label for="FirstName">
                                        First Name</label>
                                    <%= Html.TextBox("Borrower1.FirstName")%>
                                    <%= Html.ValidationMessage("Borrower1.FirstName", "*")%>
                                </p>
                                <p>
                                    <label for="FirstName">
                                        Last Name</label>
                                    <%= Html.TextBox("Borrower1.LastName")%>
                                    <%= Html.ValidationMessage("Borrower1.LastName", "*")%>
                                </p>
                                <p>
                                    <label for="Age">
                                        Age</label>
                                    <%= Html.TextBox("Borrower1.Age")%>
                                    <%= Html.ValidationMessage("Borrower1.Age", "*")%>
                                </p>
                                <p>
                                    <label for="Street">
                                        Street</label>
                                    <%= Html.TextBox("Borrower1.Street")%>
                                    <%= Html.ValidationMessage("Borrower1.Street", "*")%>
                                </p>
                                <p>
                                    <label for="Town">
                                        Town</label>
                                    <%= Html.TextBox("Borrower1.Town")%>
                                    <%= Html.ValidationMessage("Borrower1.Town", "*")%>
                                </p>
                                <p>
                                    <label for="City">
                                        City</label>
                                    <%= Html.TextBox("Borrower1.City")%>
                                    <%= Html.ValidationMessage("Borrower1.City", "*")%>
                                </p>
                                <p>
                                    <label for="PostCode">
                                        PostCode</label>
                                    <%= Html.TextBox("Borrower1.PostCode")%>
                                    <%= Html.ValidationMessage("Borrower1.PostCode", "*")%>
                                </p>
                            </td>
                            <td valign=top>
                                <div id="BorrowerDetails2">                                                            
                                <p>
                                    <label for="PersonalDetails">
                                    <b>Personal Details:</b></label>
                                </p>
                                <p>
                                    <label for="FirstName">
                                        First Name</label>
                                    <%= Html.TextBox("Borrower2.FirstName")%>                                    
                                </p>
                                <p>
                                    <label for="FirstName">
                                        Last Name</label>
                                    <%= Html.TextBox("Borrower2.LastName")%>                                    
                                </p>
                                <p>
                                    <label for="Age">
                                        Age</label>
                                    <%= Html.TextBox("Borrower2.Age")%>                                    
                                </p>
                                <p>
                                    <label for="Street">
                                        Street</label>
                                    <%= Html.TextBox("Borrower2.Street")%>                                    
                                </p>
                                <p>
                                    <label for="Town">
                                        Town</label>
                                    <%= Html.TextBox("Borrower2.Town")%>                                    
                                </p>
                                <p>
                                    <label for="City">
                                        City</label>
                                    <%= Html.TextBox("Borrower2.City")%>                                    
                                </p>
                                <p>
                                    <label for="PostCode">
                                        PostCode</label>
                                    <%= Html.TextBox("Borrower2.PostCode")%>                                    
                                </p>
                                </div>
                            </td>
                         </tr>
                       </table>
                   </fieldset>
                </div> 

    <div id="EmployerDetails" class="wizardpage">  
            Applicants employer details
                <fieldset>
                <legend>Borrower Employer Details</legend>
                    <table>
                        <tr>
                            <td valign=top>Borrower 1</td>
                            <td><div id="EmployerDetailsTitle2">Borrower 2</div></td>
                        </tr>
                        <tr>
                            <td valign=top>
                                <p>
                                    <label for="Employer">
                                    <b>Employer Details:</b></label>
                                </p>
                                <p>
                                    <label for="Name">Name</label>
                                    <%= Html.TextBox("Borrower1.EmployerName")%>
                                    <%= Html.ValidationMessage("Borrower1.EmpolyerName", "*")%>
                                </p>
                                <p>
                                    <label for="MonthlyIncome">
                                        Monthly Income</label>
                                    <%= Html.TextBox("Borrower1.MonthlyIncome")%>
                                    <%= Html.ValidationMessage("Borrower1.MonthlyIncome", "*")%>
                                </p>
                                <p>
                                    <label for="Street">
                                        Employer Street</label>
                                    <%= Html.TextBox("Borrower1.EmployerStreet")%>
                                    <%= Html.ValidationMessage("Borrower1.EmployerStreet", "*")%>
                                </p>
                                <p>
                                    <label for="Town">
                                        Employer Town</label>
                                    <%= Html.TextBox("Borrower1.EmployerTown")%>
                                    <%= Html.ValidationMessage("Borrower1.EmployerTown", "*")%>
                                </p>
                                <p>
                                    <label for="City">
                                        Employer City</label>
                                    <%= Html.TextBox("Borrower1.EmployerCity")%>
                                    <%= Html.ValidationMessage("Borrower1.EmployerCity", "*")%>
                                </p>
                                <p>
                                    <label for="PostCode">
                                        Employer PostCode</label>
                                    <%= Html.TextBox("Borrower1.EmployerPostCode")%>
                                    <%= Html.ValidationMessage("Borrower1.EmployerPostCode", "*")%>
                                </p>
                            </td>
                            <td valign=top>
                                <div id="EmployerDetails2">        
                                    <p>
                                        <label for="Employer">
                                        <b>Employer Details:</b></label>
                                    </p>
                                    <p>
                                        <label for="Name">Name</label>
                                        <%= Html.TextBox("Borrower2.EmployerName")%>                                    
                                    </p>
                                    <p>
                                        <label for="MonthlyIncome">
                                            Monthly Income</label>
                                        <%= Html.TextBox("Borrower2.MonthlyIncome")%>                                    
                                    </p>
                                    <p>
                                        <label for="Street">
                                            Employer Street</label>
                                        <%= Html.TextBox("Borrower2.EmployerStreet")%>                                    
                                    </p>
                                    <p>
                                        <label for="Town">
                                            Employer Town</label>
                                        <%= Html.TextBox("Borrower2.EmployerTown")%>                                    
                                    </p>
                                    <p>
                                        <label for="City">
                                            Employer City</label>
                                        <%= Html.TextBox("Borrower2.EmployerCity")%>                                    
                                    </p>
                                    <p>
                                        <label for="PostCode">
                                            Employer PostCode</label>
                                        <%= Html.TextBox("Borrower2.EmployerPostCode")%>                                    
                                    </p> 
                                </div>
                            </td>
                        </tr>
                    </table>
                </fieldset> 
        </div>
                
        <div id="BankDetails" class="wizardpage">
            Applicants bank details        
                <fieldset>
                <legend>Borrower Bank Account Details</legend>
                    <table>   
                        <tr>
                            <td valign=top>Borrower 1</td>                                                              
                            <td valign=top><div id="BankDetailsTitle2">Borrower 2</div></td>                                                              
                        </tr>
                        <tr>
                            <td>
                                <p>
                                    <label for="BankAccount">
                                    <b>Bank Account Details:</b></label>
                                </p>
                                <p>
                                    <label for="BankName">
                                        Bank Name</label>
                                    <%= Html.TextBox("Borrower1.BankName")%>
                                    <%= Html.ValidationMessage("Borrower1.BankName", "*")%>
                                </p>
                                <p>
                                    <label for="Name">
                                        Your Name</label>
                                    <%= Html.TextBox("Borrower1.BankAccountName")%>
                                    <%= Html.ValidationMessage("Borrower1.BankAccountName", "*")%>
                                </p>
                                <p>
                                    <label for="AccountNumber">
                                        Account Number</label>
                                    <%= Html.TextBox("Borrower1.BankAccountNumber")%>
                                    <%= Html.ValidationMessage("Borrower1.BankAccountNumber", "*")%>
                                </p>
                                <p>
                                    <label for="SortCode">
                                        Sort Code</label>
                                    <%= Html.TextBox("Borrower1.BankSortCode")%>
                                    <%= Html.ValidationMessage("Borrower1.BankSortCode", "*")%>
                                </p>                            
                                <p>
                                    <label for="CreditScore">
                                    <b>Credit Score:</b></label>
                                </p>
                                <p>
                                    <label for="CreditAgency">
                                        Credit Agency</label>
                                    <%= Html.TextBox("Borrower1.CreditAgency")%>
                                    <%= Html.ValidationMessage("Borrower1.CreditAgency", "*")%>
                                </p>
                                <p>
                                    <label for="Score">
                                        Credit Score</label>
                                    <%= Html.TextBox("Borrower1.CreditScore")%>
                                    <%= Html.ValidationMessage("Borrower1.CreditScore", "*")%>
                                </p>
                            </td>                                                              
                            <td>
                                <div id="BankDetails2">
                                    <p>
                                        <label for="BankAccount">
                                        <b>Bank Account Details:</b></label>
                                    </p>
                                    <p>
                                        <label for="BankName">
                                            Bank Name</label>
                                        <%= Html.TextBox("Borrower2.BankName")%>                                    
                                    </p>
                                    <p>
                                        <label for="Name">
                                            Your Name</label>
                                        <%= Html.TextBox("Borrower2.BankAccountName")%>                                    
                                    </p>
                                    <p>
                                        <label for="AccountNumber">
                                            Account Number</label>
                                        <%= Html.TextBox("Borrower2.BankAccountNumber")%>                                    
                                    </p>
                                    <p>
                                        <label for="SortCode">
                                            Sort Code</label>
                                        <%= Html.TextBox("Borrower2.BankSortCode")%>                                    
                                    </p>                            
                                    <p>
                                        <label for="CreditScore">
                                        <b>Credit Score:</b></label>
                                    </p>
                                    <p>
                                        <label for="CreditAgency">
                                            Credit Agency</label>
                                        <%= Html.TextBox("Borrower2.CreditAgency")%>                                    
                                    </p>
                                    <p>
                                        <label for="Score">
                                            Credit Score</label>
                                        <%= Html.TextBox("Borrower2.CreditScore")%>                                    
                                    </p>
                                </div>
                            </td>
                        </tr>
                    </table>
            </fieldset>                            
        </div>                                                   
                                                                         
        <div id="Assets" class="wizardpage">
            Does the applicant have any additional monthly income?
            <fieldset>
                <legend>Assets</legend>
                    <table border="0">
                        <tr>
                            <td></td>
                            <td><label for="AccountNumber">Account Number</label></td>                             
                            <td><label for="AssetBalance">Balance</label></td>
                        </tr>                                                                                                       
                        <tr>                            
                            <td>Pension (Including State Pension)<%= Html.Hidden("Asset1.Description", "Pension (Including State Pension)")%></td>
                            <td><%= Html.TextBox("Asset1.AccountNumber")%></td>                            
                            <td><%= Html.TextBox("Asset1.Balance")%></td>
                        </tr>
                        <tr>
                            <td>State Benefits/Allowances (Excluding State Pension)<%= Html.Hidden("Asset2.Description", "State Benefits/Allowances (Excluding State Pension)")%></td>                            
                            <td><%= Html.TextBox("Asset2.AccountNumber")%></td>                            
                            <td><%= Html.TextBox("Asset2.Balance")%></td>
                        </tr>
                        <tr>                            
                            <td>Investments<%= Html.Hidden("Asset3.Description", "Investments")%></td>
                            <td><%= Html.TextBox("Asset3.AccountNumber")%></td>                            
                            <td><%= Html.TextBox("Asset3.Balance")%></td>
                        </tr>
                    </table>                        
            </fieldset> 
        </div>
                      
        <div id="Debts" class="wizardpage"> 
            <p>
            Please exclude debts that the applicant intends to repay before or as part of taking out this mortgage, 
            also any that have less than six months repayments left. 
            </p>
                       
            <fieldset>
                <legend>Debts</legend>
                <table border="0">
                        <tr>
                            <td></td>
                            <td><label for="CreditorName">Creditor Name</label></td> 
                            <td><label for="BalanceOwed">Balance Owed</label></td>
                            <td><label for="MonthlyPayment">Monthly Payment</label></td>
                        </tr>
                        <tr>
                            <td>Personal loans/hire purchase<%= Html.Hidden("Debt1.Description", "Personal loans/hire purchase")%></td>
                            <td><%= Html.TextBox("Debt1.CreditorName")%></td>
                            <td><%= Html.TextBox("Debt1.BalanceOwed")%></td>
                            <td><%= Html.TextBox("Debt1.MonthlyPayment")%></td>
                        </tr>
                        <tr>
                            <td>Student loans<%= Html.Hidden("Debt2.Description", "Student loans")%></td>
                            <td><%= Html.TextBox("Debt2.CreditorName")%></td>
                            <td><%= Html.TextBox("Debt2.BalanceOwed")%></td>
                            <td><%= Html.TextBox("Debt2.MonthlyPayment")%></td>
                        </tr>
                        <tr>
                            <td>Credit card balance<%= Html.Hidden("Debt3.Description", "Credit card balance")%></td>
                            <td><%= Html.TextBox("Debt3.CreditorName")%></td>
                            <td><%= Html.TextBox("Debt3.BalanceOwed")%></td>
                            <td><%= Html.TextBox("Debt3.MonthlyPayment")%></td>
                        </tr>
                </table>                        
            </fieldset> 
        </div>
        
        <div id="Create" class="wizardpage">  
            <fieldset>
                <legend>Submit The Loan Application</legend>
                    <p align="center">            
                        <input type="submit" value="Submit Loan Application for Prequalification" />                        
                    </p>
                    <p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean ultricies mi vitae est. Mauris placerat eleifend leo.</p>
                    <p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean ultricies mi vitae est. Mauris placerat eleifend leo. Quisque sit amet est et sapien ullamcorper pharetra. Vestibulum erat wisi, condimentum sed, commodo vitae, ornare sit amet, wisi. Aenean fermentum, elit eget tincidunt condimentum, eros ipsum rutrum orci, sagittis tempus lacus enim ac dui. Donec non enim in turpis pulvinar facilisis. Ut felis. Praesent dapibus, neque id cursus faucibus, tortor neque egestas augue, eu vulputate magna eros eu erat. Aliquam erat volutpat. Nam dui mi, tincidunt quis, accumsan porttitor, facilisis luctus, metus</p>
            </fieldset> 
        </div>                                                                  
    </form>    
</asp:Content>

