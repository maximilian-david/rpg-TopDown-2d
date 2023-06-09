using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;

    public DialogueSettings dialogue;

    bool playerHit;

    private List<string> senteces = new List<string>();


    private void Start()
    {
        GetNPCInfo();
    }
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DiialogueControl.instance.Speech(senteces.ToArray());
        }
    }

    void GetNPCInfo()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DiialogueControl.instance.language)
            {
                case DiialogueControl.idiom.pt:
                    senteces.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;
                case DiialogueControl.idiom.eng:
                    senteces.Add(dialogue.dialogues[i].sentence.english);
                    break;
                case DiialogueControl.idiom.spa:
                    senteces.Add(dialogue.dialogues[i].sentence.spanish);
                    break;
                default:
                    break;
            }
           
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
         
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
