using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Object/Skill Data", order = 2000)]
public class SkillData : ScriptableObject
{
    [SerializeField]
    private string skilltype;
    public string SkillType { get { return skilltype; } }
    [SerializeField]
    private new string name;
    public string Name { get { return name; } }
    [SerializeField]
    private int[] cost;
    public int[] Cost { get { return cost; } }
    [SerializeField]
    private int target;
    public int Target { get { return target; } }



    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }
    [SerializeField]
    private int ac; // attack count
    public int AC { get { return ac; } }
}
