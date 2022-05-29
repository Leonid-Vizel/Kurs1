using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager
{
    class Project
    {
        #region Fields
        private static long IDcount;
        public readonly long ID;
        public readonly string name;
        private List<Executor> executors;
        private List<Task> tasks;
        private Executor TeamLead;
        private ProjectState state;
        private Manager parent;
        #endregion

        #region Properties
        public ProjectState State => state;
        public bool Closed => (tasks.Count > 0) && tasks.All(x => x.State == TaskState.Complete);
        public bool CompleteInTime => (tasks.Count > 0) && (tasks.All(x => x.CompleteInTime));
        public byte Completeness
        {
            get
            {
                if (tasks.Count > 0)
                {
                    return Convert.ToByte(Math.Floor((double)tasks.Count(x => x.State == TaskState.Complete) / tasks.Count * 100));
                }
                else
                {
                    return 0;
                }
            }
        }
        public string MiniInfo => $"Проект [ID:{ID}]Название:{name}|Всего задач: {tasks.Count}|Всего  исполнителей: {executors.Count}|Завершён на {Completeness}%";
        #endregion

        #region Constructors
        static Project()
        {
            IDcount = 0;
        }

        public Project(string name, Executor TeamLead, Manager parent)
        {
            ID = IDcount++;
            executors = new List<Executor>();
            tasks = new List<Task>();
            this.TeamLead = TeamLead;
            state = ProjectState.Project;
            this.parent = parent;
            this.name = name;
        }
        #endregion

        #region Methods
        public void RemoveWorker(Executor exec)
        {
            executors.Remove(exec);
            foreach (Task task in tasks.Where(x => x.Worker == exec))
            {
                executors.OrderBy(x => x.GetTasks().Count).First().AssignTask(task);
            }
        }

        public bool AssingWorker(Executor exec)
        {
            if (executors.Any(x => x == exec))
            {
                return false;
            }
            else
            {
                executors.Add(exec);
                return true;
            }
        }

        public void RemoveTask(Task taskInstance) => tasks.Remove(taskInstance);

        public void DistributeTasks()
        {
            List<Task> tasksAssign = new List<Task>(tasks.OrderByDescending(x => x.Complexity));
            executors = executors.OrderByDescending(x => x.skill).ToList();
            int taskPerWorker = Convert.ToInt32(Math.Floor((double)tasksAssign.Count / executors.Count));
            if (taskPerWorker > 0)
            {
                foreach (var exec in executors)
                {
                    for (int i = 0; i < taskPerWorker; i++)
                    {
                        Task assignment = tasksAssign[0];
                        tasksAssign.RemoveAt(0);
                        exec.AssignTask(assignment);
                    }
                }
            }
            if (tasksAssign.Count != 0)
            {
                tasksAssign.Reverse();
                executors.Reverse();
                foreach (var exec in executors)
                {
                    if (tasksAssign.Count == 0) break;
                    Task assignment = tasksAssign[0];
                    tasksAssign.RemoveAt(0);
                    exec.AssignTask(assignment);
                }
            }
            Console.WriteLine($"Тимлид([ID:{TeamLead.ID}]{TeamLead.name}) распределил задачи проекта по исполнителям!");
        }

        public void StartWorking() => tasks.ForEach(x => x.LockState());

        public void TimeStep() => executors.ForEach(x => x.PerformImpact());

        public void TakeControl()
        {
            Console.Clear();
            bool cycleflag = true;
            while (cycleflag)
            {
                if (!Closed && tasks.All(x => x.State == TaskState.Planned))
                {
                    Console.Write($"[Контроль проекта[ID:{ID}]]Выберите действие:\n" +
                        "0-[Информация о проекте]\n" +
                        "1-[Информация о задачах]\n" +
                        "2-[Информация о работниках]\n" +
                        "3-[Распределить задачи]\n" +
                        "4-[Назад]\n" +
                        "Ответ: ");
                    if (!byte.TryParse(Console.ReadLine(), out byte userResponce))
                    {
                        Console.Clear();
                        Console.WriteLine("Ошибка: неверный формат ввода!");
                        continue;
                    }
                    switch (userResponce)
                    {
                        case 0:
                            Console.WriteLine(this);
                            Console.Write("Для продолжения нажмите любую кнопку.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 1:
                            bool taskCycle = true;
                            while (taskCycle)
                            {
                                Console.WriteLine("Список задач: ");
                                Console.WriteLine(string.Join("\n", tasks.Select(x => x.ToString())));
                                Console.Write("Выберите действие:\n" +
                                    "1-[Добавить задачу]\n" +
                                    "2-[Удалить задачу]\n" +
                                    "3-[Назад]\n" +
                                    "Ответ: ");
                                if (!byte.TryParse(Console.ReadLine(), out byte userTaskResponce))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Ошибка: неверный формат ввода!");
                                    continue;
                                }
                                switch (userTaskResponce)
                                {
                                    case 1:
                                        Console.Write("Задайте сложность задачи(Пример:работник со скилом 100 завершит 1 задачу пложность 100 за 1 шаг): ");
                                        if (!int.TryParse(Console.ReadLine(), out int inputComplex))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Ошибка: неверный формат ввода!");
                                            continue;
                                        }
                                        Console.Write("Введите за сколько шагов должна быть выполнена задача: ");
                                        if (!int.TryParse(Console.ReadLine(), out int inputTimig))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Ошибка: неверный формат ввода!");
                                            continue;
                                        }
                                        tasks.Add(new Task(inputComplex, inputTimig, this));
                                        Console.WriteLine("Задача была успешно добавлена!");
                                        Console.Write("Для продолжения нажмите любую кнопку.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case 2:
                                        if (tasks.Count > 0)
                                        {
                                            Console.Write("Введите ID задачи: ");
                                            if (!int.TryParse(Console.ReadLine(), out int inputTaskID))
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Ошибка: неверный формат ввода!");
                                                continue;
                                            }
                                            if (tasks.Any(x => x.ID == inputTaskID))
                                            {
                                                Task foundTask = tasks.Where(x => x.ID == inputTaskID).First();
                                                tasks.Remove(foundTask);
                                                Console.Write("Для продолжения нажмите любую кнопку.");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Ошибка: Задача с таким ID не найдена!");
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Ошибка: Ни одна задача не добавлена!");
                                            continue;
                                        }
                                        break;
                                    default:
                                        taskCycle = false;
                                        Console.Clear();
                                        break;
                                }
                            }
                            break;
                        case 2:
                            Console.Clear();
                            bool workerCycle = true;
                            while (workerCycle)
                            {
                                Console.WriteLine("Список работников: ");
                                Console.WriteLine(string.Join("\n", executors.Select(x => x.ToString())));
                                Console.Write("Выберите действие:\n" +
                                    "1-[Нанять работника]\n" +
                                    "2-[Уволить работника]\n" +
                                    "3-[Назад]\n" +
                                    "Ответ: ");
                                if (!byte.TryParse(Console.ReadLine(), out byte userExecResponce))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Ошибка: неверный формат ввода!");
                                    continue;
                                }
                                switch (userExecResponce)
                                {
                                    case 1:
                                        if (parent.workersTotal.Count > 0)
                                        {
                                            Console.WriteLine("Список работников: ");
                                            Console.WriteLine(string.Join("\n", parent.workersTotal.Select(x => x.ToString())));
                                            Console.Write("Введите ID работника, чтобы его нанять: ");
                                            if (!int.TryParse(Console.ReadLine(), out int inputExecID))
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Ошибка: неверный формат ввода!");
                                                continue;
                                            }
                                            if (parent.workersTotal.Any(x => x.ID == inputExecID))
                                            {
                                                Executor foundExec = parent.workersTotal.Where(x => x.ID == inputExecID).First();
                                                if (!executors.Contains(foundExec))
                                                {
                                                    AssingWorker(foundExec);
                                                    Console.WriteLine("Работник был успешно нанят!");
                                                    Console.Write("Для продолжения нажмите любую кнопку.");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Ошибка: этот работник уже нанят!");
                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Ошибка: работник с тамик ID не найден!");
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Ошибка: Ни одного исполнителя не создано");
                                            continue;
                                        }
                                        break;
                                    case 2:
                                        if (executors.Count > 0)
                                        {
                                            Console.WriteLine("Список работников: ");
                                            Console.WriteLine(string.Join("\n", executors.Select(x => x.ToString())));
                                            Console.Write("Введите ID работника, чтобы его уволить: ");
                                            if (!int.TryParse(Console.ReadLine(), out int inputExecID))
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Ошибка: неверный формат ввода!");
                                                continue;
                                            }
                                            if (executors.Any(x => x.ID == inputExecID))
                                            {
                                                Executor foundExec = executors.Where(x => x.ID == inputExecID).First();
                                                RemoveWorker(foundExec);
                                                Console.WriteLine("Работник был успешно уволен!");
                                                Console.Write("Для продолжения нажмите любую кнопку.");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Ошибка: Работник с таким ID не найден!");
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Ошибка: Ни одного исполнителя не нанято");
                                            continue;
                                        }
                                        break;
                                    default:
                                        workerCycle = false;
                                        Console.Clear();
                                        break;
                                }
                            }
                            break;
                        case 3:
                            if (executors.Count > 0 && tasks.Count > 0)
                            {
                                DistributeTasks();
                                Console.Write("Для продолжения нажмите любую кнопку.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Ошибка: в проекте недостаточно исполнителей/задач!");
                                continue;
                            }
                            break;
                        default:
                            Console.Clear();
                            cycleflag = false;
                            break;
                    }
                }
                else if (!Closed && tasks.All(x => x.State == TaskState.Assigned))
                {
                    Console.Write($"[Контроль проекта[ID:{ID}]]Выберите действие:\n" +
                        "0-[Информация о проекте]\n" +
                        "1-[Информация о задачах]\n" +
                        "2-[Информация о работниках]\n" +
                        "3-[Открыть работу над проектом]\n" +
                        "4-[Назад]\n" +
                        "Ответ: ");
                    if (!byte.TryParse(Console.ReadLine(), out byte userResponce))
                    {
                        Console.Clear();
                        Console.WriteLine("Ошибка: неверный формат ввода!");
                        continue;
                    }
                    switch (userResponce)
                    {
                        case 0:
                            Console.WriteLine(this);
                            Console.Write("Для продолжения нажмите любую кнопку.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 1:
                            Console.WriteLine("Список задач: ");
                            Console.WriteLine(string.Join("\n", tasks.Select(x => x.ToString())));
                            Console.Write("Для продолжения нажмите любую кнопку.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            Console.WriteLine("Список работников: ");
                            Console.WriteLine(string.Join("\n", executors.Select(x => x.ToString())));
                            Console.Write("Для продолжения нажмите любую кнопку.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            if (executors.Count > 0 && tasks.Count > 0)
                            {
                                StartWorking();
                                Console.WriteLine("Проект успешно принят в работу! Чтобы завершить шаг перейдите в режим глобального контроля и совершите глобальный шаг.");
                                Console.Write("Для продолжения нажмите любую кнопку.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Ошибка: в проекте недостаточно исполнителей/задач!");
                                continue;
                            }
                            break;
                        default:
                            Console.Clear();
                            cycleflag = false;
                            break;
                    }
                }
                else
                {
                    Console.Write($"[Контроль проекта[ID:{ID}]]Выберите действие:\n" +
                    "0-[Информация о проекте]\n" +
                    "1-[Информация о задачах]\n" +
                    "2-[Информация о работниках]\n" +
                    "3-[Назад]\n" +
                    "Ответ: ");
                    if (!byte.TryParse(Console.ReadLine(), out byte userResponce))
                    {
                        Console.Clear();
                        Console.WriteLine("Ошибка: неверный формат ввода!");
                        continue;
                    }
                    switch (userResponce)
                    {
                        case 0:
                            Console.WriteLine(this);
                            Console.Write("Для продолжения нажмите любую кнопку.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 1:
                            Console.WriteLine("Список задач: ");
                            Console.WriteLine(string.Join("\n", tasks.Select(x => x.ToString())));
                            Console.Write("Для продолжения нажмите любую кнопку.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            Console.WriteLine("Список работников: ");
                            Console.WriteLine(string.Join("\n", executors.Select(x => x.ToString())));
                            Console.Write("Для продолжения нажмите любую кнопку.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            cycleflag = false;
                            break;
                    }
                }
            }
        }
        public List<Executor> GetParticipants() => executors;

        public override string ToString()
        {
            string report = $"Проект [ID:{ID}]:\n" +
                $"Название: {name}\n" +
                $"Ответственный: {TeamLead.name}\n" +
                $"Суммарная сложность:{tasks.Sum(x => x.Complexity)}\n" +
                $"Всего задач:{tasks.Count}\n" +
                $"Задач завершено:{tasks.Count(x => x.State == TaskState.Complete)}(Из них завершено вовремя:{tasks.Count(x => x.CompleteInTime)})\n" +
                $"Всего работников вовлечено:{executors.Count}\n" +
                $"Статус: ";
            if (Closed)
            {
                report += "Закрыт";
                if (CompleteInTime)
                {
                    report += "(Вовремя)";
                }
                else
                {
                    report += "(Сроки нарушены)";
                }
            }
            else
            {
                report += "Открыт";
            }
            return report;
        }
        #endregion
    }

    public enum ProjectState
    {
        Project = 0,
        Developing = 1,
        Closed = 2
    }
}