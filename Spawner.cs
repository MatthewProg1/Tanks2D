using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform spawner1;
    public Transform spawner2;
    public Transform spawner3;
    public Transform spawner4;
    public Transform spawner5;
    public Transform spawner6;

    public GameObject tank;
    public float level = 12;


    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(level);

        switch (Random.Range(1, 7))
        {
            case 1:
                Instantiate(tank, spawner1.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(tank, spawner2.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(tank, spawner3.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(tank, spawner4.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(tank, spawner5.position, Quaternion.identity);
                break;
            case 6:
                Instantiate(tank, spawner6.position, Quaternion.identity);
                break;
        }

        StartCoroutine(Spawn());


    }
}
