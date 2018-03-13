$(document).ready(function () {
 var count = 0, marketCount = 0;
 $(".currency").focus(function () {
  $(this).mask("$999,999");
 });
 $(".txt").focus(function () {
  if ($(this).val() === $(this).attr("title")) {
   $(this).val("");
  }
  if ($(this).hasClass("phone")) {
   $(this).mask("999-999-9999");
  }
 }).blur(function () {
  if ($(this).val() == "") {
   $(this).val($(this).attr("title"));
  }
 });
 $("input[type=button].add").click(function () {
  var dataBox = $(this).attr("data-box");
  var dataEl = $("input[type=text][data-box=" + dataBox + "]");
  var dataValue = dataEl.val();
  if (dataValue != "") {
   $("div#" + dataBox).append("<div class=\"data\" id=\"" + dataBox + "_" + count + "\" ><input type=\"text\" value=\"" + dataValue + "\" readonly class=\"txt\" id=\"" + dataBox + "_" + count + "\"/> <input type=\"button\" value=\"-\" class=\"btn remove\" data-id=\"" + dataBox + "_" + count + "\" onclick=\"javascript:removeData($(this));\" /></div>");
   dataEl.val("");
   count++;
  }
 });
 $("input[type=button].addmarket").click(function () {
  var dataGroup = $(this).attr("data-group"), dataHtml = "";
  $("#" + dataGroup).append("<tr id=\"marketInformation_" + marketCount + "\" class=\"market_data\"></tr>");
  $.each($(".col input[type=text][data-group=" + dataGroup + "]"), function (key, value) {
   if (value.value != "" && value.value != undefined) {
    dataHtml += "<td><input class=\"txt\" type=\"text\" id=\"" + value.id + "_" + marketCount + "\" data-id=\"" + value.id + "\" readonly value=\"" + value.value + "\" />";
   } else {
    dataHtml += "<td><input class=\"txt\" type=\"text\" id=\"" + value.id + "_" + marketCount + "\" data-id=\"" + value.id + "\" readonly value=\"\" />";
   }
  });
  dataHtml += "<input type=\"button\" value=\"-\" class=\"btn remove\" data-id=\"marketInformation_" + marketCount + "\" onclick=\"javascript:removeData($(this));\" /></tr>";
  $("#" + dataGroup + " tr#marketInformation_" + marketCount).append(dataHtml);
  marketCount++;
  $("#txtMarketName").val("");
  $("#txtMonthlyBudgets").val("");
  $("#ddlCallCenterPhone").val("NA");
  $("#txtCallCenterPhone").val("");
  $("#ddlCallCenterHours").val("NA");
  $("#txtCallCenterHours").val("");
  $("#ddlLeadEmailDelivery").val("NA");
  $("#txtLeadEmailDelivery").val("");
 });
 $(".zip").autocomplete({
  source: function (request, response) {
   $.ajax({
    type: "POST",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    url: "controls/FormHandler.ashx?type=autocomplete&keyword=" + request.term,
    dataFilter: function (data) { return data; },
    success: function (data) {
     response($.map(data, function (item) {
      return {
       label: item.Name,
       value: item.Name,
       data: item.Value
      }
     }))
    },
    error: function (result) {
     console.log(result);
    }
   });
  },
  select: function (event, ui) {
   $(this).attr("data-zipid", ui.item.data);
  },
  change: function (event, ui) {
   $(this).attr("data-zipid", ui.item.data);
  },
  minLength: 3
 });
 $("#chkCInfo").change(function () {
  if ($(this).is(":checked")) {
   $("#txtBFirstName").val($("#txtCFirstName").val());
   $("#txtBLastName").val($("#txtCLastName").val());
   $("#txtBAddress1").val($("#txtCAddress1").val());
   $("#txtBCity").val($("#txtCCity").val());
   $("#ddlBState").val($("#ddlCState").val());
   $("#txtBZip").val($("#txtCZip").val());
   var cpPhoneHtml = $("#ContactPhone").html();
   var cpEmailHtml = $("#ContactEmail").html();
   cpPhoneHtml = cpPhoneHtml.replace(/ContactPhone/g, "BusinessPhone");
   cpEmailHtml = cpEmailHtml.replace(/ContactEmail/g, "BusinessEmail");
   $("#BusinessPhone").html(cpPhoneHtml);
   $("#BusinessEmail").html(cpEmailHtml);
  } else {
   $("#txtBFirstName").val("");
   $("#txtBLastName").val("");
   $("#txtBAddress1").val("");
   $("#txtBCity").val("");
   $("#ddlBState").val("0");
   $("#txtBZip").val("");
   $("#BusinessPhone").html("");
   $("#BusinessEmail").html("");
  }
 });
 $(".call").change(function () {
  var selected = $(this).val();
  var dataBox = $(this).attr("data-box");
  if (selected == "Enter Custom") {
   $(".txt[data-box=" + dataBox + "]").removeClass("hidden");
  } else {
   $(".txt[data-box=" + dataBox + "]").val(selected);
   $(".txt[data-box=" + dataBox + "]").addClass("hidden");
  }
 });
 $("#test1").click(function () {
  setFormFields();
 });
});
function removeData($this) {
 var dataRemove = $this.attr("data-id");
 $("#" + dataRemove).remove();
}
function setFormFields() {
 var hdnId = "";
 $.each($(".multibox").not("#marketInformation"), function (key, item) {
  var hdnValue = new Array();
  hdnId = item.id;
  $.each($(item).find("input[type=text]"), function (i, input) {
   hdnValue.push(input.value);
  });
  $("#hdn" + hdnId).val(hdnValue);
 });
 var dataMarket = new Array();
 $.each($(".market_data"), function (key, item) {
  var dataValues = new Array();
  $.each($(item).find(".txt"), function (i, input) {
   dataValues.push(input.value);
  });
  dataMarket.push(dataValues + "`");
 });
 $("#hdnMarketInformation").val(dataMarket);
 return true;
}