using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AdminWorkerManagement.Entities
{
    internal class Task
    {
        private int Id { get; set; }
        private string? Description;
        private string? Technology;
        private enum Status
        {
            To_Do,
            Doing,
            Done
        }
        private Status status;
        private int IdWorker;


        public Task() { }

        public Task(int Id, string? Description, string? Technology, string? Status,
            int IdWorker)
        {
            this.Id = Id;
            this.Description = Description;
            this.Technology = Technology;
            if (!Enum.TryParse(Status, out this.status))
            {
                this.status = Task.Status.To_Do;
            }
            this.IdWorker = IdWorker;
        }
    }
}
