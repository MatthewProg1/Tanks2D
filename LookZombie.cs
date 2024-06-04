using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookZombie : MonoBehaviour
{
    public GameObject pl; // Переменная для координат объекта корабля игрока
    public float speed; // Скорость движения врага

    public void Start()
    {
        
    }

    public void Update()
    {
        if (transform.position.x != pl.transform.position.x && transform.position.y != pl.transform.position.y)
        {
            if (transform.position.y > pl.transform.position.y)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            if (transform.position.y < pl.transform.position.y)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (transform.position.x > pl.transform.position.x)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (transform.position.x < pl.transform.position.x)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }

}
