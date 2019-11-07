using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using FlashCards.Commands;
#if !SILVERLIGHT
using Microsoft.WindowsAPICodePack.Dialogs;
#endif

namespace FlashCards.ViewModel
{
    public class CardPair : ViewModelBase
    {
        protected override void OnInitialize()
        {
            _activeCard = _card1;
            _card1.Initialize();
            _card2.Initialize();


#if !SILVERLIGHT
            SetCover = new DelegateCommand(() =>
            {
             //   ParentDeck.SetCover(this);
            });

            DeletePair = new DelegateCommand(() =>
            {
                TaskDialog dlg = new TaskDialog()
                {
                    Caption = (string)Application.Current.FindResource("Resource_MessageBox_DeletePairCaption"),
                    Text = (string)Application.Current.FindResource("Resource_MessageBox_DeletePairText"),
                    Icon = TaskDialogStandardIcon.Warning,
                    Cancelable = true,
                    StandardButtons = TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No
                };

                if (dlg.Show() == TaskDialogResult.Yes)
                {
                    if (ParentDeck.SelectedCardPair == this)
                        ParentDeck.SelectedCardPair = null;
                    this.IsDeleted = true;
                    ParentDeck.IsDirty = true;
                }
            });
#endif

        }

        internal void DeActivate()
        {
            _card1.IsActive = false;
            _card2.IsActive = false;
        }

        public CardPair Duplicate()
        {
            return new CardPair() { Card1 = Card2 , Card2 = Card1 , ParentDeck = ParentDeck, OriginalCardPair = this };
        }
        
        public Card Card1 
        { 
            get
            {
                return _card1;
            }
            set
            {
                _card1 = value;
                _card1.ParentCardPair = this;
                RaisePropertyChanged(@string.of(() => Card1));
            }
        }

        public Card Card2
        {
            get
            {
                return _card2;
            }
            set
            {
                _card2 = value;
                _card2.ParentCardPair = this;
                RaisePropertyChanged(@string.of(() => Card2));
            }
        }

        [XmlIgnore]
        public CardDeck ParentDeck { get; set; }

        [XmlIgnore]
        public bool IsInEdit { get; set; }

        [XmlIgnore]
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;

                    RaisePropertyChanged(@string.of(() => IsSelected));
                    
                    if (SelectionChanged != null)
                    {
                        SelectionChanged(this, null);
                    }
                }
            }
        }
        
        [XmlIgnore]
        public bool IsMatched
        {
            get
            {
                return _isMatched;
            }
            set
            {
                if (_isMatched != value)
                {
                    _isMatched = value;
                    RaisePropertyChanged(@string.of(() => IsMatched));

                }
            }
        }  
        
        [XmlIgnore]
        public bool IsLoaded
        {
            get
            {
                return _isLoaded;
            }
            set
            {
                if (_isLoaded != value)
                {
                    _isLoaded = value;
                    RaisePropertyChanged(@string.of(() => IsLoaded));
                }
            }
        }

        [XmlIgnore]
        public bool IsDeleted
        {
            get
            {
                return _isDeleted;
            }
            set
            {
                if (_isDeleted != value)
                {
                   _isDeleted = value;
                    RaisePropertyChanged(@string.of(() => IsDeleted));
                }
            }
        }

        [XmlIgnore]
        public CardPair OriginalCardPair { get; set; }

        public event EventHandler SelectionChanged;

        [XmlIgnore]
        public bool IsMatchingGame { get; set; }

        [XmlIgnore]
        public Card ActiveCard
        {
            get
            {
                return _activeCard;
            }
            set
            {
                if (_activeCard != value)
                {
                    _activeCard.DeSelectAll();

                    _activeCard.IsActive = false;
                    
                    _activeCard = value;
                    _activeCard.IsActive = true;
                    RaisePropertyChanged(@string.of(() => ActiveCard));
                }
            }
        }

        #region Commands

        [XmlIgnore]
        public ICommand SetCover { get; private set; }

        [XmlIgnore]
        public ICommand DeletePair { get; private set; }
        
        #endregion

        private Card _card1;
        private Card _card2;
        private bool _isSelected;
        private bool _isMatched;
        private bool _isDeleted;
        private bool _isLoaded;
        private Card _activeCard;
    }
}
