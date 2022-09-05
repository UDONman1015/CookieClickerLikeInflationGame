using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1�N���b�N������̃\�E���l���ʂ����ʑ��������鑕��
//Equipment���p���������̈��ł���
[CreateAssetMenu(menuName = "Create/�K�`���A�C�e��/����/���ʋ�������", fileName = "���ʋ�������")]
public class Equipment_IncreaseInFixedAmount : Equipment
{
    //[SerializeField] ������ƃC���X�y�N�^�[����l��ҏW�\�ɂȂ�
    //private�ȕϐ��͊O���̃X�N���v�g����Q�Ƃ���Ȃ�

    //float:����
    [Header("1�N���b�N������̃\�E���l���ʂ̑�����")]
    [SerializeField] private float increaseSoulPerClickAmount;

    //�p�����̊֐���overrider���Ĉ��ʕω�������悤�ɑΉ�
    public override float GetSoulPerClick(float SoulPerClick)
    {
        return SoulPerClick + increaseSoulPerClickAmount;
    }
}
