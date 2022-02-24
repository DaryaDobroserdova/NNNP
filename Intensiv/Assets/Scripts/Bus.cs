using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bus : MonoBehaviour
{
    public VoskSpeechToText VoskSpeechToText;
    public Button btn57, btn93, btn94;
    public List<GameObject> scenes;
    public Text podskazka;
    public Canvas cvs;
    public Image img;
    ScenesManager sm = new ScenesManager();
    private string v_57 = "пятьдесят седьмой";
    private string v_93 = "девяносто третий";
    private string v_94 = "девяносто четвёртый";

    private void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!img.gameObject.activeSelf)
            {
                Next();
                if (scenes[0].GetComponent<PrintedText>().textEnd)
                    podskazka.gameObject.SetActive(true);
            }
        }
        if (scenes[0].GetComponent<PrintedText>().textEnd)
        {
            if (scenes[0].tag == "select")
            {
                btn57.gameObject.SetActive(true);
                btn93.gameObject.SetActive(true);
                btn94.gameObject.SetActive(true);
                podskazka.gameObject.SetActive(false);
            }
            else
                podskazka.gameObject.SetActive(true);
        }
        if (cvs.GetComponent<VoskSpeechToText>()._running)
            img.gameObject.SetActive(false);
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
        {
            scenes[0].GetComponent<PrintedText>().skip = true;
            //if (click != 1)
            //    podskazka.gameObject.SetActive(true);
        }
    }

    public void num_bus()
    {
        cvs.GetComponent<VoskSpeechToText>().ToggleRecording();
        scenes[0].SetActive(false);
        scenes.RemoveAt(0);
        scenes[0].SetActive(true);
        podskazka.gameObject.SetActive(false);
    }

    private void OnTranscriptionResult(string obj)
    {
        var result = new RecognitionResult(obj);
        foreach (RecognizedPhrase p in result.Phrases)
        {
            if (p.Text == v_57 || p.Text == v_93 || p.Text == v_94)
                num_bus();
        }
    }
}
