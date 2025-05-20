using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using CefSharp;
using CefSharp.OffScreen;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

public partial class DreamBigTL {
    private HtmlParser parser = new HtmlParser();
    private ChromiumWebBrowser browser = new ChromiumWebBrowser();

    public void Dispose() {
        browser.Dispose();
    }

    public DreamBigTL() {
        if (!Cef.IsInitialized.HasValue || !Cef.IsInitialized.Value) {
            var settings = new CefSettings();
            Cef.Initialize(settings);
        }
    }

    private class State {
        public string path;
        public StringBuilder epub = new StringBuilder();

        public State(string path) {
            this.path = path;
        }
    }

    public async Task temp() {
        string path = @"D:\Visual Novels\[Self-Sourced] [Ongoing] Extra C Childhood Friend\Raw\" + $"Volume {1}";
        string filename = $"{(103).ToString("D4")}.xhtml";

        State state = new State(path);
        state.epub.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><title></title><link href=\"../Styles/stylesheet.css\" type=\"text/css\" rel=\"stylesheet\" /></head><body>");

        string source = @"<div class=""fr-view article-body""><p>The Empire.</p><p>On this continent, there was only one nation called that.</p><p>It was the Holy Germanic Empire, located in the north of the continent.</p><p>In the distant past, it was a conquering nation that ruthlessly trampled on neighboring countries based on its overwhelming military power and resources, and many countries, including the Kingdom, were once under the Empire.</p><p>At that time, the Empire was literally on the verge of unifying the continent, but like all empires, its glory did not last long.</p><p>Due to internal strife over the position of emperor, the Empire was torn apart, and the once glorious Empire had become a nation that could no longer find its former status.</p><p>Of course, despite that, the fact that it still had enough national power to be called an empire was a testament to how powerful the empire of the past was.</p><p>""The Empire...""</p><p>Rudell muttered, looking at the changing scenery outside the window.</p><p>By the time the Empire appeared in the original story, it was already in ruins.</p><p>The Cult, hidden within the Empire, was rampant, causing destruction in various places, and even sacrificing an entire city.</p><p>The so-called 'City Devouring' also took place in the capital of the Empire.</p><p>In an instant, most of the high-ranking officials, including the imperial family, evaporated, and refugees who escaped from the completely collapsed Empire flocked to the Kingdom.</p><p>That was the end of the Empire in the original story.</p><p>""I never thought we'd end up going all the way to the Empire.""</p><p>""I know, you really never know what will happen in the world.""</p><p>Leje, who was also looking out the window, said that, and Rudell nodded.</p><p>The mission entrusted to Rudell and the party this time was to find Kendrick.</p><p>According to Jade, spies from the Kingdom who had infiltrated the Empire had reported that a man presumed to be Kendrick had been spotted in Penceburg, the capital of the Empire.</p><p>""B-but... I'm a-a little excited...! The E-Empire is famous for its Magical Engineering...!""</p><p>Unlike the two who seemed nervous, Silfier had a strangely expectant face.</p><p>This was because, unlike the Kingdom where magic was developed, the Empire had more advanced mechanical engineering.</p><p>For someone like her, who had the disposition of an engineer, the Empire was truly a paradise.</p><p>""Silfier... We're not going on a trip, you know?""</p><p>""Ah! Yes! I'm s-sorry...!!""</p><p>""Don't be too hard on her. If you're too nervous, you're more likely to make mistakes.""</p><p>Leje snapped at Silfier, who bowed her head in a hurry, and Rudell stopped her.</p><p>With a dissatisfied expression, Leje turned her head and narrowed her eyes.</p><p>""Honestly, you're too soft.""</p><p>""Isn't that why you like me?""</p><p>""That's really annoying.""</p><p>Leje turned her head away with a grumbling sound.</p><p>Rudell, who was looking at her, smiled faintly and lightly stroked her hair.</p><p>Perhaps she didn't dislike the gesture, as Leje silently accepted his touch.</p><p>Meanwhile...</p><p>""You two seem to be getting along well.""</p><p>""I-I guess so...""</p><p>""Hmm...""</p><p>The three who were watching the scene looked at the two with interest.</p><p>And then, finally, Leje, flinching and stopping her movements, brushed away Rudell's hand and turned her head away coyly.</p><p>""That's right, we've decided to go out.""</p><p>""Hey!!""</p><p>Rudell said, his mischievous side kicking in again, and Leje was startled and shouted at Rudell.</p><p>But...</p><p>""Hmm... You're quite late, considering.""</p><p>""I-I thought it would be a little sooner...""</p><p>""Hmm...""</p><p>The other three didn't seem all that surprised.</p><p>They weren't officially dating, but until now, Rudell and Leje's relationship was clearly not that of ordinary friends.</p><p>Unless they were fools, they would have noticed that fact.</p><p>Perhaps, as they said, it was actually too late.</p><p>""I-is that so...?""</p><p>""I can't believe you!""</p><p>""Ack!? Sorry! I was wrong! I was wrong!""</p><p>Rudell spoke in an awkward voice at the two's unexpected reaction, and Leje beat Rudell's back mercilessly.</p><p>As Rudell's screams erupted in the carriage...</p><p>""Guests, we'll be at the border soon.""</p><p>The voice of the coachman was heard from outside the carriage.</p><p>At those words, everyone in the carriage turned their heads to look out the window...</p><p>""The Empire is definitely different, starting with the terrain.""</p><p>""Are those... all mountains?""</p><p>""Oh, my...""</p><p>""It's certainly a different landscape from the Kingdom.""</p><p>Unlike the Kingdom, which was mostly flat, the landscape of the Empire was full of rugged mountain ranges.</p><p>The sight was reminiscent of his homeland in his first life, where 70% of the entire country was said to be mountainous.</p><p>""It would take more than a few days to cross all of that.""</p><p>The scenery alone was enough to make one dizzy.</p><p>However...</p><p>""Not necessarily.""</p><p>""What does that mean?""</p><p>Leje tilted her head at Rudell's subsequent words.</p><p>And at her words, Rudell smiled faintly and looked out the window.</p><p>""Look over there.""</p><p>""…?""</p><p>After a moment, Rudell, having discovered something, pointed out the window, and Leje and the rest of the group followed Rudell's fingertip with their eyes.</p><p>And what they saw was a huge ship, the size of a sailing ship, flying in the sky.</p><p>""Oh, my god!?""</p><p>""A s-ship is flying!?""</p><p>""Whoa...""</p><p>""...""</p><p>Everyone was speechless at the magnificent sight and stared at it.</p><p>Its identity was an airship.</p><p>It could be said that it was the driving force behind the Empire, where 70% of the land was mountainous, to manage its vast territory.</p><p>Magic, and engineering.</p><p>It was the existence that could be called the culmination of what is commonly called Magical Engineering.</p><p>""We'll take that to the capital, it'll probably take about two days.""</p><p>Since all expenses were supported by the Kingdom in the first place, there was no need for them to choose a method that would take a long time.</p><p>Above all, having come all the way to the Empire, wouldn't it be a shame to go back without riding an airship even once?</p><p>""It will definitely be an unforgettable sight.""</p><p>As everyone watched the scene with shining eyes.</p><p>Rudell said that with a faint smile.</p><p>* * *</p><p>The procedures at the Border Control Office went smoothly.</p><p>""What is the purpose of your visit to the Empire?""</p><p>""We're on vacation, traveling with friends. We heard that the capital of the Empire is very beautiful.""</p><p>""Indeed, the capital of the Empire can be said to be the best on the continent. Have a pleasant trip.""</p><p>With the employee's greeting as the last, Rudell finished the procedures and left the Border Control Office.</p><p>""Looks like everyone got through without any problems?""</p><p>Rudell said, finding the party waiting for him, having come out first.</p><p>Honestly, he thought that at least one person would get caught up in trouble, but surprisingly, no one seemed to have gotten into trouble.</p><p>""This is normal.""</p><p>""Yes, yes. Well done.""</p><p>Rudell let out a low chuckle as he watched Leje puff out her chest with an ""Ehem!"" sound.</p><p>""S-so, where should we go now...?""</p><p>""We need to go to the dock. We're leaving soon, so we might have to hurry...""</p><p>The remaining time was about ten minutes.</p><p>It was time to hurry to avoid missing the ship.</p><p>Rudell and his party crossed the dock, where many people were busily coming and going, and boarded the airship...</p><p>""Are you saying this huge thing really floats in the sky?""</p><p>""You can't believe it even after seeing it with your own eyes?""</p><p>Rudell asked Leje, who was looking down while sitting on the edge of the airship.</p><p>""But, it doesn't make sense. For such a huge ship to fly in the sky...""</p><p>""I don't think you're in a position to say that.""</p><p>If we were only talking about things that didn't make sense, Leje's physical abilities were already out.</p><p>""What's wrong with me!?""</p><p>""It's nothing.""</p><p>""Ugh! You, come here!""</p><p>""Ack! It hurts! It hurts!!""</p><p>Leje rushed towards Rudell and pulled his cheek, and Rudell was struggling, making a painful sound, when...</p><p>[This airship will soon be heading to Penceburg, the capital of the Empire. Passengers who have not yet boarded, please board quickly...]</p><p>An announcement was heard from a Magic Device installed on the airship, and soon, the four huge propellers located on both sides of the airship began to rotate, creating a gust of wind.</p><p>""Ugh!?""</p><p>""I'll hold you.""</p><p>Leje's long hair began to flutter in the wind.</p><p>Rudell reached out and held her hair to prevent it from fluttering.</p><p>""Th-thank you.""</p><p>""Don't mention it.""</p><p>As Rudell answered Leje's words, the airship had already finished taking off.</p><p>""Whoa...""</p><p>An exclamation escaped Leje's lips as she looked at the scene where everything seemed small below.</p><p>And at the same time, the bow of the airship slowly turned.</p><p>[This airship will soon be heading to Penceburg, the capital of the Empire. The estimated travel time is about two days, and please note that it may change depending on the weather conditions. Then, we wish you a pleasant journey.]</p><p>A somehow familiar announcement was heard...</p><p>And so, they began their voyage to Penceburg, the capital of the Empire.</p><hr><p style=""text-align: center""><a rel=""nofollow noreferrer"" href=""/post/Chapter-102-A-Parents-Heart-Z8Z219043L"">Previous Chapter</a> || <a rel=""nofollow noreferrer"" href=""https://www.dreambigtl.com/p/efwsh-extra-cs-childhood-friend-is.html"">TOC</a> || <a rel=""nofollow noreferrer"">Next Chapter</a></p> </div>";

