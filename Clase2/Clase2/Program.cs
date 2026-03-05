int[] arreglo = { 15, 22, 10, 31, 5};

for (int i = 0; i < arreglo.Length; i++)
{
    arreglo[i] = i * 2;
    Console.WriteLine(arreglo[i]);
}

//Solo lectura
foreach(int valor in arreglo){
 Console.WriteLine(valor);
 //Modificar el valor no cambia el arreglo
 //valor += 2;
}

Console.WriteLine(arreglo);

static void QuickSort(int [] array, int low, int high)
{
    if (low < high)
    {
        int pivot = partition(array, low, high);
        QuickSort(array, low, pivot - 1);
        QuickSort(array, pivot + 1, high);
    }

    return array;
}

static int partition(int[] array, int low, int high)
{
    //Vamos a tomar por defecto el ultimo elemento como pivote
    int pivot = array[high];
    int posicionActual = low - 1;
}