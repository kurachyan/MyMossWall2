using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MossTable;
using MossDictionary;

namespace MyMossWall2
{
    class MossAnalyze
    {
        CS_MossTable MT;           // MossTable
        CS_MossDictionary MD;      // MossDictionary

        private Stack<string> Stack;      // 解析スタック

        public MossAnalyze()
        {   // コンストラクタ
            Stack = new Stack<string>();
        }

        public void SetMT(CS_MossTable _mt)
        {
            this.MT = _mt;
        }
        public void SetMD(CS_MossDictionary _md)
        {
            this.MD = _md;
        }

        public void Init()
        {   // 初期情報設定
            Stack.Clear();
        }

        public void Add(String _Value)
        {   // 要素追加
            Stack.Push(_Value);
        }

//        public void Delete(String _Name)
//        {   // 要素削除
//        }

//        public Boolean Check(String _Name)
//        {   // 要素確認
//        }

//        public String Value(String _Name)
//        {
//        }

//        public String Get(int _Pos)
//        {
//        }
    }
}
