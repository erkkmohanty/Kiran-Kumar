function fun1(x){
    return function fun2(y){//closure
        return x+y;
    }
}

var f=fun1(4);
var r=f(5);

console.log(r);

var util=(function(){
var weekDays=["Monday","Tuesday","Wednesday","Thursday","Friday"];
return function(index){
    if(index>=1&& index<=5)
    return weekDays[index-1];
    else
    return "Out of Index";
}
})();

console.log(util(1));
console.log(util(6));

var util={weekDays:(function(){
var weekDays=["Monday","Tuesday","Wednesday","Thursday","Friday"];
return function(index){
    if(index>=1&& index<=5)
    return weekDays[index-1];
    else
    return "Out of Index";
}
})()};

console.log(util.weekDays(1));
console.log(util.weekDays(6));