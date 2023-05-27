using System.Text;
using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace Raudy.Net
{
    public enum Status
    {
        SUCCESS,
        ERROR
    }

    public struct MessageHeader
    {
        public int local_id { get; set; }
        public int? remote_id { get; set; }
        public string type { get; set; }
    }

    public struct Message<T>
    {
        public Status status { get; set; }
        public MessageHeader header { get; set; }
        public T result { get; set; }
        public string[] messages { get; set; }
    }

    public static class Net
    {
        private static int local_id = 0;
        private static JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

    public static Message<T> NewMessage<T>(string type, int? remote_id = null)
        {
            MessageHeader header = new MessageHeader();
            header.local_id = ++local_id;
            header.remote_id = remote_id;
            header.type = type;

            Message<T> message = new Message<T>();
            message.header = header;

            return message;
        }

        public static string MessageType(string msg)
        {
            Message<object> message = JsonConvert.DeserializeObject<Message<object>>(msg);
            return message.header.type;
        }

        public static byte[] SerializeMessage<T>(Message<T> message)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message, Formatting.None, jsonSettings));
        }
    }
}
