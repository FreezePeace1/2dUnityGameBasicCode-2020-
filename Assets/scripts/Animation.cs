using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if ((Input.GetKey(KeyCode.LeftArrow)) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("standorrun", true);
        }
        else
        {
            anim.SetBool("standorrun", false);
        }
        if (Input.GetKey(KeyCode.Mouse2) || (Input.GetKey(KeyCode.F)))
        {
            anim.SetTrigger("Trigger");
        }
    }
}
