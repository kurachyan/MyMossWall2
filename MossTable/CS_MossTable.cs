using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MossImage;

namespace MossTable
{
    public class CS_MossTable
    {
        private LinkedList<Image> Table;        // 管理テーブル
        private Image MossWork;                 // テーブル要素
        private int Count;                      // 登録数
//        private int Active;                     // 稼働位置

        public CS_MossTable()
        {   // コンストラクタ
            Table = new LinkedList<Image>();    // 管理テーブル構築
            MossWork = new Image(0, "NuN");     // 作業領域作成

            // 初期情報設定
            this.Init();
//            MossWork.SetLast(-1);
//            MossWork.SetItems("NuN");
//            Table.AddFirst(MossWork);           // 先頭に”ＮｕＮ”設定
//            this.Count = 0;
//            Active = 0;
        }

        public void Init()
        {   // 初期情報設定
            MossWork = new Image(0, "NuN");     // 作業領域作成

            MossWork.SetLast(-1);
            MossWork.SetItems("NuN");
            Table.AddFirst(MossWork);           // 先頭に”ＮｕＮ”設定
            this.Count = 0;
        }

        public void Add(String _Name)
        {   // 要素追加
            int _pos = Count + 1;

            MossWork = new Image(_pos, _Name);
            MossWork.SetLast(Count);
            MossWork.SetItems(_Name);
            Table.AddLast(MossWork);            // 最後に指定要素を追加する

            Image[] _Img = new Image[_pos + 1];
            Table.CopyTo(_Img, 0);              // 登録済の要素を配列で管理する
            Table.Clear();                      // List情報をリセットする

            _Img[Count].SetNext(_pos);          // 前の要素に追加要素の位置を登録する
            for (int i = 0; i < _Img.Count(); i++)
            {   // 登録要素数分、処理を繰り返す
                Table.AddLast(_Img[i]);         // 配列の内容をList情報に書き込む
            }

            this.Count++;                            // 要素数更新
        }

        public void Delete(String _Name)
        {   // 要素削除
//            Image _lastImage, _nextImage;       // 関連要素（０：前　１：次）
            int _seqno, _last, _next;

            if(this.Check(_Name) == true)
            {   // 指定要素は存在するか？
//                MossWork.Chgflag();             // 解放設定

                _seqno = MossWork.GetSeqNo();   // 要素のシーケンス番号を取り出す
                _last = MossWork.GetLast();     // 要素のリンク情報を取り出す
                _next = MossWork.GetNext();


                Image[] _Img = new Image[Count + 1];
                Table.CopyTo(_Img, 0);              // 登録済の要素を配列で管理する
                Table.Clear();                      // List情報をリセットする

                if (_next != -1)
                {   // 中間の要素削除
                    _Img[_seqno].Chgflag();     // 解放設定
                    _Img[_last].SetNext(_next);
                    _Img[_next].SetLast(_last);
                }
                else
                {   // 最後の要素削除
                    _Img[_seqno].Chgflag();     // 解放設定
                    _Img[_last].SetNext(-1);
                }
                for (int i = 0; i < _Img.Count(); i++)
                {   // 登録要素数分、処理を繰り返す
                    Table.AddLast(_Img[i]);         // 配列の内容をList情報に書き込む
                }

//                --Count;
            }
        }

        public void Insert(int _pos, String _Name)
        {
            if (_pos == Count)
            {
                this.Add(_Name);
            }
            else
            {
                if (_pos < this.Count)
                {
                    int _wcount = this.Count+1;

                    Image[] _Img = new Image[Count + 1];
                    Table.CopyTo(_Img, 0);              // 登録済の要素を配列で管理する
                    Table.Clear();                      // List情報をリセットする
                    this.Count = 0;

                    MossWork = new Image(0, "NuN");     // 作業領域作成
                    MossWork.SetLast(-1);
                    MossWork.SetItems("NuN");
                    Table.AddFirst(MossWork);           // 先頭に”ＮｕＮ”設定

                    for (int i = 1; i < _wcount; i++)
                    {
                        if (_Img[i].Getflag() == true)
                        {
                            this.Add(_Img[i].GetName());
                        }

                        if (i == _pos)
                        {
                            this.Add(_Name);
                        }
                    }                    
                }
            }
        }

        public void GarbageCollection()
        {
            int i = 0;
            Image[] _Img = new Image[Count+1];
            Table.CopyTo(_Img, 0);              // 登録済の要素を配列で管理する
            Table.Clear();                      // List情報をリセットする

            MossWork = new Image(0, "NuN");     // 作業領域作成
            MossWork.SetLast(-1);
            MossWork.SetItems("NuN");
            Table.AddFirst(MossWork);           // 先頭に”ＮｕＮ”設定
            this.Count = 0;

            do
            {
                i++;

                if (_Img[i].Getflag() == true)
                {
                    this.Add(_Img[i].GetName());
                }
            } while (_Img[i].GetNext() != -1);
        }

        public Boolean Check(String _Name)
        {   // 要素確認
            for (int i=0; i<Count+1; i++)
            {
                Image _mw = Table.ElementAt(i);
                String mw_Name = _mw.GetName();

                if (_mw.Getflag() == false)
                {   // 破棄要素か？
                    continue;
                }
                if (mw_Name == _Name)
                {   // 指定要素か？
                    MossWork = _mw;             // 要素情報抜き取り

                    return (true);
                }
            }

            return (false);
        }

        public String Value(String _Name)
        {
            String _ValueString;
            String _flag=@"", _Seqno=@"", _LastPos=@"", _NextPos=@"", _Items=@"";

            if (this.Check(_Name) == true)
            {
                if (MossWork.Getflag() == true)
                {
                    _flag = @"True";
                }
                else
                {
                    _flag = @"False";
                }

                _Seqno = MossWork.GetSeqNo().ToString();

                _LastPos = MossWork.GetLast().ToString();
                _NextPos = MossWork.GetNext().ToString();

                _Items = MossWork.GetItems().ToString();

                _ValueString = @"[" + _flag + ": " + _Seqno + " "+ _Name + " (" + _LastPos + "," + _NextPos + ") \"" + _Items + "\"]";
            }
            else
            {
                _ValueString = @"[None: " + _Name + "]";
            }

            return (_ValueString);
        }

        public String Get(int _Pos)
        {
            String _keyword = @"None";

            if (_Pos < Count+1)
            {
                Image _mw = Table.ElementAt(_Pos);

                _keyword = _mw.GetName();
            }

            return (_keyword);
        }

//        public Image GetWork()
//        {
//            return (this.MossWork);
//        }

        public int GetCount()
        {   // 登録数確認
            return (this.Count);
        }
    }
}
