using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RotateCard : MonoBehaviour
{
    static int cardsPicked = 0;

    //variables used for testing
    public bool FaceUp = false;
    static string cardOne;
    static string cardTwo;

    //variables used for sound
    AudioSource audioSource;
    public AudioClip noise;
    public AudioClip errornoise;
    public AudioClip clicknoise;

    //player score
    private TextMeshProUGUI Pscore;

    private void Start()
    {
        //assign variables to objects/sources
        audioSource = GetComponent<AudioSource>();
        this.transform.parent = GameObject.Find("StartPoint").transform;
        GameObject PlayerScore = GameObject.Find("ScoreInt");
        Pscore = PlayerScore.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        //if no cards picked then face them down.
        if (cardsPicked == 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            FaceUp = false;
        }
    }

    //used for suspense
    IEnumerator waitSecs()
    {
        Variables.scoreNum = int.Parse(Pscore.text);
        if (cardOne.Equals(cardTwo))
        {
            audioSource.PlayOneShot(noise, .5f);
        }
        if (cardOne.Equals(cardTwo)) yield return new WaitForSeconds(.7f);
        else yield return new WaitForSeconds(.35f);

        //if cards are equal, increment score and destroy cards.
        if (cardOne.Equals(cardTwo))
        {
            Variables.correct_Pairs++;
            GameObject[] matchedCards;
            if (!cardOne.Equals("Card_10(Clone)")) matchedCards = GameObject.FindGameObjectsWithTag(cardOne.Substring(0, 6));
            else
            {
                matchedCards = GameObject.FindGameObjectsWithTag(cardOne.Substring(0, 7));
            }
            foreach (GameObject x in matchedCards)
            {
                Destroy(x);
            }
        }
        //if not equal then play sad sound and flip cards back over.
        else
        {
            audioSource.PlayOneShot(errornoise, .5f);
            Variables.scoreNum -= 40;
            Pscore.text = Variables.scoreNum.ToString();
        }
        cardsPicked = 0;
    }

    private void OnMouseDown()
    {
        audioSource.PlayOneShot(clicknoise); //play click noise
        if (!FaceUp)
        {
            cardsPicked++;
            FaceUp = true;
            transform.Rotate(0, 180f, 0); //face it up
            if (cardsPicked == 1)
            {
                cardOne = transform.name; //assign cardOne to first picked cards name
            }
            if (cardsPicked == 2)
            {
                cardTwo = transform.name;
                StartCoroutine(waitSecs()); //test the cards and see if their equal.
            }
        }

    }
}
