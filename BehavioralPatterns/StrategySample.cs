using System;

namespace DesignPatternExamples.BehavioralPatterns
{
    public class StrategySample
    {

        private static Dictionary<string, SortStrategy> _strategyMap = new Dictionary<string, SortStrategy>();

        public static void AddSortStrategy(string name, SortStrategy sortStrategy)
        {
            _strategyMap[name] = sortStrategy;
        }


        public static void Create(bool IsShortVersion = false)
        {
            // Two contexts following different strategies
            SortedList studentRecords = new SortedList();

            studentRecords.Add("Samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");


            if (IsShortVersion)
            {
                AddSortStrategy("QuickSort", new QuickSort());
                AddSortStrategy("ShellSort", new ShellSort());
                AddSortStrategy("MergeSort", new MergeSort());

                foreach (var item in _strategyMap)
                {
                    if (_strategyMap.TryGetValue(item.Key, out SortStrategy sortStrategy))
                    {
                        studentRecords.SetSortStrategy(sortStrategy);
                        studentRecords.Sort();
                    }
                    else
                    {
                        Console.WriteLine($"Unknown strategy: {item.Key}");
                    }
                }

            }
            else
            {
                studentRecords.SetSortStrategy(new QuickSort());
                studentRecords.Sort();

                studentRecords.SetSortStrategy(new ShellSort());
                studentRecords.Sort();

                studentRecords.SetSortStrategy(new MergeSort());
                studentRecords.Sort();
            }

        }

    }

    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    public abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    public class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();  // Default is Quicksort
            Console.WriteLine("QuickSorted list ");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    public class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.ShellSort();  not-implemented
            Console.WriteLine("ShellSorted list ");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    public class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.MergeSort(); not-implemented
            Console.WriteLine("MergeSorted list ");
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    public class SortedList
    {
        private List<string> list = new List<string>();
        private SortStrategy sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this.sortstrategy = sortstrategy;
        }

        public void Add(string name)
        {
            list.Add(name);
        }

        public void Sort()
        {
            sortstrategy.Sort(list);

            // Iterate over list and display results
            foreach (string name in list)
            {
                Console.WriteLine(" " + name);
            }
            Console.WriteLine();
        }
    }
}
