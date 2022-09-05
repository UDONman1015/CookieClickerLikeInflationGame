using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
//�K�`���̏���UI�ɕ\��
public class GachaUI : MonoBehaviour
{
    //[SerializeField] ������ƃC���X�y�N�^�[����l��ҏW�\�ɂȂ�
    //private�ȕϐ��͊O���̃X�N���v�g����Q�Ƃ���Ȃ�

    //�K�`�����񂷃{�^���̐e
    [SerializeField] Transform GachaButtonsParent;

    //�\������K�`���̏��
    private Gacha gacha;

    //�K�`�����񂷃{�^�����X�g
    List<Button> RollGachaButtons = new List<Button>();

    //�K�`���̏���^���ď�����
    public void InitGachaUI(Gacha gacha)
    {
        this.gacha = gacha;

        //�K�`���̃K�`���R�X�g�\���A��]�������Ȃ����ɕ��ёւ�
        gacha.GachaCostTables = gacha.GachaCostTables.OrderBy((gachaCostTable) => gachaCostTable.RollCount).ToList();

        for (int i=0;i<gacha.GachaCostTables.Count;i++)
        {
            if(i < GachaButtonsParent.childCount)
            {
                Button button = GachaButtonsParent.GetChild(i).GetComponent<Button>();

                if(button != null)
                {
                    GachaCostTable gachaCostTable = gacha.GachaCostTables[i];

                    button.transform.GetChild(0).GetComponent<Text>().text = $"{gachaCostTable.RollCount}�A�K�`��({gachaCostTable.SoulCost})";
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

    //�K�`���̏���UI�ɔ��f
    void ShowGachaInfo()
    {
        //�K�`���̏�񂪃Z�b�g����Ă���Ε\��
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

        //�K�`���̏�񂪃Z�b�g����Ă��Ȃ���Δ�\��
        else
        {
            GachaButtonsParent.gameObject.SetActive(false);
        }
    }

    //�����I�ɖ��t���[���Ă΂��֐�
    private void Update()
    {
        //���t���[�������I�Ƀv�K�`���̏���UI�ɔ��f
        ShowGachaInfo();
    }
}
