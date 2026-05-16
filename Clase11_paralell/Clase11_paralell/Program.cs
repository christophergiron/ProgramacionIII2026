
// Task task1 = Task.Run(() =>
// {
//  
// });

DateTime now = DateTime.Now;

List<Task> tasks = new List<Task>();
for (int i = 0; i < 6; i++)
{
   tasks.Add(Task.Run(() =>
   {
      Sumar(500000000);
   }));
}

//Una pequeña pausa para cuando las tareas terminen.
await Task.WhenAll(tasks);
var elapsed = (DateTime.Now - now).Milliseconds;
Console.WriteLine("Tiempo en mili segundos " + elapsed);

// Sumar(500000000);
// Sumar(500000000);
// Sumar(500000000);
// Sumar(500000000);
// Sumar(500000000);
// Sumar(500000000);

Console.ReadLine();
static void Sumar(long n)
{
   var sum = 0;
   for (int i=0; i<n ; i++)
   {
      sum += i;
   }
   Console.WriteLine("La suma es" +sum);
}