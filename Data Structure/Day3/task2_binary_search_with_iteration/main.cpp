#include <iostream>

using namespace std;

int BinarySearch(int Arr[], int Size, int value)
{
    int low = 0;
    int high= Size -1;
    int mid = (low + high)/2;

    while (high >= low)
    {
        mid = (low + high)/2;
        if (Arr[mid] == value)
            return mid;
        else if(Arr[mid] > value)
        {
            high = mid -1;
        }
        else
            low = mid +1;
    }
    return -1;
}

int main()
{
    int Arr[10]={10,4, 5, 2, 7, 9,4, 11, 23, 1};
    cout << "Found at index no. " << BinarySearch(Arr, 10, 11);

    return 0;
}
