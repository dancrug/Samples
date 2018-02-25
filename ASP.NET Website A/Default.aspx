<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleAffilForm.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title></title>
 <meta name="viewport" content="width=device-width, initial-scale=1.0" />
 <link href="css/main.css" rel="stylesheet" type="text/css" />
 <link href="css/jquery-ui.min.css" rel="stylesheet" type="text/css" />
 <script src="scripts/jquery-1.12.min.js" type="text/javascript"></script>
 <script src="scripts/jquery.maskedinput.js" type="text/javascript"></script>
 <script src="scripts/jquery-ui.min.js" type="text/javascript"></script>
 <script src="scripts/Functions.js" type="text/javascript"></script>
</head>
<body>
 <div class="container">
  <div class="top">
   <div class="left">
    <img src="img/" alt="Sample" />
   </div>
   <div class="right">
    <img src="img/" alt="Sample" />
   </div>
  </div>
  <form id="form1" runat="server" class="frm" autocomplete="off">
  <asp:Panel runat="server" ID="pnlForm" Visible="true">
   <h1>
    General Information</h1>
   <div class="field">
    <asp:TextBox ID="txtGroupName" runat="server" CssClass="txt" Text="Group/Company Name"
     ToolTip="Group/Company Name" TabIndex="1"></asp:TextBox>
   </div>
   <div class="header">
    <label class="lbl">
     Contact Information</label>
   </div>
   <div class="field">
    <asp:TextBox ID="txtCFirstName" Text="First Name" runat="server" CssClass="txt" ToolTip="First Name"
     TabIndex="2"></asp:TextBox>
   </div>
   <div class="field">
    <asp:TextBox ID="txtCLastName" Text="Last Name" runat="server" CssClass="txt" ToolTip="Last Name"
     TabIndex="3"></asp:TextBox>
   </div>
   <div class="field">
    <asp:TextBox ID="txtCAddress1" Text="Address" runat="server" CssClass="txt" ToolTip="Address"
     TabIndex="4"></asp:TextBox>
   </div>
   <div class="field">
    <asp:TextBox ID="txtCCity" Text="City" runat="server" CssClass="txt" ToolTip="City"
     TabIndex="5"></asp:TextBox>
   </div>
   <div class="field">
    <asp:DropDownList ID="ddlCState" runat="server" CssClass="ddl" TabIndex="6">
     <asp:ListItem Value="0" Text="Select State"></asp:ListItem>
    </asp:DropDownList>
   </div>
   <div class="field">
    <asp:TextBox ID="txtCZip" runat="server" CssClass="txt" Text="Zip" MaxLength="5"
     TabIndex="7" ToolTip="Zip"></asp:TextBox>
   </div>
   <div class="field">
    <asp:TextBox ID="txtCPhone" runat="server" CssClass="txt add phone" Text="Phone"
     MaxLength="12" TabIndex="8" data-box="ContactPhone" ToolTip="Phone"></asp:TextBox>
    <input type="button" value="+" data-box="ContactPhone" class="btn add" tabindex="9" />
    <div id="ContactPhone" class="multibox" runat="server">
    </div>
    <input type="hidden" value="" id="hdnContactPhone" runat="server" data-box="ContactPhone" />
   </div>
   <div class="field">
    <asp:TextBox ID="txtCEmail" runat="server" CssClass="txt add" Text="Email" ToolTip="Email"
     TabIndex="10" data-box="ContactEmail"></asp:TextBox>
    <input type="button" value="+" data-box="ContactEmail" class="btn add" tabindex="11" />
    <div id="ContactEmail" class="multibox" runat="server">
    </div>
    <input type="hidden" value="" id="hdnContactEmail" runat="server" data-box="ContactEmail" />
   </div>
   <div class="header">
    <label class="lbl">
     Billing Information <small>(if different from contact)</small></label>
    <span class="chkspan">
     <asp:CheckBox Checked="false" runat="server" ID="chkCInfo" CssClass="chk" TabIndex="12" /><label
      for="chkCInfo" class="lbl">Same as contact information</label></span>
   </div>
   <div class="field">
    <asp:TextBox ID="txtBFirstName" Text="First Name" runat="server" CssClass="txt" ToolTip="First Name"
     TabIndex="13"></asp:TextBox>
   </div>
   <div class="field">
    <asp:TextBox ID="txtBLastName" Text="Last Name" runat="server" CssClass="txt" ToolTip="Last Name"
     TabIndex="14"></asp:TextBox>
   </div>
   <div class="field">
    <asp:TextBox ID="txtBAddress1" Text="Address" runat="server" CssClass="txt" ToolTip="Address"
     TabIndex="15"></asp:TextBox>
   </div>
   <div class="field">
    <asp:TextBox ID="txtBCity" Text="City" runat="server" CssClass="txt" ToolTip="City"
     TabIndex="16"></asp:TextBox>
   </div>
   <div class="field">
    <asp:DropDownList ID="ddlBState" runat="server" CssClass="ddl" TabIndex="17">
     <asp:ListItem Value="0" Text="Select State"></asp:ListItem>
    </asp:DropDownList>
   </div>
   <div class="field">
    <asp:TextBox ID="txtBZip" runat="server" CssClass="txt" Text="Zip" MaxLength="5"
     TabIndex="18" ToolTip="Zip"></asp:TextBox>
   </div>
   <div class="field">
    <asp:TextBox ID="txtBPhone" runat="server" CssClass="txt add phone" Text="Phone"
     MaxLength="12" TabIndex="19" ToolTip="Phone" data-box="BusinessPhone"></asp:TextBox>
    <input type="button" value="+" data-box="BusinessPhone" class="btn add" tabindex="20" />
    <div id="BusinessPhone" class="multibox" runat="server">
    </div>
    <input type="hidden" value="" id="hdnBusinessPhone" runat="server" data-box="BusinessPhone" />
   </div>
   <div class="field">
    <asp:TextBox ID="txtBEmail" runat="server" CssClass="txt add" Text="Email" ToolTip="Email"
     TabIndex="21" data-box="BusinessEmail"></asp:TextBox>
    <input type="button" value="+" data-box="BusinessEmail" class="btn add" tabindex="22" />
    <div id="BusinessEmail" class="multibox" runat="server">
    </div>
    <input type="hidden" value="" id="hdnBusinessEmail" runat="server" data-box="BusinessEmail" />
   </div>
   <div>
    <div class="col">
     <h1>
      Market Information</h1>
     <div class="field">
      <label class="lbl">
       Market Name:
      </label>
      <asp:TextBox ID="txtMarketName" runat="server" data-group="marketInformation" CssClass="txt"
       TabIndex="23"></asp:TextBox>
     </div>
     <div class="field">
      <label class="lbl">
       Monthly Budgets: <small>(if applicable)</small></label>
      <asp:TextBox ID="txtMonthlyBudgets" runat="server" CssClass="txt currency" data-group="marketInformation"
       TabIndex="24" MaxLength="12"></asp:TextBox>
     </div>
     <div class="field">
      <label class="lbl">
       Zip Codes in Market:
      </label>
      <asp:TextBox ID="txtMarketZip" runat="server" data-box="marketZips" CssClass="txt disable"
       data-group="marketInformation" TabIndex="25" AutoCompleteType="Disabled" AutoComplete="off"
       MaxLength="5" Enabled="false" Text="To be sent later"></asp:TextBox>
      <!--<input type="button" value="+" data-box="marketZips" class="btn add" tabindex="26" />
                    <div id="marketZips" class="multibox" runat="server" data-group="marketInformation">
                    </div>-->
     </div>
     <div class="field">
      <label class="lbl">
       Excluded Zip Codes: <small>(if applicable)</small></label>
      <asp:TextBox ID="txtExcludeZip" runat="server" data-box="marketExcludeZip" CssClass="txt disable"
       data-group="marketInformation" Enabled="false" TabIndex="27" MaxLength="5" Text="To be sent later"></asp:TextBox>
      <!--<input type="button" value="+" data-box="marketExcludeZip" class="btn add" tabindex="28" />
                    <div id="marketExcludeZip" class="multibox" runat="server" data-group="marketInformation">
                    </div>-->
     </div>
    </div>
    <div class="col">
     <h1>
      &nbsp;</h1>
     <div class="field">
      <label class="lbl">
       Call Center Phone Information:
      </label>
      <asp:DropDownList runat="server" ID="ddlCallCenterPhone" CssClass="ddl call" data-box="CallCenterPhone"
       TabIndex="29" data-group="marketInformation">
       <asp:ListItem Text="Select One" Value="NA"></asp:ListItem>
       <asp:ListItem Text="Corporate ISC" Value="Corporate ISC"></asp:ListItem>
       <asp:ListItem Text="Supply Later" Value="Supply Later"></asp:ListItem>
       <asp:ListItem Text="Enter Custom" Value="Enter Custom"></asp:ListItem>
      </asp:DropDownList>
      <br />
      <asp:TextBox ID="txtCallCenterPhone" runat="server" data-box="CallCenterPhone" CssClass="txt hidden"
       data-group="marketInformation" TabIndex="30" MaxLength="12" Text=""></asp:TextBox>
      <!--<input type="button" value="+" data-box="callCenterPhone" class="btn add" tabindex="30" />
                    <div id="callCenterPhone" class="multibox" runat="server" data-group="marketInformation">
                    </div>-->
     </div>
     <div class="field">
      <label class="lbl">
       Call Center Hours:</label>
      <asp:DropDownList runat="server" ID="ddlCallCenterHours" CssClass="ddl call" data-box="CallCenterHours"
       TabIndex="31" data-group="marketInformation">
       <asp:ListItem Text="Select One" Value="NA"></asp:ListItem>
       <asp:ListItem Text="Corporate ISC" Value="Corporate ISC"></asp:ListItem>
       <asp:ListItem Text="Supply Later" Value="Supply Later"></asp:ListItem>
       <asp:ListItem Text="Enter Custom" Value="Enter Custom"></asp:ListItem>
      </asp:DropDownList>
      <br />
      <asp:TextBox ID="txtCallCenterHours" runat="server" data-box="CallCenterHours" CssClass="txt hidden"
       data-group="marketInformation" TabIndex="32" Text=""></asp:TextBox>
      <!--<input type="button" value="+" data-box="callCenterHours" class="btn add" tabindex="32" />
                    <div id="callCenterHours" class="multibox" runat="server" data-group="marketInformation">
                    </div>-->
     </div>
     <div class="field">
      <label class="lbl">
       Email Address for Lead Delivery:</label>
      <asp:DropDownList runat="server" ID="ddlLeadEmailDelivery" CssClass="ddl call" data-box="LeadEmailDelivery"
       TabIndex="33" data-group="marketInformation">
       <asp:ListItem Text="Select One" Value="NA"></asp:ListItem>
       <asp:ListItem Text="Corporate ISC" Value="Corporate ISC"></asp:ListItem>
       <asp:ListItem Text="Supply Later" Value="Supply Later"></asp:ListItem>
       <asp:ListItem Text="Enter Custom" Value="Enter Custom"></asp:ListItem>
      </asp:DropDownList>
      <br />
      <asp:TextBox ID="txtLeadEmailDelivery" runat="server" CssClass="txt hidden" data-box="LeadEmailDelivery"
       data-group="marketInformation" TabIndex="34" Text=""></asp:TextBox>
      <!--<input type="button" value="+" data-box="leadEmailDelivery" class="btn add" tabindex="34" />
                    <div id="leadEmailDelivery" class="multibox" runat="server" data-group="marketInformation">
                    </div>-->
     </div>
     <div class="field">
      <input type="button" class="btn addmarket" value="Add Market" data-group="marketInformation"
       tabindex="35" />
     </div>
    </div>
   </div>
   <div class="field market">
    <table id="marketInformation" class="multibox" runat="server">
     <tbody>
      <tr>
       <th>
        Market Name
       </th>
       <th>
        Monthly Budget
       </th>
       <th>
        Inc. Zips
       </th>
       <th>
        Exc. Zips
       </th>
       <th>
        Call #
       </th>
       <th>
        Call Hours
       </th>
       <th>
        Email
       </th>
      </tr>
     </tbody>
    </table>
    <input type="hidden" runat="server" id="hdnMarketInformation" value="" />
   </div>
   <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="btn submit" TabIndex="36"
    OnClientClick="setFormFields();" OnClick="btnSubmit_Click" />
  </asp:Panel>
  <asp:Panel runat="server" ID="pnlSuccess" Visible="false">
   <p>
    Your request was submitted successfully.</p>
   <script type="text/javascript">
    setTimeout(function () {
     document.location.href = location.pathname;
    }, 2000);
   </script>
  </asp:Panel>
  </form>
  <div class="footer">
   <hr />
   &copy;
   <script type="text/javascript">    document.write(new Date().getFullYear());</script>
   Sample
  </div>
 </div>
</body>
</html>
