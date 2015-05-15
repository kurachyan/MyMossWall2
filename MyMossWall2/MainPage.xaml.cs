﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using MossTable;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace MyMossWall2
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        CS_MossTable MT;           // MossTable
//        MossDictionary MD;      // MossDictionary

        #region コンストラクタ
        public MainPage()
        {   // アプリケーション　コンストラクタ
            this.InitializeComponent();

            // 初期表示をクリアする
            ClearResultTextBox();

            // MossTable構築
            MT = new CS_MossTable();

//            // MossDictonary構築　及び、[NuN]登録
//            MD = new MossDictionary();
//            MD.Init();
        }
        #endregion

        #region ［Ｅｘｅｃｕｔｅ］ボタン押下
        private void Button01_Click(object sender, RoutedEventArgs e)
        {   // [Execute]ボタン押下
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
