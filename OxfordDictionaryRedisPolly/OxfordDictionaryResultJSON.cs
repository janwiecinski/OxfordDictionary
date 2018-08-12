using System;
using System.Collections.Generic;
using System.Text;

namespace OxfordDictionaryRedisPolly
{
    public class OxfordDictionaryResultJSON
    {
        public MetadataProvider Metadata { get; set; }
        public List<Results> Results { get; set; }
    }

    public class MetadataProvider
    {
        public string Provider { get; set; }
    }

    public class Results
    {
        public string Id { get; set; }
        public string Language { get; set; }
        public List<LexicalEntries> LexicalEntries { get; set; }
        public string Type { get; set; }
        public string Word { get; set; }
    }

    public class LexicalEntries
    {
        public List<Derivatives> Derivatives { get; set; }
        public List<Entries> Entries { get; set; }
    }

    public class Derivatives
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public class Entries
    {
       // public IEnumerable<string> Etymologies { get; set; }
        public List<Senses> Senses { get; set; }
    }

    public class Senses
    {
        public List<string> Definitions { get; set; }
    }
}
