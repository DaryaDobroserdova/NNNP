using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSelect : MonoBehaviour
{
    public VoskSpeechToText VoskSpeechToText;
    public Button g, b, p;
    private int i;
    public GameObject scene;
    public GameObject[] AllCharacters;
    private string v_g = "зелёный";
    private string v_b = "чёрный";
    private string v_p = "фиолетовый";
    ScenesManager sm = new ScenesManager();

    private void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    private void Start()
    {
        i = PlayerPrefs.GetInt("CurrentCharacter");
        AllCharacters[i].SetActive(true);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !scene.GetComponent<PrintedText>().textEnd)
        {
            scene.GetComponent<PrintedText>().skip = true;
        }
        if (scene.GetComponent<PrintedText>().textEnd)
        {
            g.gameObject.SetActive(true);
            p.gameObject.SetActive(true);
            b.gameObject.SetActive(true);
        }
    }
    public void B()
    {
        sm.NextScene(12);
    }

    public void G()
    {
        sm.NextScene(13);
    }

    public void P()
    {
        sm.NextScene(11);
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
