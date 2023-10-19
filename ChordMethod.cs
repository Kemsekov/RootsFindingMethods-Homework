
public class ChordMethod : IOptimizer
{
    public ChordMethod(Func<double, double> func, double left, double right, double precision)
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
        Iterations=0;
        return ChordMethodImpl(ObjectiveFunction, left, right, Precision);
    }
    double ChordMethodImpl(Func<double, double> func, double left, double right, double precision)
    {
        Iterations++;
        var fLeft = func(left);
        var newLeft = left - fLeft / (func(right) - fLeft) * (right - left);
        if (Math.Abs(left - newLeft) < precision) return newLeft;
        return ChordMethodImpl(func, newLeft, right, precision);
    }
    public override string ToString()
    {
        return $"Chord method done in {Iterations}";
    }
}

