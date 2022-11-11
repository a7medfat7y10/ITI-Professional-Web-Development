#include <stdio.h>
#include <stdlib.h>

int main()
{
    int i,j;
    int** marks;
    int* sum;
    int* avg;
    int students_no, subjects_no;
    //get data from the user
    printf("Enter students no: ");
    scanf("%i", &students_no);
    printf("Enter subjects no: ");
    scanf("%i", &subjects_no);

    //allocate memory for the number of students.. each has a pointer to the array of number of subjects
    marks = (int**) malloc(students_no * sizeof(int*));

    for (i=0; i<students_no; i++)
    {
        marks[i] = (int*) malloc(subjects_no * sizeof(int));
    }

    //allocate memory to store results for sum and avg
    sum = (int*) malloc (students_no * sizeof(int));
    avg = (int*) malloc (subjects_no * sizeof(int));

    //initializing sum and average with zero
    for (i=0; i<students_no;i++)
    {
        sum[i] = 0;
    }
    for (j=0; j<subjects_no;j++ )
    {
        avg[j] = 0;
    }



    //calculating sum and average
    for (i=0; i< students_no; i++)
    {
        for (j=0;j<subjects_no;j++)
        {
            printf("Enter student %i subject %i ", i+1, j+1);
            scanf("%i", &marks[i][j]);
            sum[i] +=marks[i][j];
            avg[j] +=marks[i][j];
        }
    }

    for (i=0;i<subjects_no;i++)
    {
        avg[i] /= students_no;
    }

    for (i=0;i<students_no;i++)
    {
        printf("Sum for student %i is %i \n", i+1 ,sum[i]);
    }
    for (j=0;j<subjects_no;j++)
    {

        printf("avg for subject %i is %i \n",j+1 , avg[j]);
    }



    for (i=0;i<students_no;i++)
    {
        free(marks[i]);
    }
    free(marks);
    free(sum);
    free(avg);

}
