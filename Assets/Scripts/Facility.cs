using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�{��
[CreateAssetMenu(menuName = "Create/�{��", fileName = "�{��")]
public class Facility : GachaItem
{
    //[SerializeField] ������ƃC���X�y�N�^�[����l��ҏW�\�ɂȂ�
    //private�ȕϐ��͊O���̃X�N���v�g����Q�Ƃ���Ȃ�

    //float:����
    [Header("�P�ʎ��ԓ�����̃\�E���l����")]
    [SerializeField] private float soulPerSecond;

    [Header("�w���R�X�g")]
    [SerializeField] private float initialPurchaseCost;

    //�O���̃X�N���v�g����Q�Ƃ����p��public�ϐ�(�v���p�e�B)
    public float SoulPerSecond { get { return soulPerSecond; } }
    public float InitialPurchaseCost { get { return initialPurchaseCost; } }
}
