using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rb;
    public float lifetime;
    public float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move(){
        
        //Vector2 force = transform.up * 1.1;
        rb.AddForce(transform.up * speed, ForceMode2D.Force);
        lifetime -= 1 * Time.deltaTime;
        if(lifetime < 0){

            Destroy(gameObject);
        }

    }
}
