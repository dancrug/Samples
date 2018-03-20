// Lesson 1
var fs = require("fs")
var file = process.argv[2]
//fs.createReadStream(process.stdin).pipe(process.stdout)

//Lesson 2
//process.stdin.pipe(process.stdout)

//Lesson 3
/*
var body = ''
process.stdin.on('readable', function () {
  var chunk = process.stdin.read();
  if (chunk !== null) {
    body += chunk
  }
});

process.stdin.on('end', function () {
  process.stdout.write(body.toString().toUpperCase());
});
*/

//Lesson 4
var body = ''
process.stdin.on('readable', function () {
  var chunk = process.stdin.read();
  if (chunk !== null) {
    body += chunk
  }
});

process.stdin.on('end', function () {
  var output = body.split('\n');
  for(var i=0;i<output.length;i++)
    if(i % 2 == 0)
      process.stdout.write(output[i].toLowerCase() + "\n");
    else
      process.stdout.write(output[i].toUpperCase() + "\n");
  process.stdout.write("\n");
});
