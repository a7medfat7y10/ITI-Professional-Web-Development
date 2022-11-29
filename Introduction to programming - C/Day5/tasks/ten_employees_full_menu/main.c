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

//define an object from this employee struct
struct Employee emp[10];

///Integrating this menu with 10 employees
void AddEmployee ();
void DisplayEmployeeByID ();
void DisplayAllEmployees();
void DeleteEmployeeByID ();
void DeleteEmployeeByName ();



int main()
{
    int emp_index,emp_id, emp_name;
    int i;
    for (i=0;i<10;i++)
    {
        emp[i].ID = -1;
    }

    //2d array to store the menu
    char Menu[6][15] = {"New           ", "Display By ID ", "Display All   ", "Delete By ID  ", "Delete By Name" ,"Exit          "}, ch;
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
        for (i = 0; i< 6 ; i++)
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
                        printf("Enter index:");

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
                    case 4: //delete by name
                        system("cls");
                        printf("Enter Name:");

                        DeleteEmployeeByName();
                        _getch();
                    break;
                    case 5: //exit
                        ExitFlag = 1;
                    break;
                }
            break;

            //Exit
            case ESC:
                ExitFlag=1;
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
                            current = 5;
                        }
                    break;
                    //down
                    case 80:
                        current++;
                        if (current > 5 )
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
                        current=5;
                    break;
                }
            break;
        }
    } while (!ExitFlag);
}


///Integrating this menu with 10 employees
void AddEmployee ()
{
    char override_flag;
    int emp_index;
    _flushall();
    scanf("%i", &emp_index);
    if(emp[emp_index].ID != -1)
    {
        printf("This index contains an existing employee! \n sure you want to override?\n");
        printf("y or n?");
        _flushall();
        scanf("%c", &override_flag);
        if(override_flag == 121)
        {
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
            gotoxy(15, 5);
            _flushall();
            scanf("%i",&emp[emp_index].ID );
            gotoxy(15, 10);
            _flushall();
            scanf("%s",emp[emp_index].Name );
            gotoxy(15, 15);
            _flushall();
            scanf("%i",&emp[emp_index].age );
            gotoxy(15, 20);
            _flushall();
            scanf("%c",&emp[emp_index].gender );
            gotoxy(15, 25);
            _flushall();
            scanf("%s",&emp[emp_index].Address );
            gotoxy(50, 5);
            _flushall();
            scanf("%lf",&emp[emp_index].salary);
            gotoxy(50, 10);
            _flushall();
            scanf("%lf",&emp[emp_index].overtime);
            gotoxy(50, 15);
            _flushall();
            scanf("%lf",&emp[emp_index].tax);
        }
        else if (override_flag == 110)
        {
            AddEmployee();
        }
    }
    else
    {
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
        gotoxy(15, 5);
        _flushall();
        scanf("%i",&emp[emp_index].ID );
        gotoxy(15, 10);
        _flushall();
        scanf("%s",emp[emp_index].Name );
        gotoxy(15, 15);
        _flushall();
        scanf("%i",&emp[emp_index].age );
        gotoxy(15, 20);
        _flushall();
        scanf("%c",&emp[emp_index].gender );
        gotoxy(15, 25);
        _flushall();
        scanf("%s",&emp[emp_index].Address );
        gotoxy(50, 5);
        _flushall();
        scanf("%lf",&emp[emp_index].salary);
        gotoxy(50, 10);
        _flushall();
        scanf("%lf",&emp[emp_index].overtime);
        gotoxy(50, 15);
        _flushall();
        scanf("%lf",&emp[emp_index].tax);
    }

}


void DisplayEmployeeByID ()
{
    int emp_id;
    _flushall();
    scanf("%i", &emp_id);
    system("cls");

    int i,ind;
    //emp_id = -1 //default
    if (emp_id != -1 && emp_id > 0)
    {
        for (i = 0;i< 10; i++)
        {
            if(emp_id == emp[i].ID)
            {
                printf("Employee no.%i \n id: %i Name: %s Age %i Salary %lf And Net Salary %lf \n",i+1, emp[i].ID, emp[i].Name, emp[i].age, emp[i].salary,
                    emp[i].salary + emp[i].overtime - emp[i].tax);
                ind = i;
            }
        }
    }
    else {
        printf("NO employee found");
    }

    if(emp_id != emp[ind].ID) {
        printf(" This id %d does not exist", emp_id);
    }
}


void DisplayAllEmployees()
{
    system("cls");

    int i;
    for (i = 0;i< 10; i++)
    {
        if(emp[i].ID != -1)
        {
            printf("Employee no.%i \n id: %i Name: %s Age %i Salary %lf And Net Salary %lf \n",i+1, emp[i].ID, emp[i].Name, emp[i].age, emp[i].salary,
                    emp[i].salary + emp[i].overtime - emp[i].tax);
        }

    }

}

void DeleteEmployeeByID ()
{
    int emp_id, i,j;
    _flushall();
    scanf("%i", &emp_id);
    for (i = 0; i<10; i++)
    {
        if (emp_id == emp[i].ID)
        {
            printf("employee %i deleted successfully!", emp[i].ID);
            emp[i].ID=-1;
        }

    }
}

void DeleteEmployeeByName ()
{
    char emp_name[100];
    _flushall();
    gets(emp_name);
    int i;
    for (i = 0; i<10; i++)
    {
        if (strcmp(emp_name, emp[i].Name) == 0)
        {
            printf("employee %s deleted successfully!", emp[i].Name);
            emp[i].ID=-1;
        }
    }
}

