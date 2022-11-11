#include <stdio.h>
#include <stdlib.h>

int main()
{
    int choice;
    printf("If you are an administrator enter 1\n");
    printf("If you are an editor enter 2\n");
    printf("If you are a user enter 3\n");
    scanf("%i", &choice);

    switch (choice)
    {
        case 1:
        printf("hello administrator");
        break;

        case 2:
        printf("hello editor");
        break;

        case 3:
        printf("hello user");
        break;

        default:
        printf("please enter a number from 1 to 3");
        break;

    }

    return 0;
}
