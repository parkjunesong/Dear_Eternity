using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", menuName = "Scriptable Object/Ability Data", order = 1)]
public class AbilityData : ScriptableObject
{
    [SerializeField]
    private new string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    [SerializeField]
    private string type;
    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    [SerializeField]
    private int level;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    [SerializeField]
    private int ap;
    public int AP 
    { 
        get { return ap; }
        set { ap = value; }
    }

    [SerializeField]
    private int hp;
    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }

    [SerializeField]
    private float dp;
    public float DP
    {
        get { return dp; }
        set { dp = value; }
    }
}
