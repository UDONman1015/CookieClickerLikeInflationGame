using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

//�v���C���[�̏��
public class Player : MonoBehaviour
{
    //[SerializeField] ������ƃC���X�y�N�^�[����l��ҏW�\�ɂȂ�
    //private�ȕϐ��͊O���̃X�N���v�g����Q�Ƃ���Ȃ�

    //List:�����̗v�f���ЂƂ܂Ƃ߂Ƀ��X�g�������ϐ�
    [Header("�����K�`���A�C�e�����X�g")]
    public List<GachaItem> PossessionItems = new List<GachaItem>();

    //public�ϐ���[SerializeField]�����Ȃ��Ă��C���X�y�N�^�[����l��ҏW�\�ɂȂ�
    //int:����
    [Header("�����\�E��")]
    public int Soul = 0;

    [Header("1�N���b�N������̃\�E���l���ʂ̊�{�l")]
    [SerializeField] int BaseSoulPerClick = 1;

    [Header("�v���C���[���\��")]
    [SerializeField] PlayerUI playerUI;

    //�v���C���[�̏�����
    public void InitPlayer()
    {
        //�����K�`���A�C�e�����X�g����ɂ���
        PossessionItems = new List<GachaItem>();

        //�����\�E����0�ɂ���
        Soul = 0;

        //PlayerUI�����̃v���C���[���g�̏��ŏ�����
        playerUI?.InitPlayerUI(this);

        StartCoroutine(AddSoulPerSecondCoroutine());
    }

    //�����������X�g(�����K�`���A�C�e�����X�g�̒����瑕�������𒊏o)
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

    //�����{�݃��X�g���X�g(�����K�`���A�C�e�����X�g�̒����瑕�������𒊏o)
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


    //�v���C���[��1�N���b�N������̃\�E���l����
    public int SoulPerClick
    {
        get
        {
            float soulPerClick = BaseSoulPerClick;

            #region �����ɂ��␳
            foreach(Equipment equipment in Equipments)
            {
                soulPerClick = equipment.GetSoulPerClick(soulPerClick);
            }
            #endregion

            return (int)Math.Ceiling(soulPerClick);
        }
    }

    //�v���C���[��1�b������̃\�E���l����
    public int SoulPerSecond
    {
        get
        {
            float soulPerSecond = 0;

            #region �{�݂ɂ��␳
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

    //�\�E�����l������
    public void AddSoul(int soul)
    {
        this.Soul += soul;

        if(this.Soul <= 0)
        {
            this.Soul = 0;
        }
    }

    //�\�E��������
    public void LoseSoul(int soul)
    {
        AddSoul(-soul);
    }

    //�v���C���[��1�N���b�N������̃\�E���l���ʂ�^����
    public void AddSoul_Click()
    {
        AddSoul(SoulPerClick);
    }

    //�v���C���[��1�b������̃\�E���l���ʂ�^����
    public void AddSoul_PerSecond()
    {
        AddSoul(SoulPerSecond);
    }

    //���b�\�E����^����R���[�`��
    IEnumerator AddSoulPerSecondCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);

            AddSoul_PerSecond();
        }
    }

    //�K�`���A�C�e�����l������
    public void GetItem(GachaItem gachaItem)
    {
        PossessionItems.Add(gachaItem);

        Debug.Log($"{gachaItem.ItemName}���l�����܂���");
    }
}
