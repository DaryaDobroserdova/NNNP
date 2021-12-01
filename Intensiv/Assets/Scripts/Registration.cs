using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public Canvas cvs;
    public Button btn, btn2;
    public InputField iF;
    public VoskSpeechToText VoskSpeechToText;
    public ToggleGroup tG, tG2;
    public Text text0, text2, text3;
    public Image img;
    //public bool isActive = true;
    private bool answer = false;
    public string name, gender, napr;
    public int age = -1;
    ScenesManager smn = new ScenesManager();

    Dictionary<string, int> ageSet = new Dictionary<string, int>();

    string yes = "да";
    string no = "нет";
    string mn = "мужской";
    string wn = "женский";
    string IS = "информационные системы и технологии";
    string IM = "информационные технологии в медиа индустрии";
    string IB = "информационные технологии в бизнесе";

    public string Name { get { return name; } }
    public int Age { get { return age; } }
    public string Gender { get { return gender; } }
    public string Napr { get { return napr; } }

    void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
        ageSet.Add("один", 1);
        ageSet.Add("два", 2);
        ageSet.Add("три", 3);
        ageSet.Add("четыре", 4);
        ageSet.Add("пять", 5);
        ageSet.Add("шесть", 6);
        ageSet.Add("семь", 7);
        ageSet.Add("восемь", 8);
        ageSet.Add("девять", 9);
        ageSet.Add("десять", 10);
        ageSet.Add("одииннадцать", 11);
        ageSet.Add("двенадцать", 12);
        ageSet.Add("тринадцать", 13);
        ageSet.Add("четырнадцать", 14);
        ageSet.Add("пятнадцать", 15);
        ageSet.Add("шестнадцать", 16);
        ageSet.Add("семнадцать", 17);
        ageSet.Add("восемнадцать", 18);
        ageSet.Add("девятнадцать", 19);
        ageSet.Add("двадцать", 20);
        ageSet.Add("двадцать один", 21);
        ageSet.Add("двадцать два", 22);
        ageSet.Add("двадцать три", 23);
        ageSet.Add("двадцать четыре", 24);
        ageSet.Add("двадцать пять", 25);
        ageSet.Add("двадцать шесть", 26);
        ageSet.Add("двадцать семь", 27);
        ageSet.Add("двадцать восемь", 28);
        ageSet.Add("двадцать девять", 29);
        ageSet.Add("тридцать", 30);
        ageSet.Add("тридцать один", 31);
        ageSet.Add("тридцать два", 32);
        ageSet.Add("тридцать три", 33);
        ageSet.Add("тридцать четыре", 34);
        ageSet.Add("тридцать пять", 35);
        ageSet.Add("тридцать шесть", 36);
        ageSet.Add("тридцать семь", 37);
        ageSet.Add("тридцать восемь", 38);
        ageSet.Add("тридцать девять", 39);
        ageSet.Add("сорок", 40);
        ageSet.Add("сорок один", 41);
        ageSet.Add("сорок два", 42);
        ageSet.Add("сорок три", 43);
        ageSet.Add("сорок четыре", 44);
        ageSet.Add("сорок пять", 45);
        ageSet.Add("сорок шесть", 46);
        ageSet.Add("сорок семь", 47);
        ageSet.Add("сорок восемь", 48);
        ageSet.Add("сорок девять", 49);
        ageSet.Add("пятьдесят", 50);
    }

    public void Change() 
    {
        cvs.GetComponent<VoskSpeechToText>().ToggleRecording();
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        iF.gameObject.SetActive(true);
        btn.gameObject.SetActive(false);
        btn2.gameObject.SetActive(true);
    }

    public void Accept()
    {
        if (name == "" && iF.text != "")
        {
            name = iF.text;
            s_name();
            iF.text = "";
            iF.contentType = InputField.ContentType.IntegerNumber;
        }
        if (name != "" && age == -1 && iF.text != "")
        {
            age = int.Parse(iF.text);
            s_age();
            iF.gameObject.SetActive(false);
            tG.gameObject.SetActive(true);
        }
        if (name != "" && age != -1 && gender == "")
        {
            Toggle t = tG.ActiveToggles().FirstOrDefault();
            gender = t.GetComponentInChildren<Text>().text;
            s_gender();
            tG.gameObject.SetActive(false);
            tG2.gameObject.SetActive(true);
        }
        if (name != "" && age != -1 && gender != "" && napr == "")
        {
            Toggle t = tG2.ActiveToggles().FirstOrDefault();
            napr = t.GetComponentInChildren<Text>().text;
            s_napr();
            tG2.gameObject.SetActive(false);
        }    
    }
    void s_name() 
    {
        
        btn.gameObject.SetActive(false);
        text3.text = "Слушаю...";
        text2.text = "Если я правильно распознал ваш возраст, скажите 'Да', если неправильно, и хотите перезаписать, скажите 'Нет'.";
        text0.text = name + ", скажите свой возраст";
        answer = false;
    }
    void s_age()
    {
        text3.text = "Слушаю...";
        text2.text = "Если я правильно распознал ваш пол, скажите 'Да', если неправильно, и хотите перезаписать, скажите 'Нет'.";
        text0.text = name + ", ваш пол";
        answer = false;
    }
    void s_gender()
    {
        text3.text = "Слушаю...";
        text0.text = name + ", выберите направление";
        answer = true;
    }
    void s_napr()
    {
        text3.text = "Слушаю...";
        text0.text = name + ", выберите направление";
        answer = true;
        smn.NextScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isActive && !cvs.GetComponent<VoskSpeechToText>()._didInit)
        {
            cvs.GetComponent<VoskSpeechToText>().StartVoskStt();
            cvs.GetComponent<VoskSpeechToText>()._didInit = true;
        }
        if (!isActive && cvs.GetComponent<VoskSpeechToText>()._didInit)
        {
            cvs.GetComponent<VoskSpeechToText>().ToggleRecording();
            cvs.GetComponent<VoskSpeechToText>()._didInit = false;
        }*/
        if (!cvs.GetComponent<VoskSpeechToText>()._running)
            //text3.text = "Загрузка...";
            img.gameObject.SetActive(true);
        if (cvs.GetComponent<VoskSpeechToText>()._running)// && text3.text == "Загрузка...")
            //text3.text = "";
            img.gameObject.SetActive(false);
        if (text3.text == "")
            text3.text = "Слушаю...";
        if (text3.text == "Слушаю...")
            text2.gameObject.SetActive(false);
        if (text3.text != "Слушаю...")
            text2.gameObject.SetActive(true);
    }
    private void OnTranscriptionResult(string obj)
    {
        var result = new RecognitionResult(obj);
        foreach (RecognizedPhrase p in result.Phrases)
        {
            //ИМЯ
            if (name == "")
            {
                if (answer)
                {
                    if (p.Text == yes)
                    {
                        name = text3.text;
                        s_name();
                        return;
                    }
                    if (p.Text == no)
                    {
                        text3.text = "Слушаю...";
                        answer = false;
                        return;
                    }
                }
                else
                {
                    if (result.Phrases.Length > 0 && result.Phrases[0].Text != "")
                    {
                        text3.text = p.Text;
                    }
                    if (text3.text != "Слушаю...")
                    {
                        answer = true;
                    }
                    if (text3.text == "Слушаю...")
                    {
                        answer = false;
                    }
                }
            }
            //ВОЗРАСТ
            if (name != "" && age == -1)
            {
                if (answer)
                {
                    if (p.Text == yes)
                    {
                        age = int.Parse(text3.text);
                        s_age();
                        return;
                    }
                    if (p.Text == no)
                    {
                        text3.text = "Слушаю...";
                        answer = false;
                        return;
                    }
                }
                else
                {
                    if (result.Phrases.Length > 0 && result.Phrases[0].Text != "")
                    {
                        text3.text = ageSet[p.Text].ToString();
                    }
                    if (text3.text != "Слушаю...")
                    {
                        answer = true;
                    }
                    if (text3.text == "Слушаю...")
                    {
                        answer = false;
                    }
                }
            }
            //ПОЛ
            if (name != "" && age != -1 && gender == "")
            {
                if (answer)
                {
                    if (p.Text == yes)
                    {
                        gender = text3.text;
                        s_gender();
                        return;
                    }
                    if (p.Text == no)
                    {
                        text3.text = "Слушаю...";
                        answer = false;
                        return;
                    }
                }
                else
                {
                    if (result.Phrases.Length > 0 && result.Phrases[0].Text != "" && (p.Text == mn || p.Text == wn))
                    {
                        text3.text = p.Text;
                    }
                    if (text3.text != "Слушаю...")
                    {
                        answer = true;
                    }
                    if (text3.text == "Слушаю...")
                    {
                        answer = false;
                    }
                }
            }
            //НАПРАВЛЕНИЕ
            if (name != "" && age != -1 && gender != "" && napr == "")
            {
                if (answer)
                {
                    if (p.Text == IS || p.Text == IM || p.Text == IB)
                    {
                        napr = text3.text;
                        s_napr();
                        return;
                    }
                }
                else
                {
                    if (result.Phrases.Length > 0 && result.Phrases[0].Text != "")
                    {
                        text3.text = p.Text;
                    }
                    if (text3.text != "Слушаю...")
                    {
                        answer = true;
                    }
                    if (text3.text == "Слушаю...")
                    {
                        answer = false;
                    }
                }
            }
        }
    }
}
