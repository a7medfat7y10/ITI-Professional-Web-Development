var Book = function (t, ch, a, pg, pub, cop) {    
    Book.count++;
    
    Object.defineProperty(this, "title", {
        value: t,
        configurable:false,
        enumerable:false
    })
    Object.defineProperty(this, "numofChapters", {
        value: ch,
        configurable:false,
        enumerable:false
    })
    Object.defineProperty(this, "author", {
        value: a,
        configurable:false,
        enumerable:false
    })
    Object.defineProperty(this, "publisher", {
        value: pub,
        configurable:false,
        enumerable:false
    })
    Object.defineProperty(this, "numofCopies", {
        value: cop,
        configurable:false,
        enumerable:false
    })
}
//class property
Book.count=0;

//class method
Book.getCount = function(){
    return Book.count;
}

var book1 = new Book("7 habits", 10, "stephen", 100, "abc", 2000); 
var book2 = new Book("8 habits", 15, "shean", 200, "def", 30000); 
var book3 = new Book("vertigo", 15, "morad", 200, "aaaa", 6000); 



var Box = function (h, w, l , m, books) {
    
    Object.defineProperty(this, "height", {
        value: h,
        configurable:false,
        enumerable:false
    })
    Object.defineProperty(this, "width", {
        value: w,
        configurable:false,
        enumerable:false
    })
    Object.defineProperty(this, "length", {
        value: l,
        configurable:false,
        enumerable:false
    })
    Object.defineProperty(this, "material", {
        value: m,
        configurable:false,
        enumerable:false
    })
    Object.defineProperty(this, "content", {
        value: [],
        configurable:false,
        enumerable:false
    })

    for(var i=0;i<arguments.length;i++){
        if(i>3)
            this.content.push(arguments[i])
    }


    Object.defineProperty(this, "deleteBook", {
        value: function(t)
        {
            var isdeleted = false;
            for( i=0;i<this.content.length;i++)
            {   
                if(this.content[i].title==t && isdeleted == false)
                {
                    this.content.splice(i,1);
                    isdeleted = true;
                }
            }
        },
        configurable:false,
        enumerable:false
    })

    this.toString = function(){
        console.log("The width is " + this.width + " and the height is  " + this.height + " the length is " + this.length 
        + " and the material is " + this.material + " and the books stored are " + this.content.length );
        console.log(this.content);
    }

    this.valueOf = function () {
        return this.content.length;
    }
}

var box1 = new Box(50, 20, 40, "paper", book1, book2, book2, book3, book3);
var box2 = new Box(50, 20, 40, "paper", book2, book1, book1);

console.log (box1.content);

box1.deleteBook("8 habits");
console.log (box1.content);

//how many books created from Book
console.log(Book.getCount());

box1.toString();
box2.toString();
console.log(box1+box2);
