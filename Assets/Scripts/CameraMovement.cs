using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 position = transform.position;
        if(Input.GetKey(KeyCode.W))
        {
            position.y+=0.1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            position.x-= 0.1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.y-= 0.1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += 0.1f;
        }
        transform.position = position;
        */
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z);
    }
}
