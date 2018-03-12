module.exports = function module_a(fdir, fext){
  var path = require('path')
  var fs = require('fs')
  var data = [];
  var fileCount = 0;

  /*
  fs.readdir(fdir, function (err, files) {
    if (err) {
      return callback(err);
    }
    for(var i=0; i<files.length; i++){
      if (path.extname(files[i]).replace('.','') == fext){
        data[fileCount] = files[i];
        fileCount++;
      }
    }
    callback(null, data);
  });
*/
  function callback(err, data){
    return data;
  }
  callback(null, fdir);
}
