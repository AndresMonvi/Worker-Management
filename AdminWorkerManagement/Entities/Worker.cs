using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminWorkerManagement.Entities
{
    internal class Worker
    {
        private int Id { get; set; }
        private string? Name { get; set; }
        private string? Surname { get; set; }

        private DateOnly? BirthDate { get; set; }

        private DateTime? LeavingDate { get; set; }

        public Worker() { }

        public Worker(int Id, string? Name, string? Surname, DateOnly? BithDate,
            DateTime? LeavingDate)
        {
            this.Id = Id;
            this.Name = Name;
            this.Surname = Surname;
            this.BirthDate = BithDate;
            this.LeavingDate = LeavingDate;
        }





    }
}
