using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectChara : MonoBehaviour
{
    public CharaData Data;
    string[] pos = new string[5] { "Front", "Middle", "Back", "Support", "Support" };

    void Start()
    {
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Data.Face;
        gameObject.transform.GetChild(2).GetComponent<Text>().text = "Lv." + Data.Level;
        gameObject.transform.GetChild(3).GetComponent<Image>().sprite = Resources.Load("Icon/" + Data.Type, typeof(Sprite)) as Sprite;
    }
    public void Select()
    {
        for(int i = 0; i < 5; i++)
        {
            if (CharaList.mode == i)
            {
                CharaList.SelectCharactor = new CharaSelectData(Data.Name, Data.Type, Data.Level, Data.AP, Data.HP, Data.DP, pos[i], Data.Face, Data.Standing, Data.SkillList);

                GameObject.Find("GameObject").GetComponent<CharaList>().getInfo();
            }
        }      
    }   
}
