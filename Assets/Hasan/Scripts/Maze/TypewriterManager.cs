using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterManager : MonoBehaviour
{
    [SerializeField] GameObject[] PauseObjects;

    public TextMeshProUGUI textUI;
    public string[] lines = {
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
    };
    public float typingSpeed = 0.05f;
    public AudioSource typingSound;

    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool lineFinished = false;

    void Start()
    {
        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (lineFinished && Input.GetMouseButtonDown(0))
        {
            lineFinished = false;
            currentLineIndex++;

            if (currentLineIndex < lines.Length)
            {
                StartCoroutine(TypeLine());
            }
            else
            {
                textUI.text = "";

                foreach (var obj in PauseObjects)
                {
                    obj.SetActive(true);
                }
            }
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        textUI.text = "";

        foreach (char c in lines[currentLineIndex])
        {
            textUI.text += c;

            if (typingSound != null)
                typingSound.Play();

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        lineFinished = true;
    }
}
