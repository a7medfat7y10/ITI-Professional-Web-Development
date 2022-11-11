#include <iostream>

using namespace std;

template <class Type1>
class intArray
{
    Type1 *Arr;
    int Size;

public:
    intArray(Type1 S)
    {
        Size = S;
        Arr = new Type1[Size];
    }
    intArray(const intArray& oldarr)
    {
        Size = oldarr.Size;
        Arr = new Type1[Size];
    }
    ~intArray()
    {
        delete [] Arr;
    }

    intArray& operator= (const intArray& R)
    {
        delete [] Arr;
        Size = R.Size;
        Arr = new Type1[Size];

        for (int i=0;i<Size; i++)
        {
            Arr[i] = R.Arr[i];
        }
        return *this;
    }

    Type1& operator[] (int index)
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


    void SetValue (int index , Type1 value)
    {
        if ((index >= 0) && (index <Size))
        {
            Arr[index] = value;
        }
    }


    Type1 GetValue (int index)
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
    intArray<int> Arr1(7);
    intArray<int> Arr2(7);
    intArray<int> Arr3(7);

    cout<<"ELements for array 1 :"<<endl;
    for(int i =0 ;i<Arr1.GetSize();i++)
    {
        Arr1[i]=3*i;
        cout<<Arr1[i]<<" ,";
    }

    cout<<"\n\nELements for array 2 :"<<endl;

    for(int i =0 ;i<Arr2.GetSize();i++)
    {
        Arr2[i]=5*i;
        cout<<Arr2[i]<<" ,";
    }
     Arr3=Arr1+Arr2;

    cout<<"\n\nELements for array 3 = Arr1+Arr2 :"<<endl;
    for(int i =0 ;i<Arr3.GetSize();i++)
    {

        cout<<Arr3[i]<<" ,";
    }


    //array 4 for characters
    intArray<char> Arr4(7);
        Arr4[0] ='A';
        Arr4[1] ='B';
        Arr4[2] ='C';
        Arr4[3] ='D';
        Arr4[4] ='E';
        Arr4[5] ='F';
        Arr4[6] ='G';
    cout<<"\n\nELements for array 4(char):"<<endl;
    for(int i =0 ;i<Arr4.GetSize();i++)
    {

        cout<<Arr4[i]<<" ,";
    }

    return 0;
}
