<?php
$errorCount = 0;
$src = "";
$zip = "";
$hip = "";
$subcat = "";
$ip = "";
$tcpaconsent = "";
$tcpaconsentlang = "";
$ans1 = "";
$istest = "";
$errorMessage = "";

if (isset($_POST["SRC"])) {
	$src = $_POST["SRC"];
} else {
	$errorCount += 1;
	$errorMessage .= "SRC is required;";
}
if (isset($_POST["zip"])) {
	$zip = $_POST["zip"];
} else {
	$errorCount += 1;
	$errorMessage .= "Zip is required;";
}
if (isset($_POST["Home_Improvement_Product"])) {
	$hip = $_POST["Home_Improvement_Product"];
} else {
	$errorCount += 1;
	$errorMessage .= "Home Improvement Product is required;";
}
if (isset($_POST["subcat"])) {
	$subcat = $_POST["subcat"];

} else {
	$errorCount += 1;
	$errorMessage .= "Subcat is required;";
}
if (isset($_POST["ipAddress"])) {
	$ip = $_POST["ipAddress"];
} else {
	$errorCount += 1;
	$errorMessage .= "IP is required;";
}
if (isset($_POST["TCPAConsent"])) {
	$tcpaconsent = $_POST["TCPAConsent"];

} else {
	$errorCount += 1;
	$errorMessage .= "TCPAConsent is required;";
}
if (isset($_POST["TCPAConsentLanguage"])) {
	$tcpaconsentlang = $_POST["TCPAConsentLanguage"];
} else {
	$errorCount += 1;
	$errorMessage .= "TCPAConsentLanguage is required;";
}
if (isset($_POST["answer1"])) {
	$ans1 = $_POST["answer1"];
} else {
	$errorCount += 1;
	$errorMessage .= "Answer1 is required;";
}
if (isset($_POST["Test_Lead"])) {
	$istest = $_POST["Test_Lead"];
} else {
	$errorMessage .= "Test Lead is required;";
	$errorCount += 1;
}
if ($errorCount == 0) {
	$pingToSend = array("SRC" => $src, "zip" => $zip, "Home_Improvement_Product" => $hip, "subcat" => $subcat, "ipAddress" => $ip, "TCPAConsent" => $tcpaconsent, "TCPAConsentLanguage" => $tcpaconsentlang, "answer1" => $ans1, "Test_Lead", $istest);
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_POST, 1);
	curl_setopt($ch, CURLOPT_URL, '');
	curl_setopt($ch, CURLOPT_POSTFIELDS, http_build_query($pingToSend));
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
	curl_setopt($ch, CURLOPT_FOLLOWLOCATION, true);
	curl_setopt($ch, CURLOPT_MAXREDIRS, 4);
	curl_setopt($ch, CURLOPT_TIMEOUT, 10);
	$result = curl_exec($ch);
	curl_close($ch);
	echo $result;
} else {
	echo $errorMessage;	
}
?>
