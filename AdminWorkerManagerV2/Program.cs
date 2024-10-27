using AdminWorkerManagementV2.Entities;
using AdminWorkerManagementV2.Impl;
using Task = AdminWorkerManagementV2.Entities.Task;

namespace AdminWorkerManagementV2

{
    internal class Program
    {
         static void Main(string[] args)
        {
            InitLogin();
        }

        private static void InitLogin()
        {
            Console.WriteLine("Introduce Id worker: ");
            string? input = Console.ReadLine();
            bool correctFormat = int.TryParse(input, out int option);
            if (correctFormat == false)
            {
                Console.WriteLine("Problems with app. try again later");
            }
            else
            {
                InitAppManagementApp(option);
            }

        }


        private static void InitAppManagementApp(int input)
        {
            ItWorkImpl ItWorkImpl = new ItWorkImpl();
            TeamImpl TeamImpl = new TeamImpl();
            TaskImpl TaskImpl = new TaskImpl();

            if(input == 0)
            {
                AdminMode(ItWorkImpl, TeamImpl, TaskImpl);
            } else
            {
                ItWorker? WorkerMode = ItWorkImpl.FindItWorkerByIdWorkerGiven(input);

                if (WorkerMode != null)
                {
                    bool result;
                    if (result = ItWorkImpl.CheckIfItWorkerIsTechnician(WorkerMode.GetId(),
                        TeamImpl.GetTeams()))
                    {
                        TechnicianMode(ItWorkImpl, TeamImpl, TaskImpl);
                    }

                    if (result = ItWorkImpl.CheckIfItWorkerIsManager(WorkerMode.GetId(),
                        TeamImpl.GetTeams()))
                    {
                        ManagerMode(ItWorkImpl, TeamImpl, TaskImpl);
                    }

                }
                
            }
        }

        private static void AdminMode(ItWorkImpl ItWorkImpl
            , TeamImpl TeamImpl, TaskImpl TaskImpl)
        {
            bool StopConsole = false;
            int option;
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
                                if (Team == null)
                                {
                                    Console.WriteLine("There's a team with that name. Chose another"); ;
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
                                if (TeamToGetTasks == null)
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
                                if (ItWorkersAux == null)
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
                    }
                    else
                    {
                        Console.Clear();
                    }
                } while (option > 0 && option != 12);
            }
        }

        private static void TechnicianMode(ItWorkImpl ItWorkImpl
            , TeamImpl TeamImpl, TaskImpl TaskImpl)
        {
            bool StopConsole = false;
            int option;
            while (!StopConsole)
            {

                do
                {
                    Console.WriteLine("Choose your option: \n" +
                        "6. List unnassigned tasks \n" +
                        "7. List task assignments by team name \n" +
                        "10. Assing task to IT worker \n" +
                        "12. Exit");


                    bool correctFormat = int.TryParse(Console.ReadLine(), out option);

                    if (correctFormat)
                    {
                        switch (option)
                        {

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
                                if (TeamToGetTasks == null)
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

                            case 12:
                                Console.WriteLine("Have a good day!");
                                StopConsole = true;
                                break;

                            default:
                                Console.WriteLine("Wrong input. Introduce a number between 1 and 12");
                                Console.Clear();
                                break;
                        }
                    }
                    else
                    {
                        Console.Clear();
                    }
                } while (option > 6 && option != 8 && option != 9 && option != 11);
            }
        }


        private static void ManagerMode(ItWorkImpl ItWorkImpl
            , TeamImpl TeamImpl, TaskImpl TaskImpl)
        {
            bool StopConsole = false;
            int option;
            while (!StopConsole)
            {

                do
                {
                    Console.WriteLine("Choose your option: \n" +
                        "5. List team members by team names \n" +
                        "6. List unnassigned tasks \n" +
                        "7. List task assignments by team name \n" +
                        "9. Assing It worker to a team as a technician \n" +
                        "10. Assing task to IT worker \n" +
                        "12. Exit");


                    bool correctFormat = int.TryParse(Console.ReadLine(), out option);

                    if (correctFormat)
                    {
                        switch (option)
                        {

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
                                if (TeamToGetTasks == null)
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

                            case 12:
                                Console.WriteLine("Have a good day!");
                                StopConsole = true;
                                break;

                            default:
                                Console.WriteLine("Wrong input. Introduce a number inside the options given");
                                break;
                        }
                    }
                    else
                    {
                        Console.Clear();
                    }
                } while (option > 5 && option != 12 && option != 8 && option != 11);
            }
        }

    }
}
