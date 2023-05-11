using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "Scriptable Object/Map Data", order = 1000)]
public class MapData : ScriptableObject
{
    [SerializeField]
    private new string name;
    public string Name { get { return name; } }

    [SerializeField]
    private bool crm;
    public bool CharaReadyMap { get { return crm; } }

    [SerializeField]
    private CharaData[] chara;
    public CharaData[] Chara
    {
        get { return chara; }
        set { chara = value; }
    }

    [SerializeField]
    private EnemyData[] enemy;
    public EnemyData[] Enemy { get { return enemy; } }
    
}
