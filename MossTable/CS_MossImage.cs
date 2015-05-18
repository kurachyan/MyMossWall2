using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MossImage
{
    #region MossTableイメージ
    struct Image
    {   // テーブルイメージ
        Boolean flag;           // 状態情報　（True:Active False:Unuse）
        int SeqNo;              // シーケンス番号
        String Name;            // 名称
        int LastPos;            // シーケンス位置情報
        int NextPos;
        String Items;           // 管理情報（要素）

        // 操作オブジェクト群
        //        public Image()
        //        {   // コンストラクタ１
        //            flag = true;        // 稼働初期情報設定
        //            SeqNo = 0;
        //            Name = "NuN";
        //            LastPos = -1;
        //            NextPos = 0;
        //            Items = "NuN";
        //        }
        public Image(int i, String _Name)
        {   // コンストラクタ２
            this.flag = true;        // 操作初期情報設定
            this.SeqNo = i;
            this.Name = _Name;
            this.LastPos = 0;
            this.NextPos = -1;
            this.Items = _Name;
        }
        public void SetSeqNo(int i)
        {
            this.SeqNo = i;          // シーケンス番号設定
        }
        public void SetLast(int i)
        {
            this.LastPos = i;        // 元位置情報設定
        }
        public void SetNext(int i)
        {
            this.NextPos = i;        // 接続先情報設定
        }
        public void SetItems(String word)
        {
            this.Items = word;       // 要素情報設定
        }
        public String GetName()
        {
            return (this.Name);      // 要素情報取り出し
        }
        public int GetLast()
        {
            return (this.LastPos);   // 元位置情報取り出し
        }
        public int GetNext()
        {
            return (this.NextPos);    // 接続先情報取り出し
        }
        public String GetItems()
        {
            return (this.Items);      // 要素情報取り出し
        }
        public int GetSeqNo()
        {
            return (this.SeqNo);      // シーケンス番号取り出し
        }
        public Boolean Getflag()
        {
            return (this.flag);      // 状態情報取り出し
        }
        public void Chgflag()
        {
            if (this.flag == true)
            {
                this.flag = false;
            }
            else
            {
                this.flag = true;
            }
        }
    };
    #endregion
}
