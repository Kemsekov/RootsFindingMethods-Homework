
public class BisectionMethod : IOptimizer
{
    public BisectionMethod(Func<double, double> func, double left, double right, double precision)
    {
        ObjectiveFunction = func;
        this.left = left;
        this.right = right;
        this.Precision = precision;
    }
    public Func<double, double> ObjectiveFunction { get; init; }

    private double left;
    private double right;
    public double Precision { get; }
    public int Iterations { get; protected set; } = 0;
    public double Solve()
    {
        Iterations = 0;
        return BisectionMethodImpl(ObjectiveFunction, left, right, Precision);
    }
    double BisectionMethodImpl(Func<double, double> func, double left, double right, double precision)
    {
        Iterations++;
        var mid = (right + left) / 2;
        var midF = func(mid);
        if (midF * func(left) < 0)
            right = mid;
        else
            left = mid;
        if (Math.Abs(right - left) <= precision || Math.Abs(midF) < precision) return mid;
        return BisectionMethodImpl(func, left, right, precision);
    }
    public override string ToString()
    {
        return $"Bisection method done in {Iterations}";
    }
}

