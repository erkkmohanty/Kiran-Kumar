//1. named functions
//2. function as expression /anonymous function

function add(x,y){
    return x+y;
}

var x=add(2,3);

console.log(x);//5


var result=function(x,y){
    return x+y;
};

console.log(result(4,5));//9

var add=4;//redeclaration
console.log(add);//4
console.log(add(2,5));//add is not a function