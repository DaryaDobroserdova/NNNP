using UnityEngine;
using UnityEngine.UI;

public class Dolgi : MonoBehaviour
{

    public VoskSpeechToText VoskSpeechToText;
    public Button btn, btn1;
    public Text t;
    public Image img;
    public Canvas cvs;
    private string sam = "сделать все самому";
    private string help = "попросить помощи у друзей";
    ScenesManager sm = new ScenesManager();

    private void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!img.gameObject.activeSelf)
                t.GetComponent<PrintedText>().skip = true;
        }
        if (t.GetComponent<PrintedText>().textEnd)
        {
            btn.gameObject.SetActive(true);
            btn1.gameObject.SetActive(true);
        }
        if (cvs.GetComponent<VoskSpeechToText>()._running)
            img.gameObject.SetActive(false);
    }

    public void MakeAll()
    {
        sm.NextScene(4);
    }

    public void Help()
    {
        sm.NextScene(3);
    }
    private void OnTranscriptionResult(string obj)
    {
        var result = new RecognitionResult(obj);
        foreach (RecognizedPhrase p in result.Phrases)
        {
            if (p.Text == sam && t.GetComponent<PrintedText>().textEnd)
                MakeAll();
            if (p.Text == help && t.GetComponent<PrintedText>().textEnd)
                Help();
            //if (result.Phrases.Length > 0 && result.Phrases[0].Text != "")
            //{
            //    t.text = p.Text;
            //}
        }
    }
}
