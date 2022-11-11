#include <iostream>

using namespace std;


class MyQueue
{
    int* que;
    int Size;
    int tail;
    int head;
    int no_of_elements;

public:
    MyQueue(int S)
    {
        Size = S;
        tail = 0;
        head = 0;
        que = new int[Size];
        no_of_elements = 0;
    }
    int ISFull()
    {
        return (no_of_elements == Size);
    }
    int ISEmpty()
    {
        return (no_of_elements == 0);
    }

    void ENQ (int n)
    {
        if (!ISFull())
        {
            que[tail++] = n;
            no_of_elements++;
        }
        else
        {
            cout << "Queue is full\n";
        }
    }
    int DEQ ()
    {
        if (!ISEmpty())
        {
            int return_value = que[0];
            for(int i=0;i<tail-1;i++){
                que[i]=que[i+1];
            }
            no_of_elements--;
            tail--;
            return return_value;
        }
        else
        {
            cout << "Queue is empty\n";
            return -1;
        }
    }
    int Peek ()
    {
        if (!ISEmpty())
        {
            return que[head];
        }
        else
        {
            cout << "Queue is empty\n";
            return -1;
        }
    }
    int GetCount()
    {
        return no_of_elements;
    }
    ~MyQueue()
    {
        delete []que;
    }
};


int main()
{
    MyQueue q1(6);
    q1.ENQ(4);
    q1.ENQ(5);
    q1.ENQ(6);
    q1.ENQ(7);
    q1.ENQ(8);
    q1.ENQ(9);

    cout<< q1.DEQ() <<endl; //4

    cout<< q1.GetCount() <<endl; //5

    q1.ENQ(10);

    cout<< q1.DEQ() <<endl; //5
    cout<< q1.DEQ() <<endl; //6
    cout<< q1.DEQ() <<endl; //7
    cout<< q1.DEQ() <<endl; //8
    cout<< q1.Peek() <<endl; //9
    cout<< q1.DEQ() <<endl; //9

    cout<< q1.GetCount() <<endl; //1

    q1.ENQ(11);
    q1.ENQ(12);
    q1.ENQ(13);
    q1.ENQ(14);

    cout<< q1.DEQ() <<endl; //10

    cout<< q1.GetCount() <<endl; //4
}
