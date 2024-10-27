using AdminWorkerManagement.Entities;
using AdminWorkerManagement.Impl;
using Task = AdminWorkerManagement.Entities.Task;


namespace AdminWorkerManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitAdminManagementApp();
        }

        private static void InitAdminManagementApp()
        {
            bool StopConsole = false;
            bool CheckNull;
            int option;
            ItWorkImpl ItWorkImpl = new ItWorkImpl();
            TeamImpl TeamImpl = new TeamImpl();
            TaskImpl TaskImpl = new TaskImpl();

            while (!StopConsole)
            {

                do
                {
                    Console.WriteLine("Choose your option: \n" +
                        "1. Register new ItWorker \n" +
                        "2. Register new team \n" +
                        "3. Register new task (unnassigned to anyone)\n" +
                        "4. List all team names \n" +
                        "5. List team members by team names \n" +
                        "6. List unnassigned tasks \n" +
                        "7. List task assignments by team name \n" +
                        "8. Assing It worker to a team as a manager \n" +
                        "9. Assing It worker to a team as a technician \n" +
                        "10. Assing task to IT worker \n" +
                        "11. Unregister It worker \n" +
                        "12. Exit");


                    bool correctFormat = int.TryParse(Console.ReadLine(), out option);

                    if (correctFormat)
                    {
                        switch (option)
                        {
                            case 1:
                                ItWorker itWorker = ItWorkImpl.CreateItWorker();
                                ItWorkImpl.AddItWorkerToAList(itWorker);
                                break;

                            case 2:
                                Team? Team = TeamImpl.CreateNewTeam();
                                if(Team == null)
                                {
                                    Console.WriteLine("There's a team with that name. Chose another");;
                                }
                                else
                                {
                                    TeamImpl.AddTeamsToAList(Team);
                                }
                                break;

                            case 3:
                                Task Task = TaskImpl.RegisterNewTask();
                                TaskImpl.AddTaskToAList(Task);
                                break;

                            case 4:
                                TeamImpl.ListTeamNames();
                                break;

                            case 5:
                               TeamImpl.ListTeamMembersByTeamName();
                                break;

                            case 6:
                                List<ItWorker>? WorkersList = ItWorkImpl.GetItWorkerList();
                             
                                if (WorkersList != null)
                                {
                                    TaskImpl.ShowUnassignedTaskList(WorkersList);
                                }
                                else
                                {
                                    Console.WriteLine("There're no It Workers");
                                }
                                break;

                            case 7:
                                Console.WriteLine("Introduce team name: ");
                                Team? TeamToGetTasks = TeamImpl.FindTeamByTeamName(Console.ReadLine());
                                if(TeamToGetTasks == null)
                                {
                                    Console.WriteLine("There's no team with that name");
                                }
                                else
                                {
                                    List<ItWorker>? ItWorkers = TeamImpl.ListAllTeamMembersByTeamName(TeamToGetTasks);
                                    if (ItWorkers != null)
                                    {
                                        TaskImpl.ShowTaskListByMembers(ItWorkers);
                                    }
                                    else
                                    {
                                        Console.WriteLine("There're no task assigned to that team");
                                    }
                                }
                                break;

                            case 8:
                                List<ItWorker>? ItWorkersAux = ItWorkImpl.GetItWorkerList();
                                if(ItWorkersAux == null)
                                {
                                    Console.WriteLine("There're no workers");
                                }
                                else
                                {
                                    TeamImpl.AssignItWorkerAsManagers(ItWorkersAux, ItWorkImpl);

                                }
                                break;

                            case 9:
                                List<ItWorker>? ItWorkersTech = ItWorkImpl.GetItWorkerList();
                                if (ItWorkersTech == null)
                                {
                                    Console.WriteLine("There're no workers");
                                }
                                else
                                {
                                    TeamImpl.AssignItWorkerToATeamAsTechnician(ItWorkersTech, ItWorkImpl);
                                }
                                break;

                            case 10:
                                ItWorker? ItWorkerChosenToTask = ItWorkImpl.FindItWorkerByIdWorker();
                                if (ItWorkerChosenToTask == null)
                                {
                                    Console.WriteLine("Worker not found");
                                }
                                else
                                {
                                    TaskImpl.AssingTaskToItWorker(ItWorkerChosenToTask);
                                }
                                break;


                            case 11:
                                ItWorkImpl.UnregisterItWorkerByIdWorker();
                                break;

                            case 12:
                                Console.WriteLine("Have a good day!");
                                StopConsole = true;
                                break;

                            default:
                                Console.WriteLine("Wrong input. Introduce a number between 1 and 12");
                                Console.Clear();
                            break;
                        }
                    } else
                    {
                        Console.Clear();
                    }
                } while (option > 0 && option != 12);
            }

        }
    }
}
