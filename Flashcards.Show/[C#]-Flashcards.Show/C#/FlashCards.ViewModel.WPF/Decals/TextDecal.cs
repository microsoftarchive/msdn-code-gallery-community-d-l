
namespace FlashCards.ViewModel
{
    public class TextDecal : Decal
    {
        public TextDecal()
        {
            MetaData = new TextMetaData() { Source = "Type here.."};
            Stretch = System.Windows.Media.Stretch.Uniform;
            Size = 0.5;
        }
    }
}
