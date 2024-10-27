namespace AdminWorkerManagementV2.Entities
{
    internal class Worker
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string Surname { get; set; }

        private DateOnly? BirthDate { get; set; }

        private DateTime? LeavingDate { get; set; }

        private static int WorkersQuantity = 0;

        public Worker() { }

        public Worker(string Name, string Surname, DateOnly? BithDate)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.BirthDate = BithDate;
            WorkersQuantity++;
            this.Id = WorkersQuantity;
        }
        

        public Worker(string Name, string Surname, DateOnly? BithDate,
            DateTime? LeavingDate)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.BirthDate = BithDate;
            this.LeavingDate = LeavingDate;
            WorkersQuantity++;
            this.Id = WorkersQuantity;

        }

        public string GetName()
        {
            return Name;
        }

        public string GetSurname()
        {
            return Surname;
        }

        public int GetId()
        {
            return Id;
        }






    }
}
