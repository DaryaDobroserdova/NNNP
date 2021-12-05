using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintedText : MonoBehaviour
{
    public Text printedText;
    public string text;
    public bool textEnd = false, skip = false;

    IEnumerator TextPrinting()
    {
        foreach (char c in text)
        {
            if (!textEnd && !skip)
            {
                printedText.text += c;
                yield return new WaitForSeconds(0.07f);
            }
            else
            {
                textEnd = true;
                printedText.text = text;
                break;
            }
        }
        textEnd = true;
    }
    // Start is called before the first frame update
    public void Start()
    { 
        textEnd = false;
        skip = false;
        text = printedText.text;
        printedText.text = "";
        StartCoroutine(TextPrinting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
