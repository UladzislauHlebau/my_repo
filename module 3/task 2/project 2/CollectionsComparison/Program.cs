using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            int Size = 99999;
            int SearchedInt = 0;

            ArrayListvsLinkedList(Size, SearchedInt);
            StackvsQueue(Size, SearchedInt);
            HashtablevsDictionary(Size, SearchedInt);

        }

            static void ArrayListvsLinkedList (int Size, int SearchedInt)
           {
            Random rand = new Random();

            ArrayList NewArrayList = new ArrayList();
            for (int i = 0; i < Size; i++) 
            { 
            NewArrayList.Add(rand.Next(0,100));
            }
            LinkedList<int> NewLinkedList = new LinkedList<int>();   
            for (int i = 0; i < Size; i++)
            { 
            NewLinkedList.AddLast(rand.Next(0,100));
            }
            SearchComparison1(NewArrayList, NewLinkedList, SearchedInt);
            AdditionComparison1(NewArrayList, NewLinkedList);
            RemovalComparison1(NewArrayList, NewLinkedList);
           }  
            
         static void StackvsQueue (int Size, int SearchedInt)
           {
            Random rand = new Random();

            Stack NewStack = new Stack();
            for (int i = 0; i < Size; i++) 
            { 
            NewStack.Push(rand.Next(0,100));
            }
            Queue NewQueue = new Queue();   
            for (int i = 0; i < Size; i++)
            { 
            NewQueue.Enqueue(rand.Next(0,100));
            }
            SearchComparison2(NewStack, NewQueue, SearchedInt);
            AdditionComparison2(NewStack, NewQueue);
            RemovalComparison2(NewStack, NewQueue);
           }
        
         static void HashtablevsDictionary (int Size, int SearchedInt)
           {
            Random rand = new Random();

            Hashtable Newhashtable = new Hashtable();
            for (int i = 0; i < Size; i++) 
            { 
            Newhashtable.Add(i, rand.Next(0,100));
            }
            Dictionary<int, int> MyDictionary = new Dictionary<int, int>();   
            for (int i = 0; i < Size; i++)
            { 
            MyDictionary.Add(i, rand.Next(0,100));
            }
            SearchComparison3(Newhashtable, MyDictionary, SearchedInt);
            AdditionComparison3(Newhashtable, MyDictionary);
            RemovalComparison3(Newhashtable, MyDictionary);
           }

        static void SearchComparison1(ArrayList NewArrayList, LinkedList<int> NewLinkedList, int SearchedInt)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            NewArrayList.Contains(SearchedInt);
            stopwatch.Stop();
            var ElapsedTime1 = stopwatch.ElapsedMilliseconds;
            //Console.WriteLine("Time elapsed for searching in ArrayList: {0}", stopwatch.ElapsedMilliseconds);

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch.Start();
            NewLinkedList.Contains(SearchedInt);
            stopwatch.Stop();
            var ElapsedTime2 = stopwatch1.ElapsedMilliseconds;
            //Console.WriteLine("Time elapsed for searching in LinkedList: {0}", stopwatch1.ElapsedMilliseconds);
            var SearchComparison1 = ElapsedTime2 - ElapsedTime1;
            Console.WriteLine("The difference of searching in ArrayList and in LinkedList is: {0}", SearchComparison1);
        }

        static void AdditionComparison1(ArrayList NewArrayList, LinkedList<int> NewLinkedList)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            NewArrayList.Add("25");
            stopwatch.Stop();
            var ElapsedTime1 = stopwatch.ElapsedMilliseconds;

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch.Start();
            NewLinkedList.AddFirst(56);
            stopwatch.Stop();
            var ElapsedTime2 = stopwatch1.ElapsedMilliseconds;

            var AdditionComparison1 = ElapsedTime2 - ElapsedTime1;
            Console.WriteLine("The difference of element addition to ArrayList and to LinkedList is: {0}", AdditionComparison1);
        }

        static void RemovalComparison1(ArrayList NewArrayList, LinkedList<int> NewLinkedList)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            NewArrayList.Remove("25");
            stopwatch.Stop();
            var ElapsedTime1 = stopwatch.ElapsedMilliseconds;

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch.Start();
            NewLinkedList.RemoveLast();
            stopwatch.Stop();
            var ElapsedTime2 = stopwatch1.ElapsedMilliseconds;

            var RemovalComparison1 = ElapsedTime2 - ElapsedTime1;
            Console.WriteLine("The difference of element removal from ArrayList and from LinkedList is: {0}", RemovalComparison1);
        }
        
        static void SearchComparison2(Stack NewStack, Queue NewQueue, int SearchedInt)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            NewStack.Contains(SearchedInt);
            stopwatch.Stop();
            var ElapsedTime1 = stopwatch.ElapsedMilliseconds;
            //Console.WriteLine("Time elapsed for searching in Stack: {0}", stopwatch.ElapsedMilliseconds);

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch.Start();
            NewQueue.Contains(SearchedInt);
            stopwatch.Stop();
            var ElapsedTime2 = stopwatch1.ElapsedMilliseconds;
            //Console.WriteLine("Time elapsed for searching in Queue: {0}", stopwatch1.ElapsedMilliseconds);
            var SearchComparison2 = ElapsedTime2 - ElapsedTime1;
            Console.WriteLine("The difference of searching in Stack and in Queue is: {0}", SearchComparison2);
        }

        static void AdditionComparison2(Stack NewStack, Queue NewQueue)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            NewStack.Push(25);
            stopwatch.Stop();
            var ElapsedTime1 = stopwatch.ElapsedMilliseconds;

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch.Start();
            NewQueue.Enqueue(56);
            stopwatch.Stop();
            var ElapsedTime2 = stopwatch1.ElapsedMilliseconds;

            var AdditionComparison2 = ElapsedTime2 - ElapsedTime1;
            Console.WriteLine("The difference of element addition to Stack and to Queue is: {0}", AdditionComparison2);
        }

        static void RemovalComparison2(Stack NewStack, Queue NewQueue)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            NewStack.Pop();
            stopwatch.Stop();
            var ElapsedTime1 = stopwatch.ElapsedMilliseconds;

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch.Start();
            NewQueue.Dequeue();
            stopwatch.Stop();
            var ElapsedTime2 = stopwatch1.ElapsedMilliseconds;

            var RemovalComparison2 = ElapsedTime2 - ElapsedTime1;
            Console.WriteLine("The difference of element removal from Stack and from Queue is: {0}", RemovalComparison2);
        }

        static void SearchComparison3(Hashtable Newhashtable, Dictionary<int,int> MyDictionary, int SearchedInt)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Newhashtable.Contains(SearchedInt);
            stopwatch.Stop();
            var ElapsedTime1 = stopwatch.ElapsedMilliseconds;
            //Console.WriteLine("Time elapsed for searching in Hashtable: {0}", stopwatch.ElapsedMilliseconds);

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch.Start();
            MyDictionary.ContainsValue(SearchedInt);
            stopwatch.Stop();
            var ElapsedTime2 = stopwatch1.ElapsedMilliseconds;
            //Console.WriteLine("Time elapsed for searching in Dictionary: {0}", stopwatch1.ElapsedMilliseconds);
            var SearchComparison3 = ElapsedTime2 - ElapsedTime1;
            Console.WriteLine("The difference of searching in Hashtable and in Dictionary is: {0}", SearchComparison3);
        }

        static void AdditionComparison3(Hashtable Newhashtable, Dictionary<int, int> MyDictionary)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Newhashtable.Add(100000, 25);
            stopwatch.Stop();
            var ElapsedTime1 = stopwatch.ElapsedMilliseconds;

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch.Start();
            MyDictionary.Add(100000, 56);
            stopwatch.Stop();
            var ElapsedTime2 = stopwatch1.ElapsedMilliseconds;

            var AdditionComparison3 = ElapsedTime2 - ElapsedTime1;
            Console.WriteLine("The difference of element addition to Hashtable and to Dictionary is: {0}", AdditionComparison3);
        }

        static void RemovalComparison3(Hashtable Newhashtable, Dictionary<int, int> MyDictionary)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Newhashtable.Remove(100000);
            stopwatch.Stop();
            var ElapsedTime1 = stopwatch.ElapsedMilliseconds;

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch.Start();
            MyDictionary.Remove(100000);
            stopwatch.Stop();
            var ElapsedTime2 = stopwatch1.ElapsedMilliseconds;

            var RemovalComparison3 = ElapsedTime2 - ElapsedTime1;
            Console.WriteLine("The difference of element removal from Hashtable and from Dictionary is: {0}", RemovalComparison3);
            Console.ReadKey();

        }
    }
}