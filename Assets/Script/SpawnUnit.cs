using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour
{ 
    [SerializeField]
    private EnemyData[] wave;
    public EnemyData[] Wave { set { wave = value; } }

    [SerializeField]
    private CharaSelectData[] team;
    public CharaSelectData[] Team 
    {
        get { return team; }
        set { team = value; } 
    }

    [SerializeField]
    private GameObject EPrefab;
    [SerializeField]
    private GameObject CPrefab;

    public void Spawn()
    {
        for (int i = 0; i < wave.Length; i++)
        {
            SpawnEnemy(i);            
        }
        for (int i = 0; i < team.Length; i++)
        {
            SpawnChara(i);
        }
    }

    public enemy SpawnEnemy(int i)
    {
        var newEnemy = Instantiate(EPrefab, new Vector3(200+300 * i, 1220, 0), Quaternion.identity).GetComponent<enemy>();
        newEnemy.Data = wave[i];
        newEnemy.GetComponent<SpriteRenderer>().sprite = Resources.Load("Enemy/" + wave[i].Name, typeof(Sprite)) as Sprite;
        newEnemy.gameObject.AddComponent<BoxCollider2D>();
        newEnemy.gameObject.name = i+"";
        BattleDB.Enemies.Add(newEnemy);
        return newEnemy;
    }
    public chara SpawnChara(int i)
    {
        var newChara = Instantiate(CPrefab, new Vector3(-200 + -300 * i, 1220, 0), Quaternion.identity).GetComponent<chara>();
        newChara.Data = team[i];        
        newChara.GetComponent<SpriteRenderer>().sprite = Resources.Load("Chara/" + team[i].Name, typeof(Sprite)) as Sprite;
        newChara.gameObject.AddComponent<BoxCollider2D>();
        newChara.gameObject.name = "Chara_" + i;
        BattleDB.Charactors.Add(newChara);
        for (int ii = 0; ii < newChara.Data.SkillList.Count; ii++) UseSkill.Datas.Add(newChara.Data.SkillList[ii]);
        return newChara;
    }
}