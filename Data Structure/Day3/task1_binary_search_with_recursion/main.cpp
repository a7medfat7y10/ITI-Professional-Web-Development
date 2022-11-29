#include <iostream>

using namespace std;

int BinarySearch(int Arr[], int low , int high, int value)
{
    if(low <= high)
    {
        int mid = (low+high)/2;
        if(value == Arr[mid])
        {
            return mid;
        }
        else if (Arr[mid] > value)
        {
            return BinarySearch(Arr, low ,mid-1, value);
        }
        else
        {
            return BinarySearch(Arr, mid+1, high, value);
        }
    }
    return -1;
}

int main()
{
    int Arr[10]={10,4, 5, 2, 7, 9,4, 11, 23, 1};
    cout << "Found at index no. " << BinarySearch(Arr, 0, 9, 11);

    return 0;
}
