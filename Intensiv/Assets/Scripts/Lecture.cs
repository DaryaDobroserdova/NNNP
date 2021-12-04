﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lecture : MonoBehaviour
{
    public VoskSpeechToText VoskSpeechToText;
    public Button d, a, p;
    private string v_d = "выбрать дизайн";
    private string v_a = "анализ информации";
    private string v_p = "сделать прототип";
    ScenesManager sm = new ScenesManager();

    private void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    public void D()
    {
        sm.NextScene(8);
    }

    public void A()
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
            if (p.Text == v_d)
                D();
            else if (p.Text == v_a)
                A();
            else if (p.Text == v_p)
                P();
        }
    }
}
