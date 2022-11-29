#include <iostream>

using namespace std;

class MyStack
{
    int* stk;
    int TOS; //Top Of Stack
    int Size;

public:
    MyStack(int S = 7)
    {
        //cout << "Stack constructor";
        Size = S;
        TOS = 0;
        stk = new int[Size];
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
        MyStack R(7);

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

        for (int i=0;i<TOS;i++)
        {
            stk[i] = 0;
        }
        delete []stk;
    }


};


int main()
{
    MyStack S1(6);

    /// pushing elements in stack ..
    S1.Push(3);
    S1.Push(6);
    S1.Push(9);
    S1.Push(12);

    cout<<S1.Reverse().Pop()<<endl ;

    cout<<S1.Pop()<<endl ;


}
