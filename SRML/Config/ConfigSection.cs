using IniParser.Model;
using System.Collections.Generic;
using SRML.Utils;

namespace SRML.Config
{
    public class ConfigSection
    {

        readonly Dictionary<string, ConfigElement> elementDict = new Dictionary<string, ConfigElement>();

        public IEnumerable<ConfigElement> Elements => elementDict.Values;

        public delegate void OnValueChangedDelegate(string key, object value);

        public event OnValueChangedDelegate OnValueChanged;

        public string Name { get; internal set; }
        public string Comment { get; internal set; }

        public ConfigSection(string name)
        {
            Name = name;
        }
        public void AddElement(ConfigElement element)
        {
            elementDict[element.Options.Name] = element;
            element.OnValueChanged += (val) => OnValueChanged?.Invoke(element.Options.Name, val);
        }

        public ConfigElement this[string index] => elementDict[index];

        public void Clear() => elementDict.Clear();
        public void LoadIniData(KeyDataCollection keys)
        {
            foreach (var data in keys)
            {
                if (elementDict.TryGetValue(data.KeyName, out var element))
                {
                    element.SetValue(element.Options.Parser.ParseObject(data.Value));
                }
                else
                {
                    LogUtils.BepInExLog.LogWarning($"Unknown key {data.KeyName} in section! Ignoring...");
                }
            }
        }

        public void WriteIniData(KeyDataCollection keys)
        {
            foreach (var element in elementDict)
            {
                var keyData = new KeyData(element.Key);
                keyData.Value = element.Value.Options.Parser.EncodeObject(element.Value.GetValue<object>());
                var commentList = new List<string>();
                commentList.Add(element.Value.Options.Parser.GetUsageString());
                if (element.Value.Options.Comment != null) commentList.Add(element.Value.Options.Comment);
                keyData.Comments = commentList;
                if (!keys.AddKey(keyData)) LogUtils.BepInExLog.LogWarning($"Key {element.Key} already present in section!");
            }
        }


    }
}
