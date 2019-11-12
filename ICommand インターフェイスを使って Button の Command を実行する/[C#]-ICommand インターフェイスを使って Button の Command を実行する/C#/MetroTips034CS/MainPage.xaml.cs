using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 基本ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234237 を参照してください

namespace MetroTips034CS
{
  /// <summary>
  /// 多くのアプリケーションに共通の特性を指定する基本ページ。
  /// </summary>
  public sealed partial class MainPage : MetroTips034CS.Common.LayoutAwarePage
  {
    public MainPage()
    {
      this.InitializeComponent();

      // *** 新しく設置した StackPanel の DataContext の CommandAction を設定する。
      //     UIをいじるアクションなので、コードビハインドで設定する。
      var clk = this.stackPanelForTest.DataContext as Clock;
      if (clk != null)
      {
        clk.CommandAction = async (p) =>
          {
            var color = Colors.Transparent;
            if (string.Equals(p, "PINK", StringComparison.OrdinalIgnoreCase))
              color = Colors.HotPink;
            else if (string.Equals(p, "GREEN", StringComparison.OrdinalIgnoreCase))
              color = Colors.LimeGreen;

            this.stackPanelForTest.Background = new SolidColorBrush(color);
            await Task.Delay(300);
            this.stackPanelForTest.Background = new SolidColorBrush(Colors.Transparent);
          };
      }
    }

    /// <summary>
    /// このページには、移動中に渡されるコンテンツを設定します。前のセッションからページを
    /// 再作成する場合は、保存状態も指定されます。
    /// </summary>
    /// <param name="navigationParameter">このページが最初に要求されたときに
    /// <see cref="Frame.Navigate(Type, Object)"/> に渡されたパラメーター値。
    /// </param>
    /// <param name="pageState">前のセッションでこのページによって保存された状態の
    /// ディクショナリ。ページに初めてアクセスするとき、状態は null になります。</param>
    protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
    {
    }

    /// <summary>
    /// アプリケーションが中断される場合、またはページがナビゲーション キャッシュから破棄される場合、
    /// このページに関連付けられた状態を保存します。値は、
    /// <see cref="SuspensionManager.SessionState"/> のシリアル化の要件に準拠する必要があります。
    /// </summary>
    /// <param name="pageState">シリアル化可能な状態で作成される空のディクショナリ。</param>
    protected override void SaveState(Dictionary<String, Object> pageState)
    {
    }
  }
}
