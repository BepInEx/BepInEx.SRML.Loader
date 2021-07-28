using SRML.Config.Parsing;
using System;

namespace SRML.Config.Attributes
{
    public class ConfigParserAttribute : Attribute
    {
        public IStringParser Parser;
        public ConfigParserAttribute(IStringParser parser)
        {
            Parser = parser;
        }
    }
}
