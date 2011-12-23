using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trees
{
    class BinaryTreeNode
    {
        internal int data;
        internal BinaryTreeNode left;
        internal BinaryTreeNode right;
        public BinaryTreeNode(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
        public BinaryTreeNode(int data, BinaryTreeNode left, BinaryTreeNode right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (left == null)
                sb.Append("X");
            else
                sb.Append(left.data);
            sb.Append("<---"+data+"--->");
            if (right == null)
                sb.Append("X");
            else
                sb.Append(right.data);
            return sb.ToString();
        }
    }
    class BinaryTreeNodeParent: BinaryTreeNode
    {
        internal BinaryTreeNodeParent parent;
        internal BinaryTreeNodeParent left;
        internal BinaryTreeNodeParent right;
        internal BinaryTreeNodeParent grandParent;
        public BinaryTreeNodeParent(int data):base(data){}
        public BinaryTreeNodeParent(int data, BinaryTreeNodeParent left, BinaryTreeNodeParent right)
            : base(data, left, right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
       // public BinaryTreeNodeParent():base() { }      
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (grandParent == null)
                sb.Append("X---");
            else
                sb.Append(grandParent.data + "---");
            if (parent == null)
                sb.Append("X---");
            else
                sb.Append(parent.data+"---");
            if (left == null)
                sb.Append("X");
            else
                sb.Append(left.data);
            sb.Append("<---" + data + "--->");
            if (right == null)
                sb.Append("X");
            else
                sb.Append(right.data);
            return sb.ToString();
        }
    }

    class GetTrees
    {
        /*          10
         *         /   \ 
        *         8    11
         *       
         **/
        internal static BinaryTreeNode SimpleTree()
        {
            BinaryTreeNode left = new BinaryTreeNode(8);
            BinaryTreeNode right = new BinaryTreeNode(11);
            BinaryTreeNode simpleTree = new BinaryTreeNode(10, left, right);
            return simpleTree;
        }
       /*          10
       *         /   \ 
       *        8    11
       *      /  \  /   \
       *     5   6 9    12
       */
        internal static BinaryTreeNode BalancedTree()
        {
            BinaryTreeNode n1 = new BinaryTreeNode(5);
            BinaryTreeNode n2 = new BinaryTreeNode(6);
            BinaryTreeNode n3 = new BinaryTreeNode(9);
            BinaryTreeNode n4 = new BinaryTreeNode(12);
            BinaryTreeNode left = new BinaryTreeNode(8,n1,n2);
            BinaryTreeNode right = new BinaryTreeNode(11,n3,n4);
            BinaryTreeNode simpleTree = new BinaryTreeNode(10, left, right);
            return simpleTree;
        }
        /*          10
        *         /   \ 
        *        7      13
        *      /  \    /   \
        *     5    8  11    15
        */
        internal static BinaryTreeNode BinarySearchTree()
        {
            BinaryTreeNode n1 = new BinaryTreeNode(5);
            BinaryTreeNode n2 = new BinaryTreeNode(8);
            BinaryTreeNode n3 = new BinaryTreeNode(11);
            BinaryTreeNode n4 = new BinaryTreeNode(15);
            BinaryTreeNode left = new BinaryTreeNode(7, n1, n2);
            BinaryTreeNode right = new BinaryTreeNode(13, n3, n4);
            BinaryTreeNode simpleTree = new BinaryTreeNode(10, left, right);
            return simpleTree;
        }
       /*         10
       *         /   \ 
       *        8    11
       *      /  \  /   \
       *     5   6 8    12
       *    / \          \
       *   2   3          1
       *        \
       *         4
       */
        internal static BinaryTreeNode UnBalancedTree()
        {
            BinaryTreeNode n122 = new BinaryTreeNode(4);
            BinaryTreeNode n11 = new BinaryTreeNode(2);
            BinaryTreeNode n12 = new BinaryTreeNode(3,null,n122);
            BinaryTreeNode n1 = new BinaryTreeNode(5,n11,n12);
            BinaryTreeNode n2 = new BinaryTreeNode(6);
            BinaryTreeNode n3 = new BinaryTreeNode(8);
            BinaryTreeNode n42 = new BinaryTreeNode(1);
            BinaryTreeNode n4 = new BinaryTreeNode(12,null,n42);
            BinaryTreeNode left = new BinaryTreeNode(8, n1, n2);
            BinaryTreeNode right = new BinaryTreeNode(11, n3, n4);
            BinaryTreeNode simpleTree = new BinaryTreeNode(10, left, right);
            return simpleTree;
        }
        internal static BinaryTreeNodeParent UnBalancedTreeParent()
        {
            BinaryTreeNodeParent n122 = new BinaryTreeNodeParent(4);
            BinaryTreeNodeParent n11 = new BinaryTreeNodeParent(2);
            BinaryTreeNodeParent n12 = new BinaryTreeNodeParent(3, null, n122);
            BinaryTreeNodeParent n1 = new BinaryTreeNodeParent(5, n11, n12);
            BinaryTreeNodeParent n2 = new BinaryTreeNodeParent(6);
            BinaryTreeNodeParent n3 = new BinaryTreeNodeParent(8);
            BinaryTreeNodeParent n42 = new BinaryTreeNodeParent(1);
            BinaryTreeNodeParent n4 = new BinaryTreeNodeParent(12, null, n42);
            BinaryTreeNodeParent left = new BinaryTreeNodeParent(8, n1, n2);
            BinaryTreeNodeParent right = new BinaryTreeNodeParent(11, n3, n4);
            BinaryTreeNodeParent simpleTree = new BinaryTreeNodeParent(10, left, right);
            return simpleTree;
        }
    }
    class BinarySearchTree
    {
        //Assuming no duplicate nodes
        BinaryTreeNode root;
        public BinarySearchTree()
        {
            root = null;
        }
        internal BinaryTreeNode Insert(ref BinaryTreeNode root,BinaryTreeNode newNode)
        {
            if (root == null)
            {
                root = newNode;
            }
            else { 
                if (root.data > newNode.data)
                   Insert(ref root.left, newNode);
                else 
                   Insert(ref root.right, newNode);
            }
            return root;
        }
        internal bool Search(BinaryTreeNode root,int data)
        {
            if (root == null)
                return false;
            if (root.data == data)
                return true;
            else if (root.data < data)
                return Search(root.right, data);
            else
                return Search(root.left, data);
        }
    }
    class TreeProblems
    {
        static void Main(string[] args)
        {
            
            TreeProblems tp = new TreeProblems();
            //BinaryTreeNodeParent pa=tp.AssignParent(GetTrees.UnBalancedTreeParent());
            //pa = tp.AssignGrandParent(pa);
           
            //tp.InOrderValues(GetTrees.UnBalancedTree());
            //foreach (var item in tp.inOrder)
            //    Console.WriteLine(item);
            //tp.preOrderValues(GetTrees.UnBalancedTree());
            //foreach (var item in tp.preOrder)
            //    Console.WriteLine(item);

            //BinaryTreeNode r = tp.CreateTree(tp.preOrder, tp.inOrder);
            BinaryTreeNode n1 = GetTrees.SimpleTree();
          //  BinarySearchTree bt= new BinarySearchTree();
            BinaryTreeNode n2 = GetTrees.SimpleTree();
           // bt.Insert(ref bst, new BinaryTreeNode(6));
            //bt.Insert(ref bst, new BinaryTreeNode(12));
            // bt.Insert(ref bst, new BinaryTreeNode(10));
            Console.WriteLine(tp.IsBST(n1));
        }
        bool IsSubTree(BinaryTreeNode n1, BinaryTreeNode n2)
        {
            if (n1 == null)
                return false;
            if (MatchTree(n1, n2))
                return true;
            return  IsSubTree(n1.left, n2) ||
                IsSubTree(n1.right, n2);
        }
        bool MatchTree(BinaryTreeNode n1, BinaryTreeNode n2)
        {
            if (n2 == null)
                return true;
            if (n1 == null)
                return false;
            if (n1.data == n2.data)
                return MatchTree(n1.left, n2.left)
                    && MatchTree(n1.right, n2.right);
            else
                return false;
        }
        bool IsBST(BinaryTreeNode n1)
        {
            if (n1 == null)
                return true;
            if (n1.left != null && n1.left.data > n1.data)
                return false;
            if (n1.right != null && n1.right.data < n1.data)
                return false;
            return IsBST(n1.left) && IsBST(n1.right);
        }

        int TreeHeight(BinaryTreeNode root)
        {
            if (root == null)
                return 0;
            return 1 + Math.Max(TreeHeight(root.right), TreeHeight(root.left));
        }

        BinaryTreeNodeParent AssignGrandParent(BinaryTreeNodeParent curent)
        {
            if (curent == null)
                return null;

            if (curent.left != null)
            {
                curent.left.grandParent = curent.parent;
                AssignGrandParent(curent.left);
            }
            if (curent.right != null)
            {
                curent.right.grandParent = curent.parent;
                AssignGrandParent(curent.right);
            }
            return curent;
        }

        BinaryTreeNodeParent AssignParent(BinaryTreeNodeParent curent)
        {
            if (curent == null)
                return null;

            if (curent.left != null)
            {
                curent.left.parent = curent;
                AssignParent(curent.left);
            }

            if (curent.right != null)
            {
                curent.right.parent = curent;
                AssignParent(curent.right);
            }
            return curent;
        }

        void PreOrder(BinaryTreeNode current)
        {
            if (current == null) return;
            Console.WriteLine(current);
            PreOrder(current.left);
            PreOrder(current.right);
        }
        void PreOrderIterative(BinaryTreeNode current)
        {
            Stack<BinaryTreeNode> s = new Stack<BinaryTreeNode>();
            s.Push(current);
            while(s.Count!=0)
            {
                BinaryTreeNode temp= s.Pop();
                Console.WriteLine(temp);
                s.Push(temp.right);
                s.Push(temp.left);
            }
        }
        List<int> preOrder= new List<int>();

        void preOrderValues(BinaryTreeNode current)
        {
            if (current != null) {
            preOrder.Add(current.data);
            preOrderValues(current.left);
            preOrderValues(current.right);
            }
        }

        List<int> inOrder= new List<int>();
        void InOrderValues(BinaryTreeNode current)
        {
            if (current != null)
            {
                InOrderValues(current.left);
                inOrder.Add(current.data);
                InOrderValues(current.right);
            }
        }
        
        void InOrder(BinaryTreeNode current)
        {
            if (current == null) return;
            InOrder(current.left);
            Console.WriteLine(current);
            InOrder(current.right);
        }
        void PostOrder(BinaryTreeNode current)
        {
            if (current == null) return;
            PostOrder(current.left);
            PostOrder(current.right);
            Console.WriteLine(current);
        }
        void LeveLOrder(BinaryTreeNode current)
        {
            Queue<BinaryTreeNode> q = new Queue<BinaryTreeNode>();
            q.Enqueue(current);
            while (q.Count != 0)
            {
                BinaryTreeNode temp = q.Dequeue();
                Console.WriteLine(temp);
                if (temp.left != null)
                    q.Enqueue(temp.left);
                if (temp.right != null)
                    q.Enqueue(temp.right);
            }
        }
        BinaryTreeNode CreateTree(List<int> preOrder,List<int>inOrder)
        {
            if (preOrder == null || inOrder == null) return null;
            if (preOrder.Count != inOrder.Count) return null;//throw exception
            int a = 0;
            return CreateNode(preOrder, inOrder,ref a, 0, inOrder.Count - 1);

        }

        private BinaryTreeNode CreateNode(List<int> preOrder, List<int> inOrder,ref int preIndex, int low, int high)
        {
            if (low > high)
                return null;
            BinaryTreeNode root = new BinaryTreeNode(preOrder[preIndex]);
            int pos=-1; 
            for (int i = low; i <= high; i++)
            {
                if (inOrder[i] == preOrder[preIndex])
                {
                    pos = i;
                    break;
                }
            }
            preIndex++;
            if (pos >= 0)
            {
                root.left = CreateNode(preOrder, inOrder, ref preIndex, low,pos-1);
                root.right = CreateNode(preOrder, inOrder, ref preIndex,pos + 1,high);
            }
            return root;
        }
        
    }
}
