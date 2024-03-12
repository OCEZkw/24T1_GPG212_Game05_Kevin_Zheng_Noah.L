using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactivateInputField : MonoBehaviour
{
    private InputField inputField;

    void Start()
    {
        // Get the InputField component attached to this GameObject
        inputField = GetComponent<InputField>();

        // Add a listener to detect changes in the text
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    void OnInputValueChanged(string newValue)
    {
        // Check if the input field is inactive and the text is not empty
        if (!inputField.interactable && !string.IsNullOrEmpty(newValue))
        {
            // Reactivate the input field
            Reactivate();
        }
    }

    void Reactivate()
    {
        // Save the current selection and caret position
        int caretPosition = inputField.caretPosition;

        // Reactivate the input field
        inputField.interactable = true;
        inputField.Select();
        inputField.ActivateInputField();

        // Restore the caret position
        inputField.caretPosition = caretPosition;

        // Clear the input field text
        inputField.text = "";

        // Re-add the listener to detect further changes
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }
}