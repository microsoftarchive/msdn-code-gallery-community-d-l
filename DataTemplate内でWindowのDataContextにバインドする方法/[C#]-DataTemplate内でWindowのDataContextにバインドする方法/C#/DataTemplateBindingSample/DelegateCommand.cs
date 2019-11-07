namespace DataTemplateBindingSample
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// ICommandの簡単実装
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// 未使用
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Execute時に実行する処理
        /// </summary>
        private Action<object> executeAction;

        public DelegateCommand(Action<object> executeAction)
        {
            if (executeAction == null)
            {
                throw new ArgumentNullException("executeAction");
            }
            this.executeAction = executeAction;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.executeAction(parameter);
        }
    }
}
