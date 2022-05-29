using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager
{
    class Executor
    {
        public readonly long ID;
        public readonly string name;
        public readonly int skill;
        private List<Task> assignedTasks;
        private Manager ParentManager;
        private static long IDcount;

        public List<Task> GetTasks() => assignedTasks;

        public string MiniInfo => $"Исполнитель[ID:{ID}]{name}";

        static Executor()
        {
            IDcount = 0;
        }

        public Executor(string name, int skill, Manager ParentManager)
        {
            ID = IDcount++;
            this.name = name;
            this.skill = skill;
            assignedTasks = new List<Task>();
            this.ParentManager = ParentManager;
        }

        public void AssignTask(Task assignment)
        {
            if (assignment != null)
            {
                assignment.AssignWorker(this);
                assignedTasks.Add(assignment);
            }
        }

        public void DeassignTask(Task assignment) => assignedTasks.Remove(assignment);

        public bool TryDelegate(Task task, Executor unlucky)
        {
            if (unlucky.assignedTasks.Count < assignedTasks.Count)
            {
                //Шанс 50/50
                if (new Random(DateTime.Now.Millisecond).Next(2) == 1)
                {
                    unlucky.AssignTask(task);
                    assignedTasks.Remove(task);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void PerformImpact()
        {
            if (assignedTasks.Where(x => x.State == TaskState.Work).Count() > 0)
            {
                Task currentTask = assignedTasks.Where(x => x.State == TaskState.Work).First();
                int impactResult = currentTask.Impact(skill);
                if (currentTask.State == TaskState.Complete && impactResult > 0)
                {
                    PerformImpact(impactResult);
                }
            }
        }

        public void PerformImpact(int skillPart)
        {
            if (assignedTasks.Where(x => x.State == TaskState.Work).Count() > 0)
            {
                Task currentTask = assignedTasks.Where(x => x.State == TaskState.Work).First();
                int impactResult = currentTask.Impact(skillPart);
                if (currentTask.State == TaskState.Complete && impactResult > 0)
                {
                    PerformImpact(impactResult);
                }
            }
        }

        public void TakeControl()
        {
            Console.Clear();
            bool cycleFlag = true;
            while (cycleFlag)
            {
                Console.Write($"Контроль Работника[ID:{ID}]\n" +
                            $"Выберите действие:\n" +
                            $"1-[Информация о работнике]\n" +
                            $"2-[Проекты в которых участвует]\n" +
                            $"3-[Информация о задачах]\n" +
                            $"4-[Назад]\n" +
                            $"Ответ: ");
                if (!byte.TryParse(Console.ReadLine(), out byte userResponce))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка: неверный формат ввода!");
                    continue;
                }
                switch (userResponce)
                {
                    case 1:
                        Console.WriteLine("Информация о текущем работнике:");
                        Console.WriteLine(this);
                        Console.Write("Для продолжения нажмите любую кнопку.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        IEnumerable<Project> foundProjects = ParentManager.projects.Where(x => x.GetParticipants().Contains(this));
                        if (foundProjects.Count() == 0)
                        {
                            Console.WriteLine("Работник пока не участвует ни в одном проекте.");
                            Console.Write("Для продолжения нажмите любую кнопку.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine($"Список проектов:\n{string.Join("\n", foundProjects.Select(x => x.ToString()))}");
                            Console.Write("Для продолжения нажмите любую кнопку.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 3:
                        if (assignedTasks.Count == 0)
                        {
                            Console.WriteLine("Работнику пока не назначено задач.");
                            Console.Write("Для продолжения нажмите любую кнопку.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            if (assignedTasks.Any(x => x.State == TaskState.Assigned))
                            {
                                bool taskFlag = true;
                                while (taskFlag)
                                {
                                    Console.WriteLine($"Список задач:\n{string.Join("\n", assignedTasks.OrderBy(x => x.ID).Select(x => x.ToString()))}");
                                    Console.Write($"Выберите действие:\n" +
                                        $"1-[Попытаться делегировать задачу]\n" +
                                        $"2-[Назад]\n" +
                                        $"Ответ: ");
                                    if (!byte.TryParse(Console.ReadLine(), out byte userTaskResponce))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Ошибка: неверный формат ввода!");
                                        continue;
                                    }
                                    switch (userTaskResponce)
                                    {
                                        case 1:
                                            Console.Write("Введите ID задачи: ");
                                            if (!int.TryParse(Console.ReadLine(), out int inputTaskID))
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Ошибка: неверный формат ввода!");
                                                continue;
                                            }
                                            if (assignedTasks.Select(x => x.ID).Contains(inputTaskID))
                                            {
                                                Task foundTask = assignedTasks.Where(x => x.ID == inputTaskID).First();
                                                if (foundTask.State == TaskState.Assigned)
                                                {
                                                    List<Executor> participantsFound = foundTask.GetProject().GetParticipants().Where(x => x.ID != ID).ToList();
                                                    if (participantsFound.Count() == 0)
                                                    {
                                                        Console.WriteLine("Некому передать эту задачу.");
                                                    }
                                                    else
                                                    {
                                                        Console.Write($"Список учатников проета:\n{string.Join("\n", foundTask.GetProject().GetParticipants().Select(x => x.ToString()))}\n" +
                                                        $"Введите ID участника, которому хотите передать задание: ");
                                                        if (!int.TryParse(Console.ReadLine(), out int inputExecID))
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Ошибка: неверный формат ввода!");
                                                            continue;
                                                        }
                                                        if (participantsFound.Select(x => x.ID).Contains(inputExecID))
                                                        {
                                                            if (TryDelegate(foundTask, participantsFound.Where(x => x.ID == inputExecID).First()))
                                                            {
                                                                Console.WriteLine("Вы успешно делегировали задачу!");
                                                                if (assignedTasks.Count == 0)
                                                                {
                                                                    taskFlag = false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Задачу не удалось делегировать.");
                                                            }
                                                            Console.Write("Для продолжения нажмите любую кнопку.");
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                        }
                                                        else
                                                        {
                                                            Console.Write("Работник с таким ID не учавствует в этом проекте.");
                                                            Console.Write("Для продолжения нажмите любую кнопку.");
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Эта задача уже находится в работе, её нельзя делегировать");
                                                    Console.Write("Для продолжения нажмите любую кнопку.");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Ошибка: Эта задача не назначена данному работнику!");
                                                continue;
                                            }
                                            break;
                                        default:
                                            taskFlag = false;
                                            Console.Clear();
                                            break;
                                    }
                                }
                            }
                            else
                            {

                            }
                        }
                        break;
                    default:
                        cycleFlag = false;
                        Console.Clear();
                        break;
                }
            }
        }

        public override string ToString()
        {
            if (assignedTasks.Count == 0)
            {
                return $"Работник [ID:{ID}] {name}|Навыки:{skill}|Завершено:{assignedTasks.Count(x => x.State == TaskState.Complete)}|Назначенные:{assignedTasks.Count}";
            }
            else
            {
                return $"Работник [ID:{ID}] {name}|Навыки:{skill}|Завершено:{assignedTasks.Count(x => x.State == TaskState.Complete)}|Назначенные:{assignedTasks.Count}(Ниже список)\n{string.Join("\n", assignedTasks.Select(x => x.ToString()))}";
            }
        }
    }
}