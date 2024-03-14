using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public TMP_Text text;
    public float fallspeed = 1f;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("Game Manager not found in scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.IsPaused())
        {
            transform.Translate(0f, -fallspeed * Time.deltaTime, 0f);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("WordDestroyer"))
                {
                    EndGame();
                    break;
                }
            }
        }
    }

    public void SetWord(string word)
    {
        text.SetText(word);
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;

    }



    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    public void EndGame()
    {
        if (gameManager != null)
        {
            gameManager.WinGame();
        }
    }
}
