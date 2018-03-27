var crypto = require('crypto');
var tar = require('tar')
process.stdin
.pipe(crypto.createDecipher('aes256', process.argv[2]))
.pipe(process.stdout)
