using System.Diagnostics;

Console.WriteLine($"Nombre de cœurs logiques : {Environment.ProcessorCount}");

var sw = Stopwatch.StartNew();
double sum = 1;
for(int i = 0; i < 50_000_000; i++)
{
    sum += Math.Sin(i) + Math.Cos(i);
    sum += Math.Sqrt(i);
    sum += Math.Exp(i % 10) + Math.Log(i);
    sum += Math.Pow(i % 100, 3);
    sum *= 1.0000001;
}
sw.Stop();
Console.WriteLine($"Temps de calcul séquentiel : {sw.ElapsedMilliseconds} ms");

sw.Restart();
double sumParallel = 0;
object lockObj = new object();

Parallel.For(
    0, 50_000_000,
    () => 0.0,
    (i, state, localSum) =>
    {
        localSum += Math.Sin(i) + Math.Cos(i);
        localSum += Math.Sqrt(i);
        localSum += Math.Exp(i % 10) + Math.Log(i);
        localSum += Math.Pow(i % 100, 3);
        localSum *= 1.0000001;
        return localSum;
    },
    localSum =>
    {
        lock(lockObj) { sumParallel += localSum; }
    }
);

sw.Stop();
Console.WriteLine($"Temps de calcul parallèle : {sw.ElapsedMilliseconds} ms");