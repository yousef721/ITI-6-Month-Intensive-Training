namespace Lap03;

public class Complex
{
    private int real;
    private int imaginary;

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

public string Print()
{
        // real = 0
        if (real == 0)
        {
            if (imaginary == 1)
                return "i";
            if (imaginary == -1)
                return "-i";

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
}
