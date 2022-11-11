#include <iostream>
#include <string>
#include <cstring>
#include <conio.h>


using namespace std;

class Complex
{
    int real;
    int img;

public:
    Complex(int r, int i)
    {
        real = r;
        img = i;

    }
    Complex(int n)
    {
        real = img = n;

    }
    Complex()
    {
        real = img = 0;
    }


    void SetReal(int r)
    {
        real = r;
    }
    void SetImg (int i)
    {
        img = i;
    }
    int GetReal()
    {
        return real;
    }
    int GetImg()
    {
        return img;
    }
    void Print()
    {

        if (img == 0 && real == 0)
        {
            cout << "0" << endl;
        }
        else if(img == 0)
        {
            cout << real << endl;
        }
        else if ( real == 0)
        {
            cout << img << "i" <<endl;
        }
        else if (img < 0)
        {
            cout << real << img << "i" <<endl;
        }
        else
        {
            cout << real << "+" << img << "i" <<endl;
        }
    }

    Complex Sum (Complex C)
    {
        Complex c_sum;
        c_sum.SetReal(real + C.real);
        c_sum.SetImg(img + C.img);
        return c_sum;
    }

    // operator-
    //c3 = c1-c2
    Complex operator-(const Complex& c)
    {
        Complex Result;
        Result.real = real - c.real;
        Result.img = img - c.img;

        return Result;
    }

    //c1-7
    Complex operator-(int R)
    {
        Complex Result;
        Result.real = real - R;
        Result.img = img;

        return Result;
    }

    //c1-=c3
    Complex& operator-= (Complex & c)
    {
        real -= c.real;
        img -= c.img;
        return *this;
    }

    //--c1
    Complex operator-- ()
    {
        real -= 1;
        return *this;
    }
    //c1--
    Complex operator-- (int)
    {
        Complex Temp(*this);
        real -= 1;
        return Temp;
    }


    //c1== 2
    bool  operator == (Complex c)
    {
        if( c.real== real && c.img==img)
            return true;
        else
            return false;
    }

    //c1!= 2
    bool  operator != (Complex c)
    {
        if( c.real!= real && c.img!=img)
            return true;
        else
            return false;
    }

    // >
    bool  operator > (Complex c)
    {
        if( real > c.real && img > c.img)
            return true;
        else
            return false;
    }

    //>=


    bool  operator >= (Complex c)
    {
        if( real >= c.real && c.img>= img)
            return true;
        else
            return false;
    }

    //<
    bool  operator < (Complex c)
    {
        if( real < c.real && img < c.img)
            return true;
        else
            return false;
    }

    //<=
    bool  operator <= (Complex c)
    {
        if( real <= c.real && img <= c.img)
            return true;
        else
            return false;
    }


    //int() casting
    operator int()
    {
        return real;
    }


    //char*() casting
    operator char* ()
    {
        string S = to_string(real);
        S+= "+"+to_string(img)+"i";
        int String_size=S.size();
        char* arr = new char [String_size+1];
        for(int i=0 ; i<String_size;i++)
        {
             arr[i]=S[i];
        }
        arr[String_size]='\0';

        return arr ;
    }





};
    //c3 = 7 - c1
    Complex operator-(int L, Complex& R)
    {
        Complex Result;
        Result.SetReal(L - R.GetReal());
        Result.SetImg(R.GetImg());

        return Result;
    }

    //7-=c1
    Complex operator-=(int L, Complex& R)
    {
        Complex Result;
        Result.SetReal(L - R.GetReal());
        Result.SetImg(R.GetImg());

        return Result;
    }





int main()
{
    int real_part, img_part;

    Complex c1(1,2), c2(5), c3, c4, c5, c6, c7, c8, c9(7,7), c10(8,8), c11, c12(10), c13(10);

    cout  << "Sum is: " << endl;
    c3 = c1.Sum(c2);
    c3.Print();


    //-
    c4 = c1-c2;
    c4.Print();
    c5 = 5-c1;
    c5.Print();
    c6 = c1-3;
    c6.Print();

    //-=
    c7 -= c1;
    c7.Print();

    //7-=c1
    c8 = (7-= c1);
    c8.Print();

    cout << "C-- and --c" <<endl;
    //--c1
    --c9;
    c9.Print();

    //c1--
    c11 = c10--;
    c11.Print();
    c10.Print();


    cout << "comparing Operators" <<endl;
    //==
    if(c12 == c13)
        cout << "==" <<endl;

    // !=
    if (c13 != c1)
        cout << "!=" <<endl;

    // >
    if(c12 > c10)
        cout << ">" <<endl;
    //>=
    if(c12 >= c13)
        cout << ">=" <<endl;
    //<

    if(c10 < c13)
        cout << "<" <<endl;
    //<=
    if(c12 <= c13)
        cout << "<=" <<endl;

    //int()
    cout << "int casting" <<endl;
    int R = (int) c1;
    cout << R <<endl;

    //char casting
    cout << "char casting" <<endl;
    char* c =(char*) c1;
    cout << c <<endl;





    return 0;
}
