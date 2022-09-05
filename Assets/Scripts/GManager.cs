using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Q�[���}�l�[�W��
public class GManager : MonoBehaviour
{
    [Header("�v���C���[")]
    public Player player;

    [Header("�K�`��")]
    public Gacha gacha;

    [Header("�{��")]
    public FacilityManager facilityManager;

    //����܋C�ɂ��Ȃ��Ă悢(GManager.instance�Ə����΂����ɏ�����Ă�������O������擾�ł���悤�ɂȂ�)
    public static GManager instance = null;

    //�Q�[���J�n���Ɏ����I��1�x�����Ă΂��(Start����)

    private void Awake()
    {
        instance = this;
    }

    //�Q�[���J�n���Ɏ����I��1�x�����Ă΂��

    private void Start()
    {
        player.InitPlayer();
        gacha.InitGacha();
    }
}
