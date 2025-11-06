using Newtonsoft.Json;
using StackExchange.Redis;

namespace Stocks.Services;


public static class RedisHelper
{
    private static readonly Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        ConnectionMultiplexer.Connect("localhost:6379")
    );

    public static ConnectionMultiplexer Connection => lazyConnection.Value;
    public static IDatabase Db => Connection.GetDatabase();

    public static void SetObject<T>(string key, T obj, TimeSpan? expiry = null)
    {
        var json = JsonConvert.SerializeObject(obj);
        Db.StringSet(key, json, expiry);
    }

    public static T GetObject<T>(string key)
    {
        var value = Db.StringGet(key);
        if (value.IsNullOrEmpty) return default;
        return JsonConvert.DeserializeObject<T>(value);
    }
}

