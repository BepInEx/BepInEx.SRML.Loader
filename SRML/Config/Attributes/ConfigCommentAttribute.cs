using System;

namespace SRML.Config.Attributes
{
    public class ConfigCommentAttribute : Attribute
    {
        public string Comment;
        public ConfigCommentAttribute(string comment)
        {
            Comment = comment;
        }
    }
}
