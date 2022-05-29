using System;

namespace ClassWork11
{
    public sealed class DevelopementInfoAttribute : Attribute
    {
        public string DevName { get; private set; }
        public string DevOrg { get; private set; }

        public DevelopementInfoAttribute(string developer, string organisation)
        {
            DevName = developer;
            DevOrg = organisation;
        }
    }
}
