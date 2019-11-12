using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataTemplateBindingSample
{
    /// <summary>
    /// MainWindow用ViewModel
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// ダミーデータのコレクション
        /// </summary>
        private ObservableCollection<ListItem> items;

        public ObservableCollection<ListItem> Items
        {
            get { return this.items; }
            set { this.SetProperty(ref this.items, value); }
        }

        /// <summary>
        /// コマンドが実行されたときに変更するプロパティ
        /// </summary>
        private string outputMessage;

        public string OutputMessage
        {
            get { return this.outputMessage; }
            set { this.SetProperty(ref this.outputMessage, value); }
        }

        /// <summary>
        /// DataTemplateから呼び出すコマンド
        /// </summary>
        public ICommand ViewModelCommand { get; private set; }

        public MainWindowViewModel()
        {
            this.ViewModelCommand = new DelegateCommand(
                item => this.OutputMessage = ((ListItem)item).Text + "が選択されました");
            this.Initialize();
        }

        private void Initialize()
        {
            // ダミーデータを生成
            items = new ObservableCollection<ListItem>(
                Enumerable.Range(1, 20).Select(i => new ListItem { Text = i + "th item." }));
        }





    }
}
