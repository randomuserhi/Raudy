public partial class Aniwave
{
    public interface ISource // TODO(randomuserhi): Change to private
    {
        public Task<Video?> GetMp4Link(VideoEmbed embed);
        public Task DownloadVideo(string url, string fileName); // TODO(randomuserhi): Change
    }
}