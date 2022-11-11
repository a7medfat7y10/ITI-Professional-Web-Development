#include <stdio.h>
#include <stdlib.h>

int main()
{
    int i;
    int items[6];
    for (i = 0 ; i < 6; i++)
    {
        printf("Enter your no. %i item", i+1);
        scanf("%i", &items[i]);
    }
    printf("The items you entered are \n ");
    for (i=0 ; i < 6 ; i++)
    {
        printf("%i",items[i]);
        printf("\n");
    }
    return 0;
}