        IHtmlDocument document = parser.ParseDocument(source);

        state.epub.AppendLine($"<h1>Chapter 103 - To the Empire</h1>");

        IElement body = document.QuerySelector(".fr-view.article-body");
        await Process(body, state);

        state.epub.AppendLine("</body></html>");
        File.WriteAllText(Path.Combine(path, "Text", filename), state.epub.ToString());
    }

    private static string[] validIdentifiers = new string[] { "p", "i", "b", "u", "em", "hr" };
    private static string[] ignoreIdentifiers = new string[] { "script" };
    private async Task Process(INode node, State state, bool inParagraph = false) {
        if (node.NodeType == NodeType.Element) {

            IElement el = (IElement)node;
            string identifier = $"{el.TagName.Trim().ToLower()}";

            if (ignoreIdentifiers.Contains(identifier)) return;
            if (el.GetAttribute("style") != null && el.GetAttribute("style").Contains("display: none;")) return;
            if (identifier != "hr" && el.TextContent.Trim() == string.Empty) return;

            bool isValid = validIdentifiers.Contains(identifier);
            if (identifier == "div") {
                // NOTE(randomuserhi): Special case where div should be a paragraph
                if (el.QuerySelectorAll("*:not(p):not(i):not(b):not(u):not(em)").Length == 0) {
                    isValid = true;
                    identifier = "p";
                }
            }

            bool isInParagraph = inParagraph || (identifier == "p");

            if (isValid) {
                if (!isInParagraph) state.epub.Append($"\n<p><{identifier}>");
                else state.epub.Append($"{(identifier == "p" ? "\n" : string.Empty)}<{identifier}>");
            }

            foreach (INode child in node.ChildNodes) {
                await Process(child, state, inParagraph || isValid);
            }

            if (isValid) {
                if (!isInParagraph) state.epub.Append($"</{identifier}></p>\n");
                else state.epub.Append($"</{identifier}>{(identifier == "p" ? "\n" : string.Empty)}");
            }

        } else if (node.NodeType == NodeType.Text) {
            string text = HttpUtility.HtmlEncode(node.TextContent);
            if (text == string.Empty) return;

            if (inParagraph) state.epub.Append($"{text}");
            else state.epub.Append($"<p>{text}</p>");
        }
    }

    // NOTE(randomuserhi): returns the link to the previous post
    //                     this is done because the site doesn't have an index of URLs...
    public async Task DownloadChapter(string url, string path, string filename) {
        string prevURL = string.Empty;

        try {
            State state = new State(path);
            state.epub.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><title></title><link href=\"../Styles/stylesheet.css\" type=\"text/css\" rel=\"stylesheet\" /></head><body>");

            await browser.LoadUrlAsync(url);
            await browser.WaitForInitialLoadAsync();
            string source = await browser.GetSourceAsync();

            IHtmlDocument document = parser.ParseDocument(source);

            IElement title = document.QuerySelector(".entry-title");
            state.epub.AppendLine($"<h1>{title.InnerHtml.Trim()}</h1>");
            state.epub.AppendLine($"<p><a href=\"{url}\">Original</a></p>");

            IElement body = document.QuerySelector(".post-body.entry-content");
            await Process(body, state);

            state.epub.AppendLine("</body></html>");
            File.WriteAllText(Path.Combine(path, "Text", filename), state.epub.ToString());
        } catch (Exception exception) {
            Console.WriteLine($"Error trying to obtain chapter: {url}");
            Console.WriteLine(exception);
        }
    }
}
