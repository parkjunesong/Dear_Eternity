using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chara : MonoBehaviour
{
    [SerializeField]
    private CharaSelectData data;
    public CharaSelectData Data
    {
        get { return data; }
        set { data = value; }
    }
}
