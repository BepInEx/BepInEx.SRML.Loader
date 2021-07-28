using System;

namespace SRML.Config.Attributes
{
    public class ConfigCallbackAttribute : Attribute
    {

        public string methodName;

        public ConfigCallbackAttribute(string methodName)
        {
            this.methodName = methodName;
        }


    }

}
