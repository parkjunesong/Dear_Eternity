using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScenarioData", menuName = "Scriptable Object/Scenario Data", order = 4000)]

public class ScenarioData : ScriptableObject
{
    [SerializeField]
    private int num; // 대사 개수
    public int Num { get { return num; } }
    [SerializeField]
    private string[] text;
    public string[] Text { get { return text; } }

    [SerializeField]
    private List<CharaTalkingData> charalist;
    public List<CharaTalkingData> CharaList { get { return charalist; } }

    [SerializeField]
    private MapData mapdata;
    public MapData Mapdata { get { return mapdata; } }
}
