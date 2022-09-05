using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1クリックあたりのソウル獲得量を一定割合で増加させる装備
//Equipmentを継承→装備の一種である
[CreateAssetMenu(menuName = "Create/ガチャアイテム/装備/一定割合強化装備", fileName = "一定割合強化装備")]
public class Equipment_IncreaseInAmplification : Equipment
{
    //[SerializeField] を入れるとインスペクターから値を編集可能になる
    //privateな変数は外部のスクリプトから参照されない

    //float:小数
    [Header("1クリックあたりのソウル獲得量を増加させる割合")]
    [SerializeField] private float increaseSoulPerClickAmplificationk;

    //継承元の関数をoverriderして一定割合で変化させるように対応
    public override float GetSoulPerClick(float SoulPerClick)
    {
        return SoulPerClick * (1 + increaseSoulPerClickAmplificationk);
    }
}