namespace AdminWorkerManagementV2.Entities
{
    internal class ItWorker : Worker
    {

        private int YearsOfExperience;
        private List<string> TechKnowledges;
        private enum Level
        {
            Junior,
            Medium,
            Senior
        }
        private Level WorkerLevel;

        public ItWorker(string? Name, string? Surname, DateOnly? BirthDate,
            int YearsOfExperience, List<string> TechKnowledges,
            string? Level) : base(Name, Surname, BirthDate)
        {
            this.YearsOfExperience = YearsOfExperience;
            if (!Enum.TryParse(Level, out this.WorkerLevel))
            {
                this.WorkerLevel = ItWorker.Level.Junior;
            }
            this.TechKnowledges = TechKnowledges;
        }

        
        public ItWorker(string? Id, string? Name, string? Surname, DateOnly? BirthDate,
            DateTime? LeavingDate, int YearsOfExperience, List<string>TechKnowledges,
            string? Level) : base(Name, Surname, BirthDate, LeavingDate)
        {
            this.YearsOfExperience = YearsOfExperience;
            if(!Enum.TryParse(Level, out this.WorkerLevel))
            {
                this.WorkerLevel = ItWorker.Level.Junior;
            }
            this.TechKnowledges = TechKnowledges;
        }

        public List<string> GetTechKnowledges() {  
            return this.TechKnowledges; 
        }
        
    }
}
