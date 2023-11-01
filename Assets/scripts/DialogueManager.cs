using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public Animator anim;

    private Queue<string> sentences; //как диалог(ограниченный список)

    void Start()
    {
        sentences = new Queue<string>();
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("Open", true);
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }    

    public void DisplayNextSentence()
    {
        if (sentences.Count==0)
        {
            EndDialogue();
            return;
        }
       string sentence = sentences.Dequeue();
        StopAllCoroutines();                    //Анимация текста O_O(Меняем плавно текст)
        StartCoroutine(TypeSentence(sentence));  
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) //Преобразует строку в массив символов
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        anim.SetBool("Open", false);
        animator.SetBool("isOpen", false);
    }    
}   
