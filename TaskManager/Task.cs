using System;

namespace TaskManager
{
    class Task
    {
        #region Fields
        public readonly long ID;
        private static long IDcount;
        private readonly int startComplexity;
        private int complexity;
        private Executor worker;
        private TaskState state;
        private Project project;
        private readonly int timings;
        private int impacts;
        #endregion

        #region Properties
        public TaskState State => state;
        public Executor Worker => worker;
        public int Complexity => complexity;
        public byte Completeness
        {
            get
            {
                if (complexity > 0 && startComplexity > 0)
                {
                    return Convert.ToByte(Math.Floor((1 - (double)complexity / startComplexity) * 100));
                }
                else
                {
                    return 100;
                }
            }
        }
        public bool CompleteInTime => (state == TaskState.Complete) && (impacts <= timings);
        #endregion

        #region Constructors
        static Task()
        {
            IDcount = 0;
        }

        public Task(int complexity, int timings, Project project)
        {
            ID = IDcount++;
            this.complexity = complexity;
            startComplexity = complexity;
            this.timings = timings;
            this.project = project;
            state = TaskState.Planned;
        }
        #endregion

        #region Methods
        public int Impact(int skill)
        {
            if (state != TaskState.Complete)
            {
                impacts++;
                complexity -= skill;
                if (complexity <= 0)
                {
                    state = TaskState.Complete;
                    return -complexity;
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }

        public void LockState()
        {
            if (state != TaskState.Complete)
            {
                state = TaskState.Work;
            }
        }

        public bool AssignWorker(Executor worker)
        {
            if (state == TaskState.Planned || state == TaskState.Assigned)
            {
                this.worker = worker;
                if (state == TaskState.Planned)
                {
                    state++;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public Project GetProject() => project;
        public override string ToString() => $"Задача [ID:{ID}] Статус: {state}|Сложность: {complexity}|Работник:{worker?.name ?? "Не назначен"}|Завершена на {Completeness}%";
        #endregion
    }

    public enum TaskState
    {
        Planned = -1,
        Assigned = 0,
        Work = 1,
        Complete = 2
    }
}