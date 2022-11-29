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
    char gender;
    char* Name, Address;
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
char** MultiLineEditor(int c, int* size, int* col, int* row, int* start_ch, int* end_ch);






int main()
{
    //Define arrays to pass to multi-line editor
    int sizes[8] = {3, 10, 3, 1, 15, 8, 8, 8};
    int col[8] = {15, 15, 15, 15, 15, 50, 50, 50};
    int row[8] = {5, 10, 15, 20, 25, 5, 10, 15};
    int start_ch[8] = {48, 65, 48, 65, 65, 48, 48, 48};
    int end_ch[8] = {57, 122, 57, 122,122, 57, 57, 57};

    char** empData;


    int emp_index,emp_id, emp_name;

    int i;

    //default id values to filter them from display
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
                        int emp_index;
                        _flushall();
                        scanf("%i", &emp_index);
                        AddEmployee();
                        empData = MultiLineEditor(8, sizes, col, row, start_ch, end_ch);
                        emp[emp_index].ID = atoi(empData[0]);
                        emp[emp_index].Name = empData[1];
                        emp[emp_index].age = atoi(empData[2]);
                        emp[emp_index].gender = empData[3];
                        emp[emp_index].Address = empData[4];
                        emp[emp_index].salary = atof(empData[5]);
                        emp[emp_index].overtime = atof(empData[6]);
                        emp[emp_index].tax = atof(empData[7]);
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
                        //Display (empData);
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





char** MultiLineEditor(int c, int* size, int* col, int* row, int* start_ch, int* end_ch)
{
    char ch;
    int loopflag = 0;

    ///Allocate memory for an array to get the user input in one filed and store them all in this array
    //char* user_input[10];
    char** user_input = (char**) malloc(c * sizeof(char*));

    int current_field = 0;
    //for each field
    int start = 0, end = 0, last_position = 0, temp_current = 0;
    //to save the last position of cursor in each field
    int last_positions [8] = {0, 0, 0, 0, 0, 0, 0, 0};

    // loop through the array to allocate memory for
    for(int i = 0; i < 8; i++)
    {
        user_input[i] = (char*) malloc(sizeof(char) * size[i]);
    }

    //highlight field
    int i;
    for (i=0;i<8;i++)
    {
        for(int j =0;j<size[i];j++)
        {
            gotoxy(col[i]+j,row[i]);
            textattr(HighLightPen);
            printf(" ");
        }
    }


    do
    {
        gotoxy(col[current_field]+temp_current,row[current_field]);

        ch = getch();

        if(ch>=start_ch[current_field] && ch<=end_ch[current_field] && temp_current < size[current_field])
        {
                user_input[current_field][temp_current] = ch;
                printf("%c", ch);
                temp_current++;
                last_position++;
                end++;
        }
        else if (ch == 27)
        {
            loopflag=1;
        }
        else if (ch == 13)
        {
            user_input[1][last_position + 1] = '\0';
            user_input[3][last_position + 1] = '\0';
            user_input[4][last_position + 1] = '\0';
            return user_input;
        }

        else if(!isprint(ch))
        {
            ch = getch();
            switch (ch)
            {
                //home
                case 71:
                    temp_current = start;
                break;
                //end
                case 79:
                    temp_current = end;
                break;
                //left
                case 75:
                    temp_current--;
                    if(temp_current < start)
                    {
                        temp_current = start;
                    }
                    last_position = temp_current;
                break;
                //right
                case 77:
                    temp_current++;
                    if(temp_current > size[current_field])
                        temp_current = size[current_field];
                    last_position = temp_current;
                break;
                //up
                case 72:
                    last_positions[current_field] = last_position;
                    current_field--;
                    if(current_field < 0){
                        current_field = 0;
                    }

                    temp_current = last_positions[current_field];
                    last_position = last_positions[current_field];
                break;
                //down
                case 80:
                    last_positions[current_field] = last_position;
                    current_field++;
                    if(current_field > c-1)
                        current_field = c-1;
                    temp_current = last_positions[current_field];
                    last_position = temp_current;
                break;
            }
        }
    } while (!loopflag);
    return user_input;
}

///Integrating this menu with 10 employees
void AddEmployee ()
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
    char* emp_name;
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
