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



int main()
{
    //2d array to store the menu
    char Menu[3][5] = {"New ", "Save", "Exit"}, ch;

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
                        printf("Enter new Data\n");
                        _getch();
                    break;
                    case 1: //save
                        system("cls");
                        printf("Saved Successfully! press any button to go back to menu");
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
