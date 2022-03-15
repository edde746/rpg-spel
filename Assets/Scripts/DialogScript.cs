using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

[Serializable]
public class Dialog
{
    public string[] messages;
    public UnityEvent finished;
}

public class DialogScript : MonoBehaviour
{
    public GameObject dialogBox;
    TextMeshProUGUI dialogText;
    public Dialog[] dialog;
    public float textSpeed = 0.02f;
    int activeDialog = 0;
    int activeMessage = 0;
    bool speaking = false;

    void Start()
    {
        dialogText = dialogBox.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!speaking && dialogBox.activeSelf && activeMessage < dialog[activeDialog].messages.Length - 1 && Input.GetKeyDown(KeyCode.E))
        {
            activeMessage++;
            StartCoroutine(DialogRoutine());
        }
    }

    public void SetActiveDialog(int id)
    {
        if (id >= 0 && id <= dialog.Length - 1)
        {
            activeMessage = 0;
            activeDialog = id;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            dialogBox.SetActive(true);
            StartCoroutine(DialogRoutine());
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            dialogBox.SetActive(false);
            StopAllCoroutines();
            speaking = false;
        }
    }

    IEnumerator DialogRoutine()
    {
        // Reset text & lock speaking
        speaking = true;
        dialogText.text = "";

        // Animate text
        foreach (var letter in dialog[activeDialog].messages[activeMessage])
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        // If we are finished speaking, wait 1 second and fire speaking finished event
        if (activeMessage == dialog[activeDialog].messages.Length)
        {
            yield return new WaitForSeconds(1f);
            dialog[activeDialog].finished.Invoke();
        }

        // Unlock speaking
        speaking = false;
    }
}
