#include <stdio.h>
#include <stdlib.h>

int main()
{
    //solution 1
    int Arr[5], i, *ptr;
    ptr = Arr;

    for (i=0; i<5; i++)
    {
        printf("Enter no %i\n", i+1);
        scanf("%i", &ptr[i]);
    }
    printf("you entered \n");
    for (i=0; i<5; i++)
    {
        printf("%i\n", ptr[i]);

    }

    // solution 2
    int Arr2[5],*ptr2;
    ptr2 = &Arr2[0];

    for (i=0; i<5; i++)
    {
        printf("Enter no %i\n", i+1);
        _flushall();
        scanf("%i", ptr2);
        ptr2++;
    }
    ptr2 = Arr2;
    printf("you entered \n");
    for (i=0; i<5; i++)
    {
        printf("%i\n", *ptr2);
        ptr2++;
    }

}
