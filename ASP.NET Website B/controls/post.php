<?php
$errorCount = 0;
$email = "";
$leadid = "";
$src = "";
$zip = "";
$hip = "";
$subcat = "";
$ip = "";
$tcpaconsent = "";
$tcpaconsentlang = "";
$ans1 = "";
$firstname = "";
$lastname = "";
$phone = "";
$address = "";
$city = "";
$state = "";
$timeframe = "";
$homeowner = "";
$besttime = "";
$istest = "";
$errorMessage = "";

if (isset($_POST["email"])) {
	$email = $_POST["email"];
} else {
	$errorCount += 1;
	$errorMessage .= "Email is required;";
}
if (isset($_POST["leadid"])) {
	$leadid = $_POST["leadid"];
} else {
	$errorCount += 1;
	$errorMessage .= "LeadId is required;";
}
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
if (isset($_POST["firstname"])) {
	$firstname = $_POST["firstname"];
} else {
	$errorMessage .= "First name is required;";
	$errorCount += 1;
}
if (isset($_POST["lastname"])) {
	$lastname = $_POST["lastname"];
} else {
	$errorMessage .= "Last Name is required;";
	$errorCount += 1;
}
if (isset($_POST["phone"])) {
	$phone = $_POST["phone"];
} else {
	$errorMessage .= "Phone is required;";
	$errorCount += 1;
}
if (isset($_POST["address"])) {
	$address = $_POST["address"];
} else {
	$errorMessage .= "Address is required;";
	$errorCount += 1;
}
if (isset($_POST["city"])) {
	$city = $_POST["city"];
} else {
	$errorMessage .= "City is required;";
	$errorCount += 1;
}
if (isset($_POST["state"])) {
	$state = $_POST["state"];
} else {
	$errorMessage .= "State is required;";
	$errorCount += 1;
}
if (isset($_POST["timeframe"])) {
	$timeframe = $_POST["timeframe"];
} else {
	$errorMessage .= "Timeframe is required;";
	$errorCount += 1;
}
if (isset($_POST["homeowner"])) {
	$homeowner = $_POST["homeowner"];
} else {
	$errorMessage .= "Homeowner is required;";
	$errorCount += 1;
}
if (isset($_POST["besttime"])) {
	$besttime = $_POST["besttime"];
} else {
	$errorMessage .= "Best Time is required;";
	$errorCount += 1;
}

if (isset($_POST["Test_Lead"])) {
	$istest = $_POST["Test_Lead"];
} else {
	$errorMessage .= "Test Lead is required;";
	$errorCount += 1;
}

if ($errorCount == 0) {
	$postToSend = array('email' => $email, 'Lead_id' => $leadid, 'SRC' => $src, 'zip' => $zip, 'Home_Improvement_Product' => $hip, 'subcat' => $subcat, 'ipAddress' => $ip, 'TCPAConsent' => $tcpaconsent, 'TCPAConsentLanguage' => $tcpaconsentlang, 'answer1' => $ans1, 'firstname' => $firstname, 'lastname' => $lastname, 'phone' => $phone, 'address' => $address, 'city' => $city, 'state' => $state, 'best_time_to_contact' => $besttime, 'timeframe' => $timeframe, 'homeowner' => $homeowner, 'Test_Lead' => $istest);
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_POST, 1);
	curl_setopt($ch, CURLOPT_URL, 'http://184.107.228.107/api/101e25aefb0fcdadb52ae75fa72b3626c6ab/');
	curl_setopt($ch, CURLOPT_POSTFIELDS, http_build_query($postToSend));
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