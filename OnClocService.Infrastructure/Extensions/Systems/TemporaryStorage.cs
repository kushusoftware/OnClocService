
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;

namespace OnClocService.Infrastructure.Extensions.Systems;

public static class TemporaryStorage
{
    public static void Set<T>(this ITempDataDictionary tempData, string key, T value)
    {
        tempData[key] = JsonSerializer.Serialize(value);
    }

    public static T? Get<T>(this ITempDataDictionary tempData, string key)
    {
        tempData.TryGetValue(key, out var value);
        return value == null ? default : JsonSerializer.Deserialize<T>((string)value);
    }

    public static void AddFeedback(this ITempDataDictionary tempData, string key, MessageType messageType, string messageText)
    {
        var currentFeedback = tempData.Get<List<MessageData>>(key);
        if (currentFeedback == default) currentFeedback = [];
        currentFeedback.Add(new MessageData { MessageType = messageType, MessageText = messageText });
        tempData.Set(key, currentFeedback);
    }

    public static List<MessageData>? FetchFeedback(this ITempDataDictionary tempData, string key)
    {
        return tempData.Get<List<MessageData>>(key);
    }

    public struct MessageData(MessageType messageType, string messageText)
    {
        public MessageType MessageType { get; set; } = messageType;
        public string MessageText { get; set; } = messageText;
    }

    public enum MessageType
    {
        danger = 1,
        info,
        success,
        warning
    }
}
