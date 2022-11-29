#include <iostream>

using namespace std;

class MyStack
{
    int* stk;
    int TOS; //Top Of Stack
    int Size;

public:
    MyStack(int S)
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
    cout << s1.Pop()<<endl; //5
    cout << s1.Peek()<<endl; //4
    cout << s1.Peek()<<endl; //4
    cout << s1.Pop() << endl; //4
    s1.Push(6);
    cout << "Stack Count is " << s1.GetCount() << endl; //2
}
