// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                ZeusTranslations zeus = new ZeusTranslations();

                string[] urls = {
                    "https://zeustranslations.blogspot.com/2025/07/chapter-1-when-i-found-out-she-was-cheating.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-2-the-blues-of-a-cheated-man.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-3-her-younger-sister.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-4-the-ex-girlfriends-situation.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-5-want-to-go-on-a-date.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-6-on-the-train.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-7-before-the-yokohama-date.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-8-yokohama-date.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-9-the-ex-girlfriends-unease.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-10-i-dont-want-to-go-home-yet.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-11-harukis-plan.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-12-one-small-request-on-the-way-home.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-13-a-small-suggestion.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-14-the-ex-girlfriend-makes-a-call.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-15-cat-cafe.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-16-lets-eat-monjayaki.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-17-finding-an-idol.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-18-grasping-an-idol.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-19-the-ex-girlfriends-discord.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-20-karaoke-with-a-friend.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-21-a-new-part-time-job.html",
                    "https://zeustranslations.blogspot.com/2025/07/chapter-22-recruiting-a-private-tutor.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-23-even-if-its-called-tutoring.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-24-the-ex-girlfriends-tragedy-the-ntr-guys-thrill.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-25-a-nostalgic-photo.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-26-the-mother-of-two.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-27-university-friends.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-28-a-resolve-to-sever-ties.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-29-the-ntr-guys-crisis.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-30-double-date-plan.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-31-meeting-up-at-the-board-game-cafe.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-32-board-game-cafe-and-introductions.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-33-teaching-mahjong.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-34-the-ntr-guy-and-the-ex-girlfriends-downfall.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-35-akishima-kengorou.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-36-i-cant-bear-to-watch.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-37-because-you-were-beside-me.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-38-volunteer-circle.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-39-the-ex-girlfriends-lament.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-40-the-childrens-cafeteria.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-41-along-the-road-we-carry-together.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-42-with-the-children.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-43-this-is-the-decision.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-44-the-ex-girlfriends-loss.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-45-lets-play-at-the-park.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-46-lets-play-in-the-sand.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-47-enjoying-the-cafe.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-48-i-want-you.html",
                    "https://zeustranslations.blogspot.com/2025/08/chapter-49-the-ex-girlfriends-end.html",
                    "https://zeustranslations.blogspot.com/2025/09/chapter-50-report.html",
                    "https://zeustranslations.blogspot.com/2025/09/chapter-51-at-the-ayase-residence.html",
                    "https://zeustranslations.blogspot.com/2025/09/chapter-52-report-of-the-outcome.html",
                    "https://zeustranslations.blogspot.com/2025/09/chapter-53-if-something-happens-eat-sushi.html",
                    "https://zeustranslations.blogspot.com/2025/09/chapter-54-the-ex-girlfriends-closure.html",
                    "https://zeustranslations.blogspot.com/2025/09/chapter-55-after-my-girlfriend-was-stolen-from-me-for-some-reason-her-younger-sister-turned-into-a-gyaru-and-started-coming-on-to-me.html",
                    "https://zeustranslations.blogspot.com/2025/09/chapter-56-december-is-a-month-of-worry.html",
                    "https://zeustranslations.blogspot.com/2025/09/chapter-57-different-ways-of-thinking.html",
                    "https://zeustranslations.blogspot.com/2025/09/chapter-58-the-ntr-guys-pain.html",
                    "https://zeustranslations.blogspot.com/2025/09/chapter-59-talking-with-haruki.html",
                    "https://zeustranslations.blogspot.com/2025/09/chapter-60-there-are-dates-even-before-christmas.html",
                    "https://zeustranslations.blogspot.com/2025/09/chapter-61-warming-up-at-the-cafe.html",
                    "https://zeustranslations.blogspot.com/2025/09/chapter-62-coffee-jelly-and-firm-pudding.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-63-the-ntr-guys-fall.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-64-lets-go-to-the-shrine.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-65-a-story-about-drawing-a-love-fortune.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-66-on-the-way-back-from-the-shrine.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-67-the-ntr-guys-collapse.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-68-when-thinking-about-the-future.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-69-the-qualities-of-a-manager.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-70-what-the-future-is-for.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-71-what-it-is-she-wants-to-do.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-72-the-ntr-guys-ruin.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-73-greeting-my-biological-parents.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-74-back-to-my-family-home-after-a-long-time.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-75-lets-talk-about-how-it-started.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-76-family-distance.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-77-the-ntr-guys-lament.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-78-the-ntr-guys-fathers-ruin.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-79-becoming-a-family.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-80-the-three-of-us-as-a-family.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-81-back-again-to-the-childrens-cafeteria.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-82-chicken-steak-and-glasses.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-83-flirting-and-salad.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-84-the-ex-girlfriends-viewing.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-85-interview.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-86-the-two-who-exposed-themselves.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-87-the-children-and-the-tv-staff.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-88-the-ex-girlfriends-spectacle.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-89-christmas-eve-morning.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-90-the-party-begins-at-the-ayase-house.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-91-the-food-and-the-footage.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-92-cake-tastes-like-dreams-and-happiness.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-93-the-ex-girlfriends-arrogance-the-ntr-guys-rage.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-94-gift-exchange.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-95-christmas-eve-night.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-96-as-expected-its-the-detached-house.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-97-on-this-holy-night-with-you.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-98-the-afterglow-of-a-kiss.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-99-the-fate-of-the-ex-girlfriend-and-her-lover.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-100-the-ex-girlfriends-epilogue.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-101-the-ntr-guys-epilogue.html",
                    "https://zeustranslations.blogspot.com/2025/10/chapter-102-end-their-epilogue.html",
                };

                const int chapterPerVolume = 100;

                int skip = 0;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < urls.Length; ++i) {
                    var url = urls[i];

                    Console.WriteLine($"{url}");

                    if (i >= skip) {
                        await zeus.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] Girlfriend Sister Turned Gyaru\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
                    }

                    if ((++chapter) > chapterPerVolume) {
                        ++volume;
                        chapter = 1;
                    }

                    if (i >= skip) {
                        Thread.Sleep(5000); // Cloudflare rate limiting
                    }
                }

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}