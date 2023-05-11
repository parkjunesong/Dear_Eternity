using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : BattleDB
{
    void Start()
    {
        //GameObject.Find("BattleMap���").GetComponent<SpriteRenderer>().sprite = Resources.Load("Background/" + "���1", typeof(Sprite)) as Sprite;

        GameObject.Find("��ų1").GetComponentsInChildren<Image>()[1].sprite = Resources.Load("Icon/" + Charactor_Ability[MainChara].Name + "_��ų1", typeof(Sprite)) as Sprite;
        GameObject.Find("��ų2").GetComponentsInChildren<Image>()[1].sprite = Resources.Load("Icon/" + Charactor_Ability[MainChara].Name + "_��ų2", typeof(Sprite)) as Sprite;
        GameObject.Find("��ų3").GetComponentsInChildren<Image>()[1].sprite = Resources.Load("Icon/" + Charactor_Ability[MainChara].Name + "_��ų3", typeof(Sprite)) as Sprite;
        GameObject.Find("FrontCG").GetComponent<Image>().sprite = Resources.Load("Chara/" + Charactor_Ability[MainChara].Name, typeof(Sprite)) as Sprite;
        for (int i = 0; i < Enemies.Count; i++) GameObject.Find(i.ToString()).transform.Find("Canvas").transform.Find("Enemy_Turn").GetComponent<Text>().text = Enemy_Ability[i].Turn.ToString();
    }

    public void �����̼�()
    {
        while (true)
        {
            MainChara++;
            if (MainChara == 3) MainChara = 0;
            if (Charactor_Ability[MainChara].HP != 0)
                break;
        }
        if (MainChara == 0)
        {
            GameObject.Find("Chara_0").transform.position = new Vector3(-200, 1220, 0);
            GameObject.Find("Chara_1").transform.position = new Vector3(-500, 1220, 0);
            GameObject.Find("Chara_2").transform.position = new Vector3(-800, 1220, 0);
        }
        else if (MainChara == 1)
        {
            
            GameObject.Find("Chara_1").transform.position = new Vector3(-200, 1220, 0);
            GameObject.Find("Chara_2").transform.position = new Vector3(-500, 1220, 0);
            GameObject.Find("Chara_0").transform.position = new Vector3(-800, 1220, 0);
        }
        else if (MainChara == 2)
        {            
            GameObject.Find("Chara_2").transform.position = new Vector3(-200, 1220, 0);
            GameObject.Find("Chara_0").transform.position = new Vector3(-500, 1220, 0);
            GameObject.Find("Chara_1").transform.position = new Vector3(-800, 1220, 0);
        }



        GameObject.Find("��ų1").GetComponentsInChildren<Image>()[1].sprite = Resources.Load("Icon/" + Charactor_Ability[MainChara].Name + "_��ų1", typeof(Sprite)) as Sprite;
        GameObject.Find("��ų2").GetComponentsInChildren<Image>()[1].sprite = Resources.Load("Icon/" + Charactor_Ability[MainChara].Name + "_��ų2", typeof(Sprite)) as Sprite;
        GameObject.Find("��ų3").GetComponentsInChildren<Image>()[1].sprite = Resources.Load("Icon/" + Charactor_Ability[MainChara].Name + "_��ų3", typeof(Sprite)) as Sprite;
        GameObject.Find("FrontCG").GetComponent<Image>().sprite = Resources.Load("Chara/" + Charactor_Ability[MainChara].Name, typeof(Sprite)) as Sprite;

        GameObject.Find("��������").GetComponent<ManaSet>().ManaReset();


        TurnEnd();       
    }
}
