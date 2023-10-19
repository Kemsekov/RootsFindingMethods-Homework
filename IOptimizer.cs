
public interface IOptimizer{
    public Func<double,double> ObjectiveFunction{get;}
    public int Iterations{get;}
    public double Precision{get;}
    double Solve();
}
