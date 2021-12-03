using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lecture : MonoBehaviour
{
    public VoskSpeechToText VoskSpeechToText;
    public Button btn57, btn93, btn94;
    private string v_57 = "пятьдесят семь";
    private string v_93 = "девяносто три";
    private string v_94 = "девяносто четыре";
    ScenesManager sm = new ScenesManager();
    private int i;
    public GameObject[] AllCharacters;

    private void Start()
    {
        i = PlayerPrefs.GetInt("CurrentCharacter");
        AllCharacters[i].SetActive(true);
    }

    private void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    public void num_bus()
    {
        sm.NextScene(8);
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
