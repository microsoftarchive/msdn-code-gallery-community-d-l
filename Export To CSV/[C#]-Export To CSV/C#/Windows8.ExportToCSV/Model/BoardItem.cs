namespace MSDN.Samples.ConvertingToCSVFile.Model
{
    using GalaSoft.MvvmLight;

    public class BoardItem : ObservableObject
    {
        private string _name;
        private int _value;
        private int _count;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; RaisePropertyChanged(() => Value); }
        }

        public int Count
        {
            get { return _count; }
            set { _count = value; RaisePropertyChanged(() => Count); }
        }
    }
}
