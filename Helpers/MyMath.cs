namespace NiceCalc.Helpers;

using NiceCalc.Interfaces;

internal class MyMath : IMyMath
{
    public int Add(int x, int y) => x + y;
    public int Subtract(int x, int y) => x - y;
    public int Multiply(int x, int y) => x * y;
    public int Divide(int x, int y) => x / y;
}
