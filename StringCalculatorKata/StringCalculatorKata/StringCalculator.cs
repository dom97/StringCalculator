using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public Int32 Add(String inputNumbers)
        {
            ValidateInputForNegativeNumbers(inputNumbers);
            var sum = CalculateSum(inputNumbers);

            return sum;
        }

        private Int32 CalculateSum(String inputNumbers)
        {
            var nonNegativeDigitsPattern = @"[^\d]";
            var positiveNumbers = Regex.Split(inputNumbers, nonNegativeDigitsPattern);
            var sum = 0;

            foreach (var number in positiveNumbers)
                sum += GetNumberToAdd(number);

            return sum;
        }

        private Int32 GetNumberToAdd(String number)
        {
            var value = 0;

            if (!String.IsNullOrEmpty(number))
            {
                var numberValue = Int32.Parse(number);

                if (numberValue <= 1000)
                    value = numberValue;
            }

            return value;
        }

        private void ValidateInputForNegativeNumbers(String inputNumbers)
        {
            var negativeIntegersPattern = @"[\-][\d]";
            var negativeNumberMatches = Regex.Matches(inputNumbers, negativeIntegersPattern);

            if (negativeNumberMatches.Count > 0)
            {
                var negativeNumbers = negativeNumberMatches.Cast<Match>().Select(m => m.Value).ToArray();

                throw new Exception("Negatives not allowed: " + String.Join(", ", negativeNumbers));
            }
        }
    }
}
