namespace Clase5;

public class BinaryTree
{
    public Node root;


    private Node addRecursive(Node current, int value)
    {
        if (current == null)
        {
            return new Node(value);
        }

        if (value < current.value)
        {
            current.left = addRecursive(current.left, value);
        }
        else if (value > current.value)
        {
            current.right = addRecursive(current.right, value);
        }
        
        return current;
    }

    public void add(int value)
    {
        this.root = addRecursive(this.root, value);
    }

    public void preOrden(Node current)
    {
        if (current == null)
        {
            return;
        }

        Console.Write(current.value + " ");
        preOrden(current.left);
        preOrden(current.right);
    }
    public void postOrden(Node current)
    {
        if (current == null)
        {
            return;
        }
        preOrden(current.left);
        preOrden(current.right);
        Console.Write(current.value + " ");
    }

    public void inOrden(Node current)
    {
        if (current == null)
        {
            return;
        }
        preOrden(current.left);
        Console.Write(current.value + " ");
        preOrden(current.right);
    }
}