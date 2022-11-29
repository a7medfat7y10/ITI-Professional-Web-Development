#include <iostream>

using namespace std;


class Employee
{
public:
    int ID,age;
    double salary, overtime,tax;
    string Name,Address,Gender;
    Employee()
    {

    }
    Employee (int _id,  int _age, char gender,  string _name, string _address,double _salary, double _overtime, double _tax)
    {
        Name=_name;
        age=_age;
        ID=_id;
        Address=_address;
        salary=_salary;
        tax = _tax;
        overtime = _overtime;
    }
};

//double linked list
class Node
{
public:
    Employee Data;
    Node* Pnext;
    Node* Pprev;

};


//adding new node
Node* NewNode(Employee E)
{
    Node* Pnew = new Node();
    if(Pnew == NULL)
        exit(0);
    Pnew->Data = E;
    Pnew->Pnext = Pnew->Pprev = NULL;
    return Pnew;
}




 class MyQueue
{
    public:
        Node* Pstart;
        Node* Plast;

        MyQueue( )
        {
            Pstart = Plast = NULL;
        }
         ~MyQueue()
         {
            // cout<<"destrucor\n";

         }
    bool isfull(){return false;}

    bool isEmpty()
    {
        if(Pstart==NULL)
            return true;
        return false;
    }


    void ENQ(Employee E)
    {
        Node* Pnew = NewNode(E);
        if (isEmpty()){
            Pnew->Pprev = NULL;
            Pnew->Pnext = NULL;
            Plast = Pstart =  Pnew;
        }
        else
        {
            Plast->Pnext = Pnew;
            Pnew->Pprev = Plast;
            Plast = Pnew;
        }
    }


    int DEQ ()
    {
        Node * Pnew=Pstart;

        if (isEmpty())
                printf("Queue is empty");
        else if (Plast == Pstart) {
                Plast = NULL;
                Pstart = NULL;
                delete Pnew;
        }
        else
        {
            printf("%i\n\n", Pstart->Data.ID);
            Pstart=Pstart->Pnext;
            Pstart->Pprev=NULL;
            delete Pnew;
        }
    }


    Node* Peek ()
    {
        Node* Pnew = Pstart;
        if (isEmpty())
                printf("Stack is empty");
        else {
            printf("%i\n\n",Pstart->Data.ID);
        }
    }

    Node* SearchList(int id)
    {
        Node* Psearch = Pstart;
        while (Psearch != NULL)
        {
            if (Psearch->Data.ID == id)
                break;
            Psearch = Psearch->Pnext;
        }
        return Psearch;
    }

    void ViewContent()
    {
        Node* Pdisplay = Pstart;
        if (Pdisplay == NULL)
        {
            cout << "No Employees Found";
        }
        while (Pdisplay != NULL)
        {
            cout << "ID " << Pdisplay->Data.ID<<endl;
            cout << "Name " << Pdisplay->Data.Name<<endl;
            cout << "Age " << Pdisplay->Data.age<<endl;
            cout << "Salary " << Pdisplay->Data.salary<<endl;
            cout<<"\n";
            Pdisplay = Pdisplay->Pnext;
        }
    }



};


int main()
{
    MyQueue q1,q2;

    q1.ENQ(Employee(1, 22, 'm', "Ahmed", "aaaaaaaaaaa", 1000, 200, 50));
    q1.ENQ(Employee(3, 25, 'f', "Ali", "sssssssssssss", 2000, 200, 50));
    q1.ENQ(Employee(7, 30, 'f', "Anan", "dddddddddddd", 3000, 200, 50));

    q1.DEQ();
    q1.ViewContent();

    q2.ENQ(Employee(2, 29, 'm', "Alaa", "aaaaaaaaaaa", 1000, 200, 50));
    q2.ENQ(Employee(4, 25, 'f', "soha", "sssssssssssss", 2000, 200, 50));
    q2.ENQ(Employee(8, 30, 'f', "eman", "dddddddddddd", 3000, 200, 50));

    q2.DEQ();
    q2.ViewContent();
}
