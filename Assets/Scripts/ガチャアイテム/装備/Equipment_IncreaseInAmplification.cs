using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1�N���b�N������̃\�E���l���ʂ���芄���ő��������鑕��
//Equipment���p���������̈��ł���
[CreateAssetMenu(menuName = "Create/�K�`���A�C�e��/����/��芄����������", fileName = "��芄����������")]
public class Equipment_IncreaseInAmplification : Equipment
{
    //[SerializeField] ������ƃC���X�y�N�^�[����l��ҏW�\�ɂȂ�
    //private�ȕϐ��͊O���̃X�N���v�g����Q�Ƃ���Ȃ�

    //float:����
    [Header("1�N���b�N������̃\�E���l���ʂ𑝉������銄��")]
    [SerializeField] private float increaseSoulPerClickAmplificationk;

    //�p�����̊֐���overrider���Ĉ�芄���ŕω�������悤�ɑΉ�
    public override float GetSoulPerClick(float SoulPerClick)
    {
        return SoulPerClick * (1 + increaseSoulPerClickAmplificationk);
    }
}