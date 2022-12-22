function Rectangle(width, height) {

    this.width = width;
    this.height = height;
    
    this.Area = function () {
        return this.width * this.height;
    }
    
    this.perimeter = function () {
        return 2 * (this.width + this.height);
    }
    
    this.displayInfo = function () {
        console.log("Width: " + this.width);
        console.log("Height: " + this.height);
        console.log("Area: " + this.Area());
        console.log("Premitter: " + this.perimeter());
    }
    
}

var rect1 = new Rectangle(5, 10);

rect1.displayInfo();