using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager
{
    class Manager
    {
        public List<Executor> workersTotal;
        public List<Project> projects;

        public Manager()
        {
            workersTotal = new List<Executor>();
            projects = new List<Project>();
        }

        public void TakeControl()
        {
            bool cycleflag = true;
            while (cycleflag)
            {
                Console.Write("[Контроль глобального уровня]Выберите действие:\n" +
                "1-[Создать проект]\n" +
                "2-[Создать исполнителя]\n" +
                "3-[Контроль проекта]\n" +
                "4-[Контроль исполнителя]\n" +
                "5-[Глобальный шаг]\n" +
                "6-[Завершение]\n" +
                "Ответ: ");
                if (!byte.TryParse(Console.ReadLine(), out byte userResponce))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка: неверный формат ввода!");
                    continue;
                }
                switch (userResponce)
                {
                    case 1:
                        Console.Write("Введите название Вашего проекта: ");
                        string inputName = Console.ReadLine();
                        Console.WriteLine("Наймём нового TeamLead'а для этого проекта.");
                        Console.Write("Введите его/её имя: ");
                        Executor TeamLead = new Executor(Console.ReadLine(), 0, this);
                        Project nProj = new Project(inputName, TeamLead, this);
                        projects.Add(nProj);
                        Console.WriteLine($"Проект успешно создан!");
                        Console.Write("Для продолжения нажмите любую кнопку.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Наймём сотрудника:");
                        Console.Write("Введите его/её имя: ");
                        string inputExecName = Console.ReadLine();
                        Console.Write("Введите оценку скилов работника: ");
                        if (!int.TryParse(Console.ReadLine(), out int inputExecSkills))
                        {
                            Console.Clear();
                            Console.WriteLine("Ошибка: неверный формат ввода!\n=====================");
                            continue;
                        }
                        Executor inputExec = new Executor(inputExecName, inputExecSkills, this);
                        workersTotal.Add(inputExec);
                        Console.WriteLine($"Работник успешно добавлен!");
                        Console.Write("Для продолжения нажмите любую кнопку.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        if (projects.Count > 0)
                        {
                            Console.WriteLine($"Проекты:\n{string.Join("\n", projects.Select(x => x.MiniInfo))}");
                            Console.Write("Введите ID проекта: ");
                            if (!int.TryParse(Console.ReadLine(), out int inputProjectID))
                            {
                                Console.Clear();
                                Console.WriteLine("Ошибка: неверный формат ввода!\n=====================");
                                continue;
                            }
                            if (projects.Any(x => x.ID == inputProjectID))
                            {
                                Project foundProject = projects.Where(x => x.ID == inputProjectID).First();
                                Console.Clear();
                                bool projectFlag = true;
                                while (projectFlag)
                                {
                                    Console.Write($"Проект[ID:{foundProject.ID}]\nВыберите действие:\n" +
                                    "1-[Показать информацию]\n" +
                                    "2-[Взять контроль]\n" +
                                    "3-[Назад]\n" +
                                    "Ответ: ");
                                    if (!int.TryParse(Console.ReadLine(), out int inputProjectResponce))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Ошибка: неверный формат ввода!\n=====================");
                                        continue;
                                    }
                                    switch (inputProjectResponce)
                                    {
                                        case 1:
                                            Console.WriteLine(foundProject);
                                            Console.Write("Для продолжения нажмите любую кнопку.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        case 2:
                                            projectFlag = false;
                                            foundProject.TakeControl();
                                            break;
                                        default:
                                            projectFlag = false;
                                            Console.Clear();
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Ошибка: Проект с таким ID не найден!\n=====================");
                                continue;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Ошибка: Проектов пока не создано!\n=====================");
                            continue;
                        }
                        break;
                    case 4:
                        if (workersTotal.Count > 0)
                        {
                            Console.WriteLine($"Исполнители:\n{string.Join("\n", workersTotal.Select(x => x.MiniInfo))}");
                            Console.Write("Введите ID исполнителя: ");
                            if (!int.TryParse(Console.ReadLine(), out int inputExecID))
                            {
                                Console.Clear();
                                Console.WriteLine("Ошибка: неверный формат ввода!\n=====================");
                                continue;
                            }
                            if (workersTotal.Any(x => x.ID == inputExecID))
                            {
                                Executor foundExec = workersTotal.Where(x => x.ID == inputExecID).First();
                                Console.Clear();
                                bool workerFlag = true;
                                while (workerFlag)
                                {
                                    Console.Write($"Работник[ID:{foundExec.ID}]\nВыберите действие:\n" +
                                    "1-[Показать информацию]\n" +
                                    "2-[Взять контроль]\n" +
                                    "3-[Добавить в проект]\n" +
                                    "4-[Назад]\n" +
                                    "Ответ: ");
                                    if (!int.TryParse(Console.ReadLine(), out int inputProjectResponce))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Ошибка: неверный формат ввода!\n=====================");
                                        continue;
                                    }
                                    switch (inputProjectResponce)
                                    {
                                        case 1:
                                            Console.WriteLine(foundExec);
                                            Console.Write("Для продолжения нажмите любую кнопку.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        case 2:
                                            foundExec.TakeControl();
                                            workerFlag = false;
                                            break;
                                        case 3:
                                            if (projects.Count > 0)
                                            {
                                                Console.WriteLine($"Проекты:\n{string.Join("\n", projects.Select(x => x.MiniInfo))}");
                                                Console.Write("Введите ID проекта: ");
                                                if (!int.TryParse(Console.ReadLine(), out int inputProjectID))
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Ошибка: неверный формат ввода!\n=====================");
                                                    continue;
                                                }
                                                if (projects.Any(x => x.ID == inputProjectID))
                                                {
                                                    if (projects.Where(x => x.ID == inputProjectID).First().AssingWorker(foundExec))
                                                    {
                                                        Console.WriteLine("Работник теперь учавствует в проекте!");
                                                        Console.Write("Для продолжения нажмите любую кнопку.");
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Ошибка: этот исполнитель уже назначен на этот проект!\n=====================");
                                                        continue;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Ошибка: Проект с таким ID не найден!\n=====================");
                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Ошибка: Проектов пока не создано!\n=====================");
                                                continue;
                                            }
                                            break;
                                        default:
                                            workerFlag = false;
                                            Console.Clear();
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Ошибка: Исполнитель с таким ID не найден!\n=====================");
                                continue;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Ошибка: Ни один работник ещё не нанят!\n=====================");
                            continue;
                        }
                        break;
                    case 5:
                        projects.ForEach(x => x.TimeStep());
                        Console.Clear();
                        Console.WriteLine("Шаг совершён!\n=====================");
                        break;
                    default:
                        Console.Clear();
                        cycleflag = false;
                        Console.WriteLine("Спасибо за пользование!");
                        Console.WriteLine("Нажмите на любую кнопку для завершения.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}