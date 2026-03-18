using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Fraction a = new Fraction();
        Fraction b = new Fraction(5);
        Fraction c = new Fraction(3, 4);
        Fraction d = new Fraction(1, 3);

        Console.WriteLine(a.GetFractionString());
        Console.WriteLine(a.GetDecimalValue());

        Console.WriteLine(b.GetFractionString());
        Console.WriteLine(b.GetDecimalValue());

        Console.WriteLine(c.GetFractionString());
        Console.WriteLine(c.GetDecimalValue());

        Console.WriteLine(d.GetFractionString());
        Console.WriteLine(d.GetDecimalValue());

        
    }
}

public class Fraction
{
    private int numerator;
    private int denominator;
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }
    public Fraction(int wholeNumber)
    {
        numerator = wholeNumber;
        denominator = 1;
    }
    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        if (denominator == 0)
        {
            this.denominator = 1;
        }
        else
        {
            this.denominator = denominator;
        }
    }
    public int GetTop()
    {
        return numerator;
    }
    public int GetBottom()
    {
        return denominator;
    }
    public void SetTop(int top)
    {
        numerator = top;
    }
    public void SetBottom(int bottom)
    {
        if (bottom != 0)
        {
            denominator = bottom;
        }
    }
    public string GetFractionString()
    {
        return numerator + "/" + denominator;
    }
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}