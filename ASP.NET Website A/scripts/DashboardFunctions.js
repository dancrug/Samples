/* Global Variables */

(function ($) {
 $.QueryString = (function (a) { if (a == "") return {}; var b = {}; for (var i = 0; i < a.length; ++i) { var p = a[i].split('='); if (p.length != 2) continue; b[p[0]] = decodeURIComponent(p[1].replace(/\+/g, " ")); } return b; })(window.location.search.substr(1).split('&'))
})(jQuery);

function goBack() {
 window.history.back();
}

function init() {
 try {
  if ($(".CC").length > 0) {
   $(".CC").autocomplete({
    source: function (request, response) {
     $.ajax({
      url: "../controls/AffiliateHandler.ashx?autocomplete=callcenter",
      success: function (data) {
       response($.map(data, function (item) {
        return {
         value: item.Name,
         label: item.Name,
         data: item.Value
        }
       }));
      }
     });
    },
    select: function (event, ui) {
     $("#hdnCallCenterValue").val(ui.item.data);
    },
    minLength: 1
   });
  }
  if ($(".CM").length > 0) {
   $(".CM").autocomplete({
    source: "../controls/AffiliateHandler.ashx?autocomplete=market&id=" + $.QueryString["AID"],
    minLength: 1
   });
  }
  //  if ($(".GN").length > 0) {
  //   $.ajax({
  //    url: "../controls/AffiliateHandler.ashx?autocomplete=affiliate&id=" + $.QueryString["AID"],
  //    success: function (data) {
  //     $(".GN").text(data);
  //    }
  //   });
  //  }
  if ($(".BC").length > 0) {
   $(".BC").change(function () {
    $.ajax({
     url: "../controls/AffiliateHandler.ashx?autocomplete=duplicate&id=" + $(this).val(),
     success: function (data) {
      $("#txtBFirstName").val(data[0]);
      $("#txtBLastName").val(data[1]);
      $("#txtBAddress1").val(data[2]);
      $("#txtBCity").val(data[3]);
      $("#ddlBState").val(data[4]);
      $("#txtBZip").val(data[5]);
     }
    });
   });
   if ($(".RS").length > 0) {
    var options = ["On", "Off", "Moderate"];
    $(".RS").autocomplete({
     source: options
    });
   }
  }
 }
 catch (err) {
 }
 $("#btnAddNote").click(function () {
  $(".pnlNote").show();
 });
 $("#btnCancelNote").click(function () {
  $(".pnlNote").hide();
  $(".txtNote").val("");
 });

 var name = "";
 $("button").click(function (e) {
  name = $(this).attr("data-name");
  if ($(this).hasClass("cancel") == false) {
   $("div.pnlAdd").css("top", parseInt($(document).scrollTop()) + "px");
   if ($("div.pnlAdd")) {
    $("div.pnlAdd").show();
   }
   $("#pnlAdd" + name).show();
   $("#txt" + name).focus();
  } else {
   $("div.pnlAdd").hide();
   $("#pnlAdd" + name).hide();
   $("#txt" + name).val("");
  }
 });
 try {
  var prm = Sys.WebForms.PageRequestManager.getInstance();
  prm.add_endRequest(function (s, e) {
   init();
  });
 }
 catch (err) {
 }
 $(".txt").focus(function () {
  if ($(this).val() === $(this).attr("title")) {
   $(this).val("");
  }
  if ($(this).hasClass("phone")) {
   $(this).mask("999-999-9999 x99999");
  }
 }).blur(function () {
  if ($(this).val() == "") {
   $(this).val($(this).attr("title"));
  }
 });
 $(".currency").focus(function () {
  $(this).mask("$999,999");
 });
 $(".date").focus(function () {
  $(this).mask("99/99/9999");
 });
 $.each($("td.status, .status td"), function (key, value) {
  var tdtxt = $(this).text().trim();
  switch (tdtxt) {
   case "On":
    $(this).addClass("green");
    break;
   case "Off":
    $(this).addClass("red");
    break;
   case "Moderate":
    $(this).addClass("yellow");
    break;
   default:
    break;
  }
 });
 $("input").keypress(function (e) {
  if (e.keyCode == 13)
   return false;
 });
 $("#ddlNoteCategoryFilter").change(function () {
  var fvalue = $(this).val();
  $(".noteItem").show();
  $(".noteItem").filter(function (index) {
   var svalue = $(this).find("span#NoteCategoryLabel").text();
   if (fvalue === "All") { $(this).show(); } else if (svalue === fvalue) { $(this).show(); } else { $(this).hide(); };
  })
 });

}

