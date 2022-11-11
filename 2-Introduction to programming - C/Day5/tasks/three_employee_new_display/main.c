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

struct Employee
{
    int ID, age;
    char gender, Name[100], Address[200];
    double salary , overtime, tax;
};

struct Employee emp[3];

///Integrating this menu with 3 employees
void AddThreeEmployees ()
{

    int i;
    for (i=0;i<3;i++)
    {
        system("cls");
        printf("Employee %i", i+1);
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
        scanf("%i",&emp[i].ID );
        gotoxy(15, 10);
        scanf("%s",emp[i].Name );
        gotoxy(15, 15);
        scanf("%i",&emp[i].age );
        gotoxy(15, 20);
        _flushall();
        scanf("%c",&emp[i].gender );
        gotoxy(15, 25);
        scanf("%s",&emp[i].Address );
        gotoxy(50, 5);
        scanf("%lf",&emp[i].salary);
        gotoxy(50, 10);
        scanf("%lf",&emp[i].overtime);
        gotoxy(50, 15);
        scanf("%lf",&emp[i].tax);
    }
}


void DisplayThreeEmployees ()
{
    system("cls");
    int i;
    for (i = 0;i< 3; i++)
    {
        printf("Employee no.%i \n id: %i Name: %s Age %i Salary %lf And Net Salary %lf \n",i+1, emp[i].ID, emp[i].Name, emp[i].age, emp[i].salary,
                emp[i].salary + emp[i].overtime - emp[i].tax);
    }

}




int main()
{




    //2d array to store the menu
    char Menu[3][8] = {"New    ", "Display", "Exit   "}, ch;

    int i, current = 0, ExitFlag = 0;

    //use do while to do this if the exit flag is not 0
    do
    {
        //use normal pen
        textattr(NormalPen);
        //clear screen -- using system to use terminal commmands
        system("cls");

        //loop through the menu 3 elements new, save and exit
        //highlight the current element
        for (i = 0; i< 3 ; i++)
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
                        AddThreeEmployees();
                        _getch();
                    break;
                    case 1: //display
                        system("cls");
                        DisplayThreeEmployees();
                        _getch();
                    break;
                    case 2: //exit
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
                            current = 2;
                        }
                    break;
                    //down
                    case 80:
                        current++;
                        if (current > 2 )
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
                        current=2;
                    break;
                }
            break;
        }
    } while (!ExitFlag);
}
