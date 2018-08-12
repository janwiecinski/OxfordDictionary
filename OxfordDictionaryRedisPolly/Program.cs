using System;

namespace OxfordDictionaryRedisPolly
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchedWord = Console.ReadLine();

            var result = new HttpClientWrapper().GetAsync($"https://od-api.oxforddictionaries.com/api/v1/entries/en/{searchedWord.ToLower()}");

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
