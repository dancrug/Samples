<?php
  require_once("includes/db.php");
?>

<!DOCTYPE html>
<html>
<head>
  <title>Sample Book Application</title>
  <style type="text/css">
  body {
    margin: 0;
    padding: 0;
    font-size: 62.5%;
    line-height: 1.2;
    color: #000000;
    font-family: "Arial", sans-serif;
  }
  div {
    margin: 0 auto;
    width: 1024px;
  }
  h1 {
    font-size: 2.2em;
  }
  table {
    margin: 0;
    padding: 0;
    border-spacing: 0;
    border-collapse: collapse;
  }
  table tr th {
    font-size: 1.8em;
    text-align: left;
    padding: 10px;
  }
  table tr td {
    font-size: 1.4em;
    text-align: left;
    padding: 10px;
  }
  </style>
</head>
<body>
  <div>
    <h1>Book Library</h1>
    <table>
      <tr>
        <th>ID</th>
        <th>Book Name</th>
        <th>Book Price</th>
      </tr>
      <?php
        if ($result->num_rows > 0) {
          // output data of each row
          while($row = $result->fetch_assoc()) {
            echo "<tr><td>" . $row["ID"]. "</td><td>" . $row["Book_Name"]. "</td><td>" . $row["Book_Price"]. "</td></tr>";
          }
        } else {
          // nothing found
          echo "<tr><td colspan=\"3\">0 results found</td></tr>";
        }
        ?>
    </table>
</div>
</body>
</html>
