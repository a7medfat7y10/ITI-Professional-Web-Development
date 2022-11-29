#include <iostream>

using namespace std;

void Swap(int &x, int &y)
{
    int temp = x;
    x = y;
    y = temp;
}

int Partition(int Arr[], int start, int end)
{
    //chose pivot is the first element
    int pivot = 0;

    int count = 0;
    //loop from the second element to the end
    //if the element is less than or equal the chosen pivot then increase count by one
    for (int i = start + 1; i <= end; i++) {
        if (Arr[i] <= Arr[pivot])
            count++;
    }
    //move the pivot to the right position by swap
    //(moving the elements smaller than the pivot to its left and the larger to its right)
    pivot = start + count;
    Swap(Arr[pivot], Arr[start]);


    int i = start, j = end;
    while (i < pivot && j > pivot) {

        while (Arr[i] <= Arr[pivot]) {
            i++;
        }

        while (Arr[j] > Arr[pivot]) {
            j--;
        }

        if (i < pivot && j > pivot) {
            Swap(Arr[i++], Arr[j--]);
        }
    }

    return pivot;
}

void QuickSort(int Arr[], int start, int end)
{
    int pivot;
    if(start<end)
    {
        pivot = Partition(Arr,start,end);
        //left half
        QuickSort(Arr, start, pivot-1);
        //right half
        QuickSort(Arr, pivot+1, end);
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

    QuickSort(Arr, 0, 4);
    cout << "Array After Quick Sort: "<< endl;
    for (int i = 0;i<5;i++)
    {
        cout << Arr[i] << endl;
    }
    return 0;
}
