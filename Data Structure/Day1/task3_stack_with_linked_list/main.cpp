#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include<windows.h>
#include<iostream>

using namespace std;

//defining class for Employee
class Employee
{
public:
    /*
    int ID, age;
    char gender, Name[100], Address[200];
    double salary , overtime, tax;*/
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

class MyStack
{
public:
    Node* Pstart;
    Node* Plast;

    MyStack()
    {
        Pstart = Plast = NULL;
    }

    bool isEmpty()
    {
        if (Pstart == NULL)
            return true;
        return false;
    }

    bool isfull(){return false;}

    void Push(Employee E)
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

    Employee pop()
    {
        Node* Pnew = Plast;
        if (isEmpty())
            printf("Stack is empty");
        else if (Plast == Pstart) {
            Plast = NULL;
            Pstart = NULL;
            delete Pnew;
        }
        else {
            printf("%i", Plast->Data.ID);
            Plast->Pprev->Pnext = NULL;
            Plast = Pnew->Pprev;
            delete Pnew;
        }
    }

    Employee Peek()
    {
        Node* Pnew = Plast;
        if (isEmpty())
            printf("Stack is empty");
        else {
            printf("%i",Plast->Data.ID);
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
    MyStack s1, s2;

    s1.Push(Employee(1, 22, 'm', "Ahmed", "aaaaaaaaaaa", 1000, 200, 50));
    //s1.Peek();
    s1.Push(Employee(3, 25, 'f', "Ali", "sssssssssssss", 2000, 200, 50));
    //s1.Peek();
    s1.Push(Employee(7, 30, 'f', "Anan", "dddddddddddd", 3000, 200, 50));
    //s1.Peek();
    //s1.pop();

    //s1.Peek();

    s1.ViewContent();

    s2.Push(Employee(2, 29, 'm', "Alaa", "aaaaaaaaaaa", 1000, 200, 50));
    //s2.Peek();
    s2.Push(Employee(4, 25, 'f', "soha", "sssssssssssss", 2000, 200, 50));
    //s2.Peek();
    s2.Push(Employee(8, 30, 'f', "eman", "dddddddddddd", 3000, 200, 50));
    //s2.Peek();

    s2.ViewContent();

    //s2.pop();




}
