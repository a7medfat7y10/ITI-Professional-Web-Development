#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include<windows.h>
//defines to highlight in console
#define NormalPen 0x0F
#define HighLightPen 0XF0
//define hexa code for enter and esc used in switch case
#define Enter 0x0D
#define ESC 27

#include<iostream>


using namespace std;

//given function to draw in console
void gotoxy( int column, int line )
{
    COORD coord;
    coord.X = column;
    coord.Y = line;
    SetConsoleCursorPosition(
    GetStdHandle( STD_OUTPUT_HANDLE ),
    coord
    );
}

//given function to write in console
void textattr (int i)
{
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
}


//defining struct for Employee
struct Employee
{
    int ID, age;
    char gender, Name[100], Address[200];
    double salary , overtime, tax;
};

struct Node
{
    Employee Data;
    Node* Pnext;
    Node* Pprev;

};
Node* Pstart;
Node* Plast;

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


void AddNode(Employee E)
{
    Node* Pnew = NewNode(E);
    if (Plast ==  NULL)
        Plast = Pstart =  Pnew;
    else
    {
        Plast->Pnext = Pnew;
        Pnew->Pprev = Plast;
        Plast = Pnew;
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

void Display(int id)
{
    Node* Pdisplay = SearchList(id);
    if (Pdisplay == NULL)
    {
        cout << "Employee Not Found";
    }
    else
    {
        cout << "ID " << Pdisplay->Data.ID<<endl;
        cout << "Name " << Pdisplay->Data.Name<<endl;
        cout << "Age " << Pdisplay->Data.age<<endl;
        cout << "Salary " << Pdisplay->Data.salary<<endl;
    }
}

void DisplayAll()
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

void Delete(int id)
{
    Node* Pdelete = SearchList(id);
    if (Pdelete == NULL)
        cout << "Not Found";
    else if (Pstart == Plast)
        Pstart = Plast = NULL;
    else if (Pstart == Pdelete)
    {
        Pstart = Pstart->Pnext;
        Pstart->Pprev = NULL;
    }
    else if ( Plast == Pdelete)
    {
        Plast = Plast->Pprev;
        Plast->Pnext= NULL;
    }
    else
    {
        Pdelete->Pprev->Pnext = Pdelete->Pnext;
        Pdelete->Pnext->Pprev = Pdelete->Pprev;
    }
    delete Pdelete;
}

void DeleteAll()
{
    Node* Pdelete;
    while (Pstart!=NULL)
    {
        Pdelete = Pstart;
        Pstart= Pstart->Pnext;;
        delete Pdelete;
    }
    Plast= NULL;
}

void InsertNode(Employee E)
{
    //create new node
    Node* Pnew = NewNode(E);

    //check if the list is empty
    if (Pstart == NULL)
    {
        Pstart = Plast = NULL;
    }
    else
    {
        //Psearch to the find the position to add in it
        Node* Psearch = Pstart;

        //if there still are elements in the list move to the position
        //where all the left elements are less than the psearch
        while ((Psearch != NULL) && (Psearch->Data.ID < E.ID))
            Psearch = Psearch->Pnext;

        //if Psearch is now at the last element so this adds after Plast
        if(Psearch == NULL)
        {
            Plast->Pnext = Pnew;
            Pnew -> Pprev = Plast;
            Plast = Pnew;
        }
        //if it is to add before the first element
        else if(Psearch == Pstart)
        {
            Pstart->Pprev = Pnew;
            Pnew->Pnext = Pstart;
            Pstart = Pnew;
        }
        else
        {
            Node* Ptemp = Psearch->Pprev;
            Psearch->Pprev = Pnew;
            Pnew->Pnext = Psearch;
            Pnew->Pprev = Ptemp;
            Ptemp->Pnext= Pnew;
        }
    }
}




//define an object from this employee struct
//struct Employee emp[10];

///Integrating this menu with 10 employees
void AddEmployee ();
void DisplayEmployeeByID ();
void DisplayAllEmployees();
void DeleteEmployeeByID ();


int main()
{
    int emp_index,emp_id, emp_name;
    int i;

    //2d array to store the menu
    char Menu[5][15] = {"New           ", "Display By ID ", "Display All   ", "Delete By ID  ","Exit          "}, ch;
    int current = 0, ExitFlag = 0;

    //use do while to do this if the exit flag is not 0
    do
    {
        //use normal pen
        textattr(NormalPen);
        //clear screen -- using system to use terminal commmands
        system("cls");

        //loop through the menu 3 elements new, save and exit
        //highlight the current element
        for (i = 0; i< 5 ; i++)
        {
            if (current == i)
            {
                textattr(HighLightPen);
            }
            else
            {
                textattr(NormalPen);
            }

            //gotoxy (col, row)
            gotoxy(15, 10+(3*i));
            //print new, save , exit from menu array in the desired location by gotoxy
            printf("%s", Menu[i]);
        }

        //receive char from the user
        ch = _getch();

        switch(ch)
        {
            //Enter
            case Enter:
                switch (current)
                {
                    case 0: //new
                        system("cls");

                        AddEmployee();
                        _getch();
                    break;
                    case 1: //display by id
                        system("cls");
                        printf("Enter ID:");

                        DisplayEmployeeByID();
                        _getch();
                    break;
                    case 2: //display all
                        system("cls");

                        DisplayAllEmployees();
                        _getch();
                    break;
                    case 3: //delete by id
                        system("cls");
                        printf("Enter ID:");

                        DeleteEmployeeByID();
                        _getch();
                    break;
                    case 4: //exit
                        ExitFlag = 1;
                        textattr(NormalPen);
                    break;
                }
            break;

            //Exit
            case ESC:
                ExitFlag=1;
                textattr(NormalPen);
            break;

            //Extended
            case -32:
                //recieve second char //get second byte from buffer
                ch = _getch();

                switch(ch)
                {
                    //up
                    case 72:
                        current--;
                        if (current < 0)
                        {
                            current = 4;
                        }
                    break;
                    //down
                    case 80:
                        current++;
                        if (current > 4)
                        {
                            current = 0;
                        }
                    break;
                    //home
                    case 71:
                        current=0;
                    break;
                    //end
                    case 79:
                        current=4;
                    break;
                }
            break;
        }
    } while (!ExitFlag);
}





///Integrating this menu with 10 employees

void AddEmployee ()
{
    _flushall();
    system("cls");

    //print form
    gotoxy(5, 5);
    printf("Id:" );
    gotoxy(5, 10);
    printf("Name:" );
    gotoxy(5, 15);
    printf("Age:" );
    gotoxy(5, 20);
    printf("Gender:" );
    gotoxy(5, 25);
    printf("Address:" );
    gotoxy(40, 5);
    printf("Salary:" );
    gotoxy(40, 10);
    printf("overtime:" );
    gotoxy(40, 15);
    printf("Tax:" );

    //get data from user
    Employee emp;

    gotoxy(15, 5);
    _flushall();
    scanf("%i",&emp.ID );
    gotoxy(15, 10);
    _flushall();
    scanf("%s",emp.Name );
    gotoxy(15, 15);
    _flushall();
    scanf("%i",&emp.age );
    gotoxy(15, 20);
    _flushall();
    scanf("%c",&emp.gender );
    gotoxy(15, 25);
    _flushall();
    scanf("%s",&emp.Address );
    gotoxy(50, 5);
    _flushall();
    scanf("%lf",&emp.salary);
    gotoxy(50, 10);
    _flushall();
    scanf("%lf",&emp.overtime);
    gotoxy(50, 15);
    _flushall();
    scanf("%lf",&emp.tax);



    AddNode(emp);


    //Insert sorted items
    Employee emp2 = {10, 22, 'm', "Ahmed", "aaaaaaaa", 3000, 200, 50};
    InsertNode(emp2);
    Employee emp3 = {5, 22, 'm', "Ahmed", "aaaaaaaa", 3000, 200, 50};
    InsertNode(emp3);
    Employee emp4 = {6, 22, 'm', "Ahmed", "aaaaaaaa", 3000, 200, 50};
    InsertNode(emp4);

}
void DisplayEmployeeByID ()
{
    int emp_id;
    _flushall();
    scanf("%i", &emp_id);
    system("cls");

    Display(emp_id);


}
void DisplayAllEmployees()
{
    system("cls");
    DisplayAll();

}
void DeleteEmployeeByID ()
{
    int emp_id;
    _flushall();
    scanf("%i", &emp_id);
    Delete(emp_id);
}
