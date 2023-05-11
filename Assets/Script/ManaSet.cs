using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaSet : MonoBehaviour
{
    public int[] ManaCount = new int[4] { 0, 0, 0, 0 }; // 마나, 프라나, 카르트, 비활성
    public int[] ManaType = new int[10];
    public int[] ManaPrev = new int[10];


    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            gameObject.GetComponentsInChildren<Image>()[i + 1].sprite = Resources.Load("마나", typeof(Sprite)) as Sprite;
            ManaType[i] = 1;
        }
        for (int i = 5; i < 10; i++)
        {
            gameObject.GetComponentsInChildren<Image>()[i + 1].sprite = Resources.Load("프라나", typeof(Sprite)) as Sprite;
            ManaType[i] = 2;
        }
    }
    public void ManaCounting()
    {
        int[] ma = new int[4] { 0, 0, 0, 0 };
        for (int i = 0; i < 10; i++)
        {
            if (ManaType[i] == 1) ma[0]++;
            else if (ManaType[i] == 2) ma[1]++;
            else if (ManaType[i] == 3) ma[2]++;
            else if (ManaType[i] == -1) ma[3]++;
        }
        for (int i = 0; i < 4; i++)
        {
            ManaCount[i] = ma[i];
        }
    }   
    public void ManaCreate(int mode)
    {
        switch (mode)
        {
            case (1)://마나
                {
                    int ran = Random.Range(0, 10);
                    if (ManaType[ran] == 1) ManaCreate(1);//같은 종류의 마나 자리에 재생성 방지                
                    else
                    {
                        gameObject.GetComponentsInChildren<Image>()[ran + 1].sprite = Resources.Load("마나", typeof(Sprite)) as Sprite;
                        ManaType[ran] = 1;
                    }
                    break;
                }
            case (2)://프라나
                {
                    int ran = Random.Range(0, 10);
                    if (ManaType[ran] == 2) ManaCreate(2);//같은 종류의 마나 자리에 재생성 방지                  
                    else
                    {
                        gameObject.GetComponentsInChildren<Image>()[ran + 1].sprite = Resources.Load("프라나", typeof(Sprite)) as Sprite;
                        ManaType[ran] = 2;
                    }
                    break;
                }
            case (3)://카르트
                {
                    int ran = Random.Range(0, 10);
                    if (ManaType[ran] == 3) ManaCreate(3);//같은 종류의 마나 자리에 재생성 방지              
                    else
                    {
                        gameObject.GetComponentsInChildren<Image>()[ran + 1].sprite = Resources.Load("카르트", typeof(Sprite)) as Sprite;
                        ManaType[ran] = 3;
                    }
                    break;
                }
        }
    }
    public void ManaDelete(int[] target) // prev를 기록하지 않는 단순 삭제
    {
        int[] goal = new int[3] { 0, 0, 0 };

        for (int i = 0; i < 10; i++)
        {
            for (int ii = 0; ii < 3; ii++)
            {
                if (ManaType[i] == ii+1 && goal[ii] < target[ii])
                {
                    gameObject.GetComponentsInChildren<Image>()[i + 1].sprite = Resources.Load("비활성", typeof(Sprite)) as Sprite;
                    ManaType[i] = -1;

                    goal[ii]++;
                    break;
                }
                if (goal[0] >= target[0] && goal[1] >= target[1] && goal[2] >= target[2])
                    return;
            }
        }
    }
    public void UseSkill(int[] target) // prev를 기록함.
    {
        int[] goal = new int[3] { 0, 0, 0 };

        for (int i = 0; i < 10; i++)
        {
            for (int ii = 0; ii < 3; ii++)
            {
                if (ManaType[i] == ii + 1 && goal[ii] < target[ii])
                {
                    gameObject.GetComponentsInChildren<Image>()[i + 1].sprite = Resources.Load("비활성", typeof(Sprite)) as Sprite;
                    ManaPrev[i] = ManaType[i];
                    ManaType[i] = -1;
                    
                    goal[ii]++;
                    break;
                }
                if (goal[0] >= target[0] && goal[1] >= target[1] && goal[2] >= target[2])
                    return;
            }
        }
    }

    public void ManaReset()
    {
        for (int i = 0; i < 10; i++)
        {
            if(ManaType[i] == -1)
            {              
                if (ManaPrev[i] == 1)
                {
                    gameObject.GetComponentsInChildren<Image>()[i + 1].sprite = Resources.Load("프라나", typeof(Sprite)) as Sprite;
                    ManaType[i] = 2;
                }
                else if (ManaPrev[i] == 2)
                {
                    gameObject.GetComponentsInChildren<Image>()[i + 1].sprite = Resources.Load("마나", typeof(Sprite)) as Sprite;
                    ManaType[i] = 1;
                }
                else if (ManaPrev[i] == 3)
                {
                    gameObject.GetComponentsInChildren<Image>()[i + 1].sprite = Resources.Load("카르트", typeof(Sprite)) as Sprite;
                    ManaType[i] = 3;
                }               
            }           
        }
    }

}
