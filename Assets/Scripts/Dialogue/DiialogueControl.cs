using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiialogueControl : MonoBehaviour
{
   [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa
    } 

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj; //Janela do dialogo
    public Image profileSprite; //sprite do porfil
    public Text speechText; //texto da fala
    public Text axctorNameText; //nome do npc

    [Header("Settings")]
    public float typingSpeed; // velocidade da fala

    //vari�veis de contrle
    public bool isShowing; // se a jenela est� vis�vel
    private int index; //index das senten�as
    private string[] sentences;

    public static DiialogueControl instance;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    IEnumerator TypeSentence() //vai mostrar letra por letra 
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    
    //pular pra proxima frase/fala
    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else //quando terminam os textos
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    //chamar a fala do npc
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
