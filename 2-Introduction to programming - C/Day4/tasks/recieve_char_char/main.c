#include <stdio.h>
#include <stdlib.h>

int main()
{
    char Name[20], ch;
    int i;

    printf("Enter your name\n");
    for (i=0; i < 20; i++)
    {
        ch = getche();
        if (ch == 13)
        {
            Name[i] = '\0';
            break;
        }
        Name[i] = ch;
    }

    printf("\nHi ");
    i=0;
    while (Name[i] != '\0')
    {
        printf("%c", Name[i]);
        i++;
    }

}
