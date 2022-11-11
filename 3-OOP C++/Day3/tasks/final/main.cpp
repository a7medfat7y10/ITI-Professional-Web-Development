
#include <iostream>

using namespace std;


class IntArray
{
    int *Arr;
    int Size;

public:

    /// constructors and destructor :
    IntArray(int S)
    {
        Size = S;
        Arr = new int[Size];
    }
    IntArray(const IntArray& X)
    {
        Size = X.Size;
        Arr = new int[Size];
    }
    ~IntArray()
    {
        delete [] Arr;
    }

    /// functions for calss :

      int GetSize()
    {
        return Size;
    }

      void SetValue (int index , int value)
    {
        if ((index >= 0) && (index <Size))
        {
            Arr[index] = value;
        }
    }


     int GetValue (int index)
    {
        if ((index >= 0) && (index <Size))
        {
            return Arr[index];
        }
    }

    /// operators overloading for array class :

    // 1.Asssignment Operator :

    IntArray& operator= (const IntArray& X)
    {
        delete [] Arr;
        Size = X.Size;
        Arr = new int[Size];

        for (int i=0;i<Size; i++)
        {
            Arr[i] = X.Arr[i];
        }
        return *this;

    }

     // 1. [] Operator  :

     int& operator[] (int index)
    {
        if ((index >= 0) && (index <Size))
        {
            return Arr[index];
        }
    }

    IntArray operator+(IntArray& X)
    {
        IntArray Res(5) ;
        for(int i =0 ;i<Size;i++)
        {
            Res.Arr[i]=Arr[i]+X.Arr[i];

        }
        return Res;
    }

};

int main()
{
    IntArray Arr1(5);
    IntArray Arr2(5);
    IntArray Arr3(5);

    cout<<"ELements for array 1 :"<<endl;
    for(int i =0 ;i<Arr1.GetSize();i++)
    {
        Arr1[i]=3*i;
        cout<<Arr1[i]<<endl;
    }

     cout<<"ELements for array 2 :"<<endl;

    for(int i =0 ;i<Arr2.GetSize();i++)
    {
        Arr2[i]=5*i;
        cout<<Arr2[i]<<endl;
    }
     Arr3=Arr1+Arr2;

      cout<<"ELements for array 3 = Arr1+Arr2 :"<<endl;
     for(int i =0 ;i<Arr3.GetSize();i++)
    {

        cout<<Arr3[i]<<endl;
    }






    //cout << Arr2.GetValue(3);


    return 0;
}
