using System;

namespace SRML.Config.Attributes
{
    public class ConfigReloadAttribute : Attribute
    {
        public ReloadMode Mode;
        public ConfigReloadAttribute(ReloadMode mode)
        {
            Mode = mode;
        }
    }
}
