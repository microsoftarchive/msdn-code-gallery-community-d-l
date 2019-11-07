
namespace FlashCards.ViewModel
{
    public class ImageDecal : Decal
    {
        public ImageDecal()
        {
            MetaData = new ImageMetaData();
            MinSize = 50;
            Stretch = System.Windows.Media.Stretch.Uniform;
        }  
    }
}
