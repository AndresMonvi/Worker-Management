using AdminWorkerManagement.Entities;
using System.Collections.Specialized;

namespace AdminWorkerManagement.Impl
{
    internal class TeamImpl : CommonImpl
    {

        private List<Team> TeamsList = new();
        private string TeamName;

        internal void AddTeamsToAList(Team team)
        {
            TeamsList.Add(team);
        }

        private bool TeamNameDuplicate(List<Team> teams, string teamName)
        {
            foreach (var team in teams)
            {
                if (team.GetTeamName().Equals(teamName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }



        internal Team? CreateNewTeam()
        {
            TeamName = StringAskedNotNull("Introduce the name of the team: ");
            if(TeamNameDuplicate(TeamsList, TeamName))
            {
                return null;
            }
            else
            {
                Team Team = new(TeamName);
                return Team;
            }
        }

        internal void ListTeamNames()
        {
            foreach(var Team in TeamsList) Console.WriteLine(Team.GetTeamName());
        }

        private void ShowTeamManager(Team Team)
        {
            if(Team.GetTeamManager() == null)
            {
                Console.WriteLine("There's no Manager");
            } else
            {
                Console.WriteLine("Manager: " + Team.GetTeamManager().GetName() +
                                        " " + Team.GetTeamManager().GetSurname());
            }
        }

        private void ShowTeamTechnicians(Team Team)
        {
            Console.WriteLine("Technicians: ");

            if (Team.GetTeamTechnicians() != null)
            {
                for (int i = 0; i < Team.GetTeamTechnicians().Count; i++)
                {
                    Console.WriteLine("Technician: " +
                        Team.GetTeamTechnicians()[i].GetName() + " "
                        + Team.GetTeamTechnicians()[i].GetSurname());
                }
            }
            else
            {
                Console.WriteLine("No Technicians");
            }

        }

        internal void ListTeamMembersByTeamName()
        {
            TeamName = StringAskedNotNull("Introduce the team name: "); 
            Team? Team = FindTeamByTeamName(TeamName);

            if (Team == null)
            {
                Console.WriteLine("There's no team with that name");
            }
            else
            {
                ShowTeamManager(Team);
                ShowTeamTechnicians(Team);
            }
     
        }

        internal Team? FindTeamByTeamName(string? TeamName)
        {
            if (string.IsNullOrEmpty(TeamName))
            {
                return null;
            }

            if (TeamsList == null || TeamsList.Count == 0)
            {
                return null;
            }

            for (int i = 0; i < TeamsList.Count; i++)
            {
                if (TeamsList[i].GetTeamName().ToLower() == TeamName.ToLower())
                {
                    return TeamsList[i];
                }
            }

            return null;
        }


        internal List<ItWorker>? ListAllTeamMembersByTeamName(Team Team)
        {

            if(Team == null)
            {
                return null;
            } 
            else
            {
                List<ItWorker> TeamWorkers;
                TeamWorkers = new();
                if (Team.GetTeamManager() != null)
                {
                    TeamWorkers.Add(Team.GetTeamManager());
                    for (int i = 0; i < Team.GetTeamTechnicians().Count; i++)
                    {
                        TeamWorkers.Add(Team.GetTeamTechnicians()[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < Team.GetTeamTechnicians().Count; i++)
                    {
                        TeamWorkers.Add(Team.GetTeamTechnicians()[i]);
                    }
                }
                return TeamWorkers;
            }     
        }

        

        internal void AssignItWorkerAsManagers(List<ItWorker> ItWorkers, ItWorkImpl WorkImpl)
        {

            ItWorker? ItWorkerFound = WorkImpl.FindItWorkerByIdWorker();

            if (ItWorkerFound != null)
            {
                string TeamName = StringAskedNotNull("Introduce team: ");
                Team? Team = TeamsList.Find(TeamAux => TeamAux.GetTeamName() == TeamName);
                if (Team != null)
                {
                    Team.SetTeamManager(ItWorkerFound);
                }
                else
                {
                    Console.WriteLine("Team not found");
                }
            }
            else
            {
                Console.WriteLine("Worker not found");
            }

        }

        internal void AssignItWorkerToATeamAsTechnician(List<ItWorker> ItWorkers, ItWorkImpl WorkImpl)
        {
            Console.WriteLine("Transforming worker to manager");
            ItWorker? ItWorkerFound = WorkImpl.FindItWorkerByIdWorker();

            if (ItWorkerFound != null)
            {
                string TeamNameInput = StringAskedNotNull("Introduce team: ");
                Team? TeamFound = TeamsList.Find(TeamAux => TeamAux.GetTeamName() == TeamNameInput);
                if (TeamFound != null)
                {
                    if(TeamFound.GetTeamTechnicians() != null)
                    {
                        TeamFound.GetTeamTechnicians().Add(ItWorkerFound);
                        Console.WriteLine("Worker added as Technician");
                    }
                    else
                    {
                        List<ItWorker> TechWorkers = new();
                        TechWorkers.Add(ItWorkerFound);
                        TeamFound.SetTeamTechnicians(TechWorkers);

                    }
                   
                }
                else
                {
                    Console.WriteLine("Team not found");
                }
            }
            else
            {
                Console.WriteLine("Worker not found");
            }

        }


    }
}
