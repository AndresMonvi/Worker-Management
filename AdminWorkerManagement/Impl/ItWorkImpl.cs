using AdminWorkerManagement.Entities;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminWorkerManagement.Impl
{
    internal class ItWorkImpl: WorkerImpl
    {

        private List<ItWorker> ItWorkerList = new();

        
        internal void AddItWorkerToAList(ItWorker ItWorker)
        {
            ItWorkerList.Add(ItWorker);
        }


        internal ItWorker CreateItWorker()
        {

            string Name, Surname, Level;
            DateOnly BirthDate;
            int Years;
            List<string> TechKnowledges;

            Name = StringAskedNotNull("Introduce Name: ");

            Surname = StringAskedNotNull("Introduce Surname: ");

            Console.WriteLine("Introduce date of birth (format: dd/mm/yyyy): ");
            BirthDate = IntroduceBirthDate();

            Years = IntroduceYearsOfExperience();

            TechKnowledges = new();
            TechKnowledges = AddStringsToAList(TechKnowledges, "Tech Knowledges: ");

            do
            {
                Level = StringAskedNotNull("Introduce It Worker level: junior, medium or senior");
            } while (Level.ToLower() != "junior" && Level.ToLower() != "medium"
                    && Level.ToLower() != "senior");

            ItWorker ItWorker = new(Name, Surname, BirthDate, Years, TechKnowledges,
                Level);

            return ItWorker;

        }

        internal ItWorker? FindItWorkerByIdWorker()
        {
            int IdWorker = IntAskedNotNullAndPositive("Introduce id worker: ");
            ItWorker? ItWorkerFound = ItWorkerList.Find(Worker => Worker.GetId
            () == IdWorker);

            if (ItWorkerFound == null)
            {
                Console.WriteLine("Worker not found");
                return null;
            }
            return ItWorkerFound;
        }

  

        internal void UnregisterItWorkerByIdWorker()
        {
            ItWorker? ItWorker = FindItWorkerByIdWorker();
            if(ItWorker != null)
            {
                try
                {
                    ItWorkerList.Remove(ItWorker);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Problems with the action: {ex.Message}");
                }
            }
        }

        internal List<ItWorker>? GetItWorkerList()
        {
            if(ItWorkerList != null)
            {
                return ItWorkerList;
            }
            return null;
        }



    }
}
