using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSelect : MonoBehaviour
{
    public VoskSpeechToText VoskSpeechToText;
    public Button g, b, p;
    private string v_g = "зелёный";
    private string v_b = "чёрный";
    private string v_p = "фиолетовый";
    ScenesManager sm = new ScenesManager();

    private void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    public void B()
    {
        sm.NextScene(8);
    }

    public void G()
    {
        sm.NextScene(8);
    }

    public void P()
    {
        sm.NextScene(8);
    }

    private void OnTranscriptionResult(string obj)
    {
        var result = new RecognitionResult(obj);
        foreach (RecognizedPhrase p in result.Phrases)
        {
            if (p.Text == v_b)
                B();
            else if (p.Text == v_g)
                G();
            else if (p.Text == v_p)
                P();
        }
    }
}
