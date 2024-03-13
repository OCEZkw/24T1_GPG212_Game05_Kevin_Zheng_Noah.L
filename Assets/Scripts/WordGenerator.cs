using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = { "pitch", "tasty", "elite", "friendly", "addition", "damage", "decisive", "reproduction", "holiday", "admit", "soup", "hold", "revolutionary", "twin", " bronze", "shortage", "finger", " gear",
        "gear", "constant", "shareholder", "collection", "rebellion", "love", "growth", "interest", "performance", "relinquish", "infinite", "shelf", "scream", "slot", "committee", "retired", "system", "casualy", "vegetation",
        "pig", "steep", "carriage", "blind", "pilot", "drag", "sweater", "headquarters", "precision", "subway", "bell", "multimedia", "closed", "rent" };

    public static string GetRandomWord ()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
