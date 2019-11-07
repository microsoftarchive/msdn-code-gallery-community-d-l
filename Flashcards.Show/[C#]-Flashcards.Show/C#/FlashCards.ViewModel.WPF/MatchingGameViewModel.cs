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
using System.Windows.Threading;

namespace FlashCards.ViewModel
{
    public class MatchingGameViewModel : GameViewModel
    {
        public MatchingGameViewModel(CardDeck selectedDeck, bool isMatchingGame, bool shuffleCards)
            : base(selectedDeck)
        {
            IsMatchingGame = isMatchingGame;

            if (IsMatchingGame)
                GameName = (string)Application.Current.Resources["Resource_MatchingGame"];
            else
                GameName = (string)Application.Current.Resources["Resource_MemoryGame"];

            CardPairs = new ObservableCollection<CardPair>();

            ResetCards = new DelegateCommand(() =>
            {
                IsFinished = false;
                RaisePropertyChanged(@string.of(() => IsFinished));
                ShuffleCards();
            }, () => { return SelectedDeck.Collection.Count > 0; });

            if (shuffleCards)
            {
                IsBusy = true;
                DispatcherTimer _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromSeconds(0);

                _timer.Tick += new EventHandler(delegate(object s, EventArgs ev)
                {
                    ShuffleCards();
                    IsBusy = false;
                    _timer.Stop();
                });

                _timer.Start();
            }
        }

        public MatchingGameViewModel(CardDeck selectedDeck, bool isMatchingGame)
            : this(selectedDeck, isMatchingGame, true)
        {
        }

#if WINDOWS_PHONE
        public MatchingGameViewModel(CardDeck selectedDeck, bool isMatchingGame, int[] cardsOrder, bool[] cardsUseDuplicate, bool[] cardsIsMatched, bool[] cardsIsSelected)
            : this(selectedDeck, isMatchingGame, false)
        {
            // add card pair according to original cards order
            for (int i = 0; i < cardsOrder.Length; ++i)
            {
                CardPair cardPair = selectedDeck.Collection[cardsOrder[i]];
                if (cardsUseDuplicate[i])
                {
                    cardPair = cardPair.Duplicate();
                }

                cardPair.IsMatchingGame = isMatchingGame;
                cardPair.IsMatched = cardsIsMatched[i];
                cardPair.IsLoaded = true;
                //cardPair.IsSelected = cardsIsSelected[i];
                cardPair.SelectionChanged += new EventHandler(card_SelectionChanged);
                
                CardPairs.Add(cardPair);
            }

            SetRowsAndColumns();

            Matches = cardsIsMatched.Count(isMatched => isMatched) / 2;
        }

        public void GetGameState(out int[] cardsOrder, out bool[] cardsIsDuplicate, out bool[] cardsIsMatched, out bool[] cardsIsSelected)
        {
            cardsOrder = new int[CardPairs.Count];
            cardsIsDuplicate = new bool[CardPairs.Count];
            cardsIsMatched = new bool[CardPairs.Count];
            cardsIsSelected = new bool[CardPairs.Count];

            for (int i = 0; i < cardsOrder.Length; ++i)
            {
                cardsOrder[i] = SelectedDeck.Collection.IndexOf(CardPairs[i]);
                if (cardsOrder[i] == -1)
                {
                    cardsOrder[i] = SelectedDeck.Collection.IndexOf(CardPairs[i].OriginalCardPair);
                    cardsIsDuplicate[i] = true;
                }
                else
                {
                    cardsIsDuplicate[i] = false;
                }
                cardsIsMatched[i] = CardPairs[i].IsMatched;
                cardsIsSelected[i] = CardPairs[i].IsSelected;
            }
        }

#endif

        #region IsBusy

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    RaisePropertyChanged(@string.of(() => IsBusy));
                }
            }
        }

        #endregion

        private void SetRowsAndColumns()
        {
            _countTotal = SelectedDeck.Count;

            if (_countTotal > MainViewModel.MAX_CARDS)
            {
                _countTotal = MainViewModel.MAX_CARDS;
            }

            if (_countTotal > 1)
            {
                double column = Math.Ceiling(Math.Sqrt(1.0 * _countTotal));

                Rows = (int)Math.Ceiling(_countTotal * 1.0 / column);
                Columns = (int)column;
            }
        }

        private void ShuffleCards()
        {
            SetRowsAndColumns();

#if !SILVERLIGHT
            Taskbar.UpdateTaskBarStatus(0, SelectedDeck.Count / 2);
#endif

            List<CardPair> cardpairs = Randomize<CardPair>(SelectedDeck.Collection.ToList()).Take(_countTotal / 2).ToList();

            foreach (CardPair card in CardPairs)
            {
                card.SelectionChanged -= new EventHandler(card_SelectionChanged);
            }

            CardPairs.Clear();
            
            Matches = 0;

            SlowCollectionAdd(cardpairs);
        }

        private void SlowCollectionAdd(List<CardPair> cardpairs)
        {
            List<CardPair> temp = new List<CardPair>();


            foreach (CardPair cpair in cardpairs)
            {
                cpair.IsSelected = false;

                CardPair dup = cpair.Duplicate();

                if (IsMatchingGame)
                {
                    dup.IsMatchingGame = true;
                    cpair.IsMatchingGame = true;
                }
                else
                {
                    dup.IsMatchingGame = false;
                    cpair.IsMatchingGame = false;
                }

                cpair.IsLoaded = false;
                dup.IsLoaded = false;
                cpair.IsMatched = false;
                dup.IsMatched = false;

                temp.Add(cpair);
                temp.Add(dup);
            }

            cardpairs = Randomize<CardPair>(temp);
            List<int> indexCollection = new List<int>(); int i = 0;

            foreach (CardPair cp in cardpairs)
            {
                CardPairs.Add(cp);
                cp.SelectionChanged += new EventHandler(card_SelectionChanged);
                indexCollection.Add(i++);
            }

            //Randomize the IndexCollection
            indexCollection =  Randomize<int>(indexCollection);

            DispatcherTimer _timer = new DispatcherTimer();

            _timer.Interval = TimeSpan.FromMilliseconds(MainViewModel.CardLoadingDelay); //Just waiting to Sync any animation in the View

            _timer.Tick += new EventHandler(delegate(object s, EventArgs ev)
            {
                int index = indexCollection.Count - 1;

                if (index == -1)
                    _timer.Stop();
                else
                {
                    CardPairs[indexCollection[index]].IsLoaded = true;
                    indexCollection.RemoveAt(index);
                }
                
            });

            _timer.Start();
           
        }

        void card_SelectionChanged(object sender, EventArgs e)
        {
            CardPair pair = sender as CardPair;

            if (pair == match)
            {
                pair.IsSelected = false;
                match = null;
            }

            if (pair.IsSelected)
            {

                if (match != null)
                {
                    //Check for proper Match
                    if (pair.Card1 == match.Card2) //Match success
                    {
                        DispatcherTimer _timer = new DispatcherTimer();
                        double delay = IsMatchingGame ? MainViewModel.CardMatchedDelay_MatchingGame : MainViewModel.CardMatchedDelay_MemoryGame;
                        _timer.Interval = TimeSpan.FromMilliseconds(delay); //Just waiting to Sync any animation in the View

                        List<CardPair> pairs = new List<CardPair>() { match, pair };
                        _timer.Tick += new EventHandler(delegate(object s, EventArgs ev)
                        {
                            pairs[0].IsMatched = true;
                            pairs[1].IsMatched = true;
                            Matches++;
                            _timer.Stop();
                        });
                         
                        _timer.Start();


                    }
                    else //Not matched
                    {
                        //This Timer is to Show the wrong cards little more time in the view
                        DispatcherTimer _timer = new DispatcherTimer();

                        double delay = IsMatchingGame ? MainViewModel.CardMatchFailedDelay_MatchingGame : MainViewModel.CardMatchFailedDelay_MemoryGame;

                        _timer.Interval = TimeSpan.FromMilliseconds(delay); //Just waiting to Sync any animation in the View
                        
                        List<CardPair> pairs = new List<CardPair>() { match, pair };
                        _timer.Tick += new EventHandler(delegate(object s, EventArgs ev)
                        {
                            pairs[0].IsSelected = false;
                            pairs[1].IsSelected = false;

                            _timer.Stop();
                        });

                        _timer.Start();

                    }

                    match = null;
                }
                else //First card opened
                {
                    match = pair;
                }

            }

        }

        public static List<T> Randomize<T>(List<T> list)
        {
            List<T> randomizedList = new List<T>();
            Random rnd = new Random();
            while (list.Count > 0)
            {
                int index = rnd.Next(0, list.Count); 
                randomizedList.Add(list[index]);
                list.RemoveAt(index);
            }
            return randomizedList;
        }

        public bool IsFinished { get; private set; }

        public int Rows
        {
            get
            {
                return _rows;
            }
            set
            {
                if (_rows != value)
                {
                    _rows = value;
                    RaisePropertyChanged(@string.of(() => Rows));
                }
            }
        }

        public int Columns
        {
            get
            {
                return _columns;
            }
            set
            {
                if (_columns != value)
                {
                    _columns = value;
                    RaisePropertyChanged(@string.of(() => Columns));
                }
            }
        }

        public int Matches
        {
            get
            {
                return _matches;
            }
            set
            {
                if (_matches != value)
                {
                    _matches = value;
                    RaisePropertyChanged(@string.of(() => Matches));
#if !SILVERLIGHT
                    Taskbar.UpdateTaskBarStatus(_matches, SelectedDeck.Count / 2);
#endif
                    if (_matches == _countTotal / 2)
                        OnGameFinished();
                }
            }
        }

        private void OnGameFinished()
        {
            IsFinished = true;
            RaisePropertyChanged(@string.of(() => IsFinished));
            IsFinished = false;
            
#if !SILVERLIGHT
            Taskbar.UpdateTaskBarStatus(1, 1);
#endif
        }
        
        public ObservableCollection<CardPair> CardPairs { get; private set; }

        public bool IsMatchingGame { get; private set; }

        public string GameName { get; private set; }

        #region Commands
        
        public ICommand ResetCards { get; private set; }
        #endregion

        private int _countTotal;
        private int _matches;
        private int _rows;
        private int _columns;

        private CardPair match;
    }
}
