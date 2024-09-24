public class Nodo
{
    public int Valor;
    public Nodo Izquierda;
    public Nodo Derecha;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierda = null;
        Derecha = null;
    }
}


public class ArbolesBinarios
{
    private Nodo Raiz;

    public ArbolesBinarios()
    {
        Raiz = null;
    }

    // Método para mostrar el árbol en orden
    public void MostrarEnOrden()
    {
        MostrarEnOrdenRecursivo(Raiz);
        Console.WriteLine();
    }

    private void MostrarEnOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            MostrarEnOrdenRecursivo(nodo.Izquierda);
            Console.Write(nodo.Valor + " ");
            MostrarEnOrdenRecursivo(nodo.Derecha);
        }
    }

    public Nodo GetRaiz()
    {
        return Raiz;
    }

    public void SetRaiz(Nodo raiz)
    {
        Raiz = raiz;
    }
}


public class Operaciones
{
    private ArbolesBinarios arbol;

    public Operaciones(ArbolesBinarios arbol)
    {
        this.arbol = arbol;
    }

    // Método para insertar un valor en el árbol
    public void Insertar(int valor)
    {
        arbol.SetRaiz(InsertarRecursivo(arbol.GetRaiz(), valor));
    }

    private Nodo InsertarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null)
        {
            return new Nodo(valor);
        }

        if (valor < nodo.Valor)
        {
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, valor);
        }
        else if (valor > nodo.Valor)
        {
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, valor);
        }

        return nodo;
    }

    // Método para eliminar un valor del árbol
    public void Eliminar(int valor)
    {
        arbol.SetRaiz(EliminarRecursivo(arbol.GetRaiz(), valor));
    }

    private Nodo EliminarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null)
        {
            return nodo;
        }

        if (valor < nodo.Valor)
        {
            nodo.Izquierda = EliminarRecursivo(nodo.Izquierda, valor);
        }
        else if (valor > nodo.Valor)
        {
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, valor);
        }
        else
        {
            // Nodo encontrado
            if (nodo.Izquierda == null)
            {
                return nodo.Derecha;
            }
            else if (nodo.Derecha == null)
            {
                return nodo.Izquierda;
            }

            // Nodo con dos hijos: obtener el sucesor más pequeño
            nodo.Valor = Minimo(nodo.Derecha);
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, nodo.Valor);
        }

        return nodo;
    }

    private int Minimo(Nodo nodo)
    {
        int min = nodo.Valor;
        while (nodo.Izquierda != null)
        {
            min = nodo.Izquierda.Valor;
            nodo = nodo.Izquierda;
        }
        return min;
    }
}


class Program
{
    static void Main(string[] args)
    {
        ArbolesBinarios arbol = new ArbolesBinarios();
        Operaciones operaciones = new Operaciones(arbol);
        int opcion, valor;

        do
        {
            Console.WriteLine("*********Menu*********");
            Console.WriteLine("1. Insertar un valor");
            Console.WriteLine("2. Eliminar un valor");
            Console.WriteLine("3. Mostrar en orden");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el valor a insertar: ");
                    valor = Convert.ToInt32(Console.ReadLine());
                    operaciones.Insertar(valor);
                    break;
                case 2:
                    Console.Write("Ingrese el valor a eliminar: ");
                    valor = Convert.ToInt32(Console.ReadLine());
                    operaciones.Eliminar(valor);
                    break;
                case 3:
                    Console.WriteLine("Árbol en orden:");
                    arbol.MostrarEnOrden();
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        } while (opcion != 0);
    }
}
