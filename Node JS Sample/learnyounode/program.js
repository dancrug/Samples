var mod_a = require('./module_a.js')
var fDir = process.argv[2];
var fStr = process.argv[3]

mod_a(fDir, fStr, callback);

function callback(err, data){
  data.forEach(function (item) {
    console.log(item);
  });
}
