using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
//ガチャの情報をUIに表示
public class GachaUI : MonoBehaviour
{
    //[SerializeField] を入れるとインスペクターから値を編集可能になる
    //privateな変数は外部のスクリプトから参照されない

    //ガチャを回すボタンの親
    [SerializeField] Transform GachaButtonsParent;

    //表示するガチャの情報
    private Gacha gacha;

    //ガチャを回すボタンリスト
    List<Button> RollGachaButtons = new List<Button>();

    //ガチャの情報を与えて初期化
    public void InitGachaUI(Gacha gacha)
    {
        this.gacha = gacha;

        //ガチャのガチャコスト表を、回転数が少ない順に並び替え
        gacha.GachaCostTables = gacha.GachaCostTables.OrderBy((gachaCostTable) => gachaCostTable.RollCount).ToList();

        for (int i=0;i<gacha.GachaCostTables.Count;i++)
        {
            if(i < GachaButtonsParent.childCount)
            {
                Button button = GachaButtonsParent.GetChild(i).GetComponent<Button>();

                if(button != null)
                {
                    GachaCostTable gachaCostTable = gacha.GachaCostTables[i];

                    button.transform.GetChild(0).GetComponent<Text>().text = $"{gachaCostTable.RollCount}連ガチャ({gachaCostTable.SoulCost})";
                    button.onClick.AddListener(() => gacha.RollGacha(gachaCostTable.RollCount));
                    //button.onClick.AddListener(RollGacha);

                    RollGachaButtons.Add(button);

                    void RollGacha()
                    {
                        Debug.Log($"i = {i}");
                        gacha.RollGacha(gacha.GachaCostTables[i].RollCount);
                    }
                }
            }
        }
    }

    //ガチャの情報をUIに反映
    void ShowGachaInfo()
    {
        //ガチャの情報がセットされていれば表示
        if(gacha != null)
        {
            GachaButtonsParent.gameObject.SetActive(true);

            for(int i=0;i< RollGachaButtons.Count;i++)
            {
                if(i < gacha.GachaCostTables.Count)
                {
                    RollGachaButtons[i].interactable = gacha.CanRollGacha(gacha.GachaCostTables[i].RollCount);
                }
            }
        }

        //ガチャの情報がセットされていなければ非表示
        else
        {
            GachaButtonsParent.gameObject.SetActive(false);
        }
    }

    //自動的に毎フレーム呼ばれる関数
    private void Update()
    {
        //毎フレーム自動的にプガチャの情報をUIに反映
        ShowGachaInfo();
    }
}
