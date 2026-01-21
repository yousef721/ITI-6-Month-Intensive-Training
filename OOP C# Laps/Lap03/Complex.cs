namespace Lap03;

public class Complex
{
    private int real;
    private int imaginary;

    private static int counter;

    // Default Constructor
    public Complex()
    {
        real = 0;
        imaginary = 0;
        counter++;
    }

    // Parameterized Constructor
    public Complex(int _real)
    {
        real = _real;
        imaginary = 0;
        counter++;
    }
    public Complex(int _real, int _imaginary)
    {
        real = _real;
        imaginary = _imaginary;
        counter++;
    }

    public void Initialize(int _real, int _imaginary)
    {
        real = _real;
        imaginary = _imaginary;
    }
    public void SetReal(int _real)
    {
        real = _real;
    }
    public int GetReal()
    {
        return real;
    }

    public void SetImaginary(int _imaginary)
    {
        imaginary = _imaginary;
    }
    public int GetImaginary()
    {
        return imaginary;
    }

    public Complex Add(Complex complex)
    {
        Complex result = new Complex();
        result.real = real + complex.real;
        result.imaginary = imaginary + complex.imaginary;
        return result;
    }

    public static int GetCounter()
    {
        return counter;
    }


    public string Print()
    {
        // real = 0
        if (real == 0)
        {
            if (imaginary == 1)
                return "i";
            if (imaginary == -1)
                return "-i";
            if(imaginary == 0)
                return "0";

            return $"{imaginary}i";
        }

        // imaginary = 0
        if (imaginary == 0)
        {
            return $"{real}";
        }

        // imaginary < 0
        if (imaginary < 0)
        {
            if (imaginary == -1)
            {
                return $"{real} - i";
            }
            return $"{real} - {imaginary * -1}i";
        }

        // imaginary > 0
        if (imaginary == 1)
        {
            return $"{real} + i";
        }

        return $"{real} + {imaginary}i";
    }

    // c1+c2
    public static Complex operator+(Complex left, Complex right)
    {
        return new Complex(left.real + right.real, left.imaginary + right.imaginary);
    }
    // c1+10
    public static Complex operator+(Complex left, int num)
    {
        return new Complex(left.real + num, left.imaginary);
    }
    //10+c1
    public static Complex operator+(int num, Complex right)
    {
        return new Complex(right.real + num, right.imaginary);
    }

    //c1==c2
    public static bool operator==(Complex left, Complex right)
    {
        return left.real == right.real && left.imaginary == right.imaginary;
    }

    //c1!=c2
    public static bool operator!=(Complex left, Complex right)
    {
        return left.real != right.real || left.imaginary != right.imaginary;
    }


    // Destructor
    ~Complex()
    {
        counter--;
    }
}
