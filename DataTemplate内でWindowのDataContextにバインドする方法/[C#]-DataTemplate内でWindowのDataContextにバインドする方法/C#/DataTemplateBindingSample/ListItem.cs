namespace DataTemplateBindingSample
{
    /// <summary>
    /// DataTemplateに表示するデータを保持するクラス
    /// </summary>
    public class ListItem : BindableBase
    {
        private string text;

        public string Text
        {
            get { return this.text; }
            set { this.SetProperty(ref this.text, value); }
        }
    }
}
