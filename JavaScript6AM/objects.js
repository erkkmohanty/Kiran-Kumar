//literal syntax

var obj={id:1,name:"Kiran"};
console.log(obj.id+","+obj.name);



//Object constructor

var obj2=new Object();
obj.id=2;
obj.name="Tarun";
console.log(obj.id+","+obj.name);

//function constructor class

function Employee()
{
    var address="Noida";//private
    //public
    this.id="";
    this.name="";
    this.showDetails=function(){
        return this.id+","+this.name+","+address;
    }
}

var emp=new Employee();
emp.id=3;
emp.name="Kuntala";
emp.address="addresses";
emp.address3="addresses33333333";
console.log(emp.id+","+emp.name);
console.log(emp.showDetails());


var str="Mahindra";
console.log(str.length);


//Object.create
var o1=Object.create(obj);
var o2=Object.create(obj);
console.log(o1.__proto__);
console.log(o1.id+","+o1.name);
o1.id=5;
o1.name="Rahul";
console.log(o1.id+","+o1.name);
console.log(o2.id+","+o2.name);
console.log(obj.id+","+obj.name);
