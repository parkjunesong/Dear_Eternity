using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSkill : BattleDB
{
    public static List<SkillData> Datas = new List<SkillData>();
    private GameObject ManaBoard;

    void Start()
    {
        ManaBoard = GameObject.Find("마나보드");
    }
    public void Skill1()
    {
        ManaBoard.GetComponent<ManaSet>().ManaCounting();
       
        if (enemy.SelectededEnemy != -1 && (ManaBoard.GetComponent<ManaSet>().ManaCount[0] >= Charactors[MainChara].Data.SkillList[0].Cost[0]) && (ManaBoard.GetComponent<ManaSet>().ManaCount[1] >= Charactors[MainChara].Data.SkillList[0].Cost[1]) && (ManaBoard.GetComponent<ManaSet>().ManaCount[2] >= Charactors[MainChara].Data.SkillList[0].Cost[2]))
        {
            DamageResult(Charactors[MainChara].Data.SkillList[0].Target, Charactors[MainChara].Data.SkillList[0].Damage * Charactors[MainChara].Data.AP);
            ManaBoard.GetComponent<ManaSet>().UseSkill(new int[3] { Charactors[MainChara].Data.SkillList[0].Cost[0], Charactors[MainChara].Data.SkillList[0].Cost[1], Charactors[MainChara].Data.SkillList[0].Cost[2] });

            TurnEnd();
        }      
    }

    public new void DamageResult(int target, float damage)
    {
        switch (target)
        {
            case (1)://전체공격
                {
                    for (int i = 0; i < Enemies.Count; i++)
                    {
                        if (Enemy_Ability[i].HP > 0)
                        {
                            Enemy_Ability[i].HP -= Mathf.RoundToInt(damage * (1 - Enemy_Ability[i].DP / 100));
                            GameObject.Find((i).ToString()).transform.Find("Canvas").transform.Find("HP").GetComponent<Slider>().value = (float)Enemy_Ability[i].HP / Enemies[i].Data.HP;
                        }
                        if (Enemy_Ability[i].HP <= 0)
                        {
                            Enemy_Ability[i].HP = 0;
                            Retire(i);
                            if (i == Enemies.Count - 1) return;
                        }
                    }
                    break;
                }
            case (2)://선택공격
                {
                    Enemy_Ability[enemy.SelectededEnemy].HP -= Mathf.RoundToInt(damage * (1 - Enemy_Ability[enemy.SelectededEnemy].DP / 100));
                    GameObject.Find(enemy.SelectededEnemy.ToString()).transform.Find("Canvas").transform.Find("HP").GetComponent<Slider>().value = (float)Enemy_Ability[enemy.SelectededEnemy].HP / Enemies[enemy.SelectededEnemy].Data.HP;

                    if (Enemy_Ability[enemy.SelectededEnemy].HP <= 0)
                    {
                        Enemy_Ability[enemy.SelectededEnemy].HP = 0;
                        Retire(enemy.SelectededEnemy);
                        return;
                    }
                    break;
                }
        }
    }

    public new void Retire(int i)
    {
        Debug.Log("D");
        Enemy_Ability[i].Name = "";
        Enemy_Ability[i].AP = 0;
        Enemy_Ability[i].HP = 0;
        Enemy_Ability[i].DP = 0;
        Enemy_Ability[i].Turn = 0;
        enemy.SelectededEnemy = -1;
        Destroy(GameObject.Find(i+""));
    }
}
