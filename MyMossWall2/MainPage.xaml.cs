using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// using MossInterface;
// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace MyMossWall2
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region コンストラクタ
        public MainPage()
        {   // アプリケーション　コンストラクタ
            this.InitializeComponent();

            // 初期表示をクリアする
            ClearResultTextBox();
        }
        #endregion

        #region ［Ｅｘｅｃｕｔｅ］ボタン押下
        private void Button01_Click(object sender, RoutedEventArgs e)
        {   // [Execute]ボタン押下
//            CS_MossInterface _mi;

            WriteLineResult(@"Execute");
        }
		#endregion

        #region ［Ｒｅｓｅｔ］ボタン押下
        private void Button02_Click(object sender, RoutedEventArgs e)
        {   // [Reset]ボタン押下
            ClearResultTextBox();
        }
		#endregion
    }
}
