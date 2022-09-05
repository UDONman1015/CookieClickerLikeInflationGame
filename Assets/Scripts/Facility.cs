using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//施設
[CreateAssetMenu(menuName = "Create/施設", fileName = "施設")]
public class Facility : ScriptableObject
{
    //[SerializeField] を入れるとインスペクターから値を編集可能になる
    //privateな変数は外部のスクリプトから参照されない

    //string:文字列
    [Header("施設名")]
    [SerializeField] private string facilityName;

    //float:小数
    [Header("単位時間当たりのソウル獲得量")]
    [SerializeField] private float soulPerSecond;

    [Header("購入コスト")]
    [SerializeField] private float initialPurchaseCost;

    //外部のスクリプトから参照される用のpublic変数(プロパティ)
    public string FacilityName { get { return facilityName; } }
    public float SoulPerSecond { get { return soulPerSecond; } }
    public float InitialPurchaseCost { get { return initialPurchaseCost; } }
}
