using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Word : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    private string word;
    private float speed;

    public void InitializeWord(string newWord)
    {
        // Set the word to a random word
        word = newWord;

        // Update TMP component with word
        textComponent.text = word;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public char GetNextLetter()
    {
        // Return the next letter to be typed
        return word[0];
    }

    public void TypeLetter()
    {
        // Remove the first letter from worf
        word = word.Substring(1);

        // Update the TMP component with the modified word
        textComponent.text = word;

        // Check if the word is empty, and if so, destroy GameObject
        if (string.IsNullOrEmpty(word))
        {
            Destroy(gameObject);
            FindObjectOfType<WordManager>().SpawnWord(); // Spawn new word after destroying current one
        }
    }

    private void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);

    } 
    
}