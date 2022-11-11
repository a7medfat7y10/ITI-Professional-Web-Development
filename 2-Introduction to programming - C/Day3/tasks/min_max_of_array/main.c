#include <stdio.h>

int main()
{
    int values[5],
        i;
    //input values
    for (i = 0; i < 5 ; i++ )
    {
        printf("Enter your no. %i value", i+1);
        scanf("%i", &values[i]);
    }

    int max=values[0],
        min=values[0];
    // get max
    for (i = 0; i < 5 ; i++ )
    {
        if (values[i] > max )
        {
            max = values[i];
        }
    }
    printf("The maximum value is %i \n", max);


    //get minimum
    for (i = 0; i < 5 ; i++ )
    {
        if (values[i] < min )
        {
            min = values[i];
        }
    }
    printf("The minimum value is %i\n", min);


    return 0;
}


















