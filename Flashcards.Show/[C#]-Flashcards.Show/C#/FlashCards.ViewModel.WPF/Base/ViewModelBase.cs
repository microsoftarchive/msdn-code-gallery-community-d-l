using System.ComponentModel;

namespace FlashCards.ViewModel
{
    /// <summary>
    /// Provides common functionality for ViewModel classes
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Initialize()
        {
            OnInitialize();
        }

        internal void UnInitialize()
        {
            OnUnInitialize();
        }

        protected virtual void OnInitialize()
        {
        }
        
        protected virtual void OnUnInitialize()
        {
        }
    }
}
