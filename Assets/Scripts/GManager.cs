using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲームマネージャ
public class GManager : MonoBehaviour
{
    [Header("プレイヤー")]
    public Player player;

    [Header("ガチャ")]
    public Gacha gacha;

    [Header("施設")]
    public FacilityManager facilityManager;

    //あんま気にしなくてよい(GManager.instanceと書けばここに書かれている情報を外部から取得できるようになる)
    public static GManager instance = null;

    //ゲーム開始時に自動的に1度だけ呼ばれる(Startより先)

    private void Awake()
    {
        instance = this;
    }

    //ゲーム開始時に自動的に1度だけ呼ばれる

    private void Start()
    {
        player.InitPlayer();
        gacha.InitGacha();
    }
}
