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

class ShapeColor
{
protected:
    int color;
public:
    ShapeColor(){}
    ShapeColor(int c)
    {
        color = c;
    }
    void SetShapeColor(int x)
    {
        color = x;
    }
    int GetShapeColor()
    {
        return color;
    }
};

class Rect: public ShapeColor
{
    Point UL;
    Point LR;
public:
    Rect()
    {
        SetShapeColor(0);
        //cout << "Rect Parameterless Constructor \n";
    }
    Rect(int x1, int y1, int x2, int y2, int c):UL(x1,y1),LR(x2,y2)

    {
        SetShapeColor(c);
        //cout << "Rect Constructor";
    }
    void Draw()
    {
        setcolor(GetShapeColor());
        rectangle(UL.GetX(), UL.GetY(), LR.GetX(), LR.GetY());
    }
};


class Circle: public ShapeColor
{
    Point Center;
    int radius;

public:
    Circle()
    {
        SetShapeColor(0);
        int radius = 0;
        //cout << "Circle Parameterless Constructor \n";
    }
    Circle(int x1, int y1 ,int r, int c):Center(x1,y1)

    {
        SetShapeColor(c);
        radius = r;
        //cout << "Circle Constructor";
    }

    void Draw()
    {
        setcolor(GetShapeColor());
        circle(Center.GetX(), Center.GetY(), radius);
    }

};

class Line: public ShapeColor
{
    Point Start;
    Point End;

public:
    Line()
    {
        SetShapeColor(0);
        //cout << "line Parameterless Constructor \n";
    }
    Line(int x1, int y1, int x2, int y2 ,int c):Start(x1,y1),End(x2,y2)

    {
        SetShapeColor(c);
        //cout << "Line Constructor";
    }

    void Draw()
    {
        setcolor(GetShapeColor());
        line(Start.GetX(), Start.GetY(),End.GetX(), End.GetY());
    }

};


class Triangle: public ShapeColor
{
    Point Left;
    Point Right;
    Point Top;

public:
    Triangle()
    {
        SetShapeColor(0);
        //cout << "Triangle Parameterless Constructor \n";
    }
    Triangle(int x1, int y1, int x2, int y2, int x3, int y3 ,int c):Left(x1,y1),Right(x2,y2),Top(x3,y3)

    {
        SetShapeColor(c);
        //cout << "Triangle Constructor";
    }

    void Draw()
    {
        setcolor(GetShapeColor());
        line(Left.GetX(), Left.GetY(),Right.GetX(), Right.GetY());
        line(Left.GetX(), Left.GetY(),Top.GetX(), Top.GetY());
        line(Top.GetX(), Top.GetY(),Right.GetX(), Right.GetY());
    }
};


class Picture
{
    Rect* pRect;
    int RectNum;
    Line* pLine;
    int LineNum;
    Triangle* pTriangle;
    int TriangleNum;
    Circle* pCircle;
    int CircleNum;
public:
    Picture()
    {
        pRect = NULL;
        RectNum = 0;
        pLine = NULL;
        LineNum = 0;
        pTriangle = NULL;
        TriangleNum = 0;
        pCircle = NULL;
        CircleNum = 0;
    }
    Picture(Rect* rect_arr, int rect_num, Line* line_arr, int line_num, Triangle* triangle_arr, int triangle_num, Circle* circle_arr, int circle_num)
    {
        pRect = rect_arr;
        RectNum = rect_num;
        pLine = line_arr;
        LineNum = line_num;
        pTriangle = triangle_arr;
        TriangleNum = triangle_num;
        pCircle = circle_arr;
        CircleNum = circle_num;
    }
    ~Picture()
    {
        //cout <<"Destructor" <<endl;
    }
    void SetRect(Rect* rect_arr ,int rect_num )
    {
        pRect = rect_arr;
        RectNum = rect_num;
    }
    void SetLine(Line* line_arr, int line_num)
    {
        pLine = line_arr;
        LineNum = line_num;
    }
    void SetTriangle(Triangle* triangle_arr ,int triangle_num )
    {
        pTriangle = triangle_arr;
        TriangleNum = triangle_num;
    }
    void SetCircle(Circle* circle_arr ,int circle_num )
    {
        pCircle = circle_arr;
        CircleNum = circle_num;
    }
    void Paint()
    {
        for(int i =0 ; i<RectNum;i++)
        {
            pRect[i].Draw();
        }
        for(int i =0 ; i<LineNum;i++)
        {
            pLine[i].Draw();
        }
        for(int i =0 ; i<TriangleNum;i++)
        {
            pTriangle[i].Draw();
        }
        for(int i =0 ; i<CircleNum;i++)
        {
            pCircle[i].Draw();
        }
    }

};




int main()
{
    initgraph();


    //Rectangle
    Rect R1(295,317,423,382,5);
    //R1.Draw();

    //Circle
    Circle C1 (358,209,70,8);
    C1.Draw();
    Circle C2 (358,119,19,8);
    //C2.Draw();

    //Lines
    Line L1(387,317,387,230,7);
    //L1.Draw();
    Line L2(333,317,333,230,7);
    //L2.Draw();
    Line L3(387,188,367,117, 5);
    //L3.Draw();
    Line L4(350,117,327,194,5);
    //L4.Draw();

    //Triangle
    Triangle T1(332,363,311,363,322,345,5);
    //T1.Draw();


    Rect* rect_arr;
    rect_arr = new Rect[1];
    rect_arr[0] = R1;

    Line* line_arr;
    line_arr = new Line[4];
    line_arr[0] = L1;
    line_arr[1] = L2;
    line_arr[2] = L3;
    line_arr[3] = L4;

    Circle* circle_arr;
    circle_arr = new Circle[2];
    circle_arr[0] = C1;
    circle_arr[1] = C2;

    Triangle* triangle_arr;
    triangle_arr = new Triangle[2];
    triangle_arr[0] = T1;



    Picture P(rect_arr, 1, line_arr, 4, triangle_arr, 1, circle_arr, 2);
    P.Paint();





    return 0;
}
