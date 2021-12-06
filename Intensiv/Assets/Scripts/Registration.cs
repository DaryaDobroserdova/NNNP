using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public Canvas cvs;
    public Button btn;
    public VoskSpeechToText VoskSpeechToText;
    public Image img;
    private bool answer = false;
    ScenesManager smn = new ScenesManager();

    string yes = "начать игру";

    void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }
    // Update is called once per frame
    void Update()
    {
        /*if (isActive && !cvs.GetComponent<VoskSpeechToText>()._didInit)
        {
            cvs.GetComponent<VoskSpeechToText>().StartVoskStt();
            cvs.GetComponent<VoskSpeechToText>()._didInit = true;
        }
        if (!isActive && cvs.GetComponent<VoskSpeechToText>()._didInit)
        {
            cvs.GetComponent<VoskSpeechToText>().ToggleRecording();
            cvs.GetComponent<VoskSpeechToText>()._didInit = false;
        }*/
        if (cvs.GetComponent<VoskSpeechToText>()._running)
            img.gameObject.SetActive(false);
    }
    public void clck() 
    {
        smn.NextScene(1);
    }
    private void OnTranscriptionResult(string obj)
    {
        var result = new RecognitionResult(obj);
        foreach (RecognizedPhrase p in result.Phrases)
        {
            if (p.Text == yes)
            {
                clck();
            }
        }
    }
}
