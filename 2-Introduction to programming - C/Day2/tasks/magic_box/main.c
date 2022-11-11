#include <stdio.h>
#include <Windows.h>
#include <WinCon.h>

void gotoxy( int column, int line );


void main()
{
    int order;

    do
    {
        printf ("Enter the order of the magic box\n");
        printf ("Please make sure that order is positive and odd number\n");
        scanf("%d", &order);
    }
    while (order<= 1 || order%2 == 0);

    int r, c;
    r = 1;
    c = order/2 +1;

    for (int i = 1; i <=order*order; i++)
    {
        gotoxy(c *3, r *3);
        printf("%i" , i);


        //if the int can be divided by order
        //go to the next row
        if (i%order == 0)
        {
            r++;
            if(r>order)
            {
                r = 1;
            }
        } //if int can not be divided
        //go to the previous row and column
        else {
            r--;
            c--;
            if(r < 1){
                r = order;
            }
            if (c <1) {
                c = order;
            }
        }


        /*
        //Another logic


        //if the int can be divided by order
        //go to the next row
        if (i%order == 0)
        {
            //if last row
            if (r == order)
            {
                r = 1;
            } //if not last row
            else
            {
                r++;
            }
        } //if int can not be divided
        //go to the previous row and column
        else {
            //if first row
            if (r == 1) {
                r = order;
            } else {
                r--;
            }
            //if first column
            if (c == 1) {
                c = order;
            } else {
                c--;
            }
        }
        */
    }

    return 0;
}



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


