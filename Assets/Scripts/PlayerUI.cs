using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
//�v���C���[�̏���UI�ɕ\��
public class PlayerUI : MonoBehaviour
{
    //[SerializeField] ������ƃC���X�y�N�^�[����l��ҏW�\�ɂȂ�
    //private�ȕϐ��͊O���̃X�N���v�g����Q�Ƃ���Ȃ�

    //Text:�e�L�X�g�\��UI
    [Header("�����\�E���\���e�L�X�g")]
    [SerializeField] Text SoulText;

    [Header("1�b������̃\�E���l���ʕ\���e�L�X�g")]
    [SerializeField] Text SoulPerSecondText;

    [Header("�����A�C�e���e�L�X�g")]
    [SerializeField] Text PossessionItemText;

    //�\������v���C���[�̏��
    private Player player;

    //�v���C���[�̏���^���ď�����
    public void InitPlayerUI(Player player)
    {
        this.player = player;
    }

    //�v���C���[�̏���UI�ɔ��f
    void ShowPlayerInfo()
    {
        //�v���C���[�̏�񂪃Z�b�g����Ă���Ε\��
        if(player != null)
        {
            SoulText.text = $"{player.Soul}�\�E��";
            SoulPerSecondText.text = $"{player.SoulPerSecond}�\�E��/s";

            PossessionItemText.text = "�E�����A�C�e��";

            //�v���C���[�̃A�C�e�����X�g���d���Ȃ����X�g�ɂ��ăR�s�[
            List<GachaItem> DistinctPossessionItemss = player.PossessionItems.Distinct().ToList();

            //�������ɗ�
            foreach (GachaItem item in DistinctPossessionItemss)
            {
                if(item is Equipment)
                {
                    if (player.Equipments.Contains((Equipment)item))
                    {
                        PossessionItemText.text += $"\n{item.ItemName}�~{player.PossessionItems.Count((_item) => _item.ItemName == item.ItemName)}";
                    }
                }
            }

            //�����ȊO�̃A�C�e�����
            foreach (GachaItem item in DistinctPossessionItemss)
            {
                if (!(item is Equipment))
                {
                    PossessionItemText.text += $"\n{item.ItemName}�~{player.PossessionItems.Count((_item) => _item.ItemName == item.ItemName)}";
                }
            }
        }


        //�v���C���[�̏�񂪃Z�b�g����Ă��Ȃ���Δ�\��
        else
        {
            SoulText.text = "";
            SoulPerSecondText.text = "";
            PossessionItemText.text = "";
        }
    }

    //�����I�ɖ��t���[���Ă΂��֐�
    private void Update()
    {
        //���t���[�������I�Ƀv���C���[�̏���UI�ɔ��f
        ShowPlayerInfo();
    }
}
