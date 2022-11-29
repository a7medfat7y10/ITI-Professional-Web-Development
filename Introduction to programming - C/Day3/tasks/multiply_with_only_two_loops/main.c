#include <stdio.h>
#include <stdlib.h>

int main()
{
    int n, m, x;

    int i,j,k;

    //getting the orders from the user
    printf("No. of rows of first matrix\n");
    scanf("%i", &m);
    printf("No. of cols of first matrix and No. of rows  of second matrix\n");
    scanf("%i", &n);
    printf("Enter the number of cols of second matrix\n");
    scanf("%i", &x);


    int matrix1[m][n];
    int matrix2[n][x];


    //getting elements of the first matrix
    for (i=0; i<m;i++)
    {
        for (j=0;j<n;j++)
        {
            printf("enter r%i c%i in first matrix \n",i+1, j+1);
            scanf("%i", &matrix1[i][j]);
        }
    }


    //getting elements of the second matrix
    for (i=0; i<n;i++)
    {
        for (j=0;j<x;j++)
        {
            printf("enter r%i c%i in second matrix \n",i+1, j+1);
            scanf("%i", &matrix2[i][j]);
        }
    }

    int result[m][x];

    //loop through the two matrices
    for(i=0; i<m;i++)
    {
        for(j=0;j<x;j++)
        {
            result[i][j] = 0;
            for(k=0; k<n; k++)
            {
                result[i][j]+=matrix1[i][k]*matrix2[k][j];
            }
        }
    }


    //print the result
    for(int i=0;i<m;i++)
    {
        for(int j=0;j<x;j++)
        {
            printf("%i \t",result[i][j]);
        }
        printf("\n");
    }

    return 0;
}
