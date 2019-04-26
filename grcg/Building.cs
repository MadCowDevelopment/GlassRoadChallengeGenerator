using System.Collections.Generic;

namespace grcg
{
    internal class Building
    {
        private readonly Dictionary<string, string> _translations = new Dictionary<string, string>();
        public Building(Category category)
        {
            Category = category;
        }

        public Category Category { get; }

        public void AddTranslation(string language, string name)
        {
            _translations.Add(language, name);
        }

        public string ToPostFormat()
        {
            return string.Join(" - ", _translations.Values);
        }
    }
}