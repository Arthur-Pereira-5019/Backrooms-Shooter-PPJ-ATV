using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float velocidade = 3.0f;
    public float gravidade = 9.8f;

    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveX = Input.GetAxis("Horizontal") * Vector3.right * velocidade * Time.deltaTime;

        Vector3 moveZ = Input.GetAxis("Vertical") * Vector3.forward * velocidade * Time.deltaTime;

        Vector3 move = transform.TransformDirection(moveX + moveZ);

        move.y -= gravidade * Time.deltaTime;

        controller.Move(move);
    }
}
