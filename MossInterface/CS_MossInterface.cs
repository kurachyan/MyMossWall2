using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MossInterface
{
    #region MossTableイメージ
    struct CS_MossInterface
    {   // テーブルイメージ
        Boolean flag;           // 状態情報　（True:Active False:Unuse）
        int SeqNo;              // シーケンス番号
        String Name;            // 名称
        int LastPos;            // シーケンス位置情報
        int NextPos;
        String Items;           // 管理情報（要素）

        // 操作オブジェクト群
        public CS_MossInterface(int i, String _Name)
        {   // コンストラクタ２
            flag = true;        // 操作初期情報設定
            SeqNo = i;
            Name = _Name;
            LastPos = 0;
            NextPos = -1;
            Items = _Name;
        }
        public void SetSeqNo(int i)
        {
            SeqNo = i;          // シーケンス番号設定
        }
        public void SetLast(int i)
        {
            LastPos = i;        // 元位置情報設定
        }
        public void SetNext(int i)
        {
            NextPos = i;        // 接続先情報設定
        }
        public void SetItems(String word)
        {
            Items = word;       // 要素情報設定
        }
        public String GetName()
        {
            return (Name);      // 要素情報取り出し
        }
        public int GetLast()
        {
            return (LastPos);   // 元位置情報取り出し
        }
        public int GetNext()
        {
            return (NextPos);    // 接続先情報取り出し
        }
        public String GetItems()
        {
            return (Items);      // 要素情報取り出し
        }
        public int GetSeqNo()
        {
            return (SeqNo);      // シーケンス番号取り出し
        }
        public Boolean Getflag()
        {
            return (flag);      // 状態情報取り出し
        }
        public void Chgflag()
        {
            if (flag == true)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
        }
    };
    #endregion
}
