using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�{�݉����
//GachaItem���p�����K�`������r�o�����A�C�e���̈��ł���
[CreateAssetMenu(menuName = "Create/�K�`���A�C�e��/�{�݉����", fileName = "�{�݉����")]
public class FacilityRelaseTicket : GachaItem
{
    //[SerializeField] ������ƃC���X�y�N�^�[����l��ҏW�\�ɂȂ�
    //private�ȕϐ��͊O���̃X�N���v�g����Q�Ƃ���Ȃ�

    //Rarity:N�`UR�̂����ꂩ�̒l
    [Header("���̃A�C�e���ŉ���ł���{��")]
    [SerializeField] private Facility targetFacility;

    //�O���̃X�N���v�g����Q�Ƃ����p��public�ϐ�(�v���p�e�B)
    public Facility TargetFacility { get { return targetFacility; } }
}
