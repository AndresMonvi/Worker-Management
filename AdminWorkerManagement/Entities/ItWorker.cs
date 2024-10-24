using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdminWorkerManagement.Entities
{
    internal class ItWorker : Worker
    {

        private int YearsOfExperience;
        List<string?> TechKnowledges;
        private enum Level
        {
            Junior,
            Medium,
            Senior
        }
        private Level WorkerLevel;
       

        public ItWorker(int Id, string? Name, string? Surname, DateOnly? BirthDate,
            DateTime? LeavingDate, int YearsOfExperience, List<string?>TechKnowledges,
            string? Level) : base(Id, Name, Surname, BirthDate, LeavingDate)
        {
            this.YearsOfExperience = YearsOfExperience;
            if(!Enum.TryParse(Level, out this.WorkerLevel))
            {
                this.WorkerLevel = ItWorker.Level.Junior;
            }
            this.TechKnowledges = TechKnowledges;
        }
    }
}
