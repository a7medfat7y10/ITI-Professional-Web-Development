#include <stdio.h>
#include <stdlib.h>
#include <Windows.h>
#include <WinCon.h>
#include <string.h>
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


struct Employee
{
    int ID, age;
    char gender, Name[100], Address[200];
    double salary , overtime, tax;
};

int main()
{
    int i;
    struct Employee emp;

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
    scanf("%i",&emp.ID );
    gotoxy(15, 10);
    scanf("%s",emp.Name );
    gotoxy(15, 15);
    scanf("%i",&emp.age );
    gotoxy(15, 20);
    _flushall();
    scanf("%c",&emp.gender );
    gotoxy(15, 25);
    scanf("%s",&emp.Address );
    gotoxy(50, 5);
    scanf("%lf",&emp.salary);
    gotoxy(50, 10);
    scanf("%lf",&emp.overtime);
    gotoxy(50, 15);
    scanf("%lf",&emp.tax);

    ///clear screen
    system("cls");


    printf("You successfully entered all your data...\n");
    printf("Your Net Salary: %lf", emp.salary + emp.overtime - emp.tax);

}
