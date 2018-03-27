<?php
function Fizzer($input) {
  $modFizz = 0;
  $modBuzz = 0;
  for($i = 1; $i<= $input; $i++){
    $modFizz = $i % 3;
    $modBuzz = $i % 5;
    printText($modFizz, $modBuzz, $i);
  }
}

function printText($modFizz, $modBuzz, $i) {
  if(($modFizz == 0) && ($modBuzz == 0)) {
    echo "FizzBuzz<br />";
  } else if ($modFizz == 0) {
    echo "Fizz<br />";
  } else if ($modBuzz == 0) {
    echo "Buzz<br />";
  } else {
    echo $i . "<br />";
  }
}

Fizzer(20);
?>
