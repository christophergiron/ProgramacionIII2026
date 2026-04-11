// See https://aka.ms/new-console-template for more information

using System.Globalization;
using Clase5;

BinaryTree tree = new BinaryTree();

tree.add(40);
tree.add(5);
tree.add(10);
tree.add(5);
tree.add(100);
tree.add(64);
tree.add(4);
tree.add(3);
tree.add(7);
tree.add(15);

Console.WriteLine("PreOrden");
tree.preOrden(tree.root);
Console.WriteLine("\nPostOrden");
tree.postOrden(tree.root);
Console.WriteLine("\nInOrden");
tree.inOrden(tree.root);