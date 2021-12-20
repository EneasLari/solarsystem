using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy")
        {
            if (Camera.main.GetComponent<CanvasManager>().score > 0)
            {
                Camera.main.GetComponent<CanvasManager>().score--;
            }
        }
        else if(other.gameObject.tag=="Sun"){
            print(Camera.main.GetComponent<flycamera>().initialposition);
            Camera.main.transform.position = Camera.main.GetComponent<flycamera>().initialposition;
        }
    }
}
