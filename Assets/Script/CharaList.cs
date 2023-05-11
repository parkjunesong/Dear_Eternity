using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharaList : MonoBehaviour
{
    public static CharaSelectData SelectCharactor;
    public static CharaSelectData[] Charactors = new CharaSelectData[5];
    public static int mode;

    MapData MD;
    public GameObject CList;
    public GameObject Button;
    public GameObject infoButton;
    public Image SCstanding;
    public Text SCname;
    public Text buttonText;
    string[] pos = new string[5] { "Front", "Middle", "Back", "Support", "Support" };
    bool[] isLock = new bool[5] { false, false, false, false, false };
    public static bool crm = false; // 캐릭터 세팅된 맵인지 판단 여부

    public CharaData[] Team = new CharaData[5];

    void Start()
    {
        mode = -1;
        SelectCharactor = new CharaSelectData();

        if (crm == false)
        {
            for (int i = 0; i < 5; i++)
            {
                Charactors[i] = new CharaSelectData(Team[i].Name, Team[i].Type, Team[i].Level, Team[i].AP, Team[i].HP, Team[i].DP, pos[i], Team[i].Face, Team[i].Standing, Team[i].SkillList);             

                if (i < 3)
                {
                    GameObject.Find(i + "standing").GetComponent<Image>().sprite = Charactors[i].Standing;
                    GameObject.Find(i + "type").GetComponent<Image>().sprite = Resources.Load("Icon/" + Charactors[i].Type, typeof(Sprite)) as Sprite;
                    GameObject.Find(i + "lv").GetComponent<Text>().text = "Lv." + Charactors[i].Level;
                    GameObject.Find(i + "name").GetComponent<Text>().text = Charactors[i].Name;
                }
                else
                {
                    GameObject.Find(i + "face").GetComponent<Image>().sprite = Charactors[i].Face;
                    GameObject.Find(i + "type").GetComponent<Image>().sprite = Resources.Load("Icon/" + Charactors[i].Type, typeof(Sprite)) as Sprite;
                    GameObject.Find(i + "lv").GetComponent<Text>().text = "Lv." + Charactors[i].Level;
                    GameObject.Find(i + "name").GetComponent<Text>().text = Charactors[i].Name;
                }
            }
        }
        else
        {
            MD = map.Data;
            for (int i = 0; i < 5; i++)
            {
                Charactors[i] = new CharaSelectData(MD.Chara[i].Name, MD.Chara[i].Type, MD.Chara[i].Level, MD.Chara[i].AP, MD.Chara[i].HP, MD.Chara[i].DP, pos[i], MD.Chara[i].Face, MD.Chara[i].Standing, MD.Chara[i].SkillList);
                if (Charactors[i].Name != "SelectTeam")
                    isLock[i] = true;

                if (i < 3)
                {
                    GameObject.Find(i + "standing").GetComponent<Image>().sprite = Charactors[i].Standing;
                    GameObject.Find(i + "type").GetComponent<Image>().sprite = Resources.Load("Icon/" + Charactors[i].Type, typeof(Sprite)) as Sprite;
                    GameObject.Find(i + "lv").GetComponent<Text>().text = "Lv." + Charactors[i].Level;
                    GameObject.Find(i + "name").GetComponent<Text>().text = Charactors[i].Name;
                }
                else
                {
                    GameObject.Find(i + "face").GetComponent<Image>().sprite = Charactors[i].Face;
                    GameObject.Find(i + "type").GetComponent<Image>().sprite = Resources.Load("Icon/" + Charactors[i].Type, typeof(Sprite)) as Sprite;
                    GameObject.Find(i + "lv").GetComponent<Text>().text = "Lv." + Charactors[i].Level;
                    GameObject.Find(i + "name").GetComponent<Text>().text = Charactors[i].Name;
                }
            }
        }        
    }
    public void Back_List()
    {
        CList.SetActive(false);
    }
    public void SelectFront()
    {
        mode = 0;
    }
    public void SelectMiddle()
    {
        mode = 1;
    }
    public void SelectBack()
    {
        mode = 2;
    }
    public void SelectSup1()
    {
        mode = 3;
    }
    public void SelectSup2()
    {
        mode = 4;
    }
    public void Goto_List() // 반드시 Select_Position 실행 후 실행하기.
    {
        if (isLock[mode] == false)
            CList.SetActive(true);

        if(Charactors[mode].Name == "SelectTeam")
        {
            Button.SetActive(false);
            infoButton.SetActive(false);
            SCstanding.sprite = Resources.Load("Chara/default", typeof(Sprite)) as Sprite;
            SCname.text = "";
        }
        else
        {
            Button.SetActive(true);
            infoButton.SetActive(true);
            buttonText.text = "해제";
            SCstanding.sprite = Charactors[mode].Standing;
            SCname.text = Charactors[mode].Name;
        }
    }
    public void getInfo()
    {
        Button.SetActive(true);
        infoButton.SetActive(true);
        SCstanding.sprite = SelectCharactor.Standing;
        SCname.text = SelectCharactor.Name;

        if (Charactors[mode].Name == "SelectTeam")
            buttonText.text = "가입";
        else if (Charactors[mode].Name != SelectCharactor.Name)
            buttonText.text = "교체";
        else
            buttonText.text = "해제";
    }
    public void getTeam()
    {
        if (buttonText.text == "가입" || buttonText.text == "교체")
        {
            for (int i = 0; i < 3; i++)
            {
                if (mode == i)
                {
                    Charactors[i] = SelectCharactor;
                    GameObject.Find(i + "standing").GetComponent<Image>().sprite = Charactors[i].Standing;
                    GameObject.Find(i + "type").GetComponent<Image>().sprite = Resources.Load("Icon/" + Charactors[i].Type, typeof(Sprite)) as Sprite;
                    GameObject.Find(i + "lv").GetComponent<Text>().text = "Lv."+Charactors[i].Level;
                    GameObject.Find(i + "name").GetComponent<Text>().text = Charactors[i].Name;

                    /*
                    Team[i].Name = Charactors[i].Name;
                    Team[i].Type = Charactors[i].Type;
                    Team[i].Level = Charactors[i].Level;
                    Team[i].AP = Charactors[i].AP;
                    Team[i].HP = Charactors[i].HP;
                    Team[i].DP = Charactors[i].DP;
                    //Team[i].Position = Charactors[i].pos;
                    Team[i].Face = Charactors[i].Face;
                    Team[i].Standing = Charactors[i].Standing;
                    Team[i].SkillList = Charactors[i].SkillList;
                    */
                }           
                                                
            }
            for (int i = 3; i < 5; i++)
            {
                if (mode == i)
                {
                    Charactors[i] = SelectCharactor;
                    GameObject.Find(i + "face").GetComponent<Image>().sprite = Charactors[i].Face;
                    GameObject.Find(i + "type").GetComponent<Image>().sprite = Resources.Load("Icon/" + Charactors[i].Type, typeof(Sprite)) as Sprite;
                    GameObject.Find(i + "lv").GetComponent<Text>().text = "Lv." + Charactors[i].Level;
                    GameObject.Find(i + "name").GetComponent<Text>().text = Charactors[i].Name;
                }

            }
        }
        else if (buttonText.text == "해제")
        {
            for (int i = 0; i < 3; i++)
            {
                if (mode == i)
                {
                    Charactors[i] = new CharaSelectData();
                    GameObject.Find(i + "standing").GetComponent<Image>().sprite = Charactors[i].Standing;
                    GameObject.Find(i + "type").GetComponent<Image>().sprite = Resources.Load("Icon/" + Charactors[i].Type, typeof(Sprite)) as Sprite;
                    GameObject.Find(i + "lv").GetComponent<Text>().text = "";
                    GameObject.Find(i + "name").GetComponent<Text>().text = "";
                }
                                          
            }
            for (int i = 3; i < 5; i++)
            {
                if (mode == i)
                {
                    Charactors[i] = new CharaSelectData();
                    GameObject.Find(i + "face").GetComponent<Image>().sprite = Charactors[i].Face;
                    GameObject.Find(i + "type").GetComponent<Image>().sprite = Resources.Load("Icon/" + Charactors[i].Type, typeof(Sprite)) as Sprite;
                    GameObject.Find(i + "lv").GetComponent<Text>().text = "";
                    GameObject.Find(i + "name").GetComponent<Text>().text = "";
                }

            }
        }
        CList.SetActive(false);
    }
    public void BattleStart()
    {
        int a = 0;
        for(int i = 0; i < 5; i++)
        {
            if (Charactors[i].Name == "SelectTeam")
                break;
            a++;
        }
        if (a == 5)
        {
            SceneManager.LoadScene("battle");
        }
        else
            Debug.Log("팀을 전부 편성하시오");

    }

}
