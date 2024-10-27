using AdminWorkerManagementV2.Entities;
using Task = AdminWorkerManagementV2.Entities.Task;
using Team = AdminWorkerManagementV2.Entities.Team;
using System.Collections.Concurrent;


namespace AdminWorkerManagementV2.Impl
{
    internal class TaskImpl : CommonImplV2
    {
        private List<Task> TaskList = new();
        internal Task RegisterNewTask()
        {
            string Id, Description, Status, TaskTechnology;
     
            Id = StringAskedNotNull("Introduce id task: ");

            Description = StringAskedNotNull("Introduce a description of the task: ");
           
            TaskTechnology = StringAskedNotNull("Introduce technology required for the task: ");

            do
            {
                Status = StringAskedNotNull("Introduce Status of the task: To_Do, Doing, Done");

            } while (Status != "To_Do" && Status != "Doing" && Status != "Done");

            Task Task = new(Id, Description, TaskTechnology, Status);

            return Task;

        }

        internal void AddTaskToAList(Task Task)
        {
            TaskList.Add(Task);
        }

        internal void ShowTaskListByMembers(List<ItWorker> ItWorkers)
        {
            if (TaskList != null)
            {
                for (int i = 0; i < TaskList.Count; i++)
                {
                    for (int j = 0; j < ItWorkers.Count; j++)
                    {
                        if (TaskList[i].GetIdWorker() == ItWorkers[j].GetId())
                        {
                            Console.WriteLine($"Task {TaskList[i].GetId()} + {TaskList[i].GetDescription()}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("There's no tasks");
            }
        }

        internal void ShowUnassignedTaskList(List<ItWorker> ItWorkers)
        {
            List<Task>? UnassignedTasks = UnassignedTaskList(ItWorkers);
            if (UnassignedTasks != null)
            {
                foreach (var Task in UnassignedTasks)
                {
                    Console.WriteLine($"Task {Task.GetId()} - {Task.GetDescription()}");
                }
            }
            else
            {
                Console.WriteLine("There are no tasks unasssigned");
            }
        }

        private List<Task>? UnassignedTaskList(List<ItWorker> ItWorkers)
        {
            if (TaskList == null || TaskList.Count <= 0)
            {
                Console.WriteLine("There're no tasks unassigned");
                return null;
            }
            else
            {
                List<Task> UnassignedTaskList = new();
                foreach (var task in TaskList)
                {
                    bool isAssigned = false;
                    foreach (var worker in ItWorkers)
                    {
                        if (task.GetIdWorker() == worker.GetId())
                        {
                            isAssigned = true;
                            break;
                        }
                    }
                    if (!isAssigned)
                    {
                        UnassignedTaskList.Add(task);
                    }
                }
                return UnassignedTaskList;
            }
        }





        private List<Task> TaskListAssignedByTeamMembers(List<ItWorker> TeamMembers)
        {
            List<Task> TaskAssigned = new();
            for (int i = 0; i < TaskList.Count; i++)
            {
                for(int j = 0; j < TeamMembers.Count; j++)
                {
                    if (TaskList[i].GetIdWorker() == TeamMembers[j].GetId())
                    {
                        TaskAssigned.Add(TaskList[i]);
                    }
                }
            }
            return TaskAssigned;  
        }

        internal void AssingTaskToItWorker(ItWorker TaskToWorker)
        {
            string TaskInput = StringAskedNotNull("Introduce id of the task: ");
            Task? TaskFound = TaskList.Find(Task => Task.GetId() == TaskInput);

            if (TaskFound != null)
            {
                if (TaskFound.GetStatusTask() == Entities.Task.Status.Done)
                {
                    Console.WriteLine("Can't assign a task done");
                }
                else
                {
                    List<string> Technologies = TaskToWorker.GetTechKnowledges();
                    bool TechFound = false;
                    foreach (var t in Technologies) {
                        if (t.ToLower() == TaskFound.GetTechnology().ToLower())
                        {
                            TaskFound.SetIdWorker(TaskToWorker.GetId());
                            TechFound = true;
                        }
                    }
                    if (!TechFound)
                    {
                        Console.WriteLine("No IT Worker has technology Knowledges to take the task");
                    }

                }
            }
        }


        private Task? GetTaskByIdTask(string IdTask)
        {
            for (int i = 0; i < TaskList.Count; i++)
            {
                if (TaskList[i].GetId() == IdTask)
                {
                    return TaskList[i];
                }
            }
            return null;
        }
    }
}
