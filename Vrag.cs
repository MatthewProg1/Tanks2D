using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vrag : MonoBehaviour
{
    // Start is called before the first frame update


    GameObject player;


    public GameObject patron;
    public Transform shoot;

    public GameObject bashna;

    bool yes = true;

    bool start = false;

    public DetectiveObject detectiveObject;

    public int hp = 80;

    float offset = -90f;

   Spawner spawner;

    LevelManegerr levelManegerr;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        levelManegerr = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManegerr>();

        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();

        Debug.Log(player);

      //  StartCoroutine(Detective());
    }

    // Update is called once per frame
    void Update()
    {
        if(detectiveObject.detective == true)
        {
            start = true;
        }
        if (start) { 
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 5f * Time.deltaTime);
            Vector3 difference = player.transform.position - bashna.transform.position; //положение мыши из экранных в мировые координаты
            float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            bashna.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
            StartCoroutine(Shoot());
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

    public IEnumerator Detective()
    {
        if (detectiveObject.detective == true)
        {
            start = true;
         
            StartCoroutine(Shoot());
        }
        else
        {
            start = false;
        }
        yield return new WaitForSeconds(0.5f);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Vrag")
        {
            hp -= 20;
            if(hp <= 0)
            {

                player.GetComponent<CarTurn>().tanks++;
                player.GetComponent<CarTurn>().TextTanks.text = player.GetComponent<CarTurn>().tanks + "";

                if(player.GetComponent<CarTurn>().tanks % 3 == 0)
                {
                    levelManegerr.NowLevel++;
                }

                


                if (spawner.level > 1f)
                {
                    spawner.level -= 0.5f;
                }

                Destroy(gameObject);
            }

        }

        if(collision.gameObject.tag == "Bochka")
        {
            player.GetComponent<CarTurn>().tanks++;
            player.GetComponent<CarTurn>().TextTanks.text = player.GetComponent<CarTurn>().tanks + "";

            Destroy(gameObject);
        }
    }
}
