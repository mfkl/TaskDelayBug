using System.Diagnostics;

var delay = 5000;
var tasks = Enumerable.Range(0, 10000000).Select(async x =>
{
    var sw = Stopwatch.StartNew();
    await Task.Delay(delay);
    var elapsed = sw.ElapsedMilliseconds;
    if (elapsed < delay)
        Console.WriteLine($"Supposed to wait for {delay} but instead waited for {elapsed}.");

    return 0;
});

var x = await Task.WhenAll(tasks);
Console.WriteLine(x.Sum());