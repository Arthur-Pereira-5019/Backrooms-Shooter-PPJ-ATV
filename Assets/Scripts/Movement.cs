using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocidade = 10f;
    public bool mx = false;
    public bool my = false;
    public bool mz = false;

    // Start is called before the first frame update
    void Start()
    {
        mx = (Random.value > 0.5);
        my = (Random.value > 0.5);
        mz = (Random.value > 0.5);
    }

    // Update is called once per frame
    void Update()
    {
        if(mx) {
gameObject.transform.Translate(Vector3.right*velocidade*Time.deltaTime*Mathf.Cos(Time.timeSinceLevelLoad), Space.World);
        }
        if(my) {
            gameObject.transform.Translate(Vector3.up*velocidade*Time.deltaTime*Mathf.Sin(Time.timeSinceLevelLoad), Space.World);
        }
        if(mz) {
gameObject.transform.Translate(Vector3.back*velocidade*Time.deltaTime*Mathf.Cos(Time.timeSinceLevelLoad), Space.World);
        }
        if(mx == false && my == false && mz == false) {
            mx = true;
            mz = true;
            my = true;
        }
    }
}
