var socketInput = Number(process.argv[2])

var net = require('net')
var server = net.createServer(function (socket) {
       // socket handling logic
       socket.end(dateNow() + '\n');
})
server.listen(socketInput, function () {
})


function formatDate(date) {
  return (date < 10 ? '0' : '') + date
}

function dateNow() {
  var date = new Date();
  return date.getFullYear() + '-'
  + formatDate(date.getMonth() + 1) + '-'
  + formatDate(date.getDate()) + ' '
  + formatDate(date.getHours()) + ":"
  + formatDate(date.getMinutes());
}
