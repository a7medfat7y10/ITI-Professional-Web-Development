#include <iostream>

using namespace std;

/*
After tracing there are
5 objects c1, c2, c3 in main function and the parameter and result in sum function
 4 constructors for c1,c2,c3 in main function and one for c3 sum
  and 5 destructors  c1, c2, c3 in main function and the parameter and result in sum function
*/


 int obj_count = 0;
class Complex
{
    int real;
    int img;

public:
    Complex(int r, int i)
    {
        real = r;
        img = i;
        obj_count++;
        cout<<this;
        cout<<" Constructor with 2 parameters no "<<obj_count<<endl;

    }
    Complex(int n)
    {
        real = img = n;
        obj_count++;
        cout<<this;
        cout<<" Constructor with 1 parameter no " <<obj_count<<endl;

    }
    Complex()
    {
        real = img = 0;
        obj_count++;
        cout<<this;
        cout<<" Parameterless Constructor no "<<obj_count<<endl;

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
        cout<<this;
        cout<<"Destructor"<<endl;
    }
};

int main()
{
    int real_part, img_part;

    Complex c1(1,2), c2(5), c3;

    cout  << "Sum is: " << endl;
    c3 = c1.Sum(c2);
    c3.Print();


    cout<<"There are "<<obj_count << " objects"<<endl;
    return 0;
}
