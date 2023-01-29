using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4_Duration
{
    internal class Duration
    {
        int Hours;
        int Minutes;
        int Seconds;

        public Duration(int _h, int _m, int _s)
        {
            Hours = _h;
            Minutes = _m;
            Seconds = _s;
        }
        public Duration(int secs)
        {
            Hours = secs / 3600;
            Minutes = (secs % 3600)/60;
            Seconds = (secs % 3600) % 60;
        }

        public override string ToString()
        {
            return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || (obj.GetType() != typeof(Duration)))
                return false;
            Duration d = (Duration)obj;

            return (this.Hours == d.Hours && this.Minutes == d.Minutes && this.Seconds == d.Seconds );
        }

        public static Duration operator +(Duration left, Duration right)
        {
            return (
                    new Duration((left.Hours + right.Hours)*3600 
                            + (left.Minutes + right.Minutes)*60
                            +(left.Seconds + right.Seconds)) );
        }

        public static Duration operator +(Duration left, int secs)
        {
            return (
                    new Duration(left.Hours * 3600 + left.Minutes * 60 + left.Seconds + secs));
        }

        public static Duration operator +(int secs, Duration Right)
        {
            return (
                    new Duration(Right.Hours * 3600 + Right.Minutes * 60 + Right.Seconds + secs));
        }


        public static Duration operator ++(Duration left)
        {
            return (new Duration(left.Hours * 3600+ left.Minutes * 60 + 60 + left.Seconds));
        }

        public static Duration operator --(Duration left)
        {
            return (new Duration(left.Hours * 3600 + left.Minutes * 60 - 60 + left.Seconds));
        }

        public static bool operator >(Duration left, Duration right)
        {
            if (left == null || right == null) 
                return false;

            return
                ( (left.Hours * 3600 + left.Minutes * 60 + left.Seconds) 
                >
                (right.Hours * 3600 + right.Minutes * 60 + right.Seconds));
        }
        public static bool operator <(Duration left, Duration right)
        {
            if (left == null || right == null)
                return false;

            return
                ((left.Hours * 3600 + left.Minutes * 60 + left.Seconds)
                <
                (right.Hours * 3600 + right.Minutes * 60 + right.Seconds));
        }

        public static bool operator >=(Duration left, Duration right)
        {
            if (left == null || right == null)
                return false;

            return
                ((left.Hours * 3600 + left.Minutes * 60 + left.Seconds)
                >=
                (right.Hours * 3600 + right.Minutes * 60 + right.Seconds));
        }
        public static bool operator <=(Duration left, Duration right)
        {
            if (left == null || right == null)
                return false;

            return
                ((left.Hours * 3600 + left.Minutes * 60 + left.Seconds)
                <=
                (right.Hours * 3600 + right.Minutes * 60 + right.Seconds));
        }

        public static Duration operator -(Duration Right)
        {
            return (
                    new Duration(Right.Hours * (-1), Right.Minutes * (-1) , Right.Seconds * (-1)));
        }

        public static bool operator true (Duration d)
        {
            return (d.Hours>=0)||(d.Minutes>=0)||(d.Seconds>=0);
        }
        public static bool operator false(Duration d)
        {
            return (d.Hours <= 0) && (d.Minutes <= 0) && (d.Seconds <= 0);
        }

        public static explicit operator DateTime(Duration left)
        {
            DateOnly d1 = new DateOnly(2023,1,1);
            return new DateTime(d1.Year, d1.Month, d1.Day, (int)left.Hours,
                                (int)left.Minutes, (int)left.Seconds);
        }

    }
}
