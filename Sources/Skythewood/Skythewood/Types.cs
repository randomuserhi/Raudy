public partial class Skythewood {
    public struct Content {

    }

    public struct Response<T> {
        public int status { get; set; }
        public T result { get; set; }
        public string message { get; set; }
        public string[] messages { get; set; }
    }
}