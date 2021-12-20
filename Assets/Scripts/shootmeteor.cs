using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootmeteor : MonoBehaviour
{

    public GameObject meteor;
    public float shootSpeed = 50;
    public Transform shootingtransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootBullet();
        }
    }

    void shootBullet()
    {

        GameObject newmeteor= Instantiate(meteor, shootingtransform.position, Quaternion.identity);
        //Get the Rigidbody that is attached to that instantiated bullet
        Rigidbody projectile = newmeteor.GetComponent<Rigidbody>();

        //Shoot the Bullet
        projectile.velocity = shootingtransform.forward * shootSpeed;
    }
}
