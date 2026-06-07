using System;

namespace Text2Speech2TextApp.Models
{
    /// <summary>
    /// Model representing voice capabilities. Demonstrates encapsulation.
    /// </summary>
    public class VoiceInfoModel
    {
        public string Name { get; }
        public string Gender { get; }
        public string Age { get; }
        public string Description { get; }
        public string Culture { get; }

        public VoiceInfoModel(string name, string gender, string age, string description, string culture)
        {
            Name = name;
            Gender = gender;
            Age = age;
            Description = description;
            Culture = culture;
        }

        public override string ToString()
        {
            return $"{Name} ({Culture} - {Gender})";
        }
    }
}
