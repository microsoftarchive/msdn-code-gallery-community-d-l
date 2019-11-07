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
    public class LearningGameViewModel : GameViewModel
    {
        public LearningGameViewModel(CardDeck SelectedDeck):base(SelectedDeck)
        {
            GameName = (string)Application.Current.Resources["Resource_LearningGame"];

            if (SelectedDeck.Collection.Count > 0)
            {
                SelectedCardPair = SelectedDeck.Collection[0];
                Index = 0;
                if(SelectedDeck.Collection.Count == 1)
                    IsNextEnabled = false;
                else
                    IsNextEnabled = true;
                IsPrevEnabled = false;
            }

            PreviousCommand = new DelegateCommand(() =>
            {
                Index--;

                SelectedCardPair = SelectedDeck.Collection[_index];
            });

            NextCommand = new DelegateCommand(() =>
            {
                Index++;

                SelectedCardPair = SelectedDeck.Collection[_index];
            });

            ResetCards = new DelegateCommand(() =>
            {
                Index = 0;
                SelectedCardPair = SelectedDeck.Collection[_index];
            });
        }

        public CardPair SelectedCardPair
        {
            get { return _selectedCard; }
            set
            {
                if (value != _selectedCard)
                {
                    _selectedCard = value;
                    RaisePropertyChanged(@string.of(() => SelectedCardPair));
                }
            }
        }

        public bool IsNextEnabled
        {
            get { return _isNextEnabled; }
            set
            {
                if (value != _isNextEnabled)
                {
                    _isNextEnabled = value;
                    RaisePropertyChanged(@string.of(() => IsNextEnabled));
                }
            }
        }

        public bool IsPrevEnabled
        {
            get { return _isPrevEnabled; }
            set
            {
                if (value != _isPrevEnabled)
                {
                    _isPrevEnabled = value;
                    RaisePropertyChanged(@string.of(() => IsPrevEnabled));
                }
            }
        }

        public int Index
        {
            get { return _index; }
            set
            {
                if (value != _index)
                {
                    _index = value;

                    IsNextEnabled = true;
                    IsPrevEnabled = true;

                    if (_index <= 0)
                    {
                        _index = 0;
                        IsPrevEnabled = false;
                    }
                    if (_index >= SelectedDeck.Collection.Count-1)
                    {
                        _index = SelectedDeck.Collection.Count-1;
                        IsNextEnabled = false;
                    }

                    RaisePropertyChanged(@string.of(() => Index));
                }
            }
        }

        public string GameName { get; private set; }

        #region Commands

        public ICommand NextCommand { get; private set; }
        public ICommand PreviousCommand { get; private set; }
        public ICommand ResetCards { get; private set; }

        #endregion

        private int _index;
        private bool _isNextEnabled;
        private bool _isPrevEnabled;
        private CardPair _selectedCard;
    }
}
