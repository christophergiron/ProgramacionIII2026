
using Clase3;

// int valor = 10;
// string texto = "Hola";
//
// PersonaStruct persona = new PersonaStruct
// {
//     Nombre = "Jose"
// };
//
// Pasar(valor, texto, persona);
//
// Console.WriteLine("Valores en main int:{0}, string: {1}, clase: {2}", valor, texto, persona.Nombre);
//
//
// static void Pasar(int val1, string val2, PersonaStruct persona)
// {
//     val1 = 15;
//     val2 = "Hola desde la funcion";
//     persona.Nombre = "Juan";
//     Console.WriteLine("Valores en funcion: int: {0}, string: {1}, clase: {2}", val1, val2, persona.Nombre);
// }

//Node lista = new Node(10, null);

Console.WriteLine("Ingrese el nuevo valor:");
int valor = int.Parse(Console.ReadLine());

while (valor > 0)
{
    Node lista = new Node(valor, null);
}
