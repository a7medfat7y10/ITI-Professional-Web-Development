#include <iostream>

using namespace std;

int Swap(int& x, int& y)
{
    int temp = x;
    x = y;
    y = temp;
}

void BubbleSort(int Arr[], int Size)
{
    bool sorted;
    for(int i=0;i<Size; i++)
    {
        sorted = true;
        for(int j =0;j<Size-i-1; j++)
        {
            if(Arr[j]>Arr[j+1])
            {
                Swap(Arr[j], Arr[j+1]);
                sorted = false;
            }
        }
        if (sorted) return;
    }
}


int main()
{
    int Arr[5] = {4, 2,5,3, 7};

    cout << "Array Before:" << endl;
    for (int i = 0;i<5;i++)
    {
        cout << Arr[i]<< endl;
    }

    BubbleSort(Arr, 5);
    cout << "Array After Bubble Sort: "<< endl;
    for (int i = 0;i<5;i++)
    {
        cout << Arr[i] << endl;
    }
    return 0;
}
