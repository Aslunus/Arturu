using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControllerPLayer : MonoBehaviour
{
    public float speed = 4.0f;
    public float speedJump = 8.0f;
    public float gravity = 20.0f;

    public GameObject player;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.transform.position += player.transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.transform.position -= player.transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                player.transform.position += player.transform.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                player.transform.position -= player.transform.right * speed * Time.deltaTime;//персонаж плавно двигается на W,S,D,A;
            }

        }
    }
}