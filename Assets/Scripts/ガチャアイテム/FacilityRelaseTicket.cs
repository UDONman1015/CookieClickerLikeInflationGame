using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//施設解放券
//GachaItemを継承→ガチャから排出されるアイテムの一種である
[CreateAssetMenu(menuName = "Create/ガチャアイテム/施設解放券", fileName = "施設解放券")]
public class FacilityRelaseTicket : GachaItem
{
    //[SerializeField] を入れるとインスペクターから値を編集可能になる
    //privateな変数は外部のスクリプトから参照されない

    //Rarity:N～URのいずれかの値
    [Header("このアイテムで解放できる施設")]
    [SerializeField] private Facility targetFacility;

    //外部のスクリプトから参照される用のpublic変数(プロパティ)
    public Facility TargetFacility { get { return targetFacility; } }
}
