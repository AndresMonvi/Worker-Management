using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminWorkerManagement.Entities
{
    internal class Team
    {
        private ItWorker Manager;
        private List<ItWorker> Technicians;

        public Team() { }

        public Team(ItWorker Manager, List<ItWorker> Technicians)
        {
            this.Manager = Manager;
            this.Technicians = Technicians;
        }
    }
}
