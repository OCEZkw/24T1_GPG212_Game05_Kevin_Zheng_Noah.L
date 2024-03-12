using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class WordFall : MonoBehaviour
{
    public static string[] words = 
    {
        "test",
        "hello",
        
    };

    private int score = 0;
    private string wordBeingTyped;
    public InputField inputField;
    public Text scoreDisplay;
    public Text wordDisplay;

    private void Start()
    {
        wordBeingTyped = GetRandomWord();
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string typedWord = inputField.text.ToLower().Trim();

            if (typedWord == wordBeingTyped)
            {
                UpdateScore();
                wordBeingTyped = GetRandomWord();
                UpdateUI();
                Debug.Log("correct");
            }
            else
            {
                Debug.Log("Incorrect! Try again.");
            }

            inputField.text = "";
        }
    }

    private string GetRandomWord()
    {
        return words[UnityEngine.Random.Range(0, words.Length)];
    }

    private void UpdateScore()
    {
        score++;
    }

    private void UpdateUI()
    {
        scoreDisplay.text = "Score: " + score;
        wordDisplay.text = "Word: " + wordBeingTyped;

    }
}