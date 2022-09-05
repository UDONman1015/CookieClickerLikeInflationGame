using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//装備
//GachaItemを継承→ガチャから排出されるアイテムの一種である

public class Equipment : GachaItem
{
    //外部のスクリプトからソウル獲得量を計算するためのpublicメソッド(装備ごとにソウル獲得量を算出する方法が異なる場合を想定して個別に設定出来るようにしてある)
    public virtual float GetSoulPerClick(float SoulPerClick)
    {
        return SoulPerClick;
    }
}

