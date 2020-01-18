using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCards : MonoBehaviour
{
    public GameObject[] cards = new GameObject[10];
    private Vector3 point = new Vector3();  //where to spawn the cards.
    private float Offset = 0;
    // Start is called before the first frame update

        /*
         * On awake, the program loads in a grid of cards all face down and their presentation
         * depends on how many pairs was selected.       
         */
    void Awake()
    {
        point.y = 4f;
        if (StaticVariables.Pairs == 6)
        {
            point.y = 3f;
            this.transform.position = new Vector3(-3.5f, 6.5f, 0f);
        }
        //sets the initally spawn point.
        if (StaticVariables.Pairs == 7) this.transform.position = new Vector3(-3.95f, 7.5f, 0f);
        if (StaticVariables.Pairs == 8) this.transform.position = new Vector3(-3.95f, 7.5f, 0f);
        if (StaticVariables.Pairs == 9) this.transform.position = new Vector3(-4.25f, 7.5f, 0f);
        if (StaticVariables.Pairs == 10) this.transform.position = new Vector3(-4.95f, 7.5f, 0f);
        point.z = 1f;
        point.x = Offset;

        //these if statements send specifications to the instantiateCards method.
        if (StaticVariables.Pairs == 6) instantiateCards(3, 4, 6);
        if (StaticVariables.Pairs == 7) instantiateCards(3, 4, 7);
        if (StaticVariables.Pairs == 8) instantiateCards(4, 4, 8);
        if (StaticVariables.Pairs == 9) instantiateCards(3, 5, 9);
        if (StaticVariables.Pairs == 10) instantiateCards(4, 5, 10);
    }

    void instantiateCards(int x, int y, int numcards)
    {
        int[] drawncards = new int[numcards]; //used for keeping track of which cards have already been selected
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                point.x = transform.position.x + 2.5f * j;
                getNewCard(drawncards); //draws a new card.
            }
            point.x = Offset;
            point.y -= 2.5f;
        }
        // 7 and 9 pairs require special construction of their grid layout.
        if (numcards == 7 || numcards == 9)
        {
            point.x = Offset;
            point.x = transform.position.x + 2.5f;
            getNewCard(drawncards);
            point.x = transform.position.x + 2.5f * 2;
            getNewCard(drawncards);
            if (numcards == 9)
            {
                point.x = transform.position.x + 2.5f * 3;
                getNewCard(drawncards);
            }
        }

    }

    void getNewCard(int[] drawncards)
    {
        int r = Random.Range(0,drawncards.Length);
        if (drawncards[r] < 2)
        {
            //instantiates new card at point.
            Instantiate(cards[r], point, transform.rotation);
            drawncards[r]++;
            return;
        }
        else
        {
            getNewCard(drawncards); //uses recursion to get new cards.
        }

        }
        
}
