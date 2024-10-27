using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminWorkerManagement.Impl
{
    internal class CommonImpl
    {
        protected int StringToIntParse(string? String)
        {
            bool correctFormat = int.TryParse(String, out int Number);
            if (!correctFormat)
            {
                throw new ArgumentException("There was a problem with the entry");
            }
            return Number;
        }

        protected List<string> AddStringsToAList(List<string> list, string TypeOfList)
        {
            string input;
            Console.WriteLine("Introduce " + TypeOfList + "one by one.\n " +
                "Write end if you want to finish");
            bool finish = false;
            while (!finish)
            {
                input = StringAskedNotNull("Item: ");

                if (input == null || input.ToLower() == "end")
                {
                    finish = true;
                }
                else
                {
                    list.Add(input);
                }
            }
            return list;
        }

        protected static string StringAskedNotNull(string message)
        {
            string? result;
            do
            {
                Console.WriteLine(message);
                result = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(result));
            return result;
        }

        protected static int IntAskedNotNullAndPositive(string message)
        {
            int number;

            do
            {
                Console.WriteLine(message);
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Introduced a positive number or 0");
                }
            } while (true);
        }

    }
}
