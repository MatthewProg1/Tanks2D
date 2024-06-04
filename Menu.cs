using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update

    public int BestScore;

    public Text text;



    void Start()
    {
        BestScore = PlayerPrefs.GetInt("BestScore");
        text.text = BestScore + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
