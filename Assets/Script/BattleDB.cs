using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EAbility
{
    public string Name;
    public int AP;
    public int HP;
    public float DP;
    public int Turn;

    public EAbility(string _name, int _ap, int _hp, float _dp, int _turn)
    {
        Name = _name;
        AP = _ap;
        HP = _hp;
        DP = _dp;
        Turn = _turn;
    }
}
public class CAbility
{
    public string Name;
    public int AP;
    public int HP;
    public float DP;

    public CAbility(string _name, int _ap, int _hp, float _dp)
    {
        Name = _name;
        AP = _ap;
        HP = _hp;
        DP = _dp;
    }
}

public class BattleDB : MonoBehaviour
{ 
    public static List<enemy> Enemies = new List<enemy>();
    public static EAbility[] Enemy_Ability = new EAbility[10];
    public static List<chara> Charactors = new List<chara>();
    public static CAbility[] Charactor_Ability = new CAbility[3];
    public static int Turn = 1;
    public static int MainChara = 0;

    public void BattleSet()
    {
        for(int i = 0; i < Enemies.Count; i++)
        {
            Enemy_Ability[i] = new EAbility(Enemies[i].Data.Name, Enemies[i].Data.AP, Enemies[i].Data.HP, Enemies[i].Data.DP, Enemies[i].Data.Turn);
        }
        for (int i = 0; i < Charactors.Count; i++)
        {
            Charactor_Ability[i] = new CAbility(Charactors[i].Data.Name, Charactors[i].Data.AP, Charactors[i].Data.HP, Charactors[i].Data.DP);
        }
    }
    public void TurnEnd()
    {
        Turn++;
        GameObject.Find("Turn").GetComponent<Text>().text = Turn + " Turn";

        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemy_Ability[i].HP > 0)  // 스폰된 적이 살아있다면
            {

                Enemy_Ability[i].Turn--;
                GameObject.Find(i.ToString()).transform.Find("Canvas").transform.Find("Enemy_Turn").GetComponent<Text>().text = Enemy_Ability[i].Turn.ToString();

                if (Enemy_Ability[i].Turn == 0) GameObject.Find((i).ToString()).transform.Find("Canvas").transform.Find("Panel").GetComponent<Image>().color = new Color(255 / 255f, 130 / 255f, 130 / 255f, 255 / 255f);
                if (Enemy_Ability[i].Turn == -1)
                {
                    DamageResult(Enemies[i].Data.Attack.Target, Enemies[i].Data.Attack.Damage * Enemies[i].Data.AP);
                    Enemy_Ability[i].Turn = Enemies[i].Data.Turn;
                    GameObject.Find(i.ToString()).transform.Find("Canvas").transform.Find("Enemy_Turn").GetComponent<Text>().text = Enemy_Ability[i].Turn.ToString();
                    GameObject.Find((i).ToString()).transform.Find("Canvas").transform.Find("Panel").GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
                }
            }          
        }
    }
    public void DamageResult(int target, float damage)
    {
        switch (target)
        {
            case (1)://전체공격
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Charactor_Ability[i].HP -= Mathf.RoundToInt(damage * (1 - Charactor_Ability[i].DP / 100));
                        GameObject.Find("Chara_" + i).transform.Find("Canvas").transform.Find("HP").GetComponent<Slider>().value = (float)Charactor_Ability[i].HP / Charactors[i].Data.HP;                      
                        if (Charactor_Ability[i].HP <= 0)
                        {
                            Charactor_Ability[i].HP = 0;
                            Retire(i);
                            return;
                        }
                    }
                    break;
                }
            case (2)://선봉공격
                {
                    Charactor_Ability[MainChara].HP -= Mathf.RoundToInt(damage * (1 - Charactor_Ability[MainChara].DP / 100));
                    GameObject.Find("Chara_" + MainChara).transform.Find("Canvas").transform.Find("HP").GetComponent<Slider>().value = (float)Charactor_Ability[MainChara].HP / Charactors[MainChara].Data.HP;

                    if (Charactor_Ability[MainChara].HP <= 0)
                    {
                        Charactor_Ability[MainChara].HP = 0;
                        Retire(MainChara);
                        return;
                    }
                    break;
                }
        }
        
    }
    public void Retire(int num) 
    {
        GameObject.Find("Chara_"+num).GetComponent<SpriteRenderer>().sprite = Resources.Load("Chara/사망", typeof(Sprite)) as Sprite; 
    }

}
