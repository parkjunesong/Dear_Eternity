using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoSC : MonoBehaviour
{
    public static ScenarioData SelectedScenario;
    public ScenarioData Data;
   
    public void GotoScenario()
    {
        SelectedScenario = Data;
        SceneManager.LoadScene("talk");
    }
}
