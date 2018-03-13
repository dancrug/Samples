function enableSlider() {
 $(".item").click(function () {
  var current = $(this).attr("data-page");
  $(".item").removeClass("selected");
  switch (current) {
   case "1":
    $(".item[data-page=1]").addClass("selected");
    $("#slideshow").animate({
     left: "0px"
    }, {
     duration: 1000
    });
    break;
   case "2":
    $(".item[data-page=2]").addClass("selected");
    $("#slideshow").animate({
     left: "-205px"
    }, {
     duration: 1000
    });
    break;
   case "3":
    $(".item[data-page=3]").addClass("selected");
    $("#slideshow").animate({
     left: "-411px"
    }, {
     duration: 1000
    });
    break;
  }
 });
}
$(document).ready(function () {
 $(".fancybox").fancybox({
  width: '80%'
 });
});
function disableBtn(button) {
 if (Page_ClientValidate("LeadForm")) {
  button.disabled = true;
 }
}
function enableBlur() {
 $(".txt").focus(function () {
  if ($(this).val() === $(this).attr("title")) {
   $(this).val("");
  }
  if ($(this).attr("id") === $("#LeadForm1_txtPhone").attr("id")) {
   $(this).mask("999-999-9999");
  }
 }).blur(function () {
  if ($(this).val() === "") {
   $(this).val($(this).attr("title"));
  }
 });
}
function isValidEmail(source, args) {
 var result = false;
 $.ajax({
  url: "controls/Ajax.ashx?email=" + args.Value,
  type: "POST",
  async: false,
  success: function (data) {
   result = data === "False" ? false : true;
  }
 });
 args.IsValid = result;
}
function onChangeValidEmail(source) {
 $.ajax({
  url: "controls/Ajax.ashx?email=" + source.val(),
  type: "POST",
  success: function (data) {
   if (data === "false") {
    source.focus();
    return false;
   }
  }
 });
}