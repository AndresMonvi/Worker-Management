using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminWorkerManagement.Impl
{
    internal class WorkerImpl: CommonImpl
    {
        protected static DateOnly IntroduceBirthDate()
        {

            while (true)
            {
                string? date = Console.ReadLine();

                if (DateOnly.TryParse(date, out DateOnly BirthDate))
                {
                    return BirthDate;
                }
                else
                {
                    Console.WriteLine("Birth date invalid format. Try again");
                }

            }
        }

        protected int IntroduceYearsOfExperience()
        {
            int years = IntAskedNotNullAndPositive("Introduce years of experience: ");
            return years;
        }




    }
}
