using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollideManager : MonoBehaviour
{

    public GameObject explosionpeciesPrefab;
    public GameObject explosionpeciesPrefab2;
    public float ExplosionPower = 60f;
    public float radius = 20;
    private AudioSource ExplosionAudioSource;
    public AudioClip ExplosionClip;


    void Start()
    {
        ExplosionAudioSource = Camera.main.GetComponent<AudioSource>();
        Destroy(gameObject, 10f);

    }

    //If your GameObject starts to collide with another GameObject with a Collider
    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Sun")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Player")
        {
            Camera.main.GetComponent<CanvasManager>().score++;
            ExplosionAudioSource.clip = ExplosionClip;
            ExplosionAudioSource.PlayOneShot(ExplosionAudioSource.clip);

            //Output the Collider's GameObject's name

            GameObject objectcollided = collision.collider.gameObject;
            GameObject newpecies = Instantiate(explosionpeciesPrefab, objectcollided.transform.position, Quaternion.identity);
            GameObject newpecies2 = Instantiate(explosionpeciesPrefab2, transform.position, Quaternion.identity);

            objectcollided.SetActive(false);
            gameObject.SetActive(false);

            Explode(newpecies);
            Explode(newpecies2);


            Destroy(objectcollided, 1f);
            Destroy(gameObject, 1f);
            Destroy(newpecies, 2f);
            Destroy(newpecies2, 2f);
        }
        else{
            if (Camera.main.GetComponent<CanvasManager>().score>0) {
                Camera.main.GetComponent<CanvasManager>().score--;
            }
        }

    }

    private void Explode(GameObject explosionparent)
    {
        Vector3 explosionPos = explosionparent.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(ExplosionPower, explosionPos, radius, 1.0F);
        }
    }
}
