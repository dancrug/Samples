//Lesson 9
var spawn = require('child_process').spawn;
var duplexer = require('duplexer2');

module.exports = function (cmd, args) {
    var childSpawn = spawn(cmd, args)
    return duplexer(childSpawn.stdin, childSpawn.stdout)
}
