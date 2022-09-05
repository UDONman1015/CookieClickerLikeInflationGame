using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//�K�`���{��
public class Gacha : MonoBehaviour
{
    //[SerializeField] ������ƃC���X�y�N�^�[����l��ҏW�\�ɂȂ�
    //private�ȕϐ��͊O���̃X�N���v�g����Q�Ƃ���Ȃ�

    [Header("�v���C���[")]
    [SerializeField] Player player;

    //List:�����̗v�f���ЂƂ܂Ƃ߂Ƀ��X�g�������ϐ�
    [Header("�K�`������r�o�����A�C�e�����X�g")]
    [SerializeField] private List<GachaItem> gachaItemList = new List<GachaItem>();

    [Header("�K�`���r�o���e�[�u�����X�g")]
    [SerializeField] private List<EmissionRateTable> EmissionRateTables = new List<EmissionRateTable>();

    [Header("�K�`���R�X�g�\")]
    public List<GachaCostTable> GachaCostTables = new List<GachaCostTable>();

    [Header("�K�`�����\��")]
    [SerializeField] GachaUI gachaUI;

    //�Q�[���J�n���Ɏ����I��1�x�����Ă΂��
    private void Start()
    {
        //GachaUI�����̃K�`�����g�̏��ŏ�����
        gachaUI?.InitGachaUI(this);
    }

    //�w�肳�ꂽ�A�C�e���̔r�o�����K�`���r�o���e�[�u�����X�g����Z�o
    public float GetEmissionRate(GachaItem gachaItem)
    {
        float emissionRate = 0f;

        //�K�`���r�o���e�[�u�����X�g�̑S�v�f��T�����Ďw�肳�ꂽ�A�C�e���̃��A���e�B�Ɠ������A���e�B�̔r�o���������v�f��T��
        foreach (EmissionRateTable emissionRateTable in EmissionRateTables)
        {
            if(emissionRateTable.rarity == gachaItem.ITemRarity)
            {
                emissionRate = emissionRateTable.EmissionRate;
            }
        }

        #region �A�C�e�����Ƃɓ���Ȕr�o����ݒ肵�����ꍇ�͕ʓr�ʂɐݒ�
        #endregion

        return emissionRate;
    }

    //�w�肵���񐔂̃K�`�����񂷂̂ɕK�v�ȃR�X�g
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

    //�w�肳�ꂽ�񐔂����K�`������
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

    //�v���C���[�����̉񐔂̃K�`�����񂷂��Ƃ��o���邩�ǂ���
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

//�e���A���e�B���̔r�o��
[Serializable]
public struct EmissionRateTable
{
    [Header("���A���e�B")]
    public Rarity rarity;

    [Header("�r�o��")]
    public float EmissionRate;
}

//�K�`���̉񂷉񐔂ɉ������R�X�g
[Serializable]
public struct GachaCostTable
{
    [Header("���A�K�`����")]
    public int RollCount;

    [Header("���̉񐔂̃K�`�����񂷂̂ɂ�����R�X�g")]
    public int SoulCost;
}