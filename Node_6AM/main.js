//blocking

var fs=require("fs");

//Sync Operation
var data=fs.readFileSync("./input.txt","utf-8");
console.log(data);
console.log("Synchronous Operation");

//async Operation
var data=fs.readFile("./input.txt","utf-8",function(err,data){
console.log(data);
});

console.log("Asynchronous Operation");