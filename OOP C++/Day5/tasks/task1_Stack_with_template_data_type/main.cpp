#include <iostream>

using namespace std;

template <class Type1>
class MyStack
{
    Type1 * stk;
    int TOS; //Top Of Stack
    int Size;

public:
    MyStack(Type1 S)
    {
        //cout << "Stack constructor";
        Size = S;
        TOS = 0;
        stk = new Type1[Size];
    }

    MyStack (MyStack& olds)
    {
        TOS = olds.TOS;
        Size = olds.Size;
        stk= new Type1[Size];
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

    void Push (Type1 n)
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
    Type1 Pop ()
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
    Type1 Peek ()
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
            Type1 temp = stk[i];
             R.stk[i] = stk[TOS - i -1];
             R.stk[TOS - i -1] = temp;
        }

        return R;
    }

    MyStack& operator= (const MyStack& R)
    {
        delete [] stk;
        TOS = R.TOS;
        Size = R.Size;
        stk = new Type1[Size];

        for (int i=0;i<TOS; i++)
        {
            stk[i] = R.stk[i];
        }
        return *this;
    }

    int& operator[] (int index)
    {
        if ((index >= 0) && (index <Size))
        {
            return stk[TOS -1 - index];
        }
    }


    MyStack operator+(const MyStack& S)
    {
        MyStack Result(Size + S.Size);

        for ( int i =0 ; i <TOS; i++ )
        {
            Result.Push(stk[i]);
        }
        for ( int i =0 ; i < S.TOS; i++ )
        {
            Result.Push(S.stk[i]);
        }
        return Result;
    }

    void Print();

    ~MyStack()
    {
        delete []stk;
    }


};

template <class Type2>
void MyStack<Type2>::Print()
{
   // cout << TOS <<endl;
    for(int i =0; i<TOS; i++)
    {

        cout << stk[i] << " ,";
    }
    cout << " \n";
}


int main()
{
    MyStack<int> s1(7);
    s1.Push(3);
    s1.Push(4);
    s1.Push(5);
    s1.Push(6);
    //print stack
    cout << "stack is "<< endl;
    s1.Print();
    cout << "The reversed stack is "<< endl;
    s1.Reverse().Print();

    cout << "###########################"  << endl;

    MyStack<int> s2(7);
    s2.Push(7);
    s2.Push(8);
    s2.Push(9);
    s2.Push(10);
    //print s2
    cout << "s2 is " << endl;
    s2.Print();


    cout << "###########################"  << endl;
    MyStack<int> s3(20);
    //Append
    cout << "Append stack s3 = s1+s2" << endl;
    s3 = s1 + s2;
    s3.Print();

    cout << "###########################"  << endl;
    //print with [] operators
    cout <<"print s2[0] = ";
    cout << s2[0] <<endl ;

    cout << "###########################"  << endl;
    MyStack<char> s4(7);
    s4.Push('A');
    s4.Push('B');
    s4.Push('C');
    s4.Push('D');
    //print s4
    cout << "s4(char stack) is " << endl;
    s4.Print();
}
