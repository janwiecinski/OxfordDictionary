using System;
using StackExchange.Redis;

namespace OxfordDictionaryRedisPolly
{
    public class RedisConnectionProvider
    {
        private static Lazy<ConnectionMultiplexer> redisLazyConnection;

        static RedisConnectionProvider()
        {
            redisLazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("localhost");
            });
        }

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return redisLazyConnection.Value;
            }
        }
    }
}
