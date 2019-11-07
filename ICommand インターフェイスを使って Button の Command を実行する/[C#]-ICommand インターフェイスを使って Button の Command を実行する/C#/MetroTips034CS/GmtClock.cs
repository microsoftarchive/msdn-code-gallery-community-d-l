using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MetroTips034CS
{
  public class GmtClock : Common.BindableBase
  {
    // プロジェクト・テンプレートに含まれている BindableBase クラス を継承すれば、
    // その PropertyChanged イベントハンドラと SetProperty メソッドを利用できる。

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
      internal set { SetProperty(ref _isEven, value); }
    }

    // 秒が奇数のとき true
    private bool _isOdd;
    public bool IsOdd
    {
      get { return _isOdd; }
      internal set { SetProperty(ref _isOdd, value); }
    }


    public GmtClock()
    {
      Run();
    }

    private bool _isLive = true;

    private async void Run()
    {
      DateTimeOffset lastTime;
      while (_isLive)
      {
        await Task.Delay(10);
        var nowTime = DateTimeOffset.Now.ToUniversalTime();
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
          catch{}
        }
      }
    }
  }
}
