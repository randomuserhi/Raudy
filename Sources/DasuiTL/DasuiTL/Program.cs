// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                DasuiTL dasui = new DasuiTL();

                string[] urls = {
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-1-you-should-ask-my-brother-that/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-2-because-yuito-has-a-lot-of-good-qualities-that-ayato-doesnt-have/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-3-yeah-and-i-erased-that-girls-contact-information-as-well-just-for-the-heck-of-it/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-4-hmm-so-thats-how-yuito-thought-of-me/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-5-hmm-maybe-to-prevent-other-girls-from-coming-to-yuito/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-6-yeah-yuito-wont-get-in-touch-with-suzuno-chan-anymore/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-7-hey-isnt-it-kind-of-exciting-when-a-man-and-a-woman-are-alone-in-a-closed-room/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-8-so-let-me-be-clear-i-have-no-intention-of-dating-ayato/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-9-yeah-in-that-case-its-okay-because-you-already-have-permission/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-10-as-yuito-knows-its-really-hard-to-be-popular/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-11-yeah-its-a-hotel-with-a-love-sign-so-theres-plenty-of-room-even-on-that-very-day/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-12-what-are-you-saying-youre-going-with-me-yuito/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-13-im-planning-on-having-yuito-wash-everything-including-my-breasts-and-that-part-okay/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-14-yuito-youre-quite-bold-despite-your-appearance/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-15-but-im-definitely-going-to-make-him-mine-no-matter-what-it-takes/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-16-ive-caught-you-im-not-letting-you-go-tonight/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-17-i-wanted-to-make-a-strong-connection-that-would-never-be-broken-no-matter-what/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-18-hmm-should-i-call-you-my-boyfriend/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-19-ah-and-by-relationship-i-of-course-mean-the-kind-where-a-man-and-a-woman-develop-love/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-20-i-meant-what-i-said-earlier-about-making-a-move-on-yuito/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-21-dont-underestimate-me-im-the-best-when-it-comes-to-self-protection/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-22-im-yuitos-girlfriend-yuuki-kano-nice-to-meet-you-everyone/",
                    "https://dasuitl.com/uncategorized/episode-23-besides-it-wouldnt-be-a-good-idea-to-interfere-with-suzuno-chan-and-ayatos-date/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-24-yuito-are-you-perhaps-excited-when-i-said-youre-a-virgin/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-25-of-course-who-do-you-think-i-am/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-26-by-the-way-have-suzuno-chan-and-ayato-done-it/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-27-well-then-i-guess-i-should-take-off-your-pants-and-underwear/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-28-even-though-yuito/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-29-wait-for-me-yuito-and-i-will-definitely-make-you-mine-both-body-and-soul/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-30-but-yuitos-mental-strength-is-far-greater/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-31-do-you-need-a-reason-to-voice-call-someone-you-like/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-32-if-it-were-my-sister-this-would-never-happen/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-33-hmm-so-yuito-tried-to-lie-to-me/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-34-dont-we-look-like-a-couple-to-those-people/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-35-but-i-want-you-to-remember-that-there-are-people-who-will-be-sad-because-of-that/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-36-if-you-have-any-trouble-in-the-future-i-will-help-you/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-37-i-see-yuito-was-trying-to-help-me/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-38-then-how-about-i-make-you-lose-your-virginity/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-39-it-was-really-hard-for-me-because-yuito-was-so-intense-that-various-parts-of-me-became-sticky/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-40-but-in-the-future-the-person-who-will-be-beside-yuito-is-not-suzuno-chan-but-me/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-41-dont-we-look-like-a-couple-or-a-married-couple-now/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-42-if-that-happens-it-would-probably-be-difficult-for-the-two-of-them-to-keep-dating/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-43-dont-tell-me-youre-flirting-with-another-woman-even-though-im-here/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-44-perhaps-yuito-is-a-pervert-who-gets-excited-by-touching-my-swimsuit/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-45-geez-dont-tell-the-whole-story-so-quickly/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-46-sorry-sorry-would-you-like-to-touch-my-breasts-as-an-apology/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-47-im-not-ashamed-to-show-every-inch-of-my-naked-body-to-yuito-whom-i-love/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-48-oh-and-dont-get-so-horny-that-you-try-to-undo-my-top/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-49-theres-no-way-that-my-first-kiss-and-yuitos-first-kiss-are-worth-the-same-so-its-not-an-equivalent-exchange/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-50-even-though-the-older-sister-of-the-yuuki-sisters-confessed-to-him-he-says-he-likes-the-younger-sister-is-yuito-a-main-character-of-a-light-novel/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-51-speaking-of-which-didnt-you-have-something-to-tell-me-yuito/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-52-i-feel-bad-for-suzuno-chan-and-ayato-but-we-will-win/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-53-heh-so-yuito-is-flirting-with-suzuno-chan-while-leaving-me-alone/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-54-ah-maybe-yuito-seriously-wanted-to-marry-me/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-55-eh-by-big-you-mean-this/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-56-yeah-it-would-be-sad-if-i-confiscated-everything-so-ill-specially-forgive-for-this-one/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-57-because-you-know-yuito-seems-happy-to-be-bullied-by-me/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-58-eh-its-just-getting-exciting-so-lets-continue-for-a-little-while/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-59-oh-is-it-possible-that-yuito-is-already-planning-to-marry-me/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-60-ah-im-a-little-hurt-by-that-reaction/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-61-yuito-said-it-looks-good-on-me-so-theres-no-need-to-hesitate/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-62-so-even-if-we-get-married-lets-make-sure-we-dont-fall-like-orihime-and-hikoboshi/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-63-since-yuito-and-i-are-now-classmates-honorifics-are-prohibited/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-64-then-from-now-on-you-can-call-me-by-my-first-name/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-65-do-you-really-want-to-spend-your-college-life-with-me-that-badly/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-66-damn-i-also-wanted-a-beautiful-step-sister-fiancee/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-67-does-kano-san-really-like-yuito/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-68-i-wish-i-was-in-yuitos-place/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-69-i-wish-you-would-answer-more-happily-since-its-your-beloved-sister-calling/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-70-wow-its-definitely-me/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-71-are-you-perhaps-proposing-in-a-roundabout-way/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-72-its-not-like-were-going-to-kiss-or-anything-right-now-so-its-fine/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-73-come-to-think-of-it-there-was-still-punishment-left-for-yuito-right/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-74-eh-im-just-moving-moving-my-hand-as-hard-as-i-could-while-thinking-about-yuito/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-75-nice-to-meet-you-my-name-is-yuuki-kano-im-yuitos-fiancee/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-76-eh-youre-crying-face-is-so-cute-i-wanna-take-a-look-closer/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-77-hmm-i-personally-thought-it-was-light/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-78-yeah-thats-why-after-i-make-yuitos-body-and-mind-mine-ill-behave-quietly/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-79-ah-maybe-you-take-in-as-a-sexual-way/",
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-80-so-how-about-we-kiss-more-intensely-from-now-on/",
                };

                const int chapterPerVolume = 100;

                int skip = 0;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < urls.Length; ++i) {
                    var url = urls[i];

                    Console.WriteLine($"{url}");

                    if (i >= skip) {
                        await dasui.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Incomplete] Apparently My Childhood Friend is a Yandere\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
                    }

                    if ((++chapter) > chapterPerVolume) {
                        ++volume;
                        chapter = 1;
                    }

                    if (i >= skip) {
                        Thread.Sleep(1000); // Cloudflare rate limiting
                    }
                }

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}