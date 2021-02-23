using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeLib
{
    public class BST
    {
        public Node Root;

        public void Add(int i)
        {
            Node newNode = new Node();
            newNode.Value = i;
            if (Root == null)
                Root = newNode;
            else
            {
                Node current = Root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (i < current.Value)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = newNode;
                            return;
                        }
                    }
                }
            }
        }

        public bool Delete(int key)
        {
            Node current = Root;
            Node parent = Root;
            bool isLeftChild = true;
            while (current.Value != key)
            {
                parent = current;
                if (key < current.Value)
                {
                    isLeftChild = true;
                    current = current.Left;
                }
                else
                {
                    isLeftChild = false;
                    current = current.Right;
                }
                if (current == null)
                    return false;
            }
            if ((current.Left == null) && (current.Right == null))
            {
                if (current == Root)
                    Root = null;
                else if (isLeftChild)
                    parent.Left = null;
                else
                    parent.Right = null;
            }
            else if (current.Right == null)
            {
                if (current == Root)
                    Root = current.Left;
                else if (isLeftChild)
                    parent.Left = current.Left;
                else
                    parent.Right = current.Right;
            }
            else if (current.Left == null)
            {
                if (current == Root)
                    Root = current.Right;
                else if (isLeftChild)
                    parent.Left = parent.Right;
                else
                    parent.Right = current.Right;
            }
            else
            {
                Node successor = GetSuccessor(current);
                if (current == Root)
                    Root = successor;
                else if (isLeftChild)
                    parent.Left = successor;
                else
                    parent.Right = successor;
                successor.Left = current.Left;
            }
            return true;
        }

        public Node GetSuccessor(Node delNode)
        {
            Node successorParent = delNode;
            Node successor = delNode;
            Node current = delNode.Right;
            while (!(current == null))
            {
                successorParent = current;
                successor = current;
                current = current.Left;
            }
            if (!(successor == delNode.Right))
            {
                successorParent.Left = successor.Right;
                successor.Right = delNode.Right;
            }
            return successor;
        }

        public void Clear()
        {
            Root = null;
        }

        public int Count(Node Root)
        {
            int c = 1;
            if (Root == null)
                return 0;
            else
            {
                c += Count(Root.Left);
                c += Count(Root.Right);
                return c;
            }
        }

        public Node Search(int key)
        {
            Node current = Root;
            while (current.Value != key)
            {
                if (key < current.Value)
                    current = current.Left;
                else
                    current = current.Right;
                if (current == null)
                    return null;
            }
            return current;
        }
    }
}
