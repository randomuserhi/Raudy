public partial class Aniwave {
    [Flags]
    public enum Category {
        None = 0,
        Sub = 0b0001,
        Dub = 0b0010,
        SSub = 0b0100, // Soft-Sub (subtitles included in video metadata)

        All = Sub | Dub | SSub
    }

    public struct Response<T> {
        public int status { get; set; }
        public T result { get; set; }
        public string message { get; set; }
        public string[] messages { get; set; }
    }

    public struct PackedString {
        public string value;
        public string meta;

        public PackedString(string value) {
            this.value = value;
            this.meta = "";
        }

        public PackedString(string value, string meta) {
            this.value = value;
            this.meta = meta;
        }

        public override string ToString() {
            return value;
        }
    }

    public struct WebpageSnippet {
        public string html { get; set; }
    }

    public struct AnimeInfo {
        public string link;
        public PackedString[] titles;
        public string thumbnail;
    }

    public struct Anime {
        public string link;

        public string id;
        public string thumbnail;
        public PackedString[] titles;
        public string description;
        public Category categories;

        // release date?
        // completed?
        // type: OVA, Special, Movie, TV ?
        // genres
        // duration?
    }

    public struct EpisodeList {
        public Anime anime;
        public Category category;
        public Episode[] episodes;
    }

    public struct Episode {
        public Anime anime;
        public Category category;
        public PackedString[] titles;
        public string id;
        public string epNum;

        // release date?
    }

    public struct EncodedVideoEmbed {
        public string url { get; set; }
        public string skip_data { get; set; }
    }

    public struct Video {
        public enum Type {
            File
        }

        public Type type;
        public string url;
    }

    public struct Source {
        public Episode episode;
        public string name;
        public string id;
    }

    public struct SourceList {
        public Episode episode;
        public Source[] sources;
    }

    public struct VideoEmbed {
        public string url { get; set; }
        public Dictionary<string, int[]>? skip_data { get; set; }

        public Video? video;
    }

    public struct Filter {
        public string keyword;
    }

    public struct Query {
        public Filter filter;
        public AnimeInfo[] results;
    }
}
