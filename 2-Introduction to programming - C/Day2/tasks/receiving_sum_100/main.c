#include <stdio.h>

int main()
{
    int x, sum =0;

    do
    {
        printf("Enter numbers: ");
        scanf("%d", &x);
        sum += x;
    } while(sum  <= 100);

    printf("The sum is %i", sum);
    return 0;
}
