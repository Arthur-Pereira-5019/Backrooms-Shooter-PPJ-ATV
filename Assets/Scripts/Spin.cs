using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spin : MonoBehaviour
{

public float speed = 90f;
public bool x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        x = (Random.value > 0.5);
        y = (Random.value > 0.5);
        z = (Random.value > 0.5);
    }

    // Update is called once per frame
    void Update()
    {
        if(x) {
            gameObject.transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
         if(y) {
            gameObject.transform.Rotate(Vector3.right * speed * Time.deltaTime, Space.World);
        }
         if(z) {
            gameObject.transform.Rotate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
        
    }
}
