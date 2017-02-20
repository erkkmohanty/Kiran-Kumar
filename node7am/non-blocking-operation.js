/**
 * Created by KIRAN KUMAR on 8/31/2016.
 */

var fs=require("fs");

fs.readFile("./input.txt","utf8",function (err,data) {
    if (err)
    {
        console.log(err);
    }
    if (data)
    {
        console.log(data);
    }
});

console.log("Non blocking operations");
