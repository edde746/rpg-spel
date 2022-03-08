using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DialogScript : MonoBehaviour
{
    public GameObject dialogBox;
    TextMeshProUGUI dialogText;
    public UnityEvent finishedSpeaking;
    public string[] dialog;
    public float textSpeed = 0.02f;
    int activeMessage = 0;
    bool speaking = false;

    void Start()
    {
        dialogText = dialogBox.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!speaking && dialogBox.activeSelf && activeMessage < dialog.Length - 1 && Input.GetKeyDown(KeyCode.E))
        {
            activeMessage++;
            StartCoroutine(DialogRoutine());
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
        foreach (var letter in dialog[activeMessage])
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        // If we are finished speaking, wait 1 second and fire speaking finished event
        if (activeMessage == dialog.Length - 1)
        {
            yield return new WaitForSeconds(1f);
            finishedSpeaking.Invoke();
        }

        // Unlock speaking
        speaking = false;
    }
}
