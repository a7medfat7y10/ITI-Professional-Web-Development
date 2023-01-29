using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_one_day5
{
    internal class Point3D
    {
        int x, y, z;
        public Point3D(int _x=0, int _y = 0, int _z = 0)
        {
            x= _x;
            y= _y;
            z= _z;
        }
        public override string ToString()
        {
            return $"Point Coordinates : ({x},{y},{z})";
        }
        public static explicit operator String(Point3D P)
        {
            return P.ToString();
        }
        //public static bool operator ==(Point3D Left, Point3D Right)
        //{
        //    if ((Left != null) && (Right != null))
        //        return (Left.x == Right.x) && (Left.y == Right.y) && (Left.z == Right.z);
        //    return false;
        //}

        //public static bool operator !=(Point3D Left, Point3D Right)
        //{
        //    if ((Left != null) && (Right != null))
        //        return (Left.x != Right.x) || (Left.y != Right.y) || (Left.z != Right.z);
        //    return false;
        //}

        public override bool Equals(object? obj)
        {
            if (!(obj is Point3D))
                return false;
            return
                (this.x == ((Point3D)obj).x && this.y == ((Point3D)obj).y && this.z == ((Point3D)obj).z);
        }

        public static bool operator == (Point3D left, Point3D right)
        {
            if (left.Equals(right)) return true;
            else return false;
        }
        public static bool operator !=(Point3D Left, Point3D Right)
        {
            if (Left == Right)
                return false;
            return true;
        }
    }
}
