using Lap03;

namespace Lap04;
class Program
{
    static void Main()
    {

        #region Overloading
            // // add int
            // Console.WriteLine(MathOverloading.Add(3,2));
            // Console.WriteLine(MathOverloading.Add(3,2,1));

            // // add float
            // Console.WriteLine(MathOverloading.Add(3.1f,2.2f));
            // Console.WriteLine(MathOverloading.Add(3.1f,2.2f,1.1f));

            // // Subtract int
            // Console.WriteLine(MathOverloading.Subtract(3,2));
            // Console.WriteLine(MathOverloading.Subtract(3,2,1));

            // // Subtract float
            // Console.WriteLine(MathOverloading.Subtract(3.1f,2.2f));
            // Console.WriteLine(MathOverloading.Subtract(3.1f,2.2f,1.1f));


        #endregion

        #region Default argument
            // // add int

            // // MathDefaultArgument.Add();
            // MathDefaultArgument.Add(1);
            // MathDefaultArgument.Add(2,3);
            // MathDefaultArgument.Add(4,5,6);

            // // add float
            // MathDefaultArgument.Add(1.1f);
            // MathDefaultArgument.Add(2.2f,3.3f);
            // MathDefaultArgument.Add(4.4f,5.5f,6.6f);

            // // Subtract int
            // MathDefaultArgument.Subtract(1);
            // MathDefaultArgument.Subtract(2,3);
            // MathDefaultArgument.Subtract(4,5,6);

            // // Subtract float
            // MathDefaultArgument.Subtract(1.1f);
            // MathDefaultArgument.Subtract(2.2f,3.3f);
            // MathDefaultArgument.Subtract(4.4f,5.5f,6.6f);

        #endregion

        #region Initialize Object
            // // V01
            // Complex c1 = new Complex();
            // c1.SetReal(3);
            // c1.SetImaginary(4);

            // // V02
            // Complex c2 = new Complex();
            // c2.Initialize(3,4);

        #endregion

        #region Constructor + Static + Destructor counter in class complex 

            // // Constructor
            // Complex c1 = new Complex();
            // Complex c2 = new Complex(5, 6);
            // Complex c3 = new Complex(5);

            // Console.WriteLine(c1.Print());
            // Console.WriteLine(c2.Print());
            // Console.WriteLine(c3.Print());

            // // Constructor Counter + Destructor when I remove Object decrease 1 
            // Console.WriteLine(Complex.GetCounter());

        #endregion
    
        #region Object Oriented Relations (OOR)
            #region Composition [Tightly Coupled]
                #region Line 
                    // Line line1 = new Line();
                    // //Point default ctor start
                    // //Point default ctor end
                    // //Line default ctor

                    // Console.WriteLine(line1.Print());
                    // //Line Start(0,0), End (0,0)

                    // Console.WriteLine("=================");

                    // Line line2 = new Line(1,2,3,4);
                    // //Point default ctor start
                    // //Point default ctor end
                    // //Line 4 param ctor

                    // Console.WriteLine(line2.Print());
                    // //Line Start(1,2), End (3,4)
                #endregion
            
                #region Rectangle
                    // Rectangle rectangle1 = new Rectangle();
                    // //Point default ctor start
                    // //Point default ctor end
                    // //Rectangle default ctor

                    // Console.WriteLine(rectangle1.Print());
                    // //Rectangle ul (0,0) , lr (0,0) 

                    // Console.WriteLine("=================");

                    // Rectangle rectangle2 = new Rectangle(1,2,3,4);
                    // //Point default ctor start
                    // //Point default ctor end
                    // //Rectangle 4 param ctor

                    // Console.WriteLine(rectangle2.Print());
                    // // Rectangle upperLeft Point (1,2) , lowerRight Point (3,4) 

                #endregion
            #endregion
        
           
            #region Association or Aggregation 
                #region Triangle
                    // Point P1_1 = new Point();
                    // Point P2_1 = new Point();
                    // Point P3_1 = new Point();
                    // // Point default ctor
                    // // Point default ctor
                    // // Point default ctor

                    // Triangle triangle1 = new Triangle(P1_1, P2_1, P3_1);
                    // // Triangle 3 Param ctor
                    
                    // Console.WriteLine(triangle1.Print());
                    // // Triangle P1(0,0), P2(0,0), P3(0,0)

                    // //After Process Remove relationship between Triangle and 3 points
                    // triangle1.SetP1(null);
                    // triangle1.SetP2(null);
                    // triangle1.SetP3(null);

                    // // =================================================

                    // Point P1_2 = new Point(1,2);
                    // Point P2_2 = new Point(3,4);
                    // Point P3_2 = new Point(5,6);
                    // // Point 2 param ctor
                    // // Point 2 param ctor
                    // // Point 2 param ctor


                    // Triangle triangle2 = new Triangle(P1_2, P2_2, P3_2);
                    // //Triangle 3 Param ctor

                    // Console.WriteLine(triangle2.Print());
                    // //Triangle P1(1,2), P2(3,4), P3(5,6)

                    // //After Process Remove relationship between Triangle and 3 points
                    // triangle2.SetP1(null);
                    // triangle2.SetP2(null);
                    // triangle2.SetP3(null);
                #endregion

                #region Circle
                    // int radius1 = 5;
                    // Point center1 = new Point();
                    // // Point default ctor

                    // Circle circle1 = new Circle(center1, radius1);
                    // // Circle 3 Param ctor

                    // Console.WriteLine(circle1.Print());
                    // // Circle Center Point (0,0), radius is 5

                    // //After Process Remove relationship between Triangle and 3 points
                    // circle1.SetCenterPoint(null);

                    // // =================================================

                    // int radius2 = 10;
                    // Point center2 = new Point(2,3);
                    // // Point 2 param ctor

                    // Circle circle2 = new Circle(center2, radius2);
                    // // Circle 3 Param ctor

                    // Console.WriteLine(circle2.Print());
                    // // Circle Center Point (2,3), radius is 5

                    // //After Process Remove relationship between Triangle and 3 points
                    // circle2.SetCenterPoint(null);

                #endregion
            #endregion
        #endregion
    
    }
}
