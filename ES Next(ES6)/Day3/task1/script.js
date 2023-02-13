class Ploygon{
    dim1;
    dim2;
    constructor(d1,d2){
        this.dim1=d1;
        this.dim2=d2;
    }
    draw(){
        var canvasElement = document.querySelector("#myCanvas");
        var context = canvasElement.getContext("2d");


        context.beginPath();
        context.moveTo(100, 100);
        context.lineTo(100, 100+this.dim1);
        context.lineTo(100+this.dim2, 100+this.dim1);
        context.lineTo(100+this.dim2, 100);
        context.closePath();
        
        context.lineWidth = 1;
        context.strokeStyle = '#666666';
        context.stroke();
    }
    toString(){
        return ` Polygon d1 ${this.dim1} , d2 ${this.dim2} and area is ${this.dim1 * this.dim2}`;
    }
}
var p1= new Ploygon(100, 200);
console.log(p1.toString()); 
p1.draw();

class Rectangle extends Ploygon{
    constructor(d1,d2){
        super(d1,d2);
    }
    toString(){
        return `Rectangle Height ${this.dim1} , width ${this.dim2} and area is ${this.dim1 * this.dim2}`;
    }
}
var r1= new Rectangle(100, 200);
console.log(r1.toString()); 
r1.draw();

class Square extends Ploygon{
    constructor(d){
        super(d,d);
    }
    toString(){
        return `Square Length ${this.dim1} and area is ${this.dim1 * this.dim2}`;
    }
}
var s1= new Square(100);
console.log(s1.toString()); 
s1.draw();

class Circle extends Ploygon{
    radius;
    constructor(R){
        super();
        this.radius =R;
    }
    draw(){
        var canvas = document.getElementById('myCanvas');
        var context = canvas.getContext('2d');
        context.beginPath();
        context.arc(200, 200, this.radius, 0, 2 * Math.PI, false);
        context.lineWidth = 1;
        context.strokeStyle = '#003300';
        context.stroke();
    }
    toString(){
        return `Circle Radius is ${this.radius } and area is ${this.radius * this.radius * Math.PI}`;
    }
}
var c1= new Circle(100);
console.log(c1.toString()); 
c1.draw();

class Triangle extends Ploygon{
    constructor(b,h){
        super(b,h);
    }
    draw() {
        var canvasElement = document.querySelector("#myCanvas");
        var context = canvasElement.getContext("2d");

        // the triangle
        context.beginPath();
        context.moveTo(100, 100);
        context.lineTo(100, 100+this.dim1);
        context.lineTo(100+this.dim2, 100+this.dim1);
        context.closePath();
        
        context.lineWidth = 1;
        context.strokeStyle = '#666666';
        context.stroke();
    }

    toString(){
        return `Triangle base ${this.dim1} , height ${this.dim2} and area is ${ .5 * this.dim1 * this.dim2}`;
    }
}
var t1= new Triangle(100, 200);
console.log(t1.toString()); 
t1.draw();