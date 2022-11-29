#include <iostream>

using namespace std;

void Merge(int* Arr, int Lfirst, int Llast , int Rfirst, int Rlast)
{
    int* Temp_Arr = new int [Rlast-Lfirst+1];
    int Position = 0;
    int SaveFirst = Lfirst;

    //if the right and left half still unsorted
    while ((Lfirst<=Llast) && (Rfirst <= Rlast))
    {
        if (Arr[Lfirst]< Arr[Rfirst])
        {
            Temp_Arr[Position++] = Arr[Lfirst++];
        }
        else
        {
            Temp_Arr[Position++] = Arr[Rfirst++];
        }
    }
    //if only left half
    while (Lfirst <= Llast)
        Temp_Arr[Position++] = Arr[Lfirst++];

    //if only right half
    while (Rfirst <= Rlast)
        Temp_Arr[Position++] = Arr[Rfirst++];


    //copying the sorted elements in temp to the original array
    for(int i= SaveFirst; i<= Rlast; i++)
        Arr[i] = Temp_Arr[i-SaveFirst];
}

void MergeSort(int* Arr, int first, int last)
{
    if(first<last)
    {
        int middle = (first+last) / 2;
        MergeSort(Arr, first, middle);
        MergeSort(Arr, middle+1, last);
        Merge(Arr, first, middle, middle+1, last);
    }
}

int main()
{

    int Arr[5] = {4, 8,5,3, 7};

    cout << "Array Before:" << endl;
    for (int i = 0;i<5;i++)
    {
        cout << Arr[i]<< endl;
    }

    MergeSort(Arr,0, 4);

    cout << "Array After Merge Sort: "<< endl;
    for (int i = 0;i<5;i++)
    {
        cout << Arr[i] << endl;
    }

    return 0;
}
