using System.Security.AccessControl;

namespace Clase5;

public class Node
{
    public int value { get; set; }
    public Node left { get; set;}
    public Node right { get; set;}
    
    public Node(int value)
    {
        this.value = value;
        right = null;
        left = null;
    }
}