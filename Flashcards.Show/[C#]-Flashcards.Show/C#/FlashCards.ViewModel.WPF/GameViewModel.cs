using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;
using System.Collections.ObjectModel;
using FlashCards.Commands;
using System.Windows.Input;
using System.Windows;

namespace FlashCards.ViewModel
{
    public abstract class GameViewModel : ViewModelBase
    {
        public GameViewModel(CardDeck SelectedDeck)
        {
            _selectedDeck = SelectedDeck;

           Quit = new DelegateCommand(() =>
           {
#if !SILVERLIGHT
               Application.Current.Shutdown();
#endif
           });

           Cancel = new DelegateCommand(() =>
           {
#if !WINDOWS_PHONE
               MainViewModel.Instance.CurrentView = MainViewModel.Instance.Decks;
#else
               Microsoft.Phone.Controls.PhoneApplicationFrame frame = Application.Current.RootVisual as Microsoft.Phone.Controls.PhoneApplicationFrame;
               frame.GoBack();
#endif

#if !SILVERLIGHT
               Taskbar.UpdateTaskBarStatus(0, SelectedDeck.Count / 2);
#endif
           });

           HelpCommand = new DelegateCommand(() =>
           {
#if !SILVERLIGHT
               MessageBox.Show((string)Application.Current.FindResource("Resource_MessageBox_ShowHelp"));
#endif
           });
        }

        public CardDeck SelectedDeck
        {
            get { return _selectedDeck; }
            set
            {
                if (value != _selectedDeck)
                {
                    _selectedDeck = value;
                    RaisePropertyChanged(@string.of(() => SelectedDeck));
                }
            }
        }

        #region Commands

        public ICommand Cancel { get; private set; }
        public ICommand Quit { get; private set; }
        public ICommand HelpCommand { get; private set; }

        #endregion

        private CardDeck _selectedDeck;
    }
}
