using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlashCards.Commands;
using System.Xml.Serialization;
using System.Windows.Input;
using System.Windows;
using System.Timers;
using System.Windows.Threading;
using System.ServiceModel;
using System.IO;
using System.ComponentModel;
using System.Reflection;

using FlashCardsService.Contracts;

namespace FlashCards.ViewModel
{
    public class ShareViewModel : ViewModelBase
    {
        private bool _isCanceled = false;

        public ShareViewModel(CardDeck cardDeck)
        {
            CardDeck = cardDeck;

            SenderName = Environment.UserName.ToLower();

            ShareDeck = new DelegateCommand(() =>
                {
                    IsBusy = true;
                    WaitIndicatorText = (string)Application.Current.FindResource("Resource_ShareDialog_UploadingDeck");

                    string password = null;

                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += (s, e) =>
                        {
                            // start upload to azure
                            IFlashCardService prox = null;

                            try
                            {
                                ChannelFactory<IFlashCardService> chf;
                                chf = new ChannelFactory<IFlashCardService>("FlashCardEP");

                                prox = chf.CreateChannel();
                                
                                // increase uploading timeout to 5 minutes
                                (prox as IContextChannel).OperationTimeout = TimeSpan.FromMinutes(5);
                                
                                var message = prox.UploadFile(new UploadFileContentMessage()
                                {
                                    SenderName = SenderName,
                                    FileByteStream = File.OpenRead(CardDeck.ZipPath)
                                });
                                password = message.Password;
                            }
                            catch (Exception ex)
                            {
                                Utils.LogException(MethodBase.GetCurrentMethod(), ex);
                                OnErrorOccured(ex);
                            }
                            finally
                            {
                                (prox as ICommunicationObject).Close();
                            }
                        };

                    worker.RunWorkerCompleted += (s, e) =>
                        {
                            // don't send mail if user clicked cancel
                            if (_isCanceled)
                            {
                                return;
                            }

                            if (string.IsNullOrEmpty(password))
                            {
                                // report error?
                                return;
                            }

                            // open client mail
                            WaitIndicatorText = (string)Application.Current.FindResource("Resource_ShareDialog_PreparingMail");

                            string silverlightBaseUrl = (string)Application.Current.FindResource("Resource_ShareDialog_SilverlightBaseUrl");
                            string flashCardsSiteUrl = (string)Application.Current.FindResource("Resource_ShareDialog_FlashCardsSiteUrl");
                            
                            string mailSubject = (string)Application.Current.FindResource("Resource_ShareDialog_MailSubject");
                            string mailBody = (string)Application.Current.FindResource("Resource_ShareDialog_MailBody");

                            string param = password + SenderName;
                            param = Utils.Encode(param);

                            string silverlightBaseUrlWithParameters = string.Format(silverlightBaseUrl, param);
                            string mailBodyWithParameters = string.Format(mailBody, silverlightBaseUrlWithParameters, flashCardsSiteUrl, SenderName, password);
                            Utils.SendMail(null, null, null, mailSubject, mailBodyWithParameters);

                            IsBusy = false;
                            DialogResult = true;
                        };

                    worker.RunWorkerAsync();
                });

            CancelUpload = new DelegateCommand(() =>
                {
                    _isCanceled = true;
                    IsBusy = false;
                    DialogResult = true;
                });

            CloseForm = new DelegateCommand(() =>
                {
                    DialogResult = true;
                });
        }

        public ICommand ShareDeck { get; private set; }
        public ICommand CancelUpload { get; private set; }
        public ICommand CloseForm { get; private set; }

        public CardDeck CardDeck { get; set; }

        public event EventHandler<ErrorEventArgs> ErrorOccured;

        private void OnErrorOccured(Exception ex)
        { 
            EventHandler<ErrorEventArgs> errorOccured = ErrorOccured;
            if (errorOccured != null)
            {
                errorOccured(this, new ErrorEventArgs(ex));
            }
        }

        #region SenderName

        private string _senderName;
        public string SenderName
        {
            get
            {
                return _senderName;
            }
            set
            {
                if (_senderName != value)
                {
                    _senderName = value;
                    RaisePropertyChanged("SenderName");
                }
            }
        }

        #endregion 

        #region DialogResult

        private bool? _dialogResult;
        public bool? DialogResult
        {
            get
            {
                return _dialogResult;
            }
            set
            {
                if (_dialogResult != value)
                {
                    _dialogResult = value;
                    RaisePropertyChanged("DialogResult");
                }
            }
        }

        #endregion 

        #region IsBusy

        private bool _isBusy = false;
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
                    RaisePropertyChanged("IsBusy");
                }
            }
        }

        #endregion

        #region WaitIndicatorText

        private string _waitIndicatorText;
        public string WaitIndicatorText
        {
            get
            {
                return _waitIndicatorText;
            }
            set
            {
                if (_waitIndicatorText != value)
                {
                    _waitIndicatorText = value;
                    RaisePropertyChanged("WaitIndicatorText");
                }
            }
        }

        #endregion

        public bool IsFileTooLarge
        {
            get
            {
                FileInfo fileInfo = new FileInfo(CardDeck.ZipPath);
                return (fileInfo.Length > BaseMainViewModel.MaxDeckSizeInMB * Math.Pow(2,20));
            }
        }

    }
}
