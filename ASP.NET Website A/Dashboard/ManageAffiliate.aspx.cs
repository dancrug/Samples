using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleAffilForm.Dashboard
{

 /// <summary>
 /// Page load grabs initial data from DB base on AID (Affiliate ID).
 /// </summary>
 public partial class ManageAffiliate : System.Web.UI.Page
 {

  /// <summary>
  /// Uses SampleService.cs to process inserts, edits, and deletes.
  /// </summary>
  SampleService rs = new SampleService();
  protected void Page_Load(object sender, EventArgs e)
  {
   string strAppPath = string.Empty;
   strAppPath = Request.PhysicalApplicationPath;

   if (!Page.IsPostBack)
   {
    int id = 0;
    if (Request.QueryString["AID"] != null)
    {
     id = Convert.ToInt32(Request.QueryString["AID"]);
    }
    if (id != 0)
    {
     rs.populateStates(ddlCState, strAppPath);
     rs.populateStates(ddlBState, strAppPath);
     processDropDowns(id);
    }
    else
    {
     Response.Redirect("/Dashboard");
    }
   }
  }

  /// <summary>
  /// Based on the command name, update the database with the data.
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void btnSubmit_Click(object sender, CommandEventArgs e)
  {
   string commandType = e.CommandName;
   int id = 0;
   if (Request.QueryString["AID"] != null)
   {
    id = Convert.ToInt32(Request.QueryString["AID"]);
   }
   switch (commandType)
   {
    case "AddContact":
     rs.insertContact(txtCFirstName.Text, txtCLastName.Text, txtCAddress1.Text, txtCCity.Text, ddlCState.SelectedValue, txtCZip.Text, id);
     processDropDowns(id);
     ContactGrid.DataBind();
     break;
    case "AddContactEmail":
     rs.insertContactEmail(txtCEmail.Text, Convert.ToInt32(ddlCEmail.SelectedValue), id);
     ContactEmailGrid.DataBind();
     break;
    case "AddContactPhone":
     rs.insertContactPhone(txtCPhone.Text, Convert.ToInt32(ddlCPhone.SelectedValue), id);
     ContactPhoneGrid.DataBind();
     break;
    case "AddBilling":
     rs.insertBilling(txtBFirstName.Text, txtBLastName.Text, txtBAddress1.Text, txtBCity.Text, ddlBState.SelectedValue, txtBZip.Text, id);
     processDropDowns(id);
     BillingGrid.DataBind();
     break;
    case "AddBillingEmail":
     rs.insertBillingEmail(txtBEmail.Text, Convert.ToInt32(ddlBEmail.SelectedValue), id);
     BillingEmailGrid.DataBind();
     break;
    case "AddBillingPhone":
     rs.insertBillingPhone(txtBPhone.Text, Convert.ToInt32(ddlBPhone.SelectedValue), id);
     BillingPhoneGrid.DataBind();
     break;
    case "AddMarket":
     int mid = rs.insertMarket(txtMarketName.Text, txtMonthlyBudgets.Text, ddlStatus.SelectedValue, txtMarketZip.Text, txtExcludeZip.Text, id);
     foreach (ListItem s in ddlCallCenterName.Items)
     {
      rs.insertMarketCC(Convert.ToInt32(s.Value), "000-000-0000", mid, id, "Off");
     }
     processDropDowns(id);
     MarketGrid.DataBind();
     CallCenterGrid.DataBind();
     break;
    case "AddMarketCC":
     rs.insertMarketCC(Convert.ToInt32(ddlCallCenterName.SelectedValue), txtCallCenterPhone.Text, Convert.ToInt32(ddlCCMarket.SelectedValue), id, ddlCCStatus.SelectedValue);
     CallCenterGrid.DataBind();
     break;
    case "AddMarketEALD":
     rs.insertMarketEALD(id, txtEmailAddresses.Text);
     EmailDeliveryGrid.DataBind();
     break;
    default:
     break;
   }
   foreach (Control x in this.Controls)
   {
    if (x is TextBox)
    {
     ((TextBox)x).Text = ((TextBox)x).ToolTip;
    }
   }
  }

  /// <summary>
  /// Insert new note into DB.
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void btnSubmitNote_Click(object sender, EventArgs e)
  {
   int id = 0;
   if (Request.QueryString["AID"] != null)
   {
    id = Convert.ToInt32(Request.QueryString["AID"]);
   }
   rs.insertNotes(txtNote.Text, txtNoteCategory.Text, txtNoteDate.Text, id);
   NotesList.DataBind();
   txtNote.Text = "";
   txtNoteCategory.Text = "";
   txtNoteDate.Text = "";
   processDropDowns(id);
  }

  /// <summary>
  /// Loads drop down values.
  /// </summary>
  /// <param name="id"></param>
  protected void processDropDowns(int id)
  {
   ddlCEmail.DataSource = rs.populateContactDropDown(id);
   ddlCEmail.DataValueField = "CID";
   ddlCEmail.DataTextField = "CFullName";
   ddlCEmail.DataBind();
   ddlCPhone.DataSource = rs.populateContactDropDown(id);
   ddlCPhone.DataValueField = "CID";
   ddlCPhone.DataTextField = "CFullName";
   ddlCPhone.DataBind();
   ddlBillingContact.DataSource = rs.populateContactDropDown(id);
   ddlBillingContact.DataValueField = "CID";
   ddlBillingContact.DataTextField = "CFullName";
   ddlBillingContact.DataBind();
   ddlBEmail.DataSource = rs.populateBillingDropDown(id);
   ddlBEmail.DataValueField = "BID";
   ddlBEmail.DataTextField = "BFullName";
   ddlBEmail.DataBind();
   ddlBPhone.DataSource = rs.populateBillingDropDown(id);
   ddlBPhone.DataValueField = "BID";
   ddlBPhone.DataTextField = "BFullName";
   ddlBPhone.DataBind();
   ddlCCMarket.DataSource = rs.populateMarketDropDown(id);
   ddlCCMarket.DataValueField = "MID";
   ddlCCMarket.DataTextField = "MarketName";
   ddlCCMarket.DataBind();
   ddlCallCenterName.DataSource = rs.populateCallCenterDropDown();
   ddlCallCenterName.DataValueField = "CCID";
   ddlCallCenterName.DataTextField = "CallCenterName";
   ddlCallCenterName.DataBind();
   rdoStatus.SelectedValue = rs.returnRunningStatus(id);
   lblCompanyName.Text = rs.populateAffiliateName(id);
   ddlNoteCategoryFilter.DataSource = rs.populateNoteCategoryFilter(id);
   ddlNoteCategoryFilter.DataValueField = "NoteCategory";
   ddlNoteCategoryFilter.DataTextField = "NoteCategory";
   ddlNoteCategoryFilter.DataBind();
  }

  /// <summary>
  /// Changes the Running Status
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void rdoStatus_SelectedIndexChanged(object sender, EventArgs e)
  {
   int id = 0;
   if (Request.QueryString["AID"] != null)
   {
    id = Convert.ToInt32(Request.QueryString["AID"]);
   }
   rs.updateRunningStatus(rdoStatus.SelectedValue, id);
  }

  /// <summary>
  /// Edit the note
  /// </summary>
  /// <param name="source"></param>
  /// <param name="e"></param>
  protected void NotesList_EditCommand(object source, DataListCommandEventArgs e)
  {
   NotesList.EditItemIndex = e.Item.ItemIndex;
   NotesList.DataBind();
  }

  /// <summary>
  /// Cancel editing for note
  /// </summary>
  /// <param name="source"></param>
  /// <param name="e"></param>
  protected void NotesList_CancelCommand(object source, DataListCommandEventArgs e)
  {
   NotesList.EditItemIndex = -1;
   NotesList.DataBind();
  }

  /// <summary>
  /// Deletes (Soft Delete) the note 
  /// </summary>
  /// <param name="source"></param>
  /// <param name="e"></param>
  protected void NotesList_DeleteCommand(object source, DataListCommandEventArgs e)
  {
   int id = Convert.ToInt32(NotesList.DataKeys[e.Item.ItemIndex]);
   rs.deleteNotes(id);
   NotesList.EditItemIndex = -1;
   NotesList.DataBind();
   if (Request.QueryString["AID"] != null)
   {
    id = Convert.ToInt32(Request.QueryString["AID"]);
   }
   processDropDowns(id);
  }

  /// <summary>
  /// Updates the Note 
  /// </summary>
  /// <param name="source"></param>
  /// <param name="e"></param>
  protected void NotesList_UpdateCommand(object source, DataListCommandEventArgs e)
  {
   string notes = ((TextBox)e.Item.FindControl("txtNoteSummary")).Text;
   string notecategory = ((TextBox)e.Item.FindControl("txtNoteCategory")).Text;
   string notedate = ((TextBox)e.Item.FindControl("txtNoteDate")).Text;
   int id = Convert.ToInt32(NotesList.DataKeys[e.Item.ItemIndex]);
   rs.updateNotes(notes, notecategory, notedate, id);
   NotesList.EditItemIndex = -1;
   NotesList.DataBind();
  }

  /// <summary>
  /// Binds all the grids
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void BindGrids(object sender, EventArgs e)
  {
   CompanyGrid.DataBind();
   DetailsView1.DataBind();
   MarketGrid.DataBind();
   CallCenterGrid.DataBind();
   NotesList.DataBind();
   EmailDeliveryGrid.DataBind();
   ContactGrid.DataBind();
   ContactEmailGrid.DataBind();
   ContactPhoneGrid.DataBind();
   BillingGrid.DataBind();
   BillingEmailGrid.DataBind();
   BillingPhoneGrid.DataBind();
  }
 }
}