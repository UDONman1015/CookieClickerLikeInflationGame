using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
//プレイヤーの情報をUIに表示
public class PlayerUI : MonoBehaviour
{
    //[SerializeField] を入れるとインスペクターから値を編集可能になる
    //privateな変数は外部のスクリプトから参照されない

    //Text:テキスト表示UI
    [Header("所持ソウル表示テキスト")]
    [SerializeField] Text SoulText;

    [Header("1秒あたりのソウル獲得量表示テキスト")]
    [SerializeField] Text SoulPerSecondText;

    [Header("所持アイテムテキスト")]
    [SerializeField] Text PossessionItemText;

    [Header("クリック時に追加ソウルを表示するオブジェクトのプレハブ")]
    [SerializeField] OnClickSoulButtonObject OnClickSoulButtonObjectPrefab;

    [Header("親キャンバス")]
    [SerializeField] Canvas canvas;

    [Header("カメラ")]
    [SerializeField] Camera MainCamera;

    //表示するプレイヤーの情報
    private Player player;

    //プレイヤーの情報を与えて初期化
    public void InitPlayerUI(Player player)
    {
        this.player = player;
    }

    //プレイヤーの情報をUIに反映
    void ShowPlayerInfo()
    {
        //プレイヤーの情報がセットされていれば表示
        if(player != null)
        {
            SoulText.text = $"{player.Soul}ソウル";
            SoulPerSecondText.text = $"{player.SoulPerSecond}ソウル/s";

            PossessionItemText.text = "・所持アイテム";

            //プレイヤーのアイテムリストを重複なしリストにしてコピー
            player.PossessionItems = player.PossessionItems.OrderBy((gachaItem) => (int)gachaItem.ITemRarity).ToList();
            List <GachaItem> DistinctPossessionItemss = player.PossessionItems.Distinct().ToList();

            //施設を列挙
            foreach (GachaItem item in DistinctPossessionItemss)
            {
                if (item is Facility)
                {
                    if (player.PossessionFacilities.Contains((Facility)item))
                    {
                        PossessionItemText.text += $"\n{item.ItemName}×{player.PossessionItems.Count((_item) => _item.ItemName == item.ItemName)}";
                    }
                }
            }

            //装備を列挙
            foreach (GachaItem item in DistinctPossessionItemss)
            {
                if (item is Equipment)
                {
                    if (player.Equipments.Contains((Equipment)item))
                    {
                        PossessionItemText.text += $"\n{item.ItemName}×{player.PossessionItems.Count((_item) => _item.ItemName == item.ItemName)}";
                    }
                }
            }

            //施設・装備以外のアイテムを列挙
            foreach (GachaItem item in DistinctPossessionItemss)
            {
                if (!(item is Equipment) && !(item is Facility))
                {
                    PossessionItemText.text += $"\n{item.ItemName}×{player.PossessionItems.Count((_item) => _item.ItemName == item.ItemName)}";
                }
            }
        }

        //プレイヤーの情報がセットされていなければ非表示
        else
        {
            SoulText.text = "";
            SoulPerSecondText.text = "";
            PossessionItemText.text = "";
        }
    }

    //自動的に毎フレーム呼ばれる関数
    private void Update()
    {
        //毎フレーム自動的にプレイヤーの情報をUIに反映
        ShowPlayerInfo();
    }

    //クリック時に獲得ソウル量を表示するオブジェクトを生成
    public void CreateOnClickSoulButtonObject()
    {
        OnClickSoulButtonObject onClickSoulButtonObject = Instantiate(OnClickSoulButtonObjectPrefab, canvas.transform);

        onClickSoulButtonObject.transform.localPosition = GetLocalPosition(Input.mousePosition, canvas.transform);

        onClickSoulButtonObject.Init(player.SoulPerClick);
    }

    //マウス座標をキャンバスのローカル座標に変換
    public Vector3 GetLocalPosition(Vector3 position, Transform transform)
    {
        if (MainCamera != null)
        {
            // Converts coordinates on the screen (Screen Point) to local coordinates on the RectTransform
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform.GetComponent<RectTransform>(),
                position,
                MainCamera,
                out var result);
            return new Vector3(result.x, result.y, 0);
        }

        return Vector3.zero;

    }
}
