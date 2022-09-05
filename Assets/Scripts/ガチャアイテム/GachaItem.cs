using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�K�`������r�o�����A�C�e��
public class GachaItem : ScriptableObject
{
    //[SerializeField] ������ƃC���X�y�N�^�[����l��ҏW�\�ɂȂ�
    //private�ȕϐ��͊O���̃X�N���v�g����Q�Ƃ���Ȃ�

    //Rarity:N�`UR�̂����ꂩ�̒l
    [Header("�A�C�e���̃��A���e�B")]
    [SerializeField] private Rarity itemRarity;

    //�O���̃X�N���v�g����Q�Ƃ����p��public�ϐ�(�v���p�e�B)
    public Rarity ITemRarity { get { return itemRarity; } }
    public string ItemName { get { return this.name; } }
}

//enum�͗񋓂��ꂽ�l�̂����A�K�������ꂩ��̒l�����
public enum Rarity
{
    N,
    HN,
    R,
    SR,
    SSR,
    UR,
}
