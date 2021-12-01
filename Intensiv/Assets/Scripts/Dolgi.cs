using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dolgi : MonoBehaviour
{

    public VoskSpeechToText VoskSpeechToText;
    public Button btn, btn1;
    public Text t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (t.GetComponent<PrintedText>().textEnd)
        {
            btn.gameObject.SetActive(true);
            btn1.gameObject.SetActive(true);
        }
    }
}
