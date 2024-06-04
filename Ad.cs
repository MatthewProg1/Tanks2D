using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrazyGames;
public class Ad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    public void ShowAd()
    {
        CrazyAds.Instance.beginAdBreak(Start, );
    }

    void AdError()
    {
        print("Ad has not been displayed");
        Start();
    }
}
