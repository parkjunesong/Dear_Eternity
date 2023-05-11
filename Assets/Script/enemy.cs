using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public static int SelectededEnemy = 0;

    [SerializeField]
    private EnemyData data;
    public EnemyData Data
    {
        get { return data; }
        set { data = value; } 
    }   

    void OnMouseUp()
    {
        SelectededEnemy = int.Parse(gameObject.name);       
    }
}
