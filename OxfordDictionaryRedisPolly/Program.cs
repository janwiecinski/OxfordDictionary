using StackExchange.Redis;
using System;

namespace OxfordDictionaryRedisPolly
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchedWord = Console.ReadLine().ToLower();
            var cache =  RedisConnectionProvider.Connection.GetDatabase();
            if (cache.KeyExists(searchedWord))
            {
                Console.WriteLine(cache.StringGet(searchedWord));
            }
            else
            {
                var result = new HttpClientWrapper().GetAsync($"https://od-api.oxforddictionaries.com/api/v1/entries/en/{searchedWord}").GetAwaiter().GetResult();
                cache.StringSet(searchedWord, result[1], TimeSpan.FromMinutes(15));
            }

            Console.ReadKey();
        }
    }
}
