using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class training : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(3.5f, 15.9f); //задает положение игрока в начале
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(3, 0) * Time.deltaTime); //изменяет положение игрока кажду секунду по иксу
    }
}
