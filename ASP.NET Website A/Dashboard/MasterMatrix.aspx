<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Master.Master" AutoEventWireup="true" CodeBehind="MasterMatrix.aspx.cs"
 Inherits="SampleAffilForm.Dashboard.MasterMatrix" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
  table tr td {
   position: relative;
  }

  select {
   border: none;
   outline: none;
   width: 100%;
   padding: 2px;
  }

  .fa {
   color: #000;
   font-size: 1.6em;
  }

  .matrix-note {
   cursor: pointer;
   display: block;
   position: absolute;
   top: 0;
   right: 0;
   padding: 5px;
   z-index: 10;
   width: 20px;
   height: 20px;
   text-align: center;
  }

  textarea {
   font-size: 1.0em;
   font-family: inherit;
  }
 </style>
 <script type="text/javascript">
  $(document).ready(function () {
   $(".amrid").hide();
   $(".amrnote").hide();
   $.each($("tr"), function (k, v) {
    var index = k;
    $.each($(v).children("th"), function (key, obj) {
     $(obj).attr("data-cindex", key);
    });
    $.each($(v).children("td.ccid"), function (key, obj) {
     var val = $(obj).text().trim();
     if (!isNaN(val) && val != "") {
      var status = $(".CC span[data-id=\"" + val + "\"]").text();
      $(obj).html("<select data-id=\"" + val + "\" data-rindex=\"" + index + "\" data-cindex=\"" + (key + 3) + "\" id=\"ddlStatus\" class=\"status\"><option value=\"On\">On</option><option value=\"Off\">Off</option><option value=\"Moderate\">Moderate</option></select>");
      $(obj).find("select").val(status);
      changeClass($(obj).find("select"));
     } else if (val == "") {
      //$(obj).html("<span class=\"lblStatus\" data-id=\"" + val + "\" data-rindex=\"" + index + "\" data-cindex=\"" + (key + 3) + "\">Off</span");
      $(obj).text("N/A");
     }
    });
    $.each($(v).children("td.amrname"), function (key, obj) {
     $(obj).append("<span data-id=\"" + $(obj).parent().find(".amrid").text() + "\" data-note=\"" + $(obj).parent().find(".amrnote").text() + "\" class=\"matrix-note\"><i class=\"fa fa-commenting\" aria-hidden=\"true\"></i></span>");
    });
   });
   $(".status").change(function () {
    $.ajax({
     url: "MasterMatrix.aspx/ddlCCStatus_Changed",
     data: "{ 'id': '" + $(this).attr("data-id") + "', 'status': '" + $(this).val() + "'}",
     dataType: "json",
     type: "POST",
     contentType: "application/json; charset=utf-8",
     success: function (e, r) {
     },
     error: function (e, t, n) {
      console.log(e);
     }
    });
    changeClass($(this));
   });
   var clickCount = 0;
   $(".matrix-note").click(function () {
    switch (clickCount) {
     case 0:
      $(this).parent().append("<div class=\"PanelNote\"><textarea id=\"notearea_" + $(this).attr("data-id") + "\" class=\"txt\">" + $(".amrnote[data-id='" + $(this).attr("data-id") + "']").text() + "</textarea></div>");
      clickCount += 1;
      break;
     case 1:
      clickCount = 0;
      postNote($(this));
      break;
     case 2:
      clickCount = 0;
      break;
     default:
      clickCount = 0;
      break;
    }
   });
   /*   $(".lblStatus").click(function () {
   var cVal = $(this).attr("data-cindex");
   var callCenterName = $("th[data-cindex=\"" + cVal + "\"]").text();
   $("#txtCallCenterName").val(callCenterName);
   });*/
  });
  function changeClass(obj) {
   switch ($(obj).val()) {
    case "On":
     $(obj).removeClass("red");
     $(obj).removeClass("yellow");
     $(obj).addClass("green");
     break;
    case "Off":
     $(obj).removeClass("green");
     $(obj).removeClass("yellow");
     $(obj).addClass("red");
     break;
    case "Moderate":
     $(obj).removeClass("green");
     $(obj).removeClass("red");
     $(obj).addClass("yellow");
    default:
     break;
   }
  }
  function postNote(obj) {
   var id = $(obj).attr("data-id");
   var note = $("#notearea_" + $(obj).attr("data-id") + "").val();
   $.ajax({
    url: "MasterMatrix.aspx/txtNote_Changed",
    data: "{ 'id': '" + id + "', 'note': '" + note + "'}",
    dataType: "json",
    type: "POST",
    contentType: "application/json; charset=utf-8",
    success: function (e, r) {
     $(".amrnote[data-id='" + id + "']").text(note);
     $(".PanelNote").remove();
    },
    error: function (e, t, n) {
     console.log(e);
    }
   });
  }
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
 </asp:ScriptManager>
 <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Dashboard/" Text="< Go Back"></asp:HyperLink>
 <asp:UpdatePanel runat="server" ID="UpdatePanelStatus">
  <ContentTemplate>
   <h1>Master Program Matrix</h1>
   <asp:GridView ID="GridMatrix" runat="server" CssClass="grid" DataSourceID="SqlDataSource1" AutoGenerateColumns="true"
    OnDataBound="GridMatrix_DataBound">
    <Columns>
    </Columns>
   </asp:GridView>
  </ContentTemplate>
 </asp:UpdatePanel>
 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AffiliateInformationConnectionString %>"
  SelectCommand="sp_Sample_Return_Affil_MasterGrid" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
 <div runat="server" id="GridCC" class="CC" style="display: none;">
 </div>
 <div id="pnlAddMarketCC" class="hdnfrm" style="display: none;">
  <h2>Add Call Center Information</h2>
  <div class="field">
   <asp:Label ID="txtCallCenterName" runat="server" ToolTip="Call Center Name" ValidationGroup="MICC" ClientIDMode="Static"></asp:Label>
  </div>
  <div class="field">
   <asp:TextBox ID="txtCallCenterHours" runat="server" CssClass="txt multiline" Text="Call Center Hours" ToolTip="Call Center Hours"
    ValidationGroup="MICC" TextMode="MultiLine" Rows="5"></asp:TextBox>
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
</asp:Content>
