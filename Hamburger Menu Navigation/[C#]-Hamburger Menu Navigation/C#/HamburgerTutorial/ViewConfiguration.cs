using HamburgerTutorial.Views;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace HamburgerTutorial
{ 

    public sealed partial class MainPage : Page
        {
            List<HamOption> hamOptions = new List<HamOption>
        {
            new HamOption() { Title = "Profile", IconFile ="/Assets/HamIcons/Profile.png", PageType = typeof(ProfileView) },
            new HamOption() { Title = "Blog Posts", IconFile ="/Assets/HamIcons/blog.png", PageType = typeof(BlogPostView) },
            new HamOption() { Title = "Stats", IconFile ="/Assets/HamIcons/stats.png" , PageType = typeof(StatsView) },
            new HamOption() { Title = "Settings", IconFile ="/Assets/HamIcons/settings.png", PageType = typeof(SettingsView) },

        };
        }

        public class HamOption
        {

            public string Title { get; set; }

            public Type PageType { get; set; }

            public string IconFile { get; set; }

           
        }

    }

