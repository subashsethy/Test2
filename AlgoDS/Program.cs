using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDS
{

    class ListNode
    {
        public int Data { get; set; }

        public ListNode Next { get; set; }

        public ListNode Random { get; set; }

        public ListNode(int data)
        {
            Data = data;
            Next = Random = null;
        }
    }


    class Algo
    {
        public int Reset(int num, int bit)
        {
            int x = -1 ^ (1 << bit);



            return num & x;
        }

        public int Toggle(int num, int bit)
        {
            return num ^ (1 << bit);
        }


        public bool Check(int num, int bit)
        {
            return (1 & (num >> bit)) == 0 ? true : false;
        }


        public ListNode Clone(ListNode head)
        {
            if (head == null)
                return head;

            ListNode current = head;
            while (current != null)
            {
                ListNode node = new ListNode(current.Data);

                node.Next = current.Next;

                current.Next = node;

                current = current.Next.Next;
            }



            current = head;

            while (current != null)
            {
                if (current.Random != null)


                    current.Next.Random = current.Random.Next;
                current = current.Next.Next;
            }


            current = head;
            ListNode temp = head;
            ListNode cloneNode = current.Next;
            ListNode newHead = cloneNode;

            current = current.Next.Next;
            while (current != null)
            {

                head.Next = current;
                current = current.Next;
                cloneNode.Next = current;
                current = current.Next;
                head = head.Next;
                cloneNode = cloneNode.Next;



            }

            head.Next = null;


            Dispaly(temp);


            return newHead;

        }


        public void Dispaly(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.Data + "-->");
                head = head.Next;
            }
            Console.WriteLine();
        }



        public int FindElementInfinity(int[] arr, int key)
        {
            int l = 0, h = 1;
            int val = arr[h];
            while (val < key)
            {
                l = h;
                h = 2 * h;
                val = arr[h];
            }

            return -1;
        }


        public int[] ProcessPattern(string pattern)
        {

            int[] lsp = new int[pattern.Length];
            lsp[0] = 0;
            int len = 0, i = 1;

            while (i < pattern.Length)
            {
                if (pattern[len] == pattern[i])
                {
                    len++;
                    lsp[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = lsp[len - 1];
                    }
                    else
                    {
                        lsp[i] = 0;
                        i++;
                    }
                }
            }



            return lsp;
        }

        public void KMP(string text, string pattern)
        {
            if (pattern == null)
                return;

            int i = 0, j = 0;
            int[] lsp = ProcessPattern(pattern);
            while (i < text.Length)
            {
                if (j == pattern.Length)
                {
                    Console.WriteLine("Match found at " + (i - pattern.Length));
                    break;
                }
                if (text[i] == pattern[j])
                {
                    j++;
                }
                else
                {
                    j = lsp[j - 1];
                    j++;

                }


            }



        }

        public int LengthOfLongestSubstring(string s)
        {

            HashSet<char> charSet = new HashSet<char>();
            int result = 0;
            int i = 0, j = 0;
            while (i < s.Length)
            {
                if (!charSet.Contains(s[i]))
                {

                    charSet.Add(s[i]);


                }
                else
                {
                    while (j < i)
                    {
                        if (s[i] != s[j])
                        {
                            charSet.Remove(s[j]);

                        }
                        else
                        {
                            j++;

                            break;
                        }
                        j++;
                    }


                }
                i++; ;
                if (result < i - j)
                {
                    result = i - j;
                }

            }

            return result;

        }


        public void Display(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.Data + " ->");
                head = head.Next;
            }
            Console.WriteLine();
        }
        public ListNode SwapNode(ListNode head)
        {
            if (head == null || head.Next == null)
                return head;

            ListNode prev = head;
            ListNode current = prev.Next;
            head = head.Next;

            while (current != null)
            {

                ListNode next = current.Next;
                if (next != null && next.Next != null)
                {
                    prev.Next = next.Next;
                    current.Next = prev;
                    prev = next;
                    current = prev.Next;
                }
                else
                {
                    current.Next = prev;
                    prev.Next = next;
                    break;
                }



            }


            return head;
        }


        public int BuildingSun(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return -1;

            int max = arr[0];
            int count = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= max)
                {
                    count++;
                    max = arr[i];
                }
            }

            return count;




        }

        public void MoveOneUnit(int[] arr, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                arr[endIndex] = arr[--endIndex];
            }
        }


        public void RearrangArray(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return;

            int i = 0;
            int j = 0;

            while (i < arr.Length)
            {
                if (arr[i] < 0)
                {
                    int temp = arr[i];
                    MoveOneUnit(arr, j, i);
                    arr[j] = temp;
                    j++;
                }
                i++;
            }


        }

        public void RearrangArray2(int[] arr, int start, int end)
        {
            if (start >= end)
                return;

            int mid = start + (end - start) / 2;

            RearrangArray2(arr, start, mid);
            RearrangArray2(arr, mid + 1, end);


            int[] l = new int[mid - start + 1];


            int[] r = new int[end - mid];


            for (int i = 0; i < l.Length; i++)
            {
                l[i] = arr[start + i];
            }

            for (int i = 0; i < r.Length; i++)
            {
                r[i] = arr[mid + 1 + i];
            }

            MergeNgeativePositive(arr, l, r, start);

        }

        private void MergeNgeativePositive(int[] arr, int[] l, int[] r, int index)
        {
            int i = 0, j = 0, k = index;

            while (i < l.Length && l[i] < 0)
            {
                arr[k] = l[i];
                k++;
                i++;
            }

            while (j < r.Length && r[j] < 0)
            {
                arr[k] = r[j];
                j++;
                k++;
            }


            while (i < l.Length)
            {
                arr[k++] = l[i++];

            }
            while (j < r.Length)
            {
                arr[k++] = r[j++];
            }


        }

        public int MaximumRepeatingNumber(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return -1;
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == i)
                    continue;
                else
                {

                    if (arr[arr[i]] != arr[i])
                    {
                        int temp = arr[arr[i]];
                        arr[arr[i]] = arr[i];
                        arr[i] = temp;
                        i--;
                    }
                }
            }


            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == i)
                {
                    arr[i] = -1;
                }
            }


            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0)
                {
                    arr[arr[i]]--;
                }
            }
            int max = 0, index = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < Math.Abs(arr[i]))
                {
                    index = i;
                    max = Math.Abs(arr[i]);
                }
            }
            return index;

        }

        public double Power(int m, int n)
        {
            if (n == 0) return 1;
            if (n == 1) return m;
            if (n < 1) return 1 / Power(m, -n);

            double temp = Power(m, n / 2);
            if (n % 2 == 0)
                return temp * temp;
            else
                return m * temp * temp;



        }

        public bool CanJump(int[] nums)
        {

            if (nums == null || nums.Length == 0)
                return false;


            int maxJump = nums[0], maxJumpfoundSofar = 0;

            for (int i = 1; i < nums.Length && i <= maxJump; i++)
            {
                maxJumpfoundSofar = Math.Max(nums[i] + i, maxJumpfoundSofar);
                if (maxJumpfoundSofar >= nums.Length-1)
                    return true;

                if (maxJump == i)
                {
                    maxJump = maxJumpfoundSofar;
                  
                    maxJumpfoundSofar = 0;
                }




            }
            if (maxJump >= nums.Length - 1)
                return true;


            return false;

        }



        public void PossibleString(string input,int start,int end)
        {
            if (start >= end)
                return ;



            var temp = input.Substring(start, end - start) + " " + input.Substring(end, input.Length - end + start);

            Console.WriteLine(temp);

            PossibleString(input,start,end-1);

            PossibleString(input, start + 1, end);


          

           

        



        }


        public void MaximumAverage(int[] arr, int k)
        {
            int sum = 0;
            int left = 0, right = k - 1;
            for (int i = 0; i < k; i++)
            {
                sum += arr[i];
            }

            double maxAvg = (double)sum / k; ;


            for (int i = k; i < arr.Length; i++)
            {
                double newAvg= (maxAvg * 4 - arr[i - k] + arr[i])/ (double)k;
                if (newAvg >maxAvg)
                {
                    maxAvg = (maxAvg * 4 - arr[ i-k] + arr[i]) / k;
                    right = i;
                    left = i - k+1;
                }
            }

            Console.WriteLine(string.Format("Left index and right index are {0} and {1}",left,right));

        }


        public void AllString(int[] arr,int index)
        {
            if(index==arr.Length)
            {
                for (int k = 0; k < arr.Length; k++)
                {
                    Console.Write(arr[k]);
                }
                Console.WriteLine();
                return;
            }


            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = index; j < arr.Length; j++)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;

                    AllString(arr, i+1);


                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

        }



    }



    class Program
    {
        static void Main(string[] args)
        {
            Algo obj = new Algo();
            // ListNode head = new ListNode(1);
            // head.Next = new ListNode(2);
            // head.Next.Next = new ListNode(3);
            // head.Next.Next.Next = new ListNode(4);
            // head.Next.Next.Next.Next = new ListNode(5);
            // head.Next.Next.Next.Next.Next = new ListNode(6);
            //// head.Next.Next.Next.Next.Next.Next = new ListNode(7);
            //head = obj.SwapNode(head);
            //obj.Dispaly(head);
            //string input = "BCCDE";


            //int[] arr = { 1, 2, 2, 2, 0, 2, 0, 2, 3, 8, 0, 9, 2, 3 };
            int[] arr = { 1,2,3 };
           // Console.WriteLine(obj.CanJump(arr)); ;
            obj.AllString(arr,0);



            //  Console.WriteLine(obj.LengthOfLongestSubstring("dvdf"));

            // Console.WriteLine(new Algo().Check(70, 4));
            Console.ReadLine();

        }
    }
}
