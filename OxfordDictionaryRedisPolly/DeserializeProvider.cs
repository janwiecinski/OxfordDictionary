using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OxfordDictionaryRedisPolly
{
    public static class DeserializeProvider
    {
        public static List<string> GetStringsFromJson(string stringJson)
        {
            var stringCollection = new List<string>();

            var deserializedObject = JsonConvert.DeserializeObject<OxfordDictionaryResultJSON>(stringJson);
            var wordDefinition = deserializedObject.Results[0].LexicalEntries[0].Entries[0].Senses[0].Definitions[0];
            var lexicalCategory = deserializedObject.Results[0].LexicalEntries[0].LexicalCategory;

            stringCollection.Add(lexicalCategory);
            stringCollection.Add(wordDefinition);

            stringCollection.ForEach(s=>Console.WriteLine(s));

            return stringCollection;
        }
    }
}
