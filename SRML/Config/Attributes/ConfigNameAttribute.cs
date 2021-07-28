using System;

namespace SRML.Config.Attributes
{
    public class ConfigNameAttribute : Attribute
    {
        public string Name;
        public ConfigNameAttribute(string name)
        {
            Name = name;
        }
    }
}
