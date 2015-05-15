using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MossImage;

namespace MossDictionary
{
    public class CS_MossDictionary
    {
        private Dictionary<string, string> Dictionary;      // 辞書テーブル
        private Image MossWork;                             // テーブル要素
//        private int Count;                                  // 登録数
//        public Dictionary<string, string>.KeyCollection keys;
//        private int Active;                               // 稼働位置

        public CS_MossDictionary()
        {   // コンストラクタ
            Dictionary = new Dictionary<string, string>();    // 管理テーブル構築

            // 初期情報設定
//            this.Count = 0;
//            Active = 0;
        }

//        public void Add(Image _Img)
//        {   // 辞書追加
//            string _name, _items;
//
//            _name = _Img.GetName();             // 名称取り出し
//            _items = _Img.GetItems();           // 要素取り出し
//
//            Dictionary.Add(_name, _items);      // 辞書登録
//
//        }
        public void Add(string _name, string _items)
        {   // 辞書追加
            Dictionary.Add(_name, _items);      // 辞書登録

//            this.Count++;                       // 要素数更新
        }

        public void Init()
        {   // 辞書初期化
            MossWork = new Image(0, "NuN");     // 作業領域作成
            MossWork.SetLast(-1);
            MossWork.SetItems("NuN");

//            this.Add(MossWork);                 // 初期情報登録
        }

        public void Delete(String _Name)
        {   // 要素削除
            if (this.Check(_Name) == true)
            {   // 辞書登録有り？
                Dictionary.Remove(_Name);       // 辞書内の要素を削除する
            }
        }

        public Boolean Check(String _Name)
        {   // 要素確認
            Boolean _judge = false;

            if (_Name != null)
            {   // 確認対象が登録されているか？
                if (Dictionary.ContainsKey(_Name) == true)
                {   // 辞書に要素が登録済か？
                    MossWork = new Image(0, _Name);     // 辞書内の要素を取り出す
                    MossWork.SetLast(-1);
                    MossWork.SetNext(-1);
                    MossWork.SetItems(Dictionary[_Name]);

                    _judge = true;
                }
            }

            return (_judge);
        }

        public String Get(String _Name)
        {
            String _keyword = @"None";

            if (Dictionary.ContainsKey(_Name) == true)
            {   // 辞書に要素が登録済か？
                MossWork = new Image(0, _Name);     // 辞書内の要素を取り出す
                MossWork.SetLast(-1);
                MossWork.SetNext(-1);
                MossWork.SetItems(Dictionary[_Name]);

                _keyword = Dictionary[_Name];
            }

            return (_keyword);
        }

//        public Image GetWork()
//        {
//            return(MossWork);
//        }

        public int GetCount()
        {   // 登録数確認
//            return (this.Count);
            return (Dictionary.Count);
        }
    }
}
