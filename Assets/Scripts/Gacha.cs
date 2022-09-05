using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//ガチャ本体
public class Gacha : MonoBehaviour
{
    //[SerializeField] を入れるとインスペクターから値を編集可能になる
    //privateな変数は外部のスクリプトから参照されない

    [Header("プレイヤー")]
    [SerializeField] Player player;

    //List:複数の要素をひとまとめにリスト化した変数
    [Header("ガチャから排出されるアイテムリスト")]
    [SerializeField] private List<GachaItem> gachaItemList = new List<GachaItem>();

    [Header("ガチャ排出率テーブルリスト")]
    [SerializeField] private List<EmissionRateTable> EmissionRateTables = new List<EmissionRateTable>();

    [Header("ガチャコスト表")]
    public List<GachaCostTable> GachaCostTables = new List<GachaCostTable>();

    [Header("ガチャ情報表示")]
    [SerializeField] GachaUI gachaUI;

    //ゲーム開始時に自動的に1度だけ呼ばれる
    private void Start()
    {
        //GachaUIをこのガチャ自身の情報で初期化
        gachaUI?.InitGachaUI(this);
    }

    //指定されたアイテムの排出率をガチャ排出率テーブルリストから算出
    public float GetEmissionRate(GachaItem gachaItem)
    {
        float emissionRate = 0f;

        //ガチャ排出率テーブルリストの全要素を探索して指定されたアイテムのレアリティと同じレアリティの排出率を示す要素を探す
        foreach (EmissionRateTable emissionRateTable in EmissionRateTables)
        {
            if(emissionRateTable.rarity == gachaItem.ITemRarity)
            {
                emissionRate = emissionRateTable.EmissionRate;
            }
        }

        #region アイテムごとに特殊な排出率を設定したい場合は別途個別に設定
        #endregion

        return emissionRate;
    }

    //指定した回数のガチャを回すのに必要なコスト
    public int GetGachaCost(int RollCount)
    {
        int gachaCost = 0;

        foreach(GachaCostTable gachaCostTable in GachaCostTables)
        {
            if(gachaCostTable.RollCount == RollCount)
            {
                gachaCost = gachaCostTable.SoulCost;
            }
        }

        return gachaCost;
    }

    //指定された回数だけガチャを回す
    public void RollGacha(int RollCount)
    {
        if(CanRollGacha(RollCount))
        {
            player.LoseSoul(GetGachaCost(RollCount));

            List<GachaItem> GotItems = new List<GachaItem>();

            while(GotItems.Count < RollCount)
            {
                GachaItem randomItem = null;

                do
                {
                    randomItem = gachaItemList[UnityEngine.Random.Range(0, gachaItemList.Count)];
                }

                while (UnityEngine.Random.Range(0f, 1f) > GetEmissionRate(randomItem));

                GotItems.Add(randomItem);
            }

            foreach(GachaItem item in GotItems)
            {
                player.GetItem(item);
            }
        }
    }

    //プレイヤーがその回数のガチャを回すことが出来るかどうか
    public bool CanRollGacha(int RollCount)
    {
        if (GetGachaCost(RollCount) > 0)
        {
            if(player?.Soul >= GetGachaCost(RollCount))
            {
                return true;
            }
        }

        return false;
    }
}

//各レアリティ毎の排出率
[Serializable]
public struct EmissionRateTable
{
    [Header("レアリティ")]
    public Rarity rarity;

    [Header("排出率")]
    public float EmissionRate;
}

//ガチャの回す回数に応じたコスト
[Serializable]
public struct GachaCostTable
{
    [Header("何連ガチャか")]
    public int RollCount;

    [Header("その回数のガチャを回すのにかかるコスト")]
    public int SoulCost;
}