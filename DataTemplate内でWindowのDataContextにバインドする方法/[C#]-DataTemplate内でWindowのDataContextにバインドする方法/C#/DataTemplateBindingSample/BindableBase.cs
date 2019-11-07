namespace DataTemplateBindingSample
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// INotifyPropertyChangedインターフェースのデフォルト実装
    /// </summary>
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var h = this.PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected bool SetProperty<T>(ref T store, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(store, value))
            {
                return false;
            }

            store = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
}
