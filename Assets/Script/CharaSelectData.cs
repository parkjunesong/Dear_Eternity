using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSelectData
{
    public string Name;
    public string Type;
    public int Level;
    public int AP;
    public int HP;
    public float DP;
    public string Position;
    public Sprite Face;
    public Sprite Standing;
    public List<SkillData> SkillList;

    public CharaSelectData()
    {
        Name = "SelectTeam";
        Type = "";
        Level = 0;
        AP = 0;
        HP = 0;
        DP = 0;
        Position = "";
        Face = Resources.Load("Face/default", typeof(Sprite)) as Sprite;
        Standing = Resources.Load("Chara/default", typeof(Sprite)) as Sprite;
        //skilllist
    }
    public CharaSelectData(string _name, string _type, int _level, int _ap, int _hp, float _dp, string _pos, Sprite _face, Sprite _standing, List<SkillData> _skillList)
    {
        Name = _name;
        Type = _type;
        Level = _level;
        AP = _ap;
        HP = _hp;
        DP = _dp;
        Position = _pos;
        Face = _face;
        Standing = _standing;
        SkillList = _skillList;
    }
}
