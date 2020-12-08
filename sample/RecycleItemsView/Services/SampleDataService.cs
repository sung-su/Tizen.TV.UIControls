using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RecycleItemsView.Models;
using Tizen.Uix.InputMethod;

namespace RecycleItemsView.Services
{
    public static class SampleDataService
    {
        public static IEnumerable<RecycleItem> SquareItems()
        {
            return new List<RecycleItem>()
            {
                new RecycleItem()
                {
                    Title = "Deep Into The Deep Sleep",
                    Details = "Miles Davis",
                    Extra = "Bacon ipsum dolor amet bresaola kevin tenderloin swine shoulder strip steak t-bone picanha turducken beef. Ribeye turkey t-bone pastrami meatball corned beef. Pork belly landjaeger short ribs ground round cupim, brisket ham tri-tip.",
                    Image = "Square/card_image_music_01.jpg"
                },
                new RecycleItem()
                {
                    Title = "We",
                    Details = "Miles Davis",
                    Extra = "Bacon ipsum dolor amet bresaola kevin tenderloin swine shoulder strip steak t-bone picanha turducken beef. Ribeye turkey t-bone pastrami meatball corned beef. Pork belly landjaeger short ribs ground round cupim, brisket ham tri-tip. Pig pork loin hamburger picanha ribeye, pork belly meatball chicken ham boudin sirloin corned beef frankfurter ham hock.",
                    Image = "Square/card_image_music_02.jpg"
                },
                new RecycleItem()
                {
                    Title = "The Fairy Story Of A Legend",
                    Details = "Miles Davis",
                    Extra = "Bacon ipsum dolor amet bresaola kevin tenderloin swine shoulder strip steak t-bone picanha turducken beef. Ribeye turkey t-bone pastrami meatball corned beef. Pork belly landjaeger short ribs ground round cupim, brisket ham tri-tip.",
                    Image = "Square/card_image_music_03.jpg"
                },
                new RecycleItem()
                {
                    Title = "Cursed",
                    Details = "Miles Davis",
                    Extra = "Bacon ipsum dolor amet bresaola kevin tenderloin swine shoulder strip steak t-bone picanha turducken beef. Ribeye turkey t-bone pastrami meatball corned beef. Pork belly landjaeger short ribs ground round cupim, brisket ham tri-tip.",
                    Image = "Square/card_image_music_04.jpg"
                },
                new RecycleItem()
                {
                    Title = "My Crazy One",
                    Details = "Miles Davis",
                    Extra = "Bacon ipsum dolor amet bresaola kevin tenderloin swine shoulder strip steak t-bone picanha turducken beef. Ribeye turkey t-bone pastrami meatball corned beef. Pork belly landjaeger short ribs ground round cupim, brisket ham tri-tip.",
                    Image = "Square/card_image_music_05.jpg"
                },
                new RecycleItem()
                {
                    Title = "Gone",
                    Details = "Miles Davis",
                    Extra = "Bacon ipsum dolor amet bresaola kevin tenderloin swine shoulder strip steak t-bone picanha turducken beef. Ribeye turkey t-bone pastrami meatball corned beef. Pork belly landjaeger short ribs ground round cupim, brisket ham tri-tip.",
                    Image = "Square/card_image_music_06.jpg"
                },
                new RecycleItem()
                {
                    Title = "A Cold Night To Stay",
                    Details = "Miles Davis",
                    Extra = "Bacon ipsum dolor amet bresaola kevin tenderloin swine shoulder strip steak t-bone picanha turducken beef. Ribeye turkey t-bone pastrami meatball corned beef. Pork belly landjaeger short ribs ground round cupim, brisket ham tri-tip.",
                    Image = "Square/card_image_music_07.jpg"
                },
                new RecycleItem()
                {
                    Title = "The Silence",
                    Details = "Miles Davis",
                    Extra = "Bacon ipsum dolor amet bresaola kevin tenderloin swine shoulder strip steak t-bone picanha turducken beef. Ribeye turkey t-bone pastrami meatball corned beef. Pork belly landjaeger short ribs ground round cupim, brisket ham tri-tip.",
                    Image = "Square/card_image_music_08.jpg"
                },
                new RecycleItem()
                {
                    Title = "Hear The Roar",
                    Details = "Miles Davis",
                    Extra = "Bacon ipsum dolor amet bresaola kevin tenderloin swine shoulder strip steak t-bone picanha turducken beef. Ribeye turkey t-bone pastrami meatball corned beef. Pork belly landjaeger short ribs ground round cupim, brisket ham tri-tip.",
                    Image = "Square/card_image_music_09.jpg"
                }
            };
        }

