using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace wpf_ComboBoxColumn
{
    public class ColourVM  
    {
        public SolidColorBrush ColourBrush
        {
            get 
            { 
                return new SolidColorBrush(MColour.MediaColour); 
            }
        }

        public Colour MColour { get; set; }
        
    }
}
