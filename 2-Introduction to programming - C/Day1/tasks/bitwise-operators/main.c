#include <stdio.h>

int main() {
    int a, b;
    printf("Enter two numbers\n");
    scanf("%d", &a);
    scanf("%d", &b);
    printf("And = %d \n", a & b);
    printf("OR = %d \n", a | b);
    printf("XOR = %d \n", a ^ b);

    return 0;
}
