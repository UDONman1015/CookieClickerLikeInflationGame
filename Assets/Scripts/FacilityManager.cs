using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//施設を管理
public class FacilityManager : MonoBehaviour
{
    //[SerializeField] を入れるとインスペクターから値を編集可能になる
    //privateな変数は外部のスクリプトから参照されない

    //List:複数の要素をひとまとめにリスト化した変数
    [Header("施設リスト")]
    [SerializeField] List<Facility> FacilityList = new List<Facility>();
}
