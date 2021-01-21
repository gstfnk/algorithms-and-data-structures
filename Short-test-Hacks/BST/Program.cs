using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class Program
    {
        public class Node
        {
            public int data;
            public Node left, right;

            public Node(int data)
            {
                this.data = data;
                left = right = null;
            }
        }
        public class Index
        {
            public int index;
        }
        class GFG
        {
            public virtual Node buildUtil(int[] @in, int[] post,
                              int inStrt, int inEnd,
                              Index pIndex)
            {
                // Base case  
                if (inStrt > inEnd)
                {
                    return null;
                }

                /* Pick current node from Postrder traversal  
                using postIndex and decrement postIndex */
                Node node = new Node(post[pIndex.index]);
                (pIndex.index)--;

                /* If this node has no children  
                then return */
                if (inStrt == inEnd)
                {
                    return node;
                }

                /* Else find the index of this node  
                in Inorder traversal */
                int iIndex = search(@in, inStrt, inEnd, node.data);

                /* Using index in Inorder traversal,  
                construct left and right subtress */
                node.right = buildUtil(@in, post, iIndex + 1,
                                            inEnd, pIndex);
                node.left = buildUtil(@in, post, inStrt,
                                           iIndex - 1, pIndex);

                return node;
            }

            // This function mainly initializes  
            // index of root and calls buildUtil()  
            public virtual Node buildTree(int[] @in,
                                          int[] post, int n)
            {
                Index pIndex = new Index();
                pIndex.index = n - 1;
                return buildUtil(@in, post, 0, n - 1, pIndex);
            }

            /* Function to find index of value in  
            arr[start...end]. The function assumes 
            that value is postsent in in[] */
            public virtual int search(int[] arr, int strt,
                                      int end, int value)
            {
                int i;
                for (i = strt; i <= end; i++)
                {
                    if (arr[i] == value)
                    {
                        break;
                    }
                }
                return i;
            }

            /* This funtcion is here just to test */
            public virtual void preOrder(Node node)
            {
                if (node == null)
                {
                    return;
                }
                Console.Write(node.data + " ");
                preOrder(node.left);
                preOrder(node.right);
            }

            static void Main(string[] args)
            {
                GFG tree = new GFG();
                // 5, 3, 1, 9, 8, 11, 15, 12, 19, 10, 7
                int[] post = new int[] { 5, 3, 1, 9, 8, 11, 15, 12, 19, 10, 7 };

                int[] @in = new int[post.Length];
                Array.Copy(post, @in, post.Length);
                Array.Sort(@in);

                int n = @in.Length;
                Node root = tree.buildTree(@in, post, n);
                Console.WriteLine("Preorder of the constructed tree : ");
                tree.preOrder(root);

                Console.ReadKey();
            }
        }
    }
}
