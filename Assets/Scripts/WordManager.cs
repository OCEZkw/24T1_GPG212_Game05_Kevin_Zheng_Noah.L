using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScore;

    private bool hasActiveWord;
    private Word activeWord;

    public WordSpawner wordSpawner;



    // Update is called once per frame
    void Update()
    {
        finalScore.text = scoreText.text;
    }

    public void AddWord()
    {
        WordDisplay display = wordSpawner.SpawnWord();
        Word word = new Word(WordGenerator.GetRandomWord(), display, scoreText);
        Debug.Log(word.word);



        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {

            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }

        }
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
}

