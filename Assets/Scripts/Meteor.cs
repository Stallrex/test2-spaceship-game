using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    
    AudioSource audioSource;
    Rigidbody2D rb;
    public float lifetime;
    public float speed;
    public AudioClip explode;

    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        var speed = Random.Range(0.1f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
    }

    void Fly(){
        
        //Vector2 force = transform.up * 1.1;
        rb.AddForce(transform.up * speed, ForceMode2D.Force);
        lifetime -= 1 * Time.deltaTime;
        if(lifetime < 0){
            audioSource.PlayOneShot(explode);
            Destroy(gameObject);
            Instantiate(particle, transform.position, transform.rotation);
        }

    }
}