        public static IEnumerable<RecycleItem> SettingItems()
        {
            return new List<RecycleItem>()
            {
                new RecycleItem()
                {
                    Title = "Settings",
                    Image = "Icons/ic_settings_settings.png"
                },
                new RecycleItem()
                {
                    Title = "WiFi",
                    Image = "Icons/ic_settings_wifi_3_bar.png"
                },
                new RecycleItem()
                {
                    Title = "Contacts",
                    Image = "Icons/ic_settings_parental_control.png"
                },
                new RecycleItem()
                {
                    Title = "Time",
                    Image = "Icons/ic_settings_time.png"
                }
            };
        }

        public static IEnumerable<RecycleItem> WideItems()
        {
            return new List<RecycleItem>()
            {
                new RecycleItem()
                {
                    Title = "Crazy One",
                    Details = "Purchased",
                    Image = "Wide/game_crazy_one.jpg"
                },
                new RecycleItem()
                {
                    Title = "Cursed",
                    Details = "Purchased",
                    Image = "Wide/game_cursed"
                },
                new RecycleItem()
                {
                    Title = "fairy",
                    Details = "Purchased",
                    Image = "Wide/game_fairy"
                },
                new RecycleItem()
                {
                    Title = "Hear The Roar",
                    Details = "Purchased",
                    Image = "Wide/game_hear_the_roar",
                },
                new RecycleItem()
                {
                    Title = "Silence",
                    Details = "Purchased",
                    Image = "Wide/game_silence",
                }
            };
        }

        public static IEnumerable<RecycleItem> NarrowItems()
        {
            return new List<RecycleItem>()
            {
                new RecycleItem()
                {
                    Title = "Deep Into The Deep Sleep",
                    Details = "Miles Davis",
                    Image = "Narrow/card_image_movie_01.jpg"
                },
                new RecycleItem()
                {
                    Title = "We",
                    Details = "Miles Davis",
                    Image = "Narrow/card_image_movie_02.jpg"
                },
                new RecycleItem()
                {
                    Title = "The Fairy Story Of A Legend",
                    Details = "Miles Davis",
                    Image = "Narrow/card_image_movie_03.jpg"
                },
                new RecycleItem()
                {
                    Title = "Cursed",
                    Details = "Miles Davis",
                    Image = "Narrow/card_image_movie_04.jpg"
                },
                new RecycleItem()
                {
                    Title = "My Crazy One",
                    Details = "Miles Davis",
                    Image = "Narrow/card_image_movie_05.jpg"
                },
                new RecycleItem()
                {
                    Title = "Gone",
                    Details = "Miles Davis",
                    Image = "Narrow/card_image_movie_06.jpg"
                },
                new RecycleItem()
                {
                    Title = "A Cold Night To Stay",
                    Details = "Miles Davis",
                    Image = "Narrow/card_image_movie_07.jpg"
                },
                new RecycleItem()
                {
                    Title = "The Silence",
                    Details = "Miles Davis",
                    Image = "Narrow/card_image_movie_08.jpg"
                },
                new RecycleItem()
                {
                    Title = "Hear The Roar",
                    Details = "Miles Davis",
                    Image = "Narrow/card_image_movie_09.jpg"
                }
            };
        }
    }
}
