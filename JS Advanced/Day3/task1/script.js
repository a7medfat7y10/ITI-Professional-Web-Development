var List = function(start, end, step){

    var arr = [];

    Object.defineProperty(this, "appendValue", {
        value: function(value){
            if(arr.length == 0 && value == start)
                arr.push(start);
            else if((value <= end) && (value - arr[arr.length -1] == step))
                arr.push(value);
            else
                throw 'this is not valid';
        },
        configurable: false,
        enumerable: false
    });

    Object.defineProperty(this, "prependValue", {
        value: function(value){
            if(arr.length == 0 && value == start)
                arr.push(start);
            else if((arr[0] != start) && (arr[0] - value == step))
                arr.unshift(value);
            else
                throw 'this is not valid';
        },
        configurable: false,
        enumerable: false
    });

    Object.defineProperty(this, "DequeueValue", {
        value: function(){
                arr.shift();
        },
        configurable: false,
        enumerable: false
    });

    Object.defineProperty(this, "popValue", {
        value: function(){
                arr.pop();
        },
        configurable: false,
        enumerable: false
    });
    
    this.toString = function(){
        console.log(arr);
    }
}

var l1 = new List(1, 9, 2);

//l1.appendValue(5); error
l1.appendValue(1);
l1.appendValue(3);
l1.appendValue(5);
l1.appendValue(7);
//l1.appendValue(7); error invalid duplicate
l1.appendValue(9);
//l1.appendValue(11); error invalid
l1.toString();

l1.popValue();
l1.DequeueValue();
l1.toString();

l1.prependValue(1);
//l1.prependValue(0); error
l1.toString();