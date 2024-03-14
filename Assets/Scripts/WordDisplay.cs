using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public TMP_Text text;
    public float fallspeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, -fallspeed * Time.deltaTime, 0f);
    }

    public void SetWord (string word)
    {
        text.SetText(word);
    }

    public void RemoveLetter ()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;

    }

    public void RemoveWord ()
    {
        Destroy(gameObject);
    }
}
