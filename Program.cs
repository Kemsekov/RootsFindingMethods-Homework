var left = 2;
var right = 4;
var startX = 0;
var precision = 0.000001;
double func(double x)=>x*x*x-6*x-8;
double funcDerivative(double x)=>3*x*x-6;
double funcDerDerivative(double x)=>6*x;
double phi(double x)=>Math.Pow(6*x+8,1.0/3);
var methods =new IOptimizer[]{
    new BisectionMethod(func,left,right,precision),
    new IterationMethod(phi,startX,precision),
    new NewtonMethod(func,funcDerivative,startX,precision),
    new ChordMethod(func,left,right,precision),
    new ChordNewtonCombinedMethod(func,funcDerivative,funcDerDerivative,left,right,precision)
};
System.Console.WriteLine("Start x "+startX);
System.Console.WriteLine("Precision "+precision);
foreach(var method in methods){
    var x = method.Solve();
    System.Console.WriteLine("-----------");
    System.Console.WriteLine($"X : {x}");
    System.Console.WriteLine(method);
}

