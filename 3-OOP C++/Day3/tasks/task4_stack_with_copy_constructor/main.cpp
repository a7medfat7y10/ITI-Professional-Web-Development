#include <iostream>

using namespace std;

class MyStack
{
    int* stk;
    int TOS; //Top Of Stack
    int Size;

public:
    MyStack(int S = 5)
    {
        //cout << "Stack constructor";
        Size = S;
        TOS = 0;
        stk = new int[Size];
    }

    MyStack (MyStack& olds)
    {
        TOS = olds.TOS;
        Size = olds.Size;
        stk= new int[Size];
        for (int i =0; i<TOS;i++)
        {
            stk[i] = olds.stk[i];
        }
    }
    int ISFull()
    {
        return (TOS == Size);
    }
    int ISEmpty()
    {
        return (TOS == 0);
    }

    void Push (int n)
    {
        if (!ISFull())
        {
            stk[TOS++] = n;
        }
        else
        {
            cout << "stack is full\n";
        }
    }
    int Pop ()
    {
        if (!ISEmpty())
        {
            return stk[--TOS];
        }
        else
        {
            cout << "stack is empty\n";
            return -1;
        }
    }
    int Peek ()
    {
        if (!ISEmpty())
        {
            return stk[TOS-1];
        }
        else
        {
            cout << "stack is empty\n";
            return -1;
        }
    }
    int GetCount()
    {
        return TOS;
    }

    MyStack Reverse()
    {
        MyStack R(*this);

        for (int i =0; i < TOS / 2; i++)
        {
            int temp = stk[i];
             R.stk[i] = stk[TOS - i -1];
             R.stk[TOS - i -1] = temp;
        }

        return R;
    }

    void Print()
    {
       // cout << TOS <<endl;
        for(int i =0; i<TOS; i++)
        {

            cout << stk[i] << "\n";
        }
    }

    ~MyStack()
    {
        delete []stk;
    }


};


int main()
{
    MyStack s1(7);
    s1.Push(3);
    s1.Push(4);
    s1.Push(5);
    s1.Push(6);

    cout << "Stack Count is " << s1.GetCount() << endl; //2

    //print stack
    cout << "stack is "<< endl;
    s1.Print();


    cout << "The reversed stack is "<< endl;
    s1.Reverse().Print();

    cout << "###########################"  << endl;

    cout << "Pop one element "<< endl;
    cout << s1.Pop() << endl;

    cout << "###########################"  << endl;
     cout << "Reverse the stack after pop "<< endl;
    s1.Reverse().Print();

}
