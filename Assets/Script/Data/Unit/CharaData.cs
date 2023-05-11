using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharaData", menuName = "Scriptable Object/Chara Data", order = 2)]
public class CharaData : AbilityData
{
    [SerializeField]
    private Sprite face;
    public Sprite Face
    {
        get { return face; }
        set { face = value; }
    }

    [SerializeField]
    private Sprite standing;
    public Sprite Standing
    {
        get { return standing; }
        set { standing = value; }
    }

    [SerializeField]
    private List<SkillData> skilllist;
    public List<SkillData> SkillList
    {
        get { return skilllist; }
        set { skilllist = value; }
    }
}
