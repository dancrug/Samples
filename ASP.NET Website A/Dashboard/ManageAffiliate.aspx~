<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageAffiliate.aspx.cs" MasterPageFile="~/Dashboard/Master.Master"
 Inherits="SampleAffilForm.Dashboard.ManageAffiliate" Title="Sample - Manage Affiliate" %>

<asp:Content ID="HeadContentPlaceHolder" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
 <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
 </asp:ScriptManager>
 <asp:HyperLink runat="server" NavigateUrl="~/Dashboard/" Text="< Go Back"></asp:HyperLink>
 <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">
  <ContentTemplate>
   <asp:Panel ID="pnlCompany" runat="server" CssClass="pnlForm" ClientIDMode="Static">
    <h1>Managing
     <asp:Label runat="server" Text="" ID="lblCompanyName" CssClass="GN"></asp:Label>
    </h1>
    <!-- On/Off -->
    <div class="status">
     <h1>Manage Status</h1>
     <asp:RadioButtonList ID="rdoStatus" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoStatus_SelectedIndexChanged"
      CssClass="status" AutoPostBack="true">
      <asp:ListItem Text="On" Value="On" Selected="False" class="green"></asp:ListItem>
      <asp:ListItem Text="Off" Value="Off" Selected="True" class="red"></asp:ListItem>
      <asp:ListItem Text="Moderate" Value="Moderate" Selected="False" class="orange"></asp:ListItem>
     </asp:RadioButtonList>
    </div>
    <!-- Company Grid -->
    <asp:GridView ID="CompanyGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2"
     OnRowUpdated="BindGrids" CssClass="grid">
     <Columns>
      <asp:BoundField ReadOnly="False" DataField="ID" HeaderText="ID" InsertVisible="False" SortExpression="ID"
       Visible="false" />
      <asp:BoundField DataField="GroupName" HeaderText="Group Name" SortExpression="GroupName" />
      <asp:TemplateField HeaderText="Call Center Hours">
       <ItemTemplate>
        <asp:TextBox runat="server" Text='<%# Eval("CallCenterHours") %>' TextMode="MultiLine" CssClass="multiline"
         ReadOnly="true" Height="80" Width="300" ID="lblCallCenterHours" BorderStyle="None"></asp:TextBox>
       </ItemTemplate>
       <EditItemTemplate>
        <asp:TextBox runat="server" Text='<%# Bind("CallCenterHours") %>' ID="txtCallCenterHours" TextMode="MultiLine"
         ReadOnly="false" Wrap="true" Height="90" Width="300" CssClass="multiline"></asp:TextBox>
       </EditItemTemplate>
      </asp:TemplateField>
      <asp:CommandField ShowEditButton="True" />
     </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:AffiliateInformationConnectionString %>"
     SelectCommand="sp_Sample_Return_Affil" SelectCommandType="StoredProcedure" UpdateCommand="sp_Sample_Insert_Affil"
     UpdateCommandType="StoredProcedure">
     <SelectParameters>
      <asp:QueryStringParameter Name="ID" QueryStringField="AID" Type="Int32" />
     </SelectParameters>
     <UpdateParameters>
      <asp:Parameter Name="GroupName" Type="String" />
      <asp:Parameter Name="CallCenterHours" Type="String" />
      <asp:Parameter Name="Type" Type="String" DefaultValue="UPDATE" />
      <asp:Parameter Name="ID" Type="Int32" />
      <asp:Parameter Name="AID" Type="Int32" Direction="Output" />
     </UpdateParameters>
    </asp:SqlDataSource>
   </asp:Panel>
   <asp:Panel runat="server" ID="pnlDetails" CssClass="pnlForm" DefaultButton="" ClientIDMode="Static">
    <div>
     <div class="right">
      <h1>Internal Use Only</h1>
      <asp:Label runat="server" ID="lblTest"></asp:Label>
      <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateEditButton="True" AutoGenerateRows="False" DataSourceID="SqlDataSource1"
       class="details" DataKeyNames="AID">
       <Fields>
        <asp:BoundField DataField="AID" HeaderText="AID" SortExpression="AID" InsertVisible="False" Visible="false" />
        <asp:BoundField DataField="ContractStatus" HeaderText="Contract Status" SortExpression="ContractStatus" />
        <asp:BoundField DataField="PrepaymentInvoiceStatus" HeaderText="Prepayment Invoice Status" SortExpression="PrepaymentInvoiceStatus" />
        <asp:BoundField DataField="ConvergeTrackCampaignStatus" HeaderText="ConvergeTrack Campaign Status" SortExpression="ConvergeTrackCampaignStatus" />
        <asp:BoundField DataField="LeadPostCampaignCreation" HeaderText="LeadPost Campaign Creation" SortExpression="LeadPostCampaignCreation" />
        <asp:BoundField DataField="AssetsDeliveredStatus" HeaderText="Assets Delivered Status" SortExpression="AssetsDeliveredStatus" />
        <asp:BoundField DataField="TestLeads" HeaderText="TestLeads" SortExpression="Test Leads" />
       </Fields>
      </asp:DetailsView>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AffiliateInformationConnectionString %>"
       SelectCommand="sp_Sample_Return_Affil_Status" SelectCommandType="StoredProcedure" UpdateCommand="sp_Sample_Insert_Affil_Status"
       UpdateCommandType="StoredProcedure">
       <SelectParameters>
        <asp:QueryStringParameter Name="ID" QueryStringField="AID" Type="Int32" />
       </SelectParameters>
       <UpdateParameters>
        <asp:Parameter Name="ContractStatus" Type="String" />
        <asp:Parameter Name="PrepaymentInvoiceStatus" Type="String" />
        <asp:Parameter Name="ConvergeTrackCampaignStatus" Type="String" />
        <asp:Parameter Name="LeadPostCampaignCreation" Type="String" />
        <asp:Parameter Name="AssetsDeliveredStatus" Type="String" />
        <asp:Parameter Name="TestLeads" Type="String" />
        <asp:Parameter Name="Type" Type="String" DefaultValue="Update" />
        <asp:Parameter Name="AID" Type="Int32" />
       </UpdateParameters>
      </asp:SqlDataSource>
     </div>
     <h1>Manage Market Information</h1>
     <asp:GridView ID="MarketGrid" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource9" DataKeyNames="ID,MID,ABID"
      CssClass="grid sortable">
      <Columns>
       <asp:BoundField DataField="ID" HeaderText="Market ID" ReadOnly="false" SortExpression="ID" Visible="true" />
       <asp:BoundField DataField="MID" HeaderText="Region ID" ReadOnly="false" SortExpression="ID" Visible="false" />
       <asp:BoundField DataField="MarketName" HeaderText="Market Name" SortExpression="MarketName" />
       <asp:BoundField DataField="ABID" HeaderText="Budget ID" ReadOnly="false" SortExpression="ABID" Visible="false" />
       <asp:BoundField DataField="MonthlyBudget" HeaderText="Budget" SortExpression="MonthlyBudget" />
       <asp:BoundField DataField="IncludedZipStatus" HeaderText="IncludedZipStatus" SortExpression="IncludedZipStatus"
        Visible="false" />
       <asp:BoundField DataField="ExcludedZipStatus" HeaderText="ExcludedZipStatus" SortExpression="ExcludedZipStatus"
        Visible="false" />
       <asp:TemplateField HeaderText="Status" ItemStyle-CssClass="status">
        <EditItemTemplate>
         <asp:DropDownList runat="server" ID="ddlRunningStatus" SelectedValue='<%# Bind("RunningStatus") %>'>
          <asp:ListItem Text="On" Value="On"></asp:ListItem>
          <asp:ListItem Text="Off" Value="Off"></asp:ListItem>
          <asp:ListItem Text="Moderate" Value="Moderate"></asp:ListItem>
         </asp:DropDownList>
        </EditItemTemplate>
        <ItemTemplate>
         <asp:Label runat="server" ID="lblRunningStatus" Text='<%# Eval("RunningStatus") %>' CssClass="lbl"></asp:Label>
        </ItemTemplate>
       </asp:TemplateField>
       <asp:CommandField ShowEditButton="True" />
       <asp:CommandField ShowDeleteButton="true" />
      </Columns>
     </asp:GridView>
     <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:AffiliateInformationConnectionString %>"
      SelectCommand="sp_Sample_Return_Affil_MI" SelectCommandType="StoredProcedure" UpdateCommand="sp_Sample_Insert_Affil_MI"
      UpdateCommandType="StoredProcedure" DeleteCommand="sp_Sample_Insert_Affil_MI" DeleteCommandType="StoredProcedure">
      <SelectParameters>
       <asp:QueryStringParameter Name="ID" QueryStringField="AID" Type="Int32" />
      </SelectParameters>
      <UpdateParameters>
       <asp:Parameter Name="ID" Type="Int32" />
       <asp:Parameter Name="MID" Type="Int32" />
       <asp:Parameter Name="MarketName" Type="String" />
       <asp:Parameter Name="MonthlyBudget" Type="String" />
       <asp:Parameter Name="ABID" Type="Int32" />
       <asp:Parameter Name="IncludedZipStatus" Type="String" />
       <asp:Parameter Name="ExcludedZipStatus" Type="String" />
       <asp:Parameter Name="RunningStatus" Type="String" />
       <asp:Parameter Name="Type" Type="String" DefaultValue="UPDATE" />
       <asp:Parameter Name="IsActive" Type="String" DefaultValue="True" />
       <asp:QueryStringParameter Name="AID" QueryStringField="AID" Type="Int32" />
      </UpdateParameters>
      <DeleteParameters>
       <asp:Parameter Name="ID" Type="Int32" />
       <asp:Parameter Name="MID" Type="Int32" />
       <asp:Parameter Name="MarketName" Type="String" />
       <asp:Parameter Name="MonthlyBudget" Type="String" />
       <asp:Parameter Name="ABID" Type="Int32" />
       <asp:Parameter Name="IncludedZipStatus" Type="String" />
       <asp:Parameter Name="ExcludedZipStatus" Type="String" />
       <asp:Parameter Name="RunningStatus" Type="String" />
       <asp:Parameter Name="Type" Type="String" DefaultValue="DELETE" />
       <asp:Parameter Name="IsActive" Type="String" DefaultValue="False" />
       <asp:QueryStringParameter Name="AID" QueryStringField="AID" Type="Int32" />
      </DeleteParameters>
     </asp:SqlDataSource>
     <button class="btn add" data-name="Market" type="button">
      Add Market</button>
    </div>
    <hr />
   </asp:Panel>
   <asp:Panel ID="PanelNotes" runat="server" CssClass="pnlForm" DefaultButton="btnSubmitNote">
    <div class="noteSummary">
     <h1>Notes</h1>
     <!--<label>
      Filter By:
     </label>
     <asp:DropDownList runat="server" ID="ddlNoteCategoryFilter" ClientIDMode="Static" class="filter">
     </asp:DropDownList>-->
     <asp:DataList runat="server" ID="NotesList" ClientIDMode="Static" DataSourceID="SqlDataSource11" CssClass="datalist"
      RepeatLayout="Flow" ItemStyle-CssClass="noteItem" OnEditCommand="NotesList_EditCommand" OnCancelCommand="NotesList_CancelCommand"
      OnDeleteCommand="NotesList_DeleteCommand" DataKeyField="ID" OnUpdateCommand="NotesList_UpdateCommand">
      <ItemStyle CssClass="noteItem" />
      <ItemTemplate>
       <!--<p>
        Category:
        <asp:Label ID="NoteCategoryLabel" runat="server" Text='<%# Eval("NoteCategory") %>'></asp:Label>
       </p>-->
       <p>
        Date:
        <asp:Label ID="NoteDateLabel" runat="server" Text='<%# Eval("NoteDate", "{0:MM/dd/yyyy}") %>'></asp:Label>
       </p>
       <p>
        Summary:
        <asp:Label ID="NoteSummaryLabel" runat="server" Text='<%# Eval("NoteSummary") %>'></asp:Label>
       </p>
       <!--
       <p>
        Created On:
        <asp:Label ID="CreatedDateLabel" runat="server" Text='<%# Eval("CreatedDate") %>'></asp:Label>
       </p>-->
       <asp:LinkButton ID="EditButton" Text="Edit" CommandName="Edit" runat="server" />
      </ItemTemplate>
      <EditItemTemplate>
       <p>
        <label>
         Category:
        </label>
        <br />
        <asp:TextBox runat="server" ID="txtNoteCategory" Text='<%# Bind("NoteCategory") %>' TextMode="SingleLine"
         ClientIDMode="Static"></asp:TextBox>
       </p>
       <p>
        <label style="display: block;">
         Summary:
        </label>
        <asp:TextBox runat="server" ID="txtNoteSummary" Text='<%# Bind("NoteSummary") %>' TextMode="MultiLine" ClientIDMode="Static"
         Columns="50" Rows="5"></asp:TextBox>
       </p>
       <p>
        <label>
         Date:</label><br />
        <asp:TextBox runat="server" ID="txtNoteDate" Text='<%# Bind("NoteDate", "{0:MM/dd/yyyy}") %>' TextMode="SingleLine"
         CssClass="date" ClientIDMode="Static"></asp:TextBox>
       </p>
       <p>
        <asp:LinkButton ID="UpdateButton" Text="Update" CommandName="Update" runat="server" />
        <asp:LinkButton ID="DeleteButton" Text="Delete" CommandName="Delete" runat="server" />
        <asp:LinkButton ID="CancelButton" Text="Cancel" CommandName="Cancel" runat="server" />
       </p>
      </EditItemTemplate>
     </asp:DataList>
     <asp:SqlDataSource ID="SqlDataSource11" runat="server" ConnectionString="<%$ ConnectionStrings:AffiliateInformationConnectionString %>"
      SelectCommand="sp_Sample_Return_Affil_Notes" SelectCommandType="StoredProcedure">
      <SelectParameters>
       <asp:Parameter Type="String" Name="Type" DefaultValue="SELECT" />
       <asp:QueryStringParameter Name="ID" QueryStringField="AID" Type="Int32" />
      </SelectParameters>
     </asp:SqlDataSource>
    </div>
    <br />
    <button type="button" id="btnAddNote" class="btn add" data-name="Note">
     Add Note</button>
    <hr />
   </asp:Panel>
   <!-- To be added Later -->
   <!--
  <h2>Zip Codes in Market</h2>
  <h2>Excluded Zip Codes</h2>-->
   <!----------------------->
   <asp:Panel ID="pnlCallCenter" runat="server" CssClass="pnlForm" DefaultButton="" ClientIDMode="Static">
    <div>
     <h2>Manage Call Center</h2>
     <asp:GridView ID="CallCenterGrid" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource10"
      CssClass="grid sortable" DataKeyNames="ID,ACCID,ACCPID" ClientIDMode="Static">
      <Columns>
       <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="false" />
       <asp:BoundField DataField="ACCID" HeaderText="ACCID" InsertVisible="False" ReadOnly="True" SortExpression="ACCID"
        Visible="false" />
       <asp:BoundField DataField="CallCenterName" HeaderText="Call Center Name" SortExpression="CallCenterName" ControlStyle-CssClass="CC" />
       <asp:TemplateField HeaderText="Hours">
        <ItemTemplate>
         <asp:TextBox runat="server" Text='<%# Eval("CallCenterHours") %>' TextMode="MultiLine" CssClass="multiline"
          ReadOnly="true" Height="80" Width="300" ID="lblCallCenterHours" BorderStyle="None"></asp:TextBox>
        </ItemTemplate>
       </asp:TemplateField>
       <asp:BoundField DataField="ACCPID" HeaderText="ACCPID" InsertVisible="False" ReadOnly="True" SortExpression="ACCPID"
        Visible="false" />
       <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" ControlStyle-CssClass="phone txt" />
       <asp:TemplateField HeaderText="Status" ItemStyle-CssClass="status">
        <EditItemTemplate>
         <asp:DropDownList runat="server" ID="ddlCCStatus" SelectedValue='<%# Bind("Status") %>'>
          <asp:ListItem Text="On" Value="On"></asp:ListItem>
          <asp:ListItem Text="Off" Value="Off"></asp:ListItem>
          <asp:ListItem Text="Moderate" Value="Moderate"></asp:ListItem>
         </asp:DropDownList>
        </EditItemTemplate>
        <ItemTemplate>
         <asp:Label runat="server" ID="lblCCStatus" Text='<%# Eval("Status") %>' CssClass="lbl"></asp:Label>
        </ItemTemplate>
       </asp:TemplateField>
       <asp:BoundField DataField="RID" HeaderText="Market ID" ReadOnly="false" ControlStyle-CssClass="CM" />
       <asp:BoundField DataField="MarketName" HeaderText="Market Name" SortExpression="MarketName" ReadOnly="true" />
       <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" ControlStyle-CssClass="ccedit" />
      </Columns>
     </asp:GridView>
     <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="<%$ ConnectionStrings:AffiliateInformationConnectionString %>"
      SelectCommand="sp_Sample_Return_Affil_MICC" SelectCommandType="StoredProcedure" UpdateCommand="sp_Sample_Insert_Affil_MCC"
      UpdateCommandType="StoredProcedure" DeleteCommand="sp_Sample_Insert_Affil_MCC" DeleteCommandType="StoredProcedure">
      <SelectParameters>
       <asp:QueryStringParameter Name="ID" QueryStringField="AID" Type="Int32" />
      </SelectParameters>
      <UpdateParameters>
       <asp:Parameter Name="ID" Type="Int32" />
       <asp:Parameter Name="ACCID" Type="Int32" />
       <asp:Parameter Name="CallCenterName" Type="String" />
       <asp:Parameter Name="ACCPID" Type="Int32" />
       <asp:Parameter Name="PhoneNumber" Type="String" />
       <asp:Parameter Name="RID" Type="Int32" />
       <asp:Parameter Name="MarketName" Type="String" />
       <asp:Parameter Name="Active" Type="Boolean" DefaultValue="True" />
       <asp:Parameter Name="Type" Type="String" DefaultValue="UPDATE" />
       <asp:Parameter Name="Status" Type="String" />
       <asp:Parameter Direction="InputOutput" Name="CCID" Type="Int32" />
      </UpdateParameters>
      <DeleteParameters>
       <asp:Parameter Name="ID" Type="Int32" />
       <asp:Parameter Name="ACCID" Type="Int32" />
       <asp:Parameter Name="CallCenterName" Type="String" />
       <asp:Parameter Name="ACCHID" Type="Int32" />
       <asp:Parameter Name="ACCPID" Type="Int32" />
       <asp:Parameter Name="PhoneNumber" Type="String" />
       <asp:Parameter Name="RID" Type="Int32" />
       <asp:Parameter Name="MarketName" Type="String" />
       <asp:Parameter Name="Status" Type="String" />
       <asp:Parameter Name="Active" Type="Boolean" DefaultValue="False" />
       <asp:Parameter Name="Type" Type="String" DefaultValue="DELETE" />
       <asp:Parameter Direction="InputOutput" Name="CCID" Type="Int32" />
      </DeleteParameters>
     </asp:SqlDataSource>
     <button class="btn add" data-name="MarketCC" type="button">
      Add Call Center</button>
    </div>
    <hr />
   </asp:Panel>
   <asp:Panel ID="pnlEmailAddressDel" runat="server" CssClass="pnlForm" DefaultButton="" ClientIDMode="Static">
    <div>
     <h2>Manage Email Addresses for Delivery</h2>
     <asp:GridView ID="EmailDeliveryGrid" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource12"
      CssClass="grid sortable" DataKeyNames="ID" ClientIDMode="Static">
      <Columns>
       <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="false" />
       <asp:TemplateField HeaderText="Email Addresses">
        <ItemTemplate>
         <asp:TextBox runat="server" Text='<%# Eval("EmailAddress") %>' ID="lblEmailAddresses" TextMode="MultiLine"
          Height="80" Width="200" CssClass="multiline" ReadOnly="true"></asp:TextBox>
        </ItemTemplate>
        <EditItemTemplate>
         <asp:TextBox runat="server" Text='<%# Bind("EmailAddress") %>' ID="txtEmailAddresses" TextMode="MultiLine"
          Height="90" Width="200" CssClass="multiline"></asp:TextBox>
        </EditItemTemplate>
       </asp:TemplateField>
       <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
      </Columns>
     </asp:GridView>
     <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:AffiliateInformationConnectionString %>"
      SelectCommand="sp_Sample_Return_Affil_EALD" SelectCommandType="StoredProcedure" UpdateCommand="sp_Sample_Insert_Affil_EALD"
      UpdateCommandType="StoredProcedure" DeleteCommand="sp_Sample_Insert_Affil_EALD" DeleteCommandType="StoredProcedure">
      <SelectParameters>
       <asp:QueryStringParameter Name="ID" QueryStringField="AID" Type="Int32" />
      </SelectParameters>
      <UpdateParameters>
       <asp:Parameter Name="EmailAddress" Type="String" />
       <asp:Parameter Name="Type" Type="String" DefaultValue="UPDATE" />
       <asp:Parameter Name="ID" Type="Int32" />
       <asp:Parameter Name="IsActive" Type="Boolean" DefaultValue="True" />
      </UpdateParameters>
      <DeleteParameters>
       <asp:Parameter Name="EmailAddress" Type="String" />
       <asp:Parameter Name="Type" Type="String" DefaultValue="DELETE" />
       <asp:Parameter Name="ID" Type="Int32" />
       <asp:Parameter Name="IsActive" Type="Boolean" DefaultValue="False" />
      </DeleteParameters>
     </asp:SqlDataSource>
     <button class="btn add" data-name="MarketEALD" type="button">
      Add Market Email Address for Delivery</button>
    </div>
    <hr />
   </asp:Panel>
   <!-- Contact Information -->
   <asp:Panel ID="pnlContactInfo" runat="server" CssClass="pnlForm" DefaultButton="" ClientIDMode="Static">
    <details open="open">
     <summary>Manage Contact Information</summary>
     <div>
      <asp:GridView ID="ContactGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource3"
       CssClass="grid sortable">
       <Columns>
        <asp:BoundField ReadOnly="false" DataField="ID" HeaderText="ID" InsertVisible="False" Visible="false" />
        <asp:BoundField ReadOnly="false" DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
        <asp:BoundField ReadOnly="false" DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
        <asp:BoundField ReadOnly="false" DataField="Address" HeaderText="Address" SortExpression="Address" />
        <asp:BoundField ReadOnly="false" DataField="City" HeaderText="City" SortExpression="City" />
        <asp:BoundField ReadOnly="false" DataField="State" HeaderText="State" SortExpression="State" />
        <asp:BoundField DataField="ZipCode" HeaderText="Zip Code" SortExpression="ZipCode" />
        <asp:CommandField ShowEditButton="True" />
       </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:AffiliateInformationConnectionString %>"
       SelectCommand="sp_Sample_Return_Affil_CI" SelectCommandType="StoredProcedure" UpdateCommand="sp_Sample_Insert_Affil_CI"
       UpdateCommandType="StoredProcedure">
       <SelectParameters>
        <asp:QueryStringParameter DefaultValue="" Name="ID" QueryStringField="AID" Type="Int32" />
       </SelectParameters>
       <UpdateParameters>
        <asp:Parameter Name="ID" Type="Int32" />
        <asp:Parameter Name="FirstName" Type="String" />
        <asp:Parameter Name="LastName" Type="String" />
        <asp:Parameter Name="Address" Type="String" />
        <asp:Parameter Name="City" Type="String" />
        <asp:Parameter Name="State" Type="String" />
        <asp:Parameter Name="Active" Type="Boolean" DefaultValue="True" />
        <asp:Parameter Name="CID" Type="Int32" Direction="Output" />
        <asp:Parameter Name="Type" Type="String" DefaultValue="UPDATE" />
       </UpdateParameters>
      </asp:SqlDataSource>
      <button class="btn add" data-name="Contact" type="button">
       Add Contact</button>
     </div>
     <!-- Contact Email -->
     <div class="left">
      <h2>Manage Contact Email Addresses</h2>
      <asp:GridView ID="ContactEmailGrid" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4"
       CssClass="grid sortable" DataKeyNames="ID" EditRowStyle-CssClass="edit">
       <Columns>
        <asp:BoundField ReadOnly="false" DataField="ID" HeaderText="ID" InsertVisible="False" Visible="false" />
        <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" SortExpression="EmailAddress" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
       </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:AffiliateInformationConnectionString %>"
       SelectCommand="sp_Sample_Return_Affil_CIE" SelectCommandType="StoredProcedure" UpdateCommand="sp_Sample_Insert_Affil_CIE"
       DeleteCommand="sp_Sample_Insert_Affil_CIE" DeleteCommandType="StoredProcedure" UpdateCommandType="StoredProcedure">
       <SelectParameters>
        <asp:QueryStringParameter DefaultValue="" Name="ID" QueryStringField="AID" Type="Int32" />
       </SelectParameters>
       <UpdateParameters>
        <asp:Parameter Name="ID" Type="Int32" />
        <asp:Parameter Name="EmailAddress" Type="String" />
        <asp:Parameter Name="Type" Type="String" DefaultValue="UPDATE" />
        <asp:Parameter Name="Active" Type="Boolean" DefaultValue="True" />
       </UpdateParameters>
       <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32" />
        <asp:Parameter Name="EmailAddress" Type="String" />
        <asp:Parameter Name="Type" Type="String" DefaultValue="DELETE" />
        <asp:Parameter Name="Active" Type="Boolean" DefaultValue="False" />
       </DeleteParameters>
      </asp:SqlDataSource>
      <button class="btn add" data-name="ContactEmail" type="button">
       Add Contact Email</button>
     </div>
     <div class="left">
      <h2>Manage Contact Phone Numbers</h2>
      <asp:GridView ID="ContactPhoneGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource5"
       CssClass="grid sortable" EditRowStyle-CssClass="edit">
       <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" SortExpression="ID" Visible="false" />
        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" ControlStyle-CssClass="phone" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
       </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:AffiliateInformationConnectionString %>"
       SelectCommand="sp_Sample_Return_Affil_CIP" SelectCommandType="StoredProcedure" UpdateCommand="sp_Sample_Insert_Affil_CIP"
       UpdateCommandType="StoredProcedure" DeleteCommand="sp_Sample_Insert_Affil_CIP" DeleteCommandType="StoredProcedure">
       <SelectParameters>
        <asp:QueryStringParameter Name="ID" QueryStringField="AID" Type="Int32" />
       </SelectParameters>
       <UpdateParameters>
        <asp:Parameter Name="ID" Type="Int32" />
        <asp:Parameter Name="PhoneNumber" Type="String" />
        <asp:Parameter Name="Type" Type="String" DefaultValue="UPDATE" />
        <asp:Parameter Name="Active" Type="Boolean" DefaultValue="True" />
       </UpdateParameters>
       <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32" />
        <asp:Parameter Name="PhoneNumber" Type="String" />
        <asp:Parameter Name="Type" Type="String" DefaultValue="DELETE" />
        <asp:Parameter Name="Active" Type="Boolean" DefaultValue="False" />
       </DeleteParameters>
      </asp:SqlDataSource>
      <button class="btn add" data-name="ContactPhone" type="button">
       Add Contact Phone</button>
     </div>
    </details>
    <hr />
   </asp:Panel>
   <asp:Panel ID="pnlBillingInfo" runat="server" CssClass="pnlForm" DefaultButton="" ClientIDMode="Static">
    <details open="open">
     <summary>Manage Billing Information</summary>
     <div>
      <asp:GridView ID="BillingGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource6"
       CssClass="grid sortable">
       <Columns>
        <asp:BoundField ReadOnly="false" DataField="ID" HeaderText="ID" InsertVisible="False" Visible="false" SortExpression="ID" />
        <asp:BoundField ReadOnly="false" DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
        <asp:BoundField ReadOnly="false" DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
        <asp:BoundField ReadOnly="false" DataField="Address" HeaderText="Address" SortExpression="Address" />
        <asp:BoundField ReadOnly="false" DataField="City" HeaderText="City" SortExpression="City" />
        <asp:BoundField ReadOnly="false" DataField="State" HeaderText="State" SortExpression="State" />
        <asp:BoundField DataField="ZipCode" HeaderText="ZipCode" SortExpression="ZipCode" />
        <asp:CommandField ShowEditButton="True" />
       </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:AffiliateInformationConnectionString %>"
       SelectCommand="sp_Sample_Return_Affil_BI" SelectCommandType="StoredProcedure" UpdateCommand="sp_Sample_Insert_Affil_BI"
       UpdateCommandType="StoredProcedure">
       <SelectParameters>
        <asp:QueryStringParameter Name="ID" QueryStringField="AID" Type="Int32" />
       </SelectParameters>
       <UpdateParameters>
        <asp:Parameter Name="ID" Type="Int32" />
        <asp:Parameter Name="FirstName" Type="String" />
        <asp:Parameter Name="LastName" Type="String" />
        <asp:Parameter Name="Address" Type="String" />
        <asp:Parameter Name="City" Type="String" />
        <asp:Parameter Name="State" Type="String" />
        <asp:Parameter Name="ZipCode" Type="String" />
        <asp:Parameter Name="AID" Type="Int32" />
        <asp:Parameter Name="Type" Type="String" DefaultValue="UPDATE" />
        <asp:Parameter Name="Active" Type="Boolean" DefaultValue="True" />
        <asp:Parameter Direction="InputOutput" Name="BID" Type="Int32" />
       </UpdateParameters>
      </asp:SqlDataSource>
      <button class="btn add" data-name="Billing" type="button">
       Add Billing
      </button>
     </div>
     <div class="left">
      <h2>Manage Billing Email Addresses</h2>
      <asp:GridView ID="BillingEmailGrid" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource7"
       CssClass="grid sortable" DataKeyNames="ID" EditRowStyle-CssClass="edit">
       <Columns>
        <asp:BoundField ReadOnly="True" DataField="ID" HeaderText="ID" InsertVisible="False" Visible="false" SortExpression="ID" />
        <asp:BoundField ReadOnly="false" DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
       </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:AffiliateInformationConnectionString %>"
       SelectCommand="sp_Sample_Return_Affil_BIE" SelectCommandType="StoredProcedure" UpdateCommand="sp_Sample_Insert_Affil_BIE"
       UpdateCommandType="StoredProcedure" DeleteCommand="sp_Sample_Insert_Affil_BIE" DeleteCommandType="StoredProcedure">
       <SelectParameters>
        <asp:QueryStringParameter Name="ID" QueryStringField="AID" Type="Int32" />
       </SelectParameters>
       <UpdateParameters>
        <asp:Parameter Name="ID" Type="Int32" />
        <asp:Parameter Name="EmailAddress" Type="String" />
        <asp:Parameter Name="Type" Type="String" DefaultValue="UPDATE" />
        <asp:Parameter Name="Active" Type="Boolean" DefaultValue="True" />
       </UpdateParameters>
       <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32" />
        <asp:Parameter Name="Type" Type="String" DefaultValue="DELETE" />
        <asp:Parameter Name="Active" Type="Boolean" DefaultValue="False" />
        <asp:Parameter Name="EmailAddress" Type="String" />
        <asp:Parameter Name="BID" Type="Int32" />
       </DeleteParameters>
      </asp:SqlDataSource>
      <button class="btn add" data-name="BillingEmail" type="button">
       Add Billing Email</button>
     </div>
     <div class="left">
      <h2>Manage Billing Phone Numbers</h2>
      <asp:GridView ID="BillingPhoneGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource8"
       CssClass="grid sortable" EditRowStyle-CssClass="edit">
       <Columns>
        <asp:BoundField ReadOnly="True" DataField="ID" HeaderText="ID" InsertVisible="False" Visible="false" SortExpression="ID" />
        <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" ControlStyle-CssClass="phone" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
       </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:AffiliateInformationConnectionString %>"
       SelectCommand="sp_Sample_Return_Affil_BIP" SelectCommandType="StoredProcedure" UpdateCommand="sp_Sample_Insert_Affil_BIP"
       UpdateCommandType="StoredProcedure" DeleteCommand="sp_Sample_Insert_Affil_BIP" DeleteCommandType="StoredProcedure">
       <SelectParameters>
        <asp:QueryStringParameter Name="ID" QueryStringField="AID" Type="Int32" />
       </SelectParameters>
       <UpdateParameters>
        <asp:Parameter Name="ID" Type="Int32" />
        <asp:Parameter Name="Type" Type="String" DefaultValue="UPDATE" />
        <asp:Parameter Name="Active" Type="Boolean" DefaultValue="True" />
        <asp:Parameter Name="PhoneNumber" Type="String" />
        <asp:Parameter Name="BID" Type="Int32" />
       </UpdateParameters>
       <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32" />
        <asp:Parameter Name="Type" Type="String" DefaultValue="DELETE" />
        <asp:Parameter Name="Active" Type="Boolean" DefaultValue="False" />
        <asp:Parameter Name="PhoneNumber" Type="String" />
        <asp:Parameter Name="BID" Type="Int32" />
       </DeleteParameters>
      </asp:SqlDataSource>
      <button class="btn add" data-name="BillingPhone" type="button">
       Add Billing Phone</button>
     </div>
    </details>
    <hr />
   </asp:Panel>
   <!-- Add Panels -->
   <asp:Panel runat="server" CssClass="pnlAdd">
    <div id="pnlAddContact" class="hdnfrm">
     <h2>Add Contact Information</h2>
     <div class="field">
      <asp:TextBox ID="txtCFirstName" Text="First Name" runat="server" CssClass="txt" ToolTip="First Name" ValidationGroup="CI"></asp:TextBox>
     </div>
     <div class="field">
      <asp:TextBox ID="txtCLastName" Text="Last Name" runat="server" CssClass="txt" ToolTip="Last Name" ValidationGroup="CI"></asp:TextBox>
     </div>
     <div class="field">
      <asp:TextBox ID="txtCAddress1" Text="Address" runat="server" CssClass="txt" ToolTip="Address" ValidationGroup="CI"></asp:TextBox>
     </div>
     <div class="field">
      <asp:TextBox ID="txtCCity" Text="City" runat="server" CssClass="txt" ToolTip="City" ValidationGroup="CI"></asp:TextBox>
     </div>
     <div class="field">
      <asp:DropDownList ID="ddlCState" runat="server" CssClass="ddl" ValidationGroup="CI">
       <asp:ListItem Value="0" Text="Select State"></asp:ListItem>
      </asp:DropDownList>
     </div>
     <div class="field">
      <asp:TextBox ID="txtCZip" runat="server" CssClass="txt" Text="Zip" MaxLength="5" ToolTip="Zip" ValidationGroup="CI"></asp:TextBox>
     </div>
     <asp:Button CommandName="AddContact" runat="server" ID="btnSubmitContact" OnCommand="btnSubmit_Click" CssClass="btn"
      ValidationGroup="CI" CausesValidation="true" ClientIDMode="Static" Text="Submit" />
     <button type="button" id="btnCancelContact" class="btn cancel" data-name="Contact">
      Cancel</button>
    </div>
    <div id="pnlAddContactEmail" class="hdnfrm">
     <h2>Add Contact Email Address</h2>
     <div class="field">
      <asp:TextBox ID="txtCEmail" runat="server" Text="Email" ToolTip="Email" CssClass="txt" ValidationGroup="CIE"></asp:TextBox>
     </div>
     <div class="field">
      <asp:DropDownList ID="ddlCEmail" runat="server" ToolTip="Select Contact" CssClass="ddl" ValidationGroup="CIE">
       <asp:ListItem Text="Select Contact"></asp:ListItem>
      </asp:DropDownList>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select a contact."
       ValidationGroup="CIE" ControlToValidate="ddlCEmail" InitialValue="0" CssClass="err"></asp:RequiredFieldValidator>
     </div>
     <asp:Button CommandName="AddContactEmail" runat="server" ID="btnAddContactEmail" OnCommand="btnSubmit_Click"
      ValidationGroup="CIE" CausesValidation="true" ClientIDMode="Static" CssClass="btn" Text="Submit" />
     <button type="button" id="btnCancelContactEmail" class="btn cancel" data-name="ContactEmail">
      Cancel</button>
    </div>
    <div id="pnlAddContactPhone" class="hdnfrm">
     <h2>Add Contact Phone Address</h2>
     <div class="field">
      <asp:TextBox ID="txtCPhone" runat="server" CssClass="txt phone" Text="Phone" MaxLength="18" ToolTip="Phone"
       ValidationGroup="CIP"></asp:TextBox>
     </div>
     <div class="field">
      <asp:DropDownList ID="ddlCPhone" runat="server" ToolTip="Select Contact" CssClass="ddl" ValidationGroup="CIP">
       <asp:ListItem Text="Select Contact" Value="0"></asp:ListItem>
      </asp:DropDownList>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select a contact."
       ValidationGroup="CIP" ControlToValidate="ddlCPhone" InitialValue="0" CssClass="err"></asp:RequiredFieldValidator>
     </div>
     <asp:Button CommandName="AddContactPhone" runat="server" ID="btnAddContactPhone" OnCommand="btnSubmit_Click"
      ValidationGroup="CIP" CausesValidation="true" ClientIDMode="Static" CssClass="btn" Text="Submit" />
     <button type="button" id="btnCancelContactPhone" class="btn cancel" data-name="ContactPhone">
      Cancel</button>
    </div>
    <div id="pnlAddBilling" class="hdnfrm">
     Select Contact to Duplicate for Billing
     <asp:DropDownList runat="server" ID="ddlBillingContact" AutoPostBack="false" CausesValidation="false" CssClass="BC">
      <asp:ListItem Text="Select Contact" Value="0"></asp:ListItem>
     </asp:DropDownList>
     <h2>Add Billing Information</h2>
     <div class="field">
      <asp:TextBox ID="txtBFirstName" Text="First Name" runat="server" CssClass="txt" ToolTip="First Name" ClientIDMode="Static"
       ValidationGroup="BI"></asp:TextBox>
     </div>
     <div class="field">
      <asp:TextBox ID="txtBLastName" Text="Last Name" runat="server" CssClass="txt" ToolTip="Last Name" ClientIDMode="Static"
       ValidationGroup="BI"></asp:TextBox>
     </div>
     <div class="field">
      <asp:TextBox ID="txtBAddress1" Text="Address" runat="server" CssClass="txt" ToolTip="Address" ClientIDMode="Static"
       ValidationGroup="BI"></asp:TextBox>
     </div>
     <div class="field">
      <asp:TextBox ID="txtBCity" Text="City" runat="server" CssClass="txt" ToolTip="City" ClientIDMode="Static"
       ValidationGroup="BI"></asp:TextBox>
     </div>
     <div class="field">
      <asp:DropDownList ID="ddlBState" runat="server" CssClass="ddl" ClientIDMode="Static" ValidationGroup="BI">
      </asp:DropDownList>
     </div>
     <div class="field">
      <asp:TextBox ID="txtBZip" runat="server" CssClass="txt" Text="Zip" MaxLength="5" ToolTip="Zip" ClientIDMode="Static"
       ValidationGroup="BI"></asp:TextBox>
     </div>
     <asp:Button CommandName="AddBilling" runat="server" ID="btnSubmitBilling" OnCommand="btnSubmit_Click" CssClass="btn"
      ValidationGroup="BI" CausesValidation="true" ClientIDMode="Static" Text="Submit" />
     <button type="button" id="btnCancelBilling" class="btn cancel" data-name="Billing">
      Cancel</button>
    </div>
    <div id="pnlAddBillingEmail" class="hdnfrm">
     <h2>Add Billing Email Address</h2>
     <div class="field">
      <asp:TextBox ID="txtBEmail" runat="server" Text="Email" ToolTip="Email" CssClass="txt" ValidationGroup="BIE"></asp:TextBox>
     </div>
     <div class="field">
      <asp:DropDownList ID="ddlBEmail" runat="server" ToolTip="Select Contact" CssClass="ddl" ValidationGroup="BIE">
      </asp:DropDownList>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select a contact."
       ValidationGroup="BIE" ControlToValidate="ddlBEmail" InitialValue="0" CssClass="err"></asp:RequiredFieldValidator>
     </div>
     <asp:Button CommandName="AddBillingEmail" runat="server" ID="btnAddBillingEmail" OnCommand="btnSubmit_Click"
      ValidationGroup="BIE" CausesValidation="true" ClientIDMode="Static" CssClass="btn" Text="Submit" />
     <button type="button" id="btnCancelEmail" class="btn cancel" data-name="BillingEmail">
      Cancel</button>
    </div>
    <div id="pnlAddBillingPhone" class="hdnfrm">
     <h2>Add Billing Phone Address</h2>
     <div class="field">
      <asp:TextBox ID="txtBPhone" runat="server" CssClass="txt phone" Text="Phone" MaxLength="18" ToolTip="Phone"
       ValidationGroup="BIP"></asp:TextBox>
     </div>
     <div class="field">
      <asp:DropDownList ID="ddlBPhone" runat="server" ToolTip="Select Contact" CssClass="ddl" ValidationGroup="BIP">
      </asp:DropDownList>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please select a contact."
       ValidationGroup="BIP" ControlToValidate="ddlBPhone" InitialValue="0" CssClass="err"></asp:RequiredFieldValidator>
     </div>
     <asp:Button CommandName="AddBillingPhone" runat="server" ID="btnAddBillingPhone" OnCommand="btnSubmit_Click"
      ValidationGroup="BIP" CausesValidation="true" ClientIDMode="Static" CssClass="btn" Text="Submit" />
     <button type="button" id="btnCancelPhone" class="btn cancel" data-name="BillingPhone">
      Cancel</button>
    </div>
    <div id="pnlAddMarket" class="hdnfrm">
     <h2>Add Market Information</h2>
     <div class="field">
      <asp:TextBox ID="txtMarketName" runat="server" CssClass="txt" Text="Market Name" ToolTip="Market Name" ValidationGroup="MI"></asp:TextBox>
     </div>
     <div class="field">
      <asp:TextBox ID="txtMonthlyBudgets" runat="server" CssClass="txt" Text="Budget" MaxLength="12" ToolTip="Budget"
       ValidationGroup="MI"></asp:TextBox>
     </div>
     <div class="field">
      <asp:DropDownList ID="ddlStatus" runat="server" CssClass="txt" MaxLength="12" ToolTip="Running Status" ValidationGroup="MI">
       <asp:ListItem Text="On" Value="On"></asp:ListItem>
       <asp:ListItem Text="Off" Value="Off"></asp:ListItem>
       <asp:ListItem Text="Moderate" Value="Moderate"></asp:ListItem>
      </asp:DropDownList>
     </div>
     <div class="field">
      <label class="lbl">
       Zip Codes in Market
      </label>
      <asp:TextBox ID="txtMarketZip" runat="server" CssClass="txt disable" AutoCompleteType="Disabled" AutoComplete="off"
       ValidationGroup="MI" MaxLength="5" Enabled="false" Text="To be sent later"></asp:TextBox>
     </div>
     <div class="field">
      <label class="lbl">
       Excluded Zip Codes</label>
      <asp:TextBox ID="txtExcludeZip" runat="server" CssClass="txt disable" Enabled="false" MaxLength="5" Text="To be sent later"
       ValidationGroup="MI"></asp:TextBox>
     </div>
     <asp:Button CommandName="AddMarket" runat="server" ID="btnAddMarket" OnCommand="btnSubmit_Click" CssClass="btn"
      ValidationGroup="MI" CausesValidation="true" ClientIDMode="Static" Text="Submit" />
     <button type="button" id="btnCancelMarket" class="btn cancel" data-name="Market">
      Cancel</button>
    </div>
    <div id="pnlAddMarketCC" class="hdnfrm">
     <h2>Add Call Center Information</h2>
     <div class="field">
      <asp:DropDownList ID="ddlCallCenterName" runat="server" CssClass="ddl" ToolTip="Call Center Name" ValidationGroup="MICC">
      </asp:DropDownList>
     </div>
     <div class="field">
      <asp:TextBox ID="txtCallCenterPhone" runat="server" CssClass="txt phone" Text="Call Center Phone" ToolTip="Call Center Phone"
       ValidationGroup="MICC"></asp:TextBox>
     </div>
     <div class="field">
      <asp:DropDownList ID="ddlCCMarket" runat="server" CssClass="ddl" ToolTip="Call Center Market" ValidationGroup="MICC">
      </asp:DropDownList>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select a market."
       ValidationGroup="MICC" ControlToValidate="ddlCCMarket" InitialValue="0" CssClass="err"></asp:RequiredFieldValidator>
     </div>
     <div class="field">
      <asp:DropDownList ID="ddlCCStatus" runat="server" CssClass="txt" MaxLength="12" ToolTip="Status" ValidationGroup="MICC">
       <asp:ListItem Text="On" Value="On"></asp:ListItem>
       <asp:ListItem Text="Off" Value="Off"></asp:ListItem>
       <asp:ListItem Text="Moderate" Value="Moderate"></asp:ListItem>
      </asp:DropDownList>
     </div>
     <asp:Button CommandName="AddMarketCC" runat="server" ID="btnAddMarketCC" OnCommand="btnSubmit_Click" CssClass="btn"
      ValidationGroup="MICC" CausesValidation="true" ClientIDMode="Static" Text="Submit" />
     <button type="button" id="btnCancelMarketCC" class="btn cancel" data-name="MarketCC">
      Cancel</button>
    </div>
    <div id="pnlAddMarketEALD" class="hdnfrm">
     <h2>Add Email Addresses for Lead Delivery</h2>
     <div class="field">
      <asp:TextBox ID="txtEmailAddresses" runat="server" CssClass="txt multiline" Text="Email Addresses" ToolTip="Email Addresses"
       ValidationGroup="MIEALD" TextMode="MultiLine" Rows="5"></asp:TextBox>
     </div>
     <asp:Button CommandName="AddMarketEALD" runat="server" ID="btnAddMarketEALD" OnCommand="btnSubmit_Click" CssClass="btn"
      ValidationGroup="MIEALD" CausesValidation="true" ClientIDMode="Static" Text="Submit" />
     <button type="button" id="btnCancelMarketEALD" class="btn cancel" data-name="MarketEALD">
      Cancel</button>
    </div>
    <div id="pnlAddNote" class="hdnfrm">
     <h2>Add Note</h2>
     <div class="field">
      <asp:TextBox runat="server" ID="txtNoteCategory" CssClass="txt" ValidationGroup="Note" Text="Category" ToolTip="Category"></asp:TextBox>
     </div>
     <div class="field">
      <asp:TextBox runat="server" ID="txtNote" TextMode="MultiLine" CssClass="txt multiline" ToolTip="Summary" Text="Summary"
       ValidationGroup="Note"></asp:TextBox>
     </div>
     <div class="field">
      <asp:TextBox runat="server" TextMode="SingleLine" CssClass="txt date" MaxLength="10" ToolTip="Date" Text="Date"
       ID="txtNoteDate" ValidationGroup="Note"></asp:TextBox>
     </div>
     <asp:Button runat="server" ID="btnSubmitNote" OnClick="btnSubmitNote_Click" Text="Submit Note" CssClass="btnSubmitNote btn"
      ValidationGroup="Note" />
     <button type="button" id="btnCancelNote" class="btn cancel" data-name="Note">
      Cancel</button>
    </div>
   </asp:Panel>
  </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>
