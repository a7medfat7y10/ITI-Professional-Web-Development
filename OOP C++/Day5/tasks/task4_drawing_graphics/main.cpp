#include <iostream>
#include "C:\Program Files\CodeBlocks\MinGW\include\graphics.h"
#include <conio.h>

using namespace std;

class Point
{
    int x, y;
public:
    Point()
    {
        x=y=0;
        //cout << "Point Parameterless Constructor 1 \n" ;
    }
    Point (int _x, int _y)
    {
        x = _x;
        y=_y;
        //cout << "poiny Constructor 2 \n";
    }
    ~Point()
    {
        //cout << "Point Desructor \n";
    }

    int GetX()
    {
        return x;
    }
    int GetY()
    {
        return y;
    }
    void SetX(int _x)
    {
        x = _x;
    }
    void SetY(int _y)
    {
        y = _y;
    }

    void Show()
    {
        //cout << "(" << x  << "," << y << ")\n";
    }

};


class Rect
{
    Point UL;
    Point LR;
    int color;

public:
    Rect()
    {
        int color = 0;
        //cout << "Rect Parameterless Constructor \n";
    }
    Rect(int x1, int y1, int x2, int y2, int c):UL(x1,y1),LR(x2,y2)

    {
        color = c;
        //cout << "Rect Constructor";
    }
    void Draw()
    {

        setcolor(color);
        rectangle(UL.GetX(), UL.GetY(), LR.GetX(), LR.GetY());
    }
};


class Circle
{
    Point Center;
    int color;
    int radius;

public:
    Circle()
    {
        int color = 0;
        int radius = 0;
        //cout << "Circle Parameterless Constructor \n";
    }
    Circle(int x1, int y1 ,int r, int c):Center(x1,y1)

    {
        color = c;
        radius = r;
        //cout << "Circle Constructor";
    }

    void Draw()
    {
        setcolor(color);
        circle(Center.GetX(), Center.GetY(), radius);
    }

};

class Line
{
    Point Start;
    Point End;
    int color;

public:
    Line()
    {
        int color = 0;
        //cout << "line Parameterless Constructor \n";
    }
    Line(int x1, int y1, int x2, int y2 ,int c):Start(x1,y1),End(x2,y2)

    {
        color = c;
        //cout << "Line Constructor";
    }

    void Draw()
    {
        setcolor(color);
        line(Start.GetX(), Start.GetY(),End.GetX(), End.GetY());
    }

};


class Triangle
{
    Point Left;
    Point Right;
    Point Top;
    int color;

public:
    Triangle()
    {
        int color = 0;
        //cout << "Triangle Parameterless Constructor \n";
    }
    Triangle(int x1, int y1, int x2, int y2, int x3, int y3 ,int c):Left(x1,y1),Right(x2,y2),Top(x3,y3)

    {
        color = c;
        //cout << "Triangle Constructor";
    }

    void Draw()
    {
        setcolor(color);
        line(Left.GetX(), Left.GetY(),Right.GetX(), Right.GetY());
        line(Left.GetX(), Left.GetY(),Top.GetX(), Top.GetY());
        line(Top.GetX(), Top.GetY(),Right.GetX(), Right.GetY());
    }

};



int main()
{
    initgraph();
    //Rectangle
    Rect R1(295,317,423,382,5);
    R1.Draw();

    //Circle
    Circle C1 (358,209,70,5);
    C1.Draw();
    Circle C2 (358,119,19,5);
    C2.Draw();

    //Lines
    Line L1(387,317,387,230,5);
    L1.Draw();
    Line L2(333,317,333,230,5);
    L2.Draw();
    Line L3(387,188,367,117, 5);
    L3.Draw();
    Line L4(350,117,327,194,5);
    L4.Draw();

    //Triangle
    Triangle T1(332,363,311,363,322,345,5);
    T1.Draw();


    return 0;
}
