#include <stdio.h>
#include <stdlib.h>
#include <string.h>


int main()
{
    char FirstName[10], LastName[10];

    printf("First Name\n");
    gets(FirstName);

    printf("Last Name\n");
    gets(LastName);

    strcat(FirstName, " ");
    strcat(FirstName, LastName);

    printf("User Name: ");
    puts(FirstName);

}
