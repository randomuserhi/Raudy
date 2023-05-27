public partial class _9anime
{
    interface ISource
    {
        public Task<Video?> GetMp4Link(VideoEmbed embed);
    }
}