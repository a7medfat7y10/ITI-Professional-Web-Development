#include <iostream>

using namespace std;


 int constructor_count = 0;
 int destructor_count = 0;

class Complex
{
    int real;
    int img;

public:
    Complex(int r, int i)
    {
        real = r;
        img = i;
        constructor_count++;
        cout<<this;
        cout<<" Constructor with 2 parameters no "<<constructor_count<<endl;

    }
    Complex(int n)
    {
        real = img = n;
        constructor_count++;
        cout<<this;
        cout<<" Constructor with 1 parameter no " <<constructor_count<<endl;

    }
    Complex()
    {
        real = img = 0;
        constructor_count++;
        cout<<this;
        cout<<" Parameterless Constructor no "<<constructor_count<<endl;

    }
    ///copy constructor
    Complex(Complex& oldc)
    {
        real = oldc.real;
        img = oldc.img;
        constructor_count++;
        cout<<this;
        cout<<" Copy Constructor no "<<constructor_count<<endl;

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

    ~Complex()
    {
        destructor_count++;
        cout<<this;
        cout<< " Destructor " << destructor_count <<endl;

    }
};

int main()
{
    int real_part, img_part;

    Complex c1(1,2), c2(5), c3;
    Complex c4(c1);

    cout  << "Sum is: " << endl;
    c3 = c1.Sum(c2);
    c3.Print();

    c4.Print();


    //cout<<"There are "<<constructor_count << " constructors"<<endl;
    //cout<<"There are "<<destructor_count << " destructors"<<endl;
    return 0;
}
