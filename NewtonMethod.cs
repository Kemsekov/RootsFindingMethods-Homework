
public class NewtonMethod : IOptimizer
{
    public NewtonMethod(Func<double, double> func, Func<double, double> funcDerivative, double startX, double precision)
    {
        ObjectiveFunction = func;
        this.Der = funcDerivative;
        this.Precision = precision;
        this.startX = startX;
    }
    public Func<double, double> ObjectiveFunction { get; init; }
    public Func<double, double> Der { get; }

    private double left;
    private double right;
    public double Precision { get; }
    private double startX;
    public int Iterations { get; protected set; } = 0;
    public double Solve()
    {
        Iterations=0;
        return NewtonMethodImpl(ObjectiveFunction, Der, startX, Precision);
    }
    double NewtonMethodImpl(Func<double, double> func, Func<double, double> funcDerivative, double startX, double precision)
    {
        Iterations++;
        var newX = startX - func(startX) / funcDerivative(startX);
        if (Math.Abs(newX - startX) < precision) return newX;
        return NewtonMethodImpl(func, funcDerivative, newX, precision);
    }
    public override string ToString()
    {
        return $"Newton method done in {Iterations}";
    }
}



