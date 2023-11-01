using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    float LockPos = 0;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(LockPos,LockPos, LockPos);

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Перезагружает moveDelta
        moveDelta = new Vector3(x, y, 0);

        //Меняет направление спрайта,в независимости куда идешь вправо или влево
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking")); 
        if (hit.collider == null)
        {
            //Позволяет двигаться персу
            transform.Translate(0,moveDelta.y * Time.deltaTime * 5,0);
        }


        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //Позволяет двигаться персу
            transform.Translate(moveDelta.x * Time.deltaTime * 5, 0,0);
        }

    }
}