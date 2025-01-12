using System.Text.Json;
using lesson_12_13.Controllers;

namespace lesson_12_13.Models;

public static class SessionExtensions
{
   public static void Set<T>(this ISession session, string key, T value)
   {
      session.SetString(key, JsonSerializer.Serialize<T>(value));
   }

   public static T? Get<T>(this ISession session, string key)
   {
      var value = session.GetString(key);
      return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
   }
}