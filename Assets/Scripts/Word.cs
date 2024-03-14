using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Word
{
    public string word;
    private int typeIndex;
    private int score;

    WordDisplay display;
    public TextMeshProUGUI scoreText;

    public Word(string _word, WordDisplay _display, TextMeshProUGUI _scoreText)
    {
        word = _word;
        typeIndex = 0;
        score = 0;

        display = _display;
        display.SetWord(word);
        scoreText = _scoreText;
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
        // Remove the letter on screen
        display.RemoveLetter();
    }

    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if (wordTyped)
        {
            score += 10;
            scoreText.text = "Score: " + score;
            display.RemoveWord();
        }
        return wordTyped;
    }

    public int GetScore()
    {
        return score;
    }
}
