using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spavn : MonoBehaviour
{
    public GameObject zomb;
    public Transform spavn;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Sec());
        Sec();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Sec()
    {
        yield return new WaitForSeconds(10);
        Instantiate(zomb, spavn);
        StartCoroutine(Sec2());
    }

    public IEnumerator Sec2()
    {
        yield return new WaitForSeconds(10);
       
        StartCoroutine(Sec());
    }
}
