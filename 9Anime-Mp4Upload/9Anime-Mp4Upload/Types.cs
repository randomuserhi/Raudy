public partial class _9anime
{
    [Flags]
    public enum Category
    {
        Sub = 0b0001,
        Dub = 0b0010,

        All = Sub | Dub
    }

    public struct Response<T>
    {
        public int status { get; set; }
        public T result { get; set; }
        public string message { get; set; }
        public string[] messages { get; set; }
    }

    public struct WebpageSnippet
    {
        public string html { get; set; }
    }

    public struct AnimeInfo
    {
        public string link;
        public string enTitle;
        public string jpTitle;
        public string thumbnail;
    }

    public struct Anime
    {
        public string link;

        public string id;
        public string thumbnail;
        public string enTitle;
        public string jpTitle;
        public string[] alternativeTitles;
        public string description;
        
        // release date?
        // completed?
        // type: OVA, Special, Movie, TV ?
        // genres
    }

    public struct EpisodeList
    {
        public Anime anime;
        public Category category;
        public Episode[] episodes;
    }

    public struct Episode
    {
        public Anime anime;
        public Category category;
        public string enTitle;
        public string jpTitle;
        public string id;
        public string epNum;
        
        // release date?
    }

    public struct EncodedVideoEmbed
    {
        public string url { get; set; }
        public string skip_data { get; set; }
    }

    public struct Video
    {
        public enum Type
        {
            File
        }

        public Type type;
        public string url;
    }

    public struct Source
    {
        public Episode episode;
        public string name;
        public string id;
    }

    public struct SourceList
    {
        public Episode episode;
        public Source[] sources;
    }

    public struct VideoEmbed
    {
        public string url { get; set; }
        public Dictionary<string, int[]>? skip_data { get; set; }

        public Video? video;
    }

    public struct Filter
    {
        public string keyword;
    }

    public struct Query
    {
        public Filter filter;
        public AnimeInfo[] results;
    }
}
