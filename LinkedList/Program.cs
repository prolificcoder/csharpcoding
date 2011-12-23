using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList
{
    class DoubleListNode
    {
        internal int data;
        internal DoubleListNode next;
        internal DoubleListNode prev;
        internal int priority; //lower priority is higher
        public DoubleListNode(int data, int priority, DoubleListNode next, DoubleListNode prev)
        {
            this.data = data;
            this.next = next;
            this.prev = prev;
            this.priority = priority;
        }
        public DoubleListNode(int data, int priority)
        {
            this.data = data;
            this.priority = priority;
            this.prev = null;
            this.next = null;
        }
         
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (prev == null)
                sb.Append("X<--");
            else
                sb.Append(prev.data+"<--");
            sb.Append(data);
            
            if (next == null)
                 sb.Append(" -->" + "X");
            else
                sb.Append("-->"+next.data);
            return sb.ToString();
        }
    }
    class PriorityQueue
    {
        DoubleListNode head;
        public PriorityQueue()
        {
            head = null;
        }
        internal void Enqueue(DoubleListNode newNode)
        {
            if (head == null)
            {
                head = newNode;
                return;
            }
            if (newNode.priority < head.priority)
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
                return;
            }
            DoubleListNode cur = head;
            while (cur.next != null && cur.next.priority < newNode.priority)
            {
                cur = cur.next;
            }
            if (cur.next == null)
            {
                cur.next = newNode;
                newNode.prev = cur;
            }
            else
            {
                cur.next.prev = newNode;
                newNode.next = cur.next;
                cur.next = newNode;
                newNode.prev = cur;
            }
        }

        internal DoubleListNode Deque()
        {
            if (head == null)
                return null;
            DoubleListNode temp = head;
            head = head.next;
            return temp;
        }
    }

    class ListNode
    {
        internal int data;
        internal ListNode next;
        public ListNode(int data, ListNode next)
        {
            this.data = data;
            this.next = next;
        }
        public override string ToString()
        {
            if (next == null)
                return data.ToString() + " --> " + "X";
            return data.ToString() +" --> "+ next.data.ToString();
        }
    }
    class LinkedList
    {
        internal ListNode head;
        public LinkedList(ListNode head)
        {
            this.head = head;
        }
        internal bool DetectCycle(ListNode head)
        {
            if (head.next == null || head == null)
                return false;
            ListNode slow = head;
            ListNode fast = head.next;
            while (slow != null && fast != null && fast.next !=null)
            {
                if (fast.next == slow || fast == slow)
                    return true;
                else
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }
            }
            return false;
        }
        internal ListNode GetCycleStartNode(ListNode head)
        {
            if (head == null )
                return null;
            ListNode slow = head;
            ListNode fast = head;
            while (fast.next !=null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (fast == slow)
                    break;
            }
            slow = head;
            while (fast != slow)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return fast;
        }
        internal int GetCycleListLength(ListNode head)
        {
            if (head == null)
                return 0;
            int count = 0;
            ListNode slow = head;
            ListNode fast = head;
            while (fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                count++;
                if (fast == slow)
                    break;
            }
            slow = head;
            while (fast != slow)
            {
                count++;
                slow = slow.next;
                fast = fast.next;
            }
            return count;
        }
        ListNode SwapAdjacent(ListNode head)
        {
            ListNode prev = null, cur = head;
            while (cur != null && cur.next != null)
            {
                if (prev == null)
                {
                    head = cur.next;
                    ListNode temp = cur.next.next;
                    cur.next.next = cur;
                    cur.next = temp;
                    prev = cur;
                }
                else
                {
                    prev.next = cur.next;
                    cur.next = cur.next.next;
                    prev.next.next = cur;
                    prev = cur;
                }
                cur = cur.next;
            }
            return head;

        }
  
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            ListNode cur = this.head;
            while (cur != null)
            {
                sb.Append(cur.data + "->");
                cur = cur.next;
            }
            sb.Append("X");
            return sb.ToString();
        }
    }
    class FrequencyLinkedListNode
    {
        internal string word;
        internal FrequencyLinkedListNode next;
        internal int frequency;

        public FrequencyLinkedListNode(string word, FrequencyLinkedListNode next, int frequency)
        {
            this.word = word;
            this.next = next;
            this.frequency = frequency;
        }
    }

     class VertexedLinkedListNode
    {
         internal int data;
         internal VertexedLinkedListNode next;
         internal bool IsVertex;

        public VertexedLinkedListNode(int data, VertexedLinkedListNode next, bool IsVertex)
        {
            this.data = data;
            this.next = next;
            this.IsVertex = IsVertex;
        }
       

    }
    static class StringHelper
    {
        public static string Capitalize (this string str)
        {
            if(str.Length==0)return str;
            return char.ToUpper(str[0]) + str.Substring(1); 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            //FrequencyLinkedListNode root= p.GetWordCountsInLinkedList("this is a this is mega a a a this this this ".Split().ToList());
            //Console.WriteLine(root);
            //FrequencyLinkedListNode cur = root;
            //while (cur != null)
            //{
            //  Console.WriteLine(cur.word+"  "+cur.frequency);
            //    cur=cur.next;
            //}
            //VertexedLinkedListNode root, n1, n2,n3,n4,n5,n6;
            //n6 = new VertexedLinkedListNode(8, null, true);
            //n5 = new VertexedLinkedListNode(8, n6, true);
            //n4 = new VertexedLinkedListNode(8, n5, true);
            //n3 = new VertexedLinkedListNode(8, n4, true);
            //n2 = new VertexedLinkedListNode(8, n3, true);
            //n1 = new VertexedLinkedListNode(8, n2, true);
            //root = new VertexedLinkedListNode(5, n1, true);

            //Console.WriteLine(p.MaxDistanceBetweenVertices(root));

            //ListNode n2 = null;
            //ListNode n4 = new ListNode(6, n2);
            //ListNode n3 = new ListNode(5, n4);

            //n2 = new ListNode(4, n3);
            //n4.next = n2;
            //ListNode root = new ListNode(3, n2);
            //LinkedList ll = new LinkedList(root);
            //// root1 = p.Merge(root1, root2);
            //while (root1 != null)
            //{
            //    Console.WriteLine(root1.data);
            //    root1 = root1.next;
            //}
           // Console.WriteLine(ll.ToString());
            //Console.Write(ll.DetectCycle(ll.head));
            //Console.WriteLine(ll.GetCycleListLength(ll.head));
            //DoubleListNode n1, n2, n3, n4, n5;
            //n1 = new DoubleListNode(1, 0);
            //n2 = new DoubleListNode(2, 1);
            //n3 = new DoubleListNode(3, 2);
            //n4 = new DoubleListNode(4, 1);
            //PriorityQueue pq = new PriorityQueue();
            //pq.Enqueue(n1);
            //pq.Enqueue(n2);
            //pq.Enqueue(n3);
            //pq.Enqueue(n4);
            //DoubleListNode d = pq.Deque();
            //pq.Enqueue(new DoubleListNode(5, 0));
            //d = pq.Deque();
            //d = pq.Deque();
            //Console.WriteLine(d.data + " " + d.priority);
            ListNode root, n1,n2,n3,n4,n5,n6;
            n6 = new ListNode(7, null);
            n5 = new ListNode(6, n6);
            n4 = new ListNode(5, n5);
            n3 = new ListNode(4, n4);
            n2 = new ListNode(3, n3);
            n1 = new ListNode(2, n2);
            root = new ListNode(1, n1);
          
            //ListNode root1, n3, n4;
            //n4 = new ListNode(10, null);
            //n3 = new ListNode(6, n4);
            //root1 = new ListNode(3, n3);
            ListNode cur = p.SwapAdjacent2(root);
            while (cur != null)
            {
                Console.WriteLine(cur);
                cur = cur.next;
            }
               
        }
         ListNode SwapAdjacent2(ListNode head)
        {
            ListNode cur = head;
            ListNode temp= null;
             while (cur != null && cur.next != null)
            {
                ListNode forward = cur.next;
                cur.next = forward.next;
                forward.next = cur;
                if (cur == head)
                    head = forward;
                if (temp != null)
                    temp.next = forward;
                temp = cur;
                cur = cur.next;
               
            }
            return head;

        }



        FrequencyLinkedListNode GetWordCountsInLinkedList(List<string> strings)
        {
            FrequencyLinkedListNode prev=null;
            FrequencyLinkedListNode root= new FrequencyLinkedListNode(strings.First(),null,1);
           
            foreach (string str in strings.Skip(1))
            {
                FrequencyLinkedListNode cur = root;
                while (cur != null && cur.word != str)
                {
                    prev = cur;
                    cur = cur.next;
                }
                if (cur == null)
                {
                    prev.next = new FrequencyLinkedListNode(str, null, 1);
                }
                else 
                {
                    cur.frequency++;
                    //ReArrangeList(root);
                }
            }
            return root;
        }
        void ReArrangeList(FrequencyLinkedListNode root)
        {
            FrequencyLinkedListNode first = root;
            FrequencyLinkedListNode second = root.next;
            while (second != null)
            {
                if (first.frequency == second.frequency)
                    ;//   second = second.next;

                else if (first.frequency < second.frequency)
                {
                    int tempF = second.frequency;
                    string tempW = second.word;
                    second.frequency = first.frequency;
                    second.word = first.word;
                    first.frequency = tempF;
                    first.word = tempW;

                    first = second;
                }
                second = second.next;
            }
        }

        int? MaxDistanceBetweenVertices(VertexedLinkedListNode root)
        {
            int count = 0;
            int? start = null, end = null;
            VertexedLinkedListNode cur = root;
            while (cur != null)
            {
                count++;
                if (cur.IsVertex)
                {
                    if (start == null)
                        start = count;
                    else 
                        end = count;
                }
                cur = cur.next;
            }
            return end - start;
        }

        //Merge in merge sort for linked list
        ListNode Merge(ListNode h1, ListNode h2)
        {
            if (h2 == null) return h1;
            if (h1 == null) return h2;
            ListNode cur1 = h1, cur2 = h2;
            while (cur2 != null)
            {
                if (cur1.data >= cur2.data)
                {
                    ListNode temp = cur2.next;
                    cur2.next = cur1;
                    cur1 = cur2;
                    cur2 = temp;
                }
                else
                {
                    while ( cur1.next != null && cur1.next.data < cur2.data)
                    {
                        cur1 = cur1.next;
                    }
                    if (cur1.next == null)
                    {
                        cur1.next = cur2;
                        return cur1;
                    }
                    else
                    {
                        ListNode temp = cur2.next;
                        cur2.next = cur1.next;
                        cur1.next = cur2;
                        cur2 = temp;
                    }
                }
            }
            return h1;
        }
    }
}
