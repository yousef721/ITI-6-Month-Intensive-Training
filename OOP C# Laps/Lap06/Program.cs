namespace Lap06;

class Program
{
    static void Main()
    {
        #region  Class GeoShape with all children

            // Square square = new Square(4);
            // Console.WriteLine(square.GetArea()); // 4 * 4 = 16 

            // Circle circle = new Circle(4);
            // Console.WriteLine(circle.GetArea()); // 3.14 * 4 = 50.26

            // Triangle triangle = new Triangle(4, 6);
            // Console.WriteLine(triangle.GetArea()); // 0.5 * 4 * 6 = 12

            // Rectangle rectangle = new Rectangle(4, 6);
            // Console.WriteLine(rectangle.GetArea()); // 4 * 6 = 24

        #endregion

        #region Try sumOfAreas with 2 ways

            // sumOfAreas V1
            // Rectangle[] rectangles = new Rectangle[3]
            // {
            //    new Rectangle(2,5), // 10
            //    new Rectangle(3,4), // 12
            //    new Rectangle(2,5) // 10
            // };

            // Square[] squares =
            // {
            //    new Square(10), // 100
            //    new Square(10) // 100 
            // };

            // Triangle[] triangles = 
            // {
            //    new Triangle(2,5), // 5
            //    new Triangle(2,5) // 5
            // };
            // // Circle circle = new Circle(4);
            
            // Console.WriteLine(Utility.SumOfAreasV1(rectangles,squares,triangles)); // 242

            // Console.WriteLine("==================================================");

            // // sumOfAreas V1
            // GeoShape[] geoShapes =
            // {
            //    new Rectangle(2,3), // 6
            //    new Rectangle(2,3), // 6
            //    new Rectangle(2,3), // 6
            //    new Square(10), // 100
            //    new Square(10), // 100
            //    new Triangle(2,3), // 3
            //    new Circle(4)
            // };

            // Console.WriteLine(Utility.SumOfAreasV2(geoShapes)); // 221
        #endregion
    
    }
}
