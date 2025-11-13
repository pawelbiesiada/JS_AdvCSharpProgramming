using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesNET
{
    internal class PrimeNumberValidator
    {
        const int n = 50;
        private static int[] primes = new int[n];
        private static Task<bool>[] isPrime = new Task<bool>[n];

        private static int k;
        private static int sum;

        private static void Main()
        {
            for (int i = 0; i < n; i++)
            {
                primes[i] = new Random().Next(10, 300);
                var task = new Task<bool>((x) => IsPrimeNumber((int)(x ?? 0)), primes[i]);
                task.Start();
                isPrime[i] = task;
            }

            Task.WaitAll(isPrime);



            var result = primes.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount - 3)
                .Where(x => IsPrimeNumber(x)).ToArray();

            var count = result.Count();
            var sum = result.Sum();

            k = 0; sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (isPrime[i].Result)
                {
                    k++;
                    sum += primes[i];
                };
            }
            Console.WriteLine($"Liczba liczb pierwszych {k}");
            Console.WriteLine($"Suma liczb pierwszych {sum}");
            Console.ReadKey();
        }


        public static bool IsPrimeNumber(int number)
        {

            if (number < 2) return false;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

    }


    class PrimeNumberValidator2
    {
        private static int _primesCounter;
        private static int _primesAmount;

        private static readonly object _locker = new();

        private static void Main()
        {
            List<Task> tasks = [];

            for (int i = 0; i < 50; i++)
            {
                Random rand = new();
                int r = rand.Next(10, 300);
                tasks.Add(Task.Factory.StartNew(() => {
                    if (IsPrimeNumber(r))
                    {
                        Console.WriteLine(r);
                        lock (_locker)
                        {
                            _primesAmount += r;
                            _primesCounter++;
                        }
                    }
                }));
            }

            Task.WaitAll(tasks);

            Console.WriteLine($"Wszystkich liczb pierwszych: {_primesCounter}");
            Console.WriteLine($"Suma tych liczb: {_primesAmount}");

        }


        public static bool IsPrimeNumber(int number)
        {

            if (number < 2) return false;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
