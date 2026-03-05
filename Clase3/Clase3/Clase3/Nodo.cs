namespace Clase3;

public class Node
{
    private int value;
    private Node next;

    public Node(int value, Node next)
    {
        this.value = value;
        this.next = next;
    }
    
    //public int Value() => value;
    public int Value()
    {
        return value;
    }

    public Node Next() => next;
}