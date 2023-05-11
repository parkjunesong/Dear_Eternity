using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Talking : MonoBehaviour
{
    ScenarioData Scenario;
    public Text NameField;
    public Text TalkField;
    public Image left;
    public Image front;
    public Image right;
    int count;
    void Start()
    {
        Scenario = GotoSC.SelectedScenario;
        count = 0;
        StartCoroutine(StartTalk(Scenario));            
    }
    IEnumerator StartTalk(ScenarioData SC)
    {
        NameField.text = "";
        TalkField.text = "";
        yield return StartCoroutine(Typing(Scenario.Text[count]));
        count++;

        if (count < SC.Num)
            StartCoroutine(StartTalk(Scenario));
        else
            yield break;
        
    }

    IEnumerator Typing(string text)
    {
        int i = 0;
        int a = 0;

        foreach (char letter in text.ToCharArray())
        {
            if (letter == '&') // 대화 세팅
            {
                CharaTalkingData chara = Scenario.CharaList[text[i + 1] - '0'];
                Sprite image = chara.Image[text[i + 3] - '0'];
                int position = text[i + 5] - '0';

                NameField.text = chara.Name;
                if (position == 0)
                    left.sprite = image;
                else if (position == 1)
                    front.sprite = image;
                else if (position == 2)
                    right.sprite = image;

                a = i - 1;
                i = 0;
                break;
            }
            if (letter == '@') // 전투씬 전환
            {
                map.Data = Scenario.Mapdata;
                SceneManager.LoadScene("team");
                if (map.Data.CharaReadyMap == true)
                    CharaList.crm = true;

                a = i - 1;
                i = 0;
                yield break;
            }
            i++;
        }

        foreach (char letter in text.ToCharArray())
        {
            TalkField.text += letter;
            yield return new WaitForSeconds(0.01f);

            if (i == a)
                break;
            else
                i++;
        }
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Mouse0));
    }
}
