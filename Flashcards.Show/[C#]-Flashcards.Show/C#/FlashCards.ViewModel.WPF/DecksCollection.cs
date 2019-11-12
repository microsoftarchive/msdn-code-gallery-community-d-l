using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FlashCards.Commands;
using System.Windows;

namespace FlashCards.ViewModel
{
    public class DecksCollection : ViewModelBase
    {
        public DecksCollection()
        {
            _decks = new ObservableCollection<CardDeck>();

            CreateNewDeck = new DelegateCommand(() =>
            {
                SelectedDeck = new CardDeck() { Title = Title };
                SelectedDeck.CreateNewCardPair.Execute(null);
                MainViewModel.Instance.CurrentView = SelectedDeck;
                Title = "";
                IsNew = false;
            }, 
            () =>
            {
                return !string.IsNullOrEmpty(Title);
            });
        }

        public CardDeck SelectedDeck
        {
            get { return _selectedDeck; }
            set 
            {
                if (_selectedDeck != value)
                {
                    if (_selectedDeck != null)
                    {
                        _selectedDeck.IsSelected = false;
                    }
                    
                    _selectedDeck = value;
                    RaisePropertyChanged(@string.of(() => SelectedDeck));

                    if (_selectedDeck != null)
                    {
                        _selectedDeck.IsSelected = true;
                    }
                    
                }
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;

                RaisePropertyChanged(@string.of(() => Title));
            }
        }

        public bool IsNew { get; set; }

        public ObservableCollection<CardDeck> Collection
        {
            get
            {
                return _decks;
            }
        }

        private bool _hasDeckFile;
        public bool HasDeckFile
        {
            get
            {
                return _hasDeckFile;
            }
            set
            {
                _hasDeckFile = value;
                RaisePropertyChanged(@string.of(() => HasDeckFile));
            }
        }

        public ICommand CreateNewDeck { get; private set; }

        private ObservableCollection<CardDeck> _decks;
        private CardDeck _selectedDeck;
        private string _title;
    }
}
