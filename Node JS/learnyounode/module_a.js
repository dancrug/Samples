var path = require('path')
var fs = require('fs')

module.exports = function (fdir, fext, callback){
  fs.readdir(fdir, function (err, files) {
    if(err)
      return callback(err);

    files = files.filter(function (file) {
      return path.extname(file) === '.' + fext;
    })

    callback(null, files);
  });
}
