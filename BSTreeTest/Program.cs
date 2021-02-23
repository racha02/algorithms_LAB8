using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTreeLib;

namespace BSTreeTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            BST bstree = new BST();

            bstree.Clear();
            bstree.Add(5);
            bstree.Add(7);
            bstree.Add(2);
            bstree.Add(10);
            bstree.Add(21);
            bstree.Add(4);
            bstree.Add(9);
            bstree.Add(15);
            /*Console.WriteLine("Number of members = {0}",
            bstree.Count(bstree.Root));
            Console.WriteLine();
            InorderTraversal(bstree.Root);
            Console.WriteLine();
            bstree.Delete(4);
            InorderTraversal(bstree.Root);
            Console.WriteLine();
            bstree.Add(10);
            InorderTraversal(bstree.Root);
            Console.WriteLine("\n");

            if (bstree.Search(100) != null)
                Console.WriteLine("Founded 10 in BST");
            else
                Console.WriteLine("Not Founded 10 in BST");
            Console.WriteLine();*/

            Console.WriteLine(""+ LeftMostTree(bstree.Root)) ;
            Console.WriteLine(""+ RightMostTree(bstree.Root));
        }
        static void InorderTraversal(Node current)
        {
            if (current != null)
            {
                InorderTraversal(current.Left);
                Console.Write("{0} ", current.Value.ToString());
                InorderTraversal(current.Right);
            }
        }
        static void PostorderTraversal(Node current)
        {
            if (current != null)
            {
                PostorderTraversal(current.Left);
                PostorderTraversal(current.Right);
                Console.Write("{0} ", current.Value.ToString());
            }
        }
        static int LeftMostTree(Node current)
        {
            
            int min = 0;
            while (current != null)
            {
                min = current.Value;
                current = current.Left;         
            }
            return min;

        }

        static int RightMostTree(Node current)
        {
            int max = 0;
            while (current != null)
            {
                max = current.Value;
                current = current.Right;
            }
            return max;

        }
    }
}

