using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Raudy.Net {
    public enum Status {
        SUCCESS,
        ERROR
    }

    public struct MessageHeader {
        public int local_id { get; set; }
        public int? remote_id { get; set; }
        public string type { get; set; }
    }

    public struct Message<T> {
        public Status status { get; set; }
        public MessageHeader header { get; set; }
        public T content { get; set; }
        public string tags { get; set; }
    }

    public static class Net {
        public delegate void onConnect(EndPoint endpoint);
        public delegate void onAccept(EndPoint endpoint);
        public delegate void onReceive(ArraySegment<byte> buffer, EndPoint endpoint);
        public delegate void onDisconnect(EndPoint endpoint);

        private static int local_id = 0;
        private static JsonSerializerSettings jsonSettings = new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        };

        public static Message<T> NewMessage<T>(string type, int? remote_id = null) {
            MessageHeader header = new MessageHeader();
            header.local_id = ++local_id;
            header.remote_id = remote_id;
            header.type = type;

            Message<T> message = new Message<T>();
            message.header = header;

            return message;
        }

        public static Message<T> DeserializeMessage<T>(string msg) {
            return JsonConvert.DeserializeObject<Message<T>>(msg);
        }

        public static string MessageType(string msg) {
            Message<object> message = JsonConvert.DeserializeObject<Message<object>>(msg);
            return message.header.type;
        }

        public static byte[] SerializeMessage<T>(Message<T> message) {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message, Formatting.None, jsonSettings));
        }
    }
}
