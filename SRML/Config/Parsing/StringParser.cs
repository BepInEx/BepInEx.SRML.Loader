﻿using System;

namespace SRML.Config.Parsing
{

    public class DelegateStringParser<T> : StringParser<T>
    {
        public delegate string EncodeGenericDelegate<T>(T obj);
        public delegate T ParseGenericDelegate<T>(string str);

        EncodeGenericDelegate<T> encoder;
        ParseGenericDelegate<T> parser;

        public DelegateStringParser(EncodeGenericDelegate<T> encoder, ParseGenericDelegate<T> parser)
        {
            this.encoder = encoder;
            this.parser = parser;
        }
        public override string Encode(T obj)
        {
            return encoder(obj);
        }

        public override T Parse(string str)
        {
            return parser(str);
        }
    }
    public abstract class StringParser<T> : IStringParser
    {
        public Type ParsedType => typeof(T);

        public abstract string Encode(T obj);

        public abstract T Parse(string str);

        public string EncodeObject(object obj)
        {
            return Encode((T)obj);
        }

        public object ParseObject(string str)
        {
            return Parse(str);
        }

        public string GetUsageString()
        {
            return ParsedType.Name;
        }
    }
    public interface IStringParser
    {
        Type ParsedType { get; }
        object ParseObject(string str);
        string EncodeObject(object obj);

        string GetUsageString();
    }

    public interface IStringParserProvider
    {
        IStringParser GetParser();
    }
}
