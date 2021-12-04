using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    public VoskSpeechToText VoskSpeechToText;
    public Button btn, btn1;
    public List<GameObject> scenes;
    public Text podskazka;
    public Canvas cvs;
    private string keep_silent = "скрыть свои проблемы";
    private string tell = "откровенно рассказать ситуацию";
    ScenesManager sm = new ScenesManager();

    private void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    private void Update()
    {
        if (scenes[0].tag == "select" && !cvs.GetComponent<VoskSpeechToText>()._didInit)
        {
                cvs.GetComponent<VoskSpeechToText>().StartVoskStt();
                cvs.GetComponent<VoskSpeechToText>()._didInit = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Next();
        }
        if (scenes[0].GetComponent<PrintedText>().textEnd)
        {
            if (scenes[0].tag == "select")
            {
                btn.gameObject.SetActive(true);
                btn1.gameObject.SetActive(true);
                podskazka.gameObject.SetActive(false);
            }
            else
                podskazka.gameObject.SetActive(true);
        }
    }

    public void Next()
    {
        if (scenes[0].GetComponent<PrintedText>().textEnd && scenes[0].tag != "select")
        {
            if (scenes.Count > 1)
            {
                scenes[0].SetActive(false);
                scenes.RemoveAt(0);
                scenes[0].SetActive(true);
                podskazka.gameObject.SetActive(false);
            }
            else
                sm.NextScene(5);
        }
        else
            scenes[0].GetComponent<PrintedText>().skip = true;
    }

    public void KeepSilent()
    {
        sm.NextScene(6);
    }

    public void Tell()
    {
        sm.NextScene(7);
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
