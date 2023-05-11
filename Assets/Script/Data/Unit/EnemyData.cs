using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Object/Enemy Data", order = 3)]
public class EnemyData : AbilityData
{   
    [SerializeField]
    private int turn;
    public int Turn { get { return turn; } }
    [SerializeField]
    private SkillData attack;
    public SkillData Attack { get { return attack; } }
}
