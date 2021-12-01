using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstScene : MonoBehaviour
{
    public Text text;

    public VoskSpeechToText VoskSpeechToText;
    private string change = "изменить";
    private string select = "выбрать";
    private string start = "начать";

    public int i;
    public int currentCharacter;
    public GameObject[] AllCharacter;
    public GameObject ButtonToLeft;
    public GameObject ButtonToRight;
    public GameObject ButtonSelectCharacter;
    public GameObject TextSelectCharacter;

    private void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    public void Start()
    {
        if (PlayerPrefs.HasKey("CurrentCharacter"))
        {
            i = PlayerPrefs.GetInt("CurrentCharacter");
            currentCharacter = PlayerPrefs.GetInt("CurrentCharacter");
        }
        else
        {
            PlayerPrefs.SetInt("CurrentCharacter", i);
        }

        AllCharacter[i].SetActive(true);

        ButtonSelectCharacter.SetActive(false);
        TextSelectCharacter.SetActive(true);

        if (i > 0)
        {
            ButtonToLeft.SetActive(true);
        }

        if (i == AllCharacter.Length - 1)
        {
            ButtonToRight.SetActive(false);
        }
    }
    
    public void ArrowRight()
    {
        if (i < AllCharacter.Length)
        {
            if (i == 0)
            {
                ButtonToLeft.SetActive(true);
            }

            AllCharacter[i].SetActive(false);
            i++;
            AllCharacter[i].SetActive(true);

            if (currentCharacter == i)
            {
                ButtonSelectCharacter.SetActive(false);
                TextSelectCharacter.SetActive(true);
            }
            else
            {
                ButtonSelectCharacter.SetActive(true);
                TextSelectCharacter.SetActive(false);
            }

            if (i+1 == AllCharacter.Length)
            {
                ButtonToRight.SetActive(false);
            }
        }
      
    }

    public void ArrowLeft()
    {
        if (i < AllCharacter.Length)
        {
            AllCharacter[i].SetActive(false);
            i--;
            AllCharacter[i].SetActive(true);
            ButtonToRight.SetActive(true);

            if (currentCharacter == i)
            {
                ButtonSelectCharacter.SetActive(false);
                TextSelectCharacter.SetActive(true);
            }
            else
            {
                ButtonSelectCharacter.SetActive(true);
                TextSelectCharacter.SetActive(false);
            }

            if (i == 0)
            {
                ButtonToLeft.SetActive(false);
            }
        }
    }

    public void SelectCharacter()
    {
        PlayerPrefs.SetInt("CurrentCharacter", i);
        currentCharacter = i;
        ButtonSelectCharacter.SetActive(false);
        TextSelectCharacter.SetActive(true);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(3);
    }

    private void OnTranscriptionResult(string obj)
    {
        var result = new RecognitionResult(obj);
        foreach (RecognizedPhrase p in result.Phrases)
        {
            if (p.Text == change && i==0)
                ArrowRight();
            else if (p.Text == change && i==1)
                ArrowLeft();
            if (p.Text == select)
                SelectCharacter();
            if (p.Text == start)
                ChangeScene();
        }
    }

}
