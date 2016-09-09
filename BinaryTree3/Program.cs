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

            Console.ReadKey();

            for (int i = 0; i < tree.testPrint.Count; i++)
            {
                Console.Write(tree.testPrint[i] + " ");
            }

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
        int count; //Amount of Nodes
        int next; //The number for the next Node
        Node current; //Selected Node
        Node root; //Root of the Tree

        public List<int> testPrint = new List<int>();

        public BinaryTree()
        {
            count = 0;
            current = null;
            root = null;
        }

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
                List<int> nodes = new List<int>();
                
                current = root;
                count++;
                next = count;

                while (next > 1)
                {
                    if(next %2 == 0)
                    {

                        nodes.Add(next);
                        next = next / 2;

                    }
                    else if(next %2 == 1)
                    {

                        nodes.Add(next);
                        next = (next - 1) / 2;
                        //nodes.Add(next);
                    }
                }

                for (int i = nodes.Count; i > nodes.Count; i--)
                {
                    if(nodes[i] %2 == 0)
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
                            current.left = new Node(x);
                            testPrint.Add(x);
                        }

                    }
                }

            }

        }
    }
}
