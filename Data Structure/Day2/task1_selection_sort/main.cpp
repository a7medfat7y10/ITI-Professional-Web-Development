#include <iostream>

using namespace std;

int Swap(int& x, int& y)
{
    int temp = x;
    x = y;
    y = temp;
}

int IndexOfMinValue(int Arr[], int start_index, int end_index)
{
    int Position = start_index;
    for (int i=start_index; i<end_index; i++)
    {
        if (Arr[i] < Arr[Position])
        {
            Position = i;
        }
    }
    return Position;
}

void SelectionSort(int Arr[], int Size)
{
    int Position;
    for (int i=0;i<Size;i++)
    {
        Position = IndexOfMinValue(Arr, i, Size);
        Swap(Arr[i], Arr[Position]);
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

    SelectionSort(Arr, 5);
    cout << "Array After Selection Sort: "<< endl;
    for (int i = 0;i<5;i++)
    {
        cout << Arr[i] << endl;
    }
    return 0;
}
