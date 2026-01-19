using System;

namespace Lap04;

public class Rectangle
{
        // Composition
        Point upperLeft;
        Point lowerRight;

        public Rectangle()
        {
            upperLeft = new Point();
            lowerRight = new Point();

            Console.WriteLine("Rectangle default ctor");
        }
        public Rectangle(int x1,int y1,int x2,int y2)
        {
            upperLeft = new Point(x1,y1);
            lowerRight = new Point(x2,y2);      

            Console.WriteLine("Rectangle 4 param ctor");
        }

        public void SetUL(Point _upperLeft) { upperLeft = _upperLeft; }
        public void SetLR(Point _lowerRight) { lowerRight = _lowerRight; }
        public Point GetUL() {  return upperLeft; }
        public Point GetLR() { return lowerRight; }


        public string Print() 
        {
            return $"Rectangle upperLeft Point {upperLeft.Print()} , lowerRight Point {lowerRight.Print()} ";
        }
}
