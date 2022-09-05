using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ガチャから排出されるアイテム
public class GachaItem : ScriptableObject
{
    //[SerializeField] を入れるとインスペクターから値を編集可能になる
    //privateな変数は外部のスクリプトから参照されない

    //Rarity:N～URのいずれかの値
    [Header("アイテムのレアリティ")]
    [SerializeField] private Rarity itemRarity;

    //外部のスクリプトから参照される用のpublic変数(プロパティ)
    public Rarity ITemRarity { get { return itemRarity; } }
    public string ItemName { get { return this.name; } }
}

//enumは列挙された値のうち、必ずいずれか一つの値を取る
public enum Rarity
{
    N,
    HN,
    R,
    SR,
    SSR,
    UR,
}
