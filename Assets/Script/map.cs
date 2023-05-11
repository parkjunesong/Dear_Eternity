using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public static MapData Data;
    void Awake()
    {
        gameObject.GetComponent<SpawnUnit>().Wave = Data.Enemy;
        gameObject.GetComponent<SpawnUnit>().Team = CharaList.Charactors;        
        gameObject.GetComponent<SpawnUnit>().Spawn();
        gameObject.GetComponent<BattleDB>().BattleSet();
    }
}
