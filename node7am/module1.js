
function  sub(x,y) {
    console.log(x-y);
}

var obj={
    sayHello:function () {
        console.log("Hello There");
    },
    greet:function () {
        console.log("Greetings Everyone");
    },
    sub:sub
};
module.exports=obj;