#include <iostream>

using namespace std;


class Complex
{
    int real;
    int img;

public:
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

};

Complex Sub (Complex L, Complex R)
{
    Complex c_sub;
    c_sub.SetReal(L.GetReal() - R.GetReal());
    c_sub.SetImg(L.GetImg()- R.GetImg());
    return c_sub;
}



int main()
{
    int real_part, img_part;

    Complex c1, c2, c3, c4;

    cout << "Enter number 1 real part" << endl;
    cin>>real_part;
    cout << "Enter number 1 imaginary part" << endl;
    cin>>img_part;
    c1.SetReal(real_part);
    c1.SetImg(img_part);

    cout << "Enter number 2 real part" << endl;
    cin>>real_part;
    cout << "Enter number 2 imaginary part" << endl;
    cin>>img_part;
    c2.SetReal(real_part);
    c2.SetImg(img_part);

    cout << "You Entered:" << endl;
    c1.Print();
    c2.Print();

    cout  << "Sum is: " << endl;
    c3 = c1.Sum(c2);
    c3.Print();

    cout  << "Subtraction is: " << endl;
    c4 = Sub(c1, c2);
    c4.Print();

    //cout << "Hello world!" << endl;
    return 0;
}
