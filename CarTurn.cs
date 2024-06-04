using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarTurn : MonoBehaviour
{
    // Start is called before the first frame update


    public int speed;
    public float JumpForce;

  //  public Rigidbody2D rig;

    public int moveSpeed = 5;


    private Vector3 mousePos;

    public GameObject bashna;

    public GameObject patron;

    public Transform shoot;

    bool yes = true;

    public int hp = 100;

    public Slider hpBar;

    public float offset;

    public int tanks = 0;

    public Text TextTanks;

   



   // public Text CountTanks;

    //public GameObject vrag;

    public bool ride = false;
    public bool ride2 = false;



    public GameObject part1;
    public GameObject part2;
    public GameObject part3;
    public GameObject part4;


    int BestScore;

 







    void Start()
    {
      
    }

    // Update is called once per frame



    //void Update()
    //{
    //    if (Input.GetButtonDown(KeyCode.W)
    //    {
    //        transform.Translate(Vector3.up * 10 * Time.deltaTime);
    //    }
    //    if (Pressed2)
    //    {
    //        transform.Rotate(0, 0, -3f);
    //    }
    //    if (Pressed3)
    //    {
    //        transform.Rotate(0, 0, 3f);
    //    }
    //}

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            ride = true;
            ride2 = false;
      


        }

        if (Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false)
        {
            ride = false;
            ride2 = false;
        }



        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            ride = false;
            ride2 = true;
        
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -0.3f);

        
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, 0.3f);
           
        }

        

        if (Input.GetMouseButton(0))
        {
            StartCoroutine(Shoot());
        }

        if (ride)
        {
            part1.SetActive(true);
            part2.SetActive(true);
        }
        if(ride == false)
        {
            part1.SetActive(false);
            part2.SetActive(false);
        }

        if (ride2)
        {
            part3.SetActive(true);
            part4.SetActive(true);
        }
        if(ride2 == false)
        {
            part3.SetActive(false);
            part4.SetActive(false);
        }







        //mousePosition.z = transform.position.z - Camera.main.transform.position.z; // это только для перспективной камеры необходимо
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bashna.transform.position; //положение мыши из экранных в мировые координаты
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        bashna.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
    



        //bashna.transform.position = Vector2.MoveTowards(transform.position, Input.mousePosition, 1 * Time.deltaTime);


    }



    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Vrag")
        {
            hp -= 10;

            hpBar.value = hp;

            if(hp < 0)
            {
                BestScore = PlayerPrefs.GetInt("BestScore");
                if(BestScore < tanks)
                {
                    BestScore = tanks;
                    PlayerPrefs.SetInt("BestScore", BestScore);
                }
                SceneManager.LoadScene("Menu");
            }


        }

        if(collision.gameObject.tag == "Health")
        {
            hp += 25;
            hpBar.value = hp;

        }
    }

   

    

    public IEnumerator Shoot()
    {
        if (yes)
        {
            var pat = Instantiate(patron, shoot.position, Quaternion.identity);
            pat.transform.rotation = bashna.transform.rotation;
            StartCoroutine(Wait());
            yield return new WaitForSeconds(1.5f);
            Destroy(pat);
        }
    }

    public IEnumerator Wait()
    {
        yes = false;
        yield return new WaitForSeconds(0.8f);
        yes = true;
    }

}
