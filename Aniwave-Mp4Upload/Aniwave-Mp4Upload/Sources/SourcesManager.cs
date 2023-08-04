public partial class Aniwave
{
    interface ISource
    {
        public Task<Video?> GetMp4Link(VideoEmbed embed);
    }
}