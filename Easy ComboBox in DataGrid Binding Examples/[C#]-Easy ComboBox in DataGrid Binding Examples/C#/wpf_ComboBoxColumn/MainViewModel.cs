using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows;
using System.Diagnostics;
namespace wpf_ComboBoxColumn
{
    public class MainViewModel : NotifyUIBase
    {
        public ObservableCollection<ColourVM> Colours { get; set; }
        public ObservableCollection<Media> Medias { get; set; }

        public MainViewModel()
        {
            Colours = new ObservableCollection<ColourVM>
            {
                new ColourVM{ MColour = new Colour{Id = 1, MediaColour=Colors.Yellow, ColourString="Yellow"}},
                new ColourVM{ MColour = new Colour{Id = 2, MediaColour=Colors.Blue, ColourString="Blue"}},
                new ColourVM{ MColour = new Colour{Id = 3, MediaColour=Colors.Red, ColourString="Red"}},
                new ColourVM{ MColour = new Colour{Id = 4, MediaColour=Colors.Green, ColourString="Green"}},
                new ColourVM{ MColour = new Colour{Id = 5, MediaColour=Colors.Purple, ColourString="Purple"}}
            };

            ColourCollection cc = Application.Current.Resources["ColourSource"] as ColourCollection;
            cc.Add(new SimpleColour { ColourString = "Yellow", Id = 1 });
            cc.Add(new SimpleColour { ColourString = "Blue", Id = 2 });
            cc.Add(new SimpleColour { ColourString = "Red", Id = 3 });
            cc.Add(new SimpleColour { ColourString = "Green", Id = 4 });
            cc.Add( new SimpleColour{ColourString="Purple", Id=5});
            Application.Current.Resources["ColourSource"] = cc;

            Medias = new ObservableCollection<Media>
            {
                new Media{ ColourId=4, Container="Bottle", MediaType="Acrylic Paint", Volume=59},
                new Media{ ColourId=1, Container="Tube", MediaType="Oil Paint", Volume=24},
                new Media{ ColourId=3, Container="Bottle", MediaType="Acrylic Paint", Volume=59},
                new Media{ ColourId=2, Container="Tube", MediaType="Oil Paint", Volume=24},  
                new Media{ ColourId=5, Container="Bottle", MediaType="Acrylic Paint", Volume=59}      
            };
            RaisePropertyChanged("Colours");
            RaisePropertyChanged("Medias");

        }
    }
}
