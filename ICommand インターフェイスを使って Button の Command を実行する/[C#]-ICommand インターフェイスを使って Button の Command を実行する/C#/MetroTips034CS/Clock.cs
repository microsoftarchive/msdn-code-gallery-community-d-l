using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MetroTips034CS
{
  public class Clock : Common.BindableBase
  {
    // プロジェクト・テンプレートに含まれている BindableBase クラス を継承すれば、
    // その PropertyChanged イベントハンドラと SetProperty メソッドを利用できる。



    // *** ICommand を使ってみるテスト
    private DelegateCommand _command;
    public DelegateCommand Command {
      get {
        if(_command == null)
          _command = new DelegateCommand(
                       (p) =>
                       {
                         var action = CommandAction;
                         if (action != null)
                           action(p);
                       },
                       () => IsEven);

        return _command;
      }
    }
    public Action<string> CommandAction { get; set; }





    // 現在時刻を表すプロパティ
    private DateTimeOffset _nowTime;
    public DateTimeOffset NowTime 
    {
      get { return _nowTime; }
      internal set { SetProperty(ref _nowTime, value); }
    }

    // 秒が偶数のとき true
    private bool _isEven;
    public bool IsEven 
    {
      get { return _isEven; }
      internal set
      {
        if (SetProperty(ref _isEven, value))
        {
          // *** IsEven プロパティが変化したときだけ
          //     CanExecuteChanged イベントを発火させる
          this.Command.RaiseCanExecuteChanged();
        }
      }
    }

    // 秒が奇数のとき true
    private bool _isOdd;
    public bool IsOdd
    {
      get { return _isOdd; }
      internal set { SetProperty(ref _isOdd, value); }
    }


    public Clock()
    {
      Run();
    }

    private async void Run()
    {
      DateTimeOffset lastTime;
      while (true)
      {
        await Task.Delay(10);
        var nowTime = DateTimeOffset.Now;
        if (lastTime.Second != nowTime.Second)
        {
          try
          {
            this.NowTime = nowTime;

            bool isEvenSec = (nowTime.Second % 2 == 0);
            this.IsEven = isEvenSec;
            this.IsOdd = !isEvenSec;

            lastTime = nowTime;
          }
          catch { }
        }
      }
    }
  }
}
