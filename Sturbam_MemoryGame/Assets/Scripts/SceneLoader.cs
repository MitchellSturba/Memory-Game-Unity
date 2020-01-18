//Mitchell Sturba 104750636
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    IEnumerator waitforSoundClip()
    {
        yield return new WaitForSeconds(.15f);
        SceneManager.LoadScene("PlayScene");
    }
    /*
     * Loads the scene with a little delay so you can fully hear the ding noise
    */
    public void LoadPlayScene()
    {
        StartCoroutine(waitforSoundClip());
    }
    /*
     * Resets all variables back to when the scene is loaded
     */
    public void ResetScene()
    {
        Variables.correct_Pairs = 0;
        Clock.timer = 0;
        Variables.scoreNum = 1000;
        Variables.win = false;
        Variables.activatable = true;
        SceneManager.LoadScene("PlayScene");
        if (Variables.scoreNum == 0) GameObject.Find("GameOver").SetActive(false);
    }
    /*
     * For the back button that takes you back to the main menu
     */
    public void LoadHomeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
