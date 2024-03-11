using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class WordManager : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordSpawnPoint;
    public List<string> wordList = new List<string>() { "example", "keyboard", "Test"};

    private void Start()
    {
        if (wordPrefab == null)
        {
            Debug.LogError("wordPrefab is not assigned in the inspector!");
            return;
        }

        if (wordPrefab.GetComponent<Word>() == null)
        {
            Debug.LogError("Word script is missing on the wordPrefab!");
            return;
        }


        SpawnWord();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            CheckInput();
        }
    }

    public void SpawnWord()
    {
        GameObject wordObj = Instantiate(wordPrefab, wordSpawnPoint.position, Quaternion.identity);
        Word word = wordObj.GetComponent<Word>();

        // random word from the list
        word.InitializeWord(GetRandomWord());

        // word speed
        word.SetSpeed(Random.Range(2f, 5f));
    }

    private string GetRandomWord()
    {
        //  random word from the wordList
        if (wordList.Count > 0)
        {
            int randomIndex = Random.Range(0, wordList.Count);
            return wordList[randomIndex];
        }

        return "default";
    }

    private void CheckInput()
    {
        // input from the user
        string input = Input.inputString;

        // Check the input matches the first letter of any active word
        Word activeWord = FindObjectOfType<Word>();
        if (activeWord != null && input.Length > 0 && input[0] == activeWord.GetNextLetter())
        {
            // is correct, remove the typed letter from the word
            activeWord.TypeLetter();
        }
    }
}
