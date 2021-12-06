using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public VoskSpeechToText VoskSpeechToText;
    private string v_d = "самостоятельно";
    private string v_a = "попросить помощи";
    private int i;
    public Canvas cvs;
    public GameObject[] AllCharacters;
    public GameObject[] AllCharacters2;
    public List<GameObject> scenes;
    public List<Button> btn;
    public Text podskazka;
    ScenesManager sm = new ScenesManager();

    private void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    private void Start()
    {
        i = PlayerPrefs.GetInt("CurrentCharacter");
    }

    void Update()
    {
        if (scenes[0].tag == "select" && !cvs.GetComponent<VoskSpeechToText>()._didInit)
        {
            cvs.GetComponent<VoskSpeechToText>().StartVoskStt();
            cvs.GetComponent<VoskSpeechToText>()._didInit = true;
        }
        if (scenes[0].tag != "lecture" && scenes[0].tag != "select")
        {
            AllCharacters[i].SetActive(true);
            AllCharacters2[i].SetActive(false);
        }
        if (scenes[0].tag == "lecture")
        {
            AllCharacters[i].SetActive(false);
            AllCharacters2[i].SetActive(false);
        }
        if (scenes[0].tag == "select")
        {
            AllCharacters2[i].SetActive(false);
            AllCharacters[i].SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Next();
        }
        if (scenes[0].GetComponent<PrintedText>().textEnd)
        {
            if (scenes[0].tag == "select")
            {
                btn[0].gameObject.SetActive(true);
                btn[1].gameObject.SetActive(true);
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
                sm.NextScene(0);
        }
        else
            scenes[0].GetComponent<PrintedText>().skip = true;
    }

    public void Error()
    {
        scenes[0].GetComponent<PrintedText>().printedText.text = "Преподаватель:\n- Неправильно. Вспомните материал и попробуйте ещё раз!";
        scenes[0].GetComponent<PrintedText>().Start();
    }

    public void Sam()
    {
        scenes[0].SetActive(false);
        scenes.RemoveAt(0);
        scenes.RemoveAt(0);
        scenes[0].SetActive(true);
        podskazka.gameObject.SetActive(false);
        btn.RemoveRange(0, 2);
        cvs.GetComponent<VoskSpeechToText>().ToggleRecording();
    }

    public void Help()
    {
        scenes[0].SetActive(false);
        scenes.RemoveAt(0);
        scenes[0].SetActive(true);
        podskazka.gameObject.SetActive(false);
        btn.RemoveRange(0, 2);
        cvs.GetComponent<VoskSpeechToText>().ToggleRecording();
    }

    private void OnTranscriptionResult(string obj)
    {
        var result = new RecognitionResult(obj);
        foreach (RecognizedPhrase p in result.Phrases)
        {
            if (p.Text == v_d)
                Sam();
            else if (p.Text == v_a)
                Help();
        }
    }
}
