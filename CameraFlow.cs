using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    private Vector3 playerVector;
    public Transform player;
    public int speed;


    void Start()
    {
        
    }



    void Update()
    {
        playerVector = player.position;

        playerVector.z = -10;
        transform.position = Vector3.Lerp(transform.position, playerVector, speed * Time.deltaTime);
    }
}
