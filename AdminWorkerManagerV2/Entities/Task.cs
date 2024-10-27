namespace AdminWorkerManagementV2.Entities
{
    internal class Task
    {
        private string Id { get; set; }
        private string Description;
        private string Technology;
        internal enum Status
        {
            To_Do,
            Doing,
            Done
        }
        private Status StatusChosen;
        private int IdWorker;

        public Task()
        {

        }

        public Task(string Id, string Description, string Technology, string StatusInput)
        {
            this.Id = Id;
            this.Description = Description;
            this.Technology = Technology;
            if (!Enum.TryParse<Status>(StatusInput,true, out Status statusChosen))
            {
                throw new Exception("Status not valid");
            }
            else
            {
                StatusChosen = statusChosen;
            }

        }

        public Task(string Id, string Description, string Technology, string StatusInput,
            int IdWorker)
        {
            this.Id = Id;
            this.Description = Description;
            this.Technology = Technology;
            if (!Enum.TryParse<Status>(StatusInput, true, out Status statusChosen))
            {
                throw new Exception("Status not valid");
            }
            else
            {
                StatusChosen = statusChosen;
            }
            this.IdWorker = IdWorker;
        }

        public Status GetStatusTask()
        {
            return StatusChosen;
        }

        public int GetIdWorker()
        {
            return IdWorker;
        }

        public void SetIdWorker(int IdWorker)
        {
            this.IdWorker= IdWorker;
        }

        public string GetId()
        {
            return Id;
        }

        public void SetId(string Id)
        {
            this.Id = Id;
        }

        public string GetDescription()
        {
            return Description;
        }

        public void SetDescription(string Description)
        {
            this.Description = Description;
        }

        public string GetTechnology()
        {
            return Technology;
        }



    }
}
