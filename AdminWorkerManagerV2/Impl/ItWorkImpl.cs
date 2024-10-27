using AdminWorkerManagementV2.Entities;
using System.Threading.Tasks;

namespace AdminWorkerManagementV2.Impl
{
    internal class ItWorkImpl : WorkerImpl
    {

        private List<ItWorker> ItWorkerList = new();


        internal void AddItWorkerToAList(ItWorker ItWorker)
        {
            ItWorkerList.Add(ItWorker);
        }

        internal List<ItWorker>? GetWorkerList()
        {
            return ItWorkerList;
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

        internal ItWorker? FindItWorkerByIdWorkerGiven(int idWorker)
        {
            ItWorker? ItWorkerFound = ItWorkerList.Find(Worker => Worker.GetId
            () == idWorker);

            if (ItWorkerFound == null)
            {
                Console.WriteLine("Worker not found");
                return null;
            }
            return ItWorkerFound;
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
            if (ItWorker != null)
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
            if (ItWorkerList != null)
            {
                return ItWorkerList;
            }
            return null;
        }

        internal bool CheckIfItWorkerIsManager(int itdWorker, List<Team> TeamsList)
        {
            ItWorker? ItWorkerF = FindItWorkerByIdWorker();

            if (ItWorkerF != null)
            {
                if (TeamsList != null)
                {
                    foreach (Team team in TeamsList)
                    {
                        if (team.GetTeamManager().GetId() == ItWorkerF.GetId())
                        {
                            return true;
                        }
                    }
                }

            }
            return false;

        }

        internal bool CheckIfItWorkerIsTechnician(int idWorker, List<Team> TeamsList)
        {
            ItWorker? ItWorkerF = FindItWorkerByIdWorker();

            if (ItWorkerF != null)
            {
                if (TeamsList != null)
                {
                    foreach (Team team in TeamsList)
                    {
                        foreach (var technician in team.GetTeamTechnicians())
                        {
                            if (technician.GetId() == ItWorkerF.GetId())
                            {
                                return true;
                            }
                        }
                    }
                }

            }
            return false;

        }
    }
}
