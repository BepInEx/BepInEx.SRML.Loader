using System;

namespace SRML.Config.Attributes
{
    public class ConfigFileAttribute : Attribute
    {
        internal string FileName;
        internal string DefaultSection;
        public ConfigFileAttribute(string name, string defaultsection = "CONFIG")
        {
            FileName = name;
            DefaultSection = defaultsection;
        }
    }
}
