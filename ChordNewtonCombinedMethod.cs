
public class ChordNewtonCombinedMethod : IOptimizer
{
    public ChordNewtonCombinedMethod(Func<double, double> func, Func<double, double> funcDer, Func<double, double> funcDerDer, double left, double right, double precision)
    {
        ObjectiveFunction = func;
        this.left = left;
        this.right = right;
        this.Precision = precision;
        this.Der = funcDer;
        this.DerDer = funcDerDer;
    }
    public Func<double, double> ObjectiveFunction { get; init; }

    private double left;
    private double right;
    public double Precision { get; }
    Func<double, double> Der { get; }
    Func<double, double> DerDer { get; }
    public int Iterations { get; protected set; } = 0;
    public double Solve()
    {
        Iterations=0;
        return ChordNewtonCombinedMethodImpl(ObjectiveFunction, Der, DerDer, left, right, Precision);
    }
    double ChordNewtonCombinedMethodImpl(Func<double, double> func, Func<double, double> funcDer, Func<double, double> funcDerDer, double left, double right, double precision)
    {
        Iterations++;
        var diff = Math.Abs(left - right);
        if (diff < precision) return (right + left) / 2;
        var x = (left + right) / 2;
        var fLeft = func(left);
        var fRight = func(right);
        var condition = fLeft * funcDerDer(x);
        if (condition > 0)
        {
            left -= fLeft / funcDer(left);
            right = left - fLeft / (fRight - fLeft) * (right - left);
        }
        else
        {
            left -= fLeft / (fRight - fLeft) * (right - left);
            right -= fRight / funcDer(right);
        }
        return ChordNewtonCombinedMethodImpl(func, funcDer, funcDerDer, left, right, precision);
    }
    public override string ToString()
    {
        return $"Chord newton method done in {Iterations}";
    }
}

