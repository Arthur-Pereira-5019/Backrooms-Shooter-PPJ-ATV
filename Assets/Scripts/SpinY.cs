using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpinY : MonoBehaviour
{

public float speed = 90f;

    void Update()
    {

            gameObject.transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
        
    }
}
