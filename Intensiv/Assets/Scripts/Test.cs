using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public VoskSpeechToText VoskSpeechToText;
    public Button classm, sam;
    private string v_sam = "самостоятельно";
    private string v_classm = "попросить помощи";
    ScenesManager sm = new ScenesManager();


    private void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    public void Sam()
    {
        sm.NextScene(8);
    }

    public void Classm()
    {
        sm.NextScene(8);
    }

    private void OnTranscriptionResult(string obj)
    {
        var result = new RecognitionResult(obj);
        foreach (RecognizedPhrase p in result.Phrases)
        {
            if (p.Text == v_sam)
                Sam();
            else if (p.Text == v_classm)
                Classm();
        }
    }
}
