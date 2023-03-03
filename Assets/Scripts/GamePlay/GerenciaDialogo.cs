using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciaDialogo : MonoBehaviour
{
    public Text NameText;
    public Text DialogoText;
    public Queue<string> sentencas;
    public Animator anime;
    public bool isSpeaking = false;
    public Image ImagemNPC;
    // Start is called before the first frame update
    void Start()
    {
        anime = GameObject.FindGameObjectWithTag("GUI/Dialogo").GetComponent<Animator>();
        sentencas = new Queue<string>();
        DialogoText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && isSpeaking == true)
        {
            StartCoroutine(MostraProximaSentenca());
        }
    }
    public void AwakeDialogo(Dialogo dialogo)
    {
        StartCoroutine(StartDialogo(dialogo));
        DialogoText.text = "";
    }
    IEnumerator StartDialogo(Dialogo dialogoC)
    {
        ImagemNPC.sprite = dialogoC.ImagemNpc;
        NameText.text = dialogoC.Name;
        sentencas.Clear();
        foreach(string sentenca in dialogoC.SentenceText)
        {
            sentencas.Enqueue(sentenca);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(MostraProximaSentenca());
    }

    IEnumerator MostraProximaSentenca()
    {
        if (sentencas.Count == 0)
        {
            StartCoroutine(FimDialogo());
            yield return null; 
        }
        string sentence = sentencas.Dequeue();
        //DialogoText.text = sentence;
        isSpeaking = true;
        FindObjectOfType<EscreveTexto>().AddText(DialogoText, sentence, 0.09f);
        
    }
    IEnumerator FimDialogo()
    {
        anime.SetTrigger("Nmostra");
        anime.ResetTrigger("Mostra");
        isSpeaking = false;
        yield return null;
    }
}
