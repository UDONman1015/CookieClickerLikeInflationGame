using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

//プレイヤーの情報
public class Player : MonoBehaviour
{
    //[SerializeField] を入れるとインスペクターから値を編集可能になる
    //privateな変数は外部のスクリプトから参照されない

    //List:複数の要素をひとまとめにリスト化した変数
    [Header("所持ガチャアイテムリスト")]
    public List<GachaItem> PossessionItems = new List<GachaItem>();

    //public変数は[SerializeField]を入れなくてもインスペクターから値を編集可能になる
    //int:整数
    [Header("所持ソウル")]
    public int Soul = 0;

    [Header("1クリックあたりのソウル獲得量の基本値")]
    [SerializeField] int BaseSoulPerClick = 1;

    [Header("プレイヤー情報表示")]
    [SerializeField] PlayerUI playerUI;

    //プレイヤーの初期化
    public void InitPlayer()
    {
        //所持ガチャアイテムリストを空にする
        PossessionItems = new List<GachaItem>();

        //所持ソウルを0にする
        Soul = 0;

        //PlayerUIをこのプレイヤー自身の情報で初期化
        playerUI?.InitPlayerUI(this);

        StartCoroutine(AddSoulPerSecondCoroutine());
    }

    //所持装備リスト(所持ガチャアイテムリストの中から装備だけを抽出)
    public List<Equipment> Equipments
    {
        get
        {
            List<Equipment> equipments = new List<Equipment>();

            foreach(GachaItem gachaItem in PossessionItems)
            {
                if(gachaItem != null)
                {
                    if(gachaItem is Equipment)
                    {
                        equipments.Add((Equipment)gachaItem);
                    }
                }
            }

            return equipments;
        }
    }

    //所持施設リストリスト(所持ガチャアイテムリストの中から装備だけを抽出)
    public List<Facility> PossessionFacilities
    {
        get
        {
            List<Facility> prossessionFacilities = new List<Facility>();

            foreach (GachaItem gachaItem in PossessionItems)
            {
                if (gachaItem != null)
                {
                    if (gachaItem is Facility)
                    {
                        prossessionFacilities.Add((Facility)gachaItem);
                    }
                }
            }

            return prossessionFacilities;
        }
    }


    //プレイヤーの1クリックあたりのソウル獲得量
    public int SoulPerClick
    {
        get
        {
            float soulPerClick = BaseSoulPerClick;

            #region 装備による補正
            foreach(Equipment equipment in Equipments)
            {
                soulPerClick = equipment.GetSoulPerClick(soulPerClick);
            }
            #endregion

            return (int)Math.Ceiling(soulPerClick);
        }
    }

    //プレイヤーの1秒あたりのソウル獲得量
    public int SoulPerSecond
    {
        get
        {
            float soulPerSecond = 0;

            #region 施設による補正
            foreach(Facility facility in PossessionFacilities)
            {
                if(facility != null)
                {
                    soulPerSecond += facility.SoulPerSecond;
                }
            }
            #endregion

            return (int)Math.Ceiling(soulPerSecond);
        }
    }

    //ソウルを獲得する
    public void AddSoul(int soul)
    {
        this.Soul += soul;

        if(this.Soul <= 0)
        {
            this.Soul = 0;
        }
    }

    //ソウルを失う
    public void LoseSoul(int soul)
    {
        AddSoul(-soul);
    }

    //プレイヤーに1クリック当たりのソウル獲得量を与える
    public void AddSoul_Click()
    {
        AddSoul(SoulPerClick);
    }

    //プレイヤーに1秒当たりのソウル獲得量を与える
    public void AddSoul_PerSecond()
    {
        AddSoul(SoulPerSecond);
    }

    //毎秒ソウルを与えるコルーチン
    IEnumerator AddSoulPerSecondCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);

            AddSoul_PerSecond();
        }
    }

    //ガチャアイテムを獲得する
    public void GetItem(GachaItem gachaItem)
    {
        PossessionItems.Add(gachaItem);

        Debug.Log($"{gachaItem.ItemName}を獲得しました");
    }
}
