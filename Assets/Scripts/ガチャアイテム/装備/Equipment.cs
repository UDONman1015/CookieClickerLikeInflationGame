using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����
//GachaItem���p�����K�`������r�o�����A�C�e���̈��ł���

public class Equipment : GachaItem
{
    //�O���̃X�N���v�g����\�E���l���ʂ��v�Z���邽�߂�public���\�b�h(�������ƂɃ\�E���l���ʂ��Z�o������@���قȂ�ꍇ��z�肵�Čʂɐݒ�o����悤�ɂ��Ă���)
    public virtual float GetSoulPerClick(float SoulPerClick)
    {
        return SoulPerClick;
    }
}

