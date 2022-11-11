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



char user_input[10];

void LineEditor (int col, int row, int start_ch, int end_ch)
{
    int i=0;
    char ch;
    user_input[10] = "";
    int loopflag=0, start=0, end=0, current=0;

   // int* current_ptr = 0;


    for (i=0;i<10;i++)
    {
        gotoxy(col+i,row);
        textattr(HighLightPen);
        printf(" ");

    }


    do
    {
        gotoxy(col+current,row);
        ch = getch();
        if(ch>=start_ch && ch<=end_ch)
        {
            if(end <10)
            {
                user_input[current] = ch;
                printf("%c", ch);
                current++;
                end++;
            }
        }
        else if (ch == 27)
        {
            loopflag=1;
        }
        else if (ch == 13)
        {
            user_input[current] = '\0';

            loopflag=1;
        }

        else if(!isprint(ch))
        {
            ch = getch();
            switch (ch)
            {
                //home
                case 71:
                    current = start;
                break;
                //end
                case 79:
                    current = end;
                break;
                //left
                case 75:
                    current--;
                    if(current < start)
                        current = start;
                break;
                //right
                case 77:
                    current++;
                    if(current > end)
                        current = end;
                break;
            }
        }
    } while(!loopflag);
    return user_input[10];
}

///Integrating this menu with 10 employees
void AddEmployee ()
{
    char override_flag;
    int emp_index;
    _flushall();
    scanf("%i", &emp_index);

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

    //get data from user

    //id
    _flushall();
    LineEditor(15,5,48,57);
    emp[emp_index].ID = atoi(user_input);

    //name
   _flushall();
   LineEditor(15,10, 'A','z');
   strcpy(emp[emp_index].Name, user_input);
    //age
    _flushall();
    LineEditor(15,15,48,57);
    emp[emp_index].age = atoi(user_input);
    //gender
    _flushall();
   LineEditor(15,20, 'A','z');
   //strcpy(emp.gender, user_input);
   emp[emp_index].gender = user_input;
    //address
    _flushall();
   LineEditor(15,25, 'A','z');
   strcpy(emp[emp_index].Address, user_input);
    //salary
    _flushall();
    LineEditor(50,5,48,57);
    emp[emp_index].salary = atoi(user_input);
    //overtime
    _flushall();
    LineEditor(50,10,48,57);
    emp[emp_index].overtime = atoi(user_input);
    //tax
    _flushall();
    LineEditor(50,15,48,57);
    emp[emp_index].tax = atoi(user_input);
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

