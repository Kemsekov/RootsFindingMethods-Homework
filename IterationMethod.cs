
public class IterationMethod : IOptimizer
{
    public IterationMethod(Func<double, double> phi, double startX, double precision)
    {
        ObjectiveFunction = phi;
        this.Precision = precision;
        this.startX = startX;
    }
    public Func<double, double> ObjectiveFunction { get; init; }
    public double Precision { get; }
    private double startX;
    public int Iterations { get; protected set; } = 0;
    public double Solve()
    {
        Iterations = 0;
        return IterationMethodImpl(ObjectiveFunction, startX, Precision);
    }
    double IterationMethodImpl(Func<double, double> phi, double startX, double precision)
    {
        Iterations++;
        var newX = phi(startX);
        if (Math.Abs(newX - startX) < precision) return newX;
        return IterationMethodImpl(phi, newX, precision);
    }
    public override string ToString()
    {
        return $"Iterations method done in {Iterations}";
    }
}



