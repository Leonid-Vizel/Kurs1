using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassWork7
{
    class Worker
    {
        private long ID;
        private string name;
        private WorkerType position;
        private Worker[] lower;
        private List<WorkerTask> tasks;
        private static long IDcount;
        public static List<Worker> Existingworkers;

        public long GetID() => ID;
        public Worker[] GetLower() => lower;
        public string GetName() => name;
        public static Worker GetByID(long ID) => Existingworkers.Where(x => x.ID == ID).FirstOrDefault();

        static Worker()
        {
            Existingworkers = new List<Worker>();
            IDcount = 0;
        }

        public Worker(string name, WorkerType position, params Worker[] lowers)
        {
            ID = IDcount++;
            this.name = name;
            this.position = position;
            lower = lowers;
            tasks = new List<WorkerTask>();
            Existingworkers.Add(this);
        }

        ~Worker() => Existingworkers.Remove(this);

        public override string ToString() => $"[ID:{ID}] Имя:{name}|Должность:{position}|Подчинённые:{lower.Length}|Заданий присвоено:{tasks.Count}";
        public override bool Equals(object obj)
        {
            if (obj is Worker)
            {
                return ID == (obj as Worker).ID;
            }
            else
            {
                return false;
            }
        }
        public bool Ask(WorkerTask WhatToDo)
        {
            Console.Write($"{name} получает задание {WhatToDo.GetName()} и ");
            if (lower.Length > 0)
            {
                if (lower.Count(x => x.position == WorkerType.controller) == lower.Count())
                {
                    Console.WriteLine("передаёт его дальше");
                    return lower.First().Ask(WhatToDo);
                }
                else if (WhatToDo.GetTType() == TaskType.ForProgrammers && lower.Any(x => x.position == WorkerType.controllerProgrammer))
                {
                    Console.WriteLine("передаёт его дальше");
                    return lower.Where(x => x.position == WorkerType.controllerProgrammer).First().Ask(WhatToDo);
                }
                else if (WhatToDo.GetTType() == TaskType.ForSysAdmins && lower.Any(x => x.position == WorkerType.controllerAdmin))
                {
                    Console.WriteLine("передаёт его дальше");
                    return lower.Where(x => x.position == WorkerType.controllerAdmin).First().Ask(WhatToDo);
                }
                else if (WhatToDo.GetTType() == TaskType.ForProgrammers && lower.Any(x => x.position == WorkerType.programmer))
                {
                    Console.WriteLine("передаёт его дальше");
                    return lower.Where(x => x.position == WorkerType.programmer).OrderBy(x => x.tasks.Count()).First().Ask(WhatToDo);
                }
                else if (WhatToDo.GetTType() == TaskType.ForSysAdmins && lower.Any(x => x.position == WorkerType.sysAdmin))
                {
                    Console.WriteLine("передаёт его дальше");
                    return lower.Where(x => x.position == WorkerType.sysAdmin).OrderBy(x => x.tasks.Count()).First().Ask(WhatToDo);
                }
                else if (lower.Any(x => x.position == WorkerType.controller))
                {
                    Console.WriteLine("передаёт его дальше");
                    return lower.Where(x => x.position == WorkerType.controller).First().Ask(WhatToDo);
                }
                else
                {
                    Console.WriteLine("не может передать задание указанному человеку.");
                    return false;
                }
            }
            else
            {
                if ((position == WorkerType.programmer && WhatToDo.GetTType() == TaskType.ForProgrammers) || (position == WorkerType.sysAdmin && WhatToDo.GetTType() == TaskType.ForSysAdmins))
                {
                    Console.WriteLine("понимает, что оказывается крайнем(крайней) и приступает к работе");
                    tasks.Add(WhatToDo);
                    return true;
                }
                else
                {
                    Console.WriteLine("не может принять это задание так как спецификация задания отлична от спецификации рабоника(Нет подчинённых)");
                    return false;
                }
            }
        }
    }

    enum WorkerType
    {
        controller = 0, //Высшие должности или заказчик
        controllerProgrammer = 1, //Начальник программистов
        controllerAdmin = 2, //Начальник системщиков
        programmer = 3, //Программист
        sysAdmin = 4 //Системщик
    }
}
