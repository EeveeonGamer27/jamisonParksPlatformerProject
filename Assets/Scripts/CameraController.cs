using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("TaxingEeveeon").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.position.x, transform.position.y, -10);
        /*if (player.position.x >= transform.position.x + 4)
        {
            Vector3 movingCam = transform.position;
            movingCam.x += Speed * Time.deltaTime;
            transform.position = new Vector3(movingCam.x, transform.position.y, -10);

            if (player.position.x >= transform.position.x + 7.5)
            {
                    Vector3 movingCam2 = transform.position;
                    movingCam2.x += Speed * Time.deltaTime;
                    transform.position = new Vector3(movingCam2.x, transform.position.y, -10);

                if (player.position.x >= transform.position.x + 10)
                {
                    Vector3 movingCam3 = transform.position;
                    movingCam3.x += Speed * 2 * Time.deltaTime;
                    transform.position = new Vector3(movingCam3.x, transform.position.y, -10);
                }
            }
        }
        else if (player.position.x <= transform.position.x - 4)
        {
            Vector3 movingCam = transform.position;
            movingCam.x -= Speed * Time.deltaTime;
            transform.position = new Vector3(movingCam.x, transform.position.y, -10);

            if (player.position.x <= transform.position.x - 7.5)
            {
                Vector3 movingCam2 = transform.position;
                movingCam2.x -= Speed * Time.deltaTime;
                transform.position = new Vector3(movingCam2.x, transform.position.y, -10);

                if (player.position.x <= transform.position.x - 10)
                {
                    Vector3 movingCam3 = transform.position;
                    movingCam3.x -= Speed * 2 * Time.deltaTime;
                    transform.position = new Vector3(movingCam3.x, transform.position.y, -10);
                }
            }
        }*/
    }
}
