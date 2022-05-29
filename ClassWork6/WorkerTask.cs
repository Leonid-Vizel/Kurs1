namespace ClassWork6
{
    class WorkerTask
    {
        private string name;
        private TaskType type;

        public WorkerTask(string name, TaskType type)
        {
            this.name = name;
            this.type = type;
        }

        public TaskType GetTType() => type;
        public string GetName() => name;
    }

    enum TaskType
    {
        ForProgrammers = 0,
        ForSysAdmins = 1
    }
}
