using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    public VoskSpeechToText VoskSpeechToText;
    public Button btn, btn1;
    private string keep_silent = "скрыть свои проблемы";
    private string tell = "откровенно рассказать ситуацию";
    ScenesManager sm = new ScenesManager();

    private void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    public void KeepSilent()
    {
        sm.NextScene(8);
    }

    public void Tell()
    {
        sm.NextScene(9);
    }
    private void OnTranscriptionResult(string obj)
    {
        var result = new RecognitionResult(obj);
        foreach (RecognizedPhrase p in result.Phrases)
        {
            if (p.Text == keep_silent)
                KeepSilent();
            else if (p.Text == tell)
                Tell();
        }
    }
}
