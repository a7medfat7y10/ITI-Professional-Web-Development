#include <iostream>

using namespace std;


class intArray
{
    int *Arr;
    int Size;

public:
    intArray(int S)
    {
        Size = S;
        Arr = new int[Size];
    }
    intArray(const intArray& oldarr)
    {
        Size = oldarr.Size;
        Arr = new int[Size];
    }
    ~intArray()
    {
        delete [] Arr;
    }

    intArray& operator= (const intArray& R)
    {
        delete [] Arr;
        Size = R.Size;
        Arr = new int[Size];

        for (int i=0;i<Size; i++)
        {
            Arr[i] = R.Arr[i];
        }
        return *this;
    }

    int& operator[] (int index)
    {
        if ((index >= 0) && (index <Size))
        {
            return Arr[index];
        }
    }


    intArray operator+ (intArray& A)
    {
        intArray Res(7);
        for ( int i =0 ; i <Size; i++ )
        {
            Res.Arr[i] = Arr[i]  + A.Arr[i];
        }
        return Res;
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
      //  return-1;
    }


    int GetSize()
    {
        return Size;
    }

};



int main()
{
  /*
    intArray myA(7), a2(7), a3(7);


    myA.SetValue(0,3);
    a2 = myA;
    cout << a2.GetValue(0) << endl;

    myA[1] = 5;
    myA[2] = 10;
    myA[3] = 20;
    cout << myA[1] << endl;
    cout << myA[2] << endl;
    cout << myA[3] << endl;



    cout << "myA array is"  <<endl;
    for (int i=0; i<myA.GetSize();i++)
    {
        myA[i] = 3* i;
        cout << myA[i] << endl ;
    }

    cout << "a2 array is"  <<endl;
    for (int i=0; i<a2.GetSize();i++)
    {
        a2[i] = 4* i;
        cout << a2[i] << endl ;
    }


    //sum
    a3=myA+a2;

    cout << "Sum array is"  <<endl;
    for (int i=0; i<a3.GetSize();i++)
    {
        cout << a3[i]<< endl ;
    }

*/
    intArray Arr1(7);
    intArray Arr2(7);
    intArray Arr3(7);

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

    return 0;
}
