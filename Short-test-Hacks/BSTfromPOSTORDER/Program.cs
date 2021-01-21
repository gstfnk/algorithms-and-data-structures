using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTfromPOSTORDER
{
    class Program
    {
        public class Node
        {
            public int key;
            public Node left, right;

            public Node(int key)
            {
                this.key = key;
            }
        }
        public static void inorder(Node root)
        {
            if (root == null)
            {
                return;
            }

            inorder(root.left);
            Console.Write(root.key + " ");
            inorder(root.right);
        }

        public static Node constructBST(int[] postorder, int start, int end)
        {
            // base case
            if (start > end)
            {
                return null;
            }

            // Construct the root node of the subtree formed by keys of the
            // postorder sequence in range [start, end]
            Node node = new Node(postorder[end]);

            // search the index of last element in current range of postorder
            // sequence which is smaller than the value of root node
            int i;
            for (i = end; i >= start; i--)
            {
                if (postorder[i] < node.key)
                {
                    break;
                }
            }

            // Build right subtree before left subtree since the values are
            // being read from the end of the postorder sequence

            // recursively construct the right subtree
            node.right = constructBST(postorder, i + 1, end - 1);

            // recursively construct the left subtree
            node.left = constructBST(postorder, start, i);

            // return current node
            return node;
        }
        static void Main(string[] args)
        {
            /* Construct below BST
                  15
                /    \
               /      \
              10       20
             /  \     /  \
            /     \  /    \
           8     12 16     25
        */

            int[] postorder = { 5, 3, 1, 9, 8, 11, 15, 12, 19, 10, 7 };

            // construct the BST
            Node root = constructBST(postorder, 0, postorder.Length - 1);

            // print the BST
            //System.out.print("Inorder Traversal of BST is : ");
            Console.WriteLine("Inorder Traversal of BST is : ");

            // inorder on the BST always returns a sorted sequence
            inorder(root);

            Console.ReadKey();
        }
    }
}
