#include <stdio.h>
#include <stdlib.h>

void swap_by_value(int x, int y)
{
    int temp = x;
    x = y;
    y = temp;
}

void swap_by_address(int* x, int* y)
{
    int temp = *x;
    *x = *y;
    *y = temp;
}

int main()
{
    int a;
    int b;

    printf ("Enter the first number");
    _flushall();
    scanf("%i", &a);

    printf ("Enter the second number");
    _flushall();
    scanf("%i", &b);

    swap_by_value(a,b);
    printf("a is %i\n", a);
    printf("b is %i\n\n", b);

    swap_by_address(&a,&b);
    printf("a is %i\n", a);
    printf("b is %i\n", b);
}
