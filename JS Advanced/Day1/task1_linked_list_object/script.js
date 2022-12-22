var linkedList = {
    
    data: [],
    
    enqueueObj:function(value){
        if(this.data.length == 0)
        {
            this.data.push({val : value});
        }
        else if  (this.data[this.data.length-1].val<value)
        {
            
            this.data.push({val : value});
        }
        else
        {
            throw'invalid push';
        }
    },
  
    insertObj:function(value)
    {
        var pre;
        var j =0;
        
        var values=[];
        for(var i =0; i<this.data.length; i++)
        {
            values[i] = this.data[i].val;
        }
        
        if(values.indexOf(value) == -1){
            while(values[j] < value)
            {
                pre = j;
                j++;
            }
            this.data.splice(pre+1,0,{val: value});
        }
        else 
        {
            throw 'duplicate value';
        }
    },

    popObj:function()
    {
        this.data.pop();
    },
    
    removeObj:function(value)
    {
        var values=[];
        for(var i =0; i<this.data.length; i++)
        {
            values[i] = this.data[i].val;
        }


        if(!values.includes(value))
        {
            throw'data not found';
        }
        else
        {
            var index = values.indexOf(value);
            this.data.splice(index,1);
        }
    },
    
    dequeueObj:function()
    {
        if(this.data.length==0)
            throw "empty";
        else
            this.data.shift();
    },
    
    display:function()
    {
        console.log(this.data);
    }
};

linkedList.enqueueObj(1);
linkedList.enqueueObj(2);
linkedList.enqueueObj(4);
linkedList.enqueueObj(8);
linkedList.enqueueObj(10);

linkedList.insertObj(3);

linkedList.removeObj(8)

linkedList.dequeueObj();

linkedList.popObj();

linkedList.display();



