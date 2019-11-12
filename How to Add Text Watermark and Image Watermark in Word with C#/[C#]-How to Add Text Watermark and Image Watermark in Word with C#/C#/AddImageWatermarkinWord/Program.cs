using Spire.Doc;


namespace AddImageWatermarkinWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document();
            document.LoadFromFile(@"E:\Visual Studio\Sample\How to Make a Cake.docx");

            PictureWatermark picture = new PictureWatermark();
            picture.Picture = System.Drawing.Image.FromFile(@"C:\Users\Administrator\Pictures\cake.jpg");
            picture.Scaling = 180;
            
            document.Watermark = picture;
            document.SaveToFile("result.docx");
        }
    }
}
