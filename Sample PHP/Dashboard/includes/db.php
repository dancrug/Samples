<?php
$servername = "localhost";
$username = "book_user";
$password = "yN5qAoIl0UsoABNf@0";
$dbname = "Inventory";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT * FROM Books";
$result = $conn->query($sql);

$conn->close();
?>
