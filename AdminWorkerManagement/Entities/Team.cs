﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminWorkerManagement.Entities
{
    internal class Team
    {
        private string? TeamName { get; set; }
        private ItWorker? Manager;
        private List<ItWorker>? Technicians;

        public Team(string TeamName) {
            this.TeamName = TeamName;        }

        public Team(ItWorker Manager, List<ItWorker> Technicians)
        {
            this.Manager = Manager;
            this.Technicians = Technicians;
        }

        public string GetTeamName()
        {
            return TeamName;
        }

        public void SetTeamName(string Name)
        {
            TeamName = Name;
        }
        public ItWorker GetTeamManager()
        {
            return Manager;
        }

        public void SetTeamManager(ItWorker itWorker)
        {
            Manager = itWorker;
        }

        public List<ItWorker> GetTeamTechnicians()
        {
            return Technicians;
        }

        public void SetTeamTechnicians(List<ItWorker> Technicians)
        {
            this.Technicians = Technicians;
        }
    }
}
