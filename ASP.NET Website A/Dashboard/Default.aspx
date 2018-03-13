<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleAffilForm.Dashboard.Default"
 MasterPageFile="~/Dashboard/Master.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
 <h1>Sample | Affiliate Dashboard | <a href="MasterMatrix.aspx" title="Master Matrix">Master Program 
   Matix</a> | <a href="ManageVendor.aspx" title="Manage Vender">Manage Vendors</a></h1>
 <asp:Panel runat="server" ID="Panel0" CssClass="dashboard">
  <asp:GridView ID="AffiliateGrid" runat="server" AutoGenerateColumns="False" OnRowCommand="AffiliateGrid_RowCommand"
   CssClass="grid sortable" DataKeyNames="ID" DataSourceID="SqlDataSource1" UseAccessibleHeader="true">
   <Columns>
    <asp:BoundField DataField="ID" ReadOnly="true" HeaderText="ID" InsertVisible="False" SortExpression="ID" />
    <asp:BoundField DataField="GroupName" Visible="true" HeaderText="Group Name" SortExpression="GroupName" />
    <asp:BoundField DataField="RunningStatus" Visible="true" HeaderText="Status" SortExpression="Status" />
    <asp:CommandField ShowSelectButton="True" ShowDeleteButton="true" ControlStyle-CssClass="btn ctrl" />
   </Columns>
  </asp:GridView>
  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AffiliateInformationConnectionString %>"
   SelectCommand="sp_Sample_Return_Affil" SelectCommandType="StoredProcedure" DeleteCommand="sp_Sample_Insert_Affil"
   DeleteCommandType="StoredProcedure">
   <SelectParameters>
    <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="AID" Type="Int32" />
   </SelectParameters>
   <DeleteParameters>
    <asp:Parameter Name="GroupName" Type="String" />
    <asp:Parameter Name="Type" Type="String" DefaultValue="DELETE" />
    <asp:Parameter Name="ID" Type="Int32" />
    <asp:Parameter Name="AID" Type="Int32" Direction="Output" />
   </DeleteParameters>
  </asp:SqlDataSource>
  <button type="button" id="btnInsertAffil" data-name="Affil" class="btn">
   Add New Affiliate</button>
  <div id="pnlAddAffil" class="pnlForm">
   <label class="lbl">
    Enter Affiliate Name:</label><br />
   <asp:TextBox runat="server" ID="txtAffil" CssClass="txt" ClientIDMode="Static"></asp:TextBox><br />
   <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn" Text="Submit" />
   <button type="button" id="btnCancelAffil" class="btn cancel" data-name="Affil">
    Cancel</button>
  </div>

 </asp:Panel>
</asp:Content>
