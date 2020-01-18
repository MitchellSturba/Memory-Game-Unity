using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Variables : MonoBehaviour
{
    //variabels used throughout the game
    public static int correct_Pairs = 0;
    public GameObject Mainscreen;
    public GameObject WinScreen;
    public GameObject theCards;
    public GameObject gameOver;
    public static bool win = false;
    public static int scoreNum = 1000;

    //texts
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI finaltime;

    //more texts
    public TextMeshProUGUI finalScoreSource;
    public TextMeshProUGUI finaltimeSource;

    //audio clips
    public AudioClip winnoise;
    public AudioClip losenoise;
    public AudioSource Source;

    public static bool activatable = true;

    // Start is called before the first frame update

    // Update is called once per frame

    private void Update()
    {
        if (correct_Pairs == StaticVariables.Pairs || scoreNum == 0 && activatable)
        {
            //We're in the endgame now.
            correct_Pairs = 0;
            if (scoreNum > 0) Source.PlayOneShot(winnoise);
            else Source.PlayOneShot(losenoise);
            win = true;
            Mainscreen.SetActive(false);
            theCards.SetActive(false);
            finalScore.text = finalScoreSource.text;
            finaltime.text = finaltimeSource.text;
            WinScreen.SetActive(true);
            activatable = false;
            if (scoreNum == 0) gameOver.SetActive(true);
        }
    }
}
