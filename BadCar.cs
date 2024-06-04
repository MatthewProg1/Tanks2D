using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCar : MonoBehaviour
{
    public GameObject pl;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pl.transform.position.x > -90 && pl.transform.position.x < -6)
        {
            if (pl.transform.position.y < -7 && pl.transform.position.y > -51)
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
        else
        {
            //transform.rotation = pl.transform.rotation;
        }

        //transform.LookAt(target, Vector3.left);

        
        
    }
}
