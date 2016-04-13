var fs = require("fs");
//Blocking Code
//var data = fs.readFileSync("input.txt");
//console.log(data.toString());

//Non Blocking Code
fs.readFile("input.txt", function (err,data) {
    if (err) return console.log(err);
    console.log(data.toString());
})

console.log("Program Ended");