#include <iostream>

using namespace std;

template <class Type1>
class MyQueue
{
    Type1* que;
    int Size;
    int tail;
    int head;
    int no_of_elements;

public:
    MyQueue(Type1 S)
    {
        Size = S;
        tail = 0;
        head = 0;
        que = new Type1[Size];
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

    void ENQ (Type1 n)
    {
        if (!ISFull())
        {
            if (tail==Size)
            {
                tail = 0;
            }
            que[tail] = n;
            tail++;
            no_of_elements++;
        }
        else
        {
            cout << "Queue is full\n";
        }
    }
    Type1 DEQ ()
    {
        if (!ISEmpty())
        {
              if(head == Size )
              {
                  head = 0;
              }
              no_of_elements--;
              return que[head++];
        }
        else
        {
            cout << "Queue is empty\n";
            return -1;
        }
    }
    Type1 Peek ()
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
    void Print();
    ~MyQueue()
    {
        delete []que;
    }
};


template <class Type2>
void MyQueue<Type2>::Print()
{
   // cout << TOS <<endl;
    for(int i =head; i != tail; i = (i+1) % Size)
    {

        cout << que[i] << " ,";
    }
    cout << " \n";
}



int main()
{

    //queue 1
    MyQueue<int> q1(6);
    q1.ENQ(4);
    q1.ENQ(5);
    q1.ENQ(6);
    q1.ENQ(7);
    q1.ENQ(8);
    q1.ENQ(9);
    cout << "q1(int queue) is" <<endl;
    cout<< q1.DEQ() << ",";
    cout<< q1.DEQ() << ",";
    cout<< q1.DEQ() << ",";
    cout<< q1.DEQ() << ",";
    cout<< q1.DEQ() << ",";
    cout<< q1.DEQ() << endl;



    //queue 2
    MyQueue<char> q2(6);
    q2.ENQ('A');
    q2.ENQ('B');
    q2.ENQ('C');
    q2.ENQ('D');
    q2.ENQ('E');
    q2.ENQ('F');
    cout << "q2 (char queue) is" <<endl;
    cout<< q2.DEQ() << ",";
    cout<< q2.DEQ() << ",";
    cout<< q2.DEQ() << ",";
    cout<< q2.DEQ() << ",";
    cout<< q2.DEQ() << ",";
    cout<< q2.DEQ() << endl;


}
