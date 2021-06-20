using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppForAlg
{
    class Program
    {
        public class CalculateModel
        {
            public int sumOfDigits { get; set; }
            public List<int> numbers { get; set; }

            public CalculateModel(int sumOfDigits, List<int> numbers)
            {
                this.sumOfDigits = sumOfDigits;
                this.numbers = numbers;
            }
        }

        public static int solution(int[] A)
        {
            List<CalculateModel> calculateModels = new List<CalculateModel>();

            foreach (var number in A)
            {
                int sum = 0, m;
                int n = number;
                while (n > 0)
                {
                    m = n % 10;
                    sum = sum + m;
                    n = n / 10;
                }

                if (calculateModels.Any(x => x.sumOfDigits == sum))
                    calculateModels.Where(x => x.sumOfDigits == sum).FirstOrDefault().numbers.Add(number);

                else
                    calculateModels.Add(new CalculateModel(sum, new List<int> {number}));
            }

            bool countNumberValid = true;
            foreach (var model in calculateModels)
            {
                if (model.numbers.Count == 1)
                    countNumberValid = false;
            }
            
            if (!countNumberValid)
                return -1;

            List<int> sums = new List<int>();
            foreach (var model in calculateModels)
            {
                if (model.numbers.Count > 2)
                {
                    int maxSum = model.numbers.OrderByDescending(z => z).Take(2).Sum();
                    sums.Add(maxSum);
                }
                else
                    sums.Add(model.numbers.Sum());
            }
            
            return sums.Max();
        }

        static void Main(string[] args)
        {
            int[] arr = {51, 71, 17, 42};
           //int []arr = { 42, 33, 60 };
           //int []arr = { 51, 32, 43 };
           Console.WriteLine(solution(arr));
        }
    }
}
