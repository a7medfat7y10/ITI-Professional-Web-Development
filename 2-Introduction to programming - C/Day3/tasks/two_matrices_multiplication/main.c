#include <stdio.h>
#include <stdlib.h>

int main()
{
    int matrix1[3][2];
    int matrix2[2][1];

    int result[3][1];

    //getting elements of the first matrix
    for (int i=0; i<3;i++)
    {
        for (int j=0;j<2;j++)
        {
            printf("enter row%i col%i in first matrix \n",i+1, j+1);
            scanf("%i", &matrix1[i][j]);
        }
    }


    //getting elements of the second matrix
    for (int i=0; i<2;i++)
    {
        for (int j=0;j<1;j++)
        {
            printf("enter row%i col%i in second matrix \n",i+1, j+1);
            scanf("%i", &matrix2[i][j]);
        }
    }


    int i,j,k;

    for(i=0; i<3;i++)
    {
        for(j=0;j<1;j++)
        {
            result[i][j]=0;
            for(k=0; k<2; k++)
            {
                result[i][j]+=matrix1[i][k]*matrix2[k][j];
            }
        }
    }


    for(int i=0;i<3;i++)
    {
        for(int j=0;j<1;j++)
        {
            printf("%i",result[i][j]);
        }
        printf("\n");
    }

    return 0;
}
