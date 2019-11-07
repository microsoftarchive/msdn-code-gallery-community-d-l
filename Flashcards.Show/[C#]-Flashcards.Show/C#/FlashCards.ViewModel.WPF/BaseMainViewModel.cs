
namespace FlashCards.ViewModel
{
    public class BaseMainViewModel : ViewModelBase
    {
        // these fields are declared as readonly instead of const in because they participate in binding
        public static readonly int MaxDeckSizeInMB = 5;

#if WINDOWS_PHONE
        public static readonly int MAX_CARDS = 4 * 4;
#else
        public static readonly int MAX_CARDS = 6 * 6;
#endif
        public static readonly double CardLoadingDelay = 50.0;
        public static readonly double CardMatchedDelay_MemoryGame = 1000.0;
        public static readonly double CardMatchedDelay_MatchingGame = 10;
        public static readonly double CardMatchFailedDelay_MemoryGame = 900.0;
        public static readonly double CardMatchFailedDelay_MatchingGame = 100.0;
        public static readonly double DeleteDelay = 200.0;

        public const string DecksFolder = "Decks";
        public const string ZippedDeckExtension = ".deckx";

        protected BaseMainViewModel()
        {
            SelectedZipPath = string.Empty;
            DeckTitle = string.Empty;
        }

        private ViewModelBase _currentView;

        public ViewModelBase CurrentView
        {
            get { return _currentView; }
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    RaisePropertyChanged(@string.of(() => CurrentView));
                }
            }
        }

        public DecksCollection Decks { get; set; }

        public string SelectedZipPath { get; set; }

        public string DeckTitle { get; set; }
    }
}
