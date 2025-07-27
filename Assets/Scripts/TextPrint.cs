using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPrint : MonoBehaviour
{
    TMP_Text description;
    public string[] phrases = new string[] { "It looks happy to see you!", "It looks like its having fun.", "It thinks you were going to abandon it." };
    public string typingText;

    void Awake()
    {
        description = GetComponent<TMP_Text>();
    }

    IEnumerator Wait()
    {
        description.text = string.Empty;

        for (int i = 0; i < typingText.Length; i++)
        {
            description.text += typingText[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(5f);
        description.text = string.Empty;
        yield return null;
    }

    public void PrintText()
    {
        StartCoroutine(Wait());
    }
}
