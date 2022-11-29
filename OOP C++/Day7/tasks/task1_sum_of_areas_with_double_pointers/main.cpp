#include <iostream>

using namespace std;

class GeoShape
{
protected:
    int Dim1, Dim2;
public:
    GeoShape (int d1 = 0, int d2=0)
    {
        Dim1 = d1; Dim2 = d2;
        //cout << "GeoShape Constructor \n";
    }
    ~GeoShape()
    {
        //cout << "GeoShape Destructor \n";

    }
    int GetDim1()
    {
        return Dim1;
    }
    int GetDim2()
    {
        return Dim2;
    }
    void SetDim1(int D)
    {
        Dim1 = D;
    }
    void SetDim2(int D)
    {
        Dim2 = D;
    }
    virtual double CalcArea()
    {
        return 0;
    }

};


class Rect :public GeoShape
{
public:
    Rect (int W, int H): GeoShape(W, H)
    {
        //cout << "Rect Constructor \n";
    }
    ~Rect()
    {
        //cout << "Rect Destructor \n";
    }
    double CalcArea() override
    {
        return Dim1 * Dim2;
    }

};

class Square : public Rect
{
public:
    Square (int L): Rect(L, L)
    {
        //cout << "Square Constructor \n";
    }
    ~Square()
    {
        //cout << "Square Destructor \n";
    }

    ///override SetDim1 and 2 of the geoshape
    void SetDim1 (int D)
    {
        Dim1 = Dim2 = D;
    }
    void SetDim2 (int D)
    {
        Dim1 = Dim2 = D;
    }
};

class Triangle : public GeoShape
{
public:
    Triangle (int W, int H): GeoShape(W, H)
    {
        //cout << "triangle Constructor \n";
    }
    ~Triangle()
    {
        //cout << "Triangle Destructor \n";
    }
    double CalcArea () override
    {
        return 0.5 * Dim1 * Dim2;
    }
};


class Circle : public GeoShape
{
public:
    Circle(int R) :GeoShape(R, R)
    {
        //cout << "Circle Constructor \n"
    }
    ~Circle()
    {
        //cout << "Circle Destructor \n";
    }
    ///override SetDim1 and 2 of the geoshape
    void SetDim1 (int R)
    {
        Dim1 = Dim2 = R;
    }
    void SetDim2 (int R)
    {
        Dim1 = Dim2 = R;
    }
    double CalcArea () override
    {
        return 3.14 * Dim1 * Dim2;
    }
};

/*
double sum_of_areas(Rect* rect_arr, int num_of_rects , Square* square_arr , int num_of_squares, Triangle* triangle_arr, int num_of_triangles , Circle* circle_arr, int num_of_circles)
{
    int i;
    double sum = 0;
    for(i = 0; i<num_of_rects;i++)
    {
        sum += rect_arr[i].CalcArea();
    }
    for(i = 0; i<num_of_squares;i++)
    {
        sum += square_arr[i].CalcArea();
    }
    for(i = 0; i<num_of_triangles;i++)
    {
        sum += triangle_arr[i].CalcArea();
    }
    for(i = 0; i<num_of_circles;i++)
    {
        sum += circle_arr[i].CalcArea();
    }
    return sum;
}
*/

//GArr is a two dimensional array contains the arrays of each shape
//c is the number of objects
double sum_of_areas_v2(GeoShape** GArr, int c )
{
    double sum = 0;
    for (int i =0 ; i<c; i++)
    {
        //GArr[i] is the address of the first
        sum += GArr[i]->CalcArea();
    }
    return sum;
}


int main()
{
    //Creating objects from each shape
    Rect R1 (10,15), R2 (20,30), R3(40,50); //objects from rect
    Square S1(10),  S2 (20); //objects from square
    Triangle T1 (10,15), T2(20,30); //objects from tri
    Circle C1 (7), C2(14); //objects from circle


    //creating the arrays
    Rect r1[3] = {R1, R2, R3}; //array of objects
    Square s1[2] = {S1, S2};    //array of objects
    Triangle t1[2] = {T1, T2};//array of objects
    Circle c1[2] = {C1, C2};//array of objects


    //Array of arrays which has objects for each shape(two dimensional)
    GeoShape* Arr[9] = {r1, &r1[1], &r1[2], s1 , &s1[1] , t1, &t1[1], c1, &c1[1] };

    /*
    cout <<  sum_of_areas(r1, 3, s1, 2, t1, 2, c1, 2)<<endl;
    */
    cout <<  sum_of_areas_v2(Arr, 9)<<endl;

    return 0;
}
