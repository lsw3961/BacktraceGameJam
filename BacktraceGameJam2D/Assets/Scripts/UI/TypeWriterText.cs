using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TypeWriterText : MonoBehaviour
{
    // Start is called before the first frame update
   TMP_Text text;
    string story;
    [SerializeField] float SecondsPerLetter = 0.125f;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        story = text.text;
        text.text = "";

        StartCoroutine("PlayText");
    }

    IEnumerator PlayText() 
    {
        foreach (char c in story) 
        {
            text.text += c;
            yield return new WaitForSeconds(SecondsPerLetter);
        }
    }
}
