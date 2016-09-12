using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree3
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.AddNode(12);
            tree.AddNode(10);
            tree.AddNode(55);
            tree.AddNode(20);
            tree.AddNode(40);
            tree.AddNode(50);
            tree.AddNode(42);

            Console.ReadKey();

            tree.PrintList(); //print de lijst

            Console.ReadLine();
            Console.WriteLine();

            tree.PrintTest(); //hard-coded check op die lijst (tot 3 lagen)
            
            Console.ReadLine();
        }
    }

    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int x)
        {
            data = x;
        }
    }

    public class BinaryTree
    {
        int count; //Totaal aantal nodes.
        int next; //Volgende node bij het bedenken van het stappenplan.
        Node current; //Selected Node.
        Node root; //Root van de tree.

        List<int> testPrint = new List<int>(); //Lijst die alle Node.data onthoud om later uit te printen (om te testen of hij goed wordt opgebouwd).

        public BinaryTree()
        {
            count = 0;
            current = null;
            root = null;
        }

        /// <summary>
        /// Add Methode die vanaf de doel positie, het pad terug naar de root opslaat in een list (nodes) en deze
        /// vervolgens met een for-loop achterstevoren uitleest en via die weg de node aanmaakt en koppelt aan de juiste parent.
        /// </summary>
        /// <param name="x">data die de node moet onthouden.</param>
        public void AddNode(int x)
        {
            //root check
            if(root == null)
            {
                //Add the root
                root = new Node(x);
                count = 1;

                current = root;
                testPrint.Add(x);
            }
            else
            {
                List<int> nodes = new List<int>(); //Lijst met stappen vanaf het doel terug naar de root node.
                
                current = root;
                count++;
                next = count;

                while (next > 1) //Zolang de volgende stap (next) niet de root is...
                {
                    if(next %2 == 0) //ALS volgende stap == even
                    {
                        nodes.Add(next); //voeg stap toe aan de lijst
                        next = next / 2; //ga naar de parent (terug te rekenen)

                    }
                    else if(next %2 == 1) //ALS volgende stap == oneven
                    {
                        nodes.Add(next); //voeg stap toe aan de lijst
                        next = (next - 1) / 2; //ga naar de parent (terug te rekenen)
                    }
                }

                for (int i = nodes.Count; i > 0; i--) //loop die de list achterstevoren uitleest en zo de stappen volgt om de node echt te plaatsen/koppelen.
                {
                    if(nodes[i-1] %2 == 0)
                    {
                        if(current.left != null)
                        {
                            current = current.left;
                        }
                        else
                        {
                            current.left = new Node(x);
                            testPrint.Add(x);
                        }
                        
                    }
                    else
                    {
                        if(current.right != null)
                        {
                            current = current.right;
                        }
                        else
                        {
                            current.right = new Node(x);
                            testPrint.Add(x);
                        }

                    }
                }

            }

        }

        /// <summary>
        /// Een methode die de testPrint [List] print."
        /// </summary>
        public void PrintList()
        {
            for (int i = 0; i < testPrint.Count; i++)
            {
                Console.Write(testPrint[i] + " ");
            }
        }

        /// <summary>
        /// Hard-Coded print functie om de testgetallen te controleren.
        /// </summary>
        public void PrintTest()
        {
            Console.WriteLine(root.data);
            Console.WriteLine("left: " + root.left.data + " " + "right: " + root.right.data);
            Console.WriteLine("left: " + root.left.left.data + " " + root.left.right.data + " " + "right: " + root.right.left.data + " " + root.right.right.data);
        }
    }
}
