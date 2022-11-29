#include <stdio.h>
#include <stdlib.h>

int main()
{
    //array
    /*
    int marks[3][4] ={{1,2,3,4},
                      {5,6,7,8},
                      {9,10,11,12}};
    */

    int marks [3][4];
    for(int i = 0; i<3;i++)
    {
        for(int j=0;j<4;j++)
        {
            printf("Enter row%i col%i ", i+1, j+1);
            scanf("%i", &marks[i][j]);
        }
    }

    //sum of each row
    int i,j, sum;
    for(i=0;i<3;i++)
    {
        sum = 0;
        for (j=0;j<4;j++)
        {
            sum += marks[i][j];
        }
        printf("The sum of row no. %i is %i\n",i+1,sum);
    }


    printf("\n");

    //average of each column
    int sum_column,k,l;
    float avg;

    for (k=0; k<4 ; k++)
    {
        sum_column=0;
        for (l=0; l<3 ; l++)
        {
            sum_column+=marks[l][k];
        }
        printf("The sum of column no. %i is %i\n",k+1,sum_column);
        avg = sum_column/3;
        printf("The avg of column no. %i is %f\n",k+1,avg);
    }

    return 0;
}
