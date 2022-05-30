using System;

namespace ClassWork12
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    public sealed class DeveloperInfoAttribute : Attribute
    {
        public string DevName { get; private set; }
        public DateTime DevTime { get; private set; }

        public DeveloperInfoAttribute(string developer, DateTime date)
        {
            DevName = developer;
            DevTime = date;
        }

        public DeveloperInfoAttribute(string developer)
        {
            DevName = developer;
            DevTime = DateTime.Now;
        }
    }
}
