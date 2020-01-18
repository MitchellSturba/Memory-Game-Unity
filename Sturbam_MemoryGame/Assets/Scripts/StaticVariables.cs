using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StaticVariables : MonoBehaviour
{
    public static int Pairs = 6;

    /*
     * all these functions are used by the buttons to set variabels to the number of pairs
     */   
    public void SelectedSix()
    {
        sceneSet();
        Pairs = 6;
    }
    public void SelectedSeven()
    {
        sceneSet();
        Pairs = 7;
    }
    public void SelectedEight()
    {
        sceneSet();
        Pairs = 8;
    }
    public void SelectedNine()
    {
        sceneSet();
        Pairs = 9;
    }
    public void SelectedTen()
    {
        sceneSet();
        Pairs = 10;
    }
    /*
     * In case the user is playing multiple games, all varaibles need to be 
     * reset to what it is when the scene intially loads.   
     */
    public void sceneSet() {
        Variables.correct_Pairs = 0;
        Clock.timer = 0;
        Variables.scoreNum = 1000;
        Variables.win = false;
        Variables.activatable = true;
        SceneManager.LoadScene("PlayScene");
    }

}
