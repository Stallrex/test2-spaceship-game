using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource audioSource;
    public float speed = 5;
    public float x;
    public float y;

    public float RotationSpeed = 2;

    public GameObject trail;

    public Transform firepoint;

    private bool CanMove = true;
    public Transform firepoint2;

    public GameObject bullet;

    public GameObject explosion;

    public AudioClip shoot;
    public AudioClip explode;

    public GameObject bullet_sprite;
    public GameObject bullet_sprite1;
    public GameObject bullet_sprite2;

    public int bullet_count;

// Base Stuff
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating(nameof(AddBullet), 3, 5);
    }
    void Update(){
        ShowBullets();
        if(CanMove == true){
        Movement();
        }
        
        OutOfBounds();

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Shoot();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Meteor") && CanMove)
        {
        
        Instantiate(explosion, transform.position, transform.rotation);
        CanMove = false;
        Invoke("Reload", 3);
        audioSource.PlayOneShot(explode);
        }
    }

// Shooting, Displayin Shooting
    void Shoot(){
        if(bullet_count > 0){
            audioSource.PlayOneShot(shoot);
            Instantiate(bullet, firepoint.position, firepoint.rotation);
            Instantiate(bullet, firepoint2.position, firepoint2.rotation);
            bullet_count--;

        }
        
    }

    void AddBullet(){
        if(bullet_count < 3){

            bullet_count++;
        }
    }

    void ShowBullets(){

        if(bullet_count == 0){

            bullet_sprite.SetActive(false);
            bullet_sprite1.SetActive(false);
            bullet_sprite2.SetActive(false);

        }
        if(bullet_count == 1){

            bullet_sprite.SetActive(true);
            bullet_sprite1.SetActive(false);
            bullet_sprite2.SetActive(false);

        }
        if(bullet_count == 2){

            bullet_sprite.SetActive(true);
            bullet_sprite1.SetActive(true);
            bullet_sprite2.SetActive(false);

        }
        if(bullet_count == 3){

            bullet_sprite.SetActive(true);
            bullet_sprite1.SetActive(true);
            bullet_sprite2.SetActive(true);

        }


    }

    void Reload(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OutOfBounds(){
        Vector2 screenPos = Camera.main.WorldToViewportPoint(transform.position);
            if(screenPos.x < 0){

              transform.position = transform.position * Vector2.left - new Vector2(1,0);

            }
            if(screenPos.x > 1){

              transform.position = transform.position * Vector2.left + new Vector2(1,0);

            }
            if(screenPos.y < 0){

              transform.position = transform.position * Vector2.down - new Vector2(0,1);

            }
            if(screenPos.y > 1){

              transform.position = transform.position * Vector2.down + new Vector2(0,1);

            }
    }


// Movement
    void Movement(){
        if(y == 0){
            trail.SetActive(false);
        }
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        var forceY = y * speed;
        Velocity(forceY);
        Rotate(transform, x * -RotationSpeed);
    }


    void Velocity(float speeding){

        Vector2 force = transform.up * speeding;
        rb.AddForce(force, ForceMode2D.Force);
        trail.SetActive(true);
    }

    void Rotate(Transform t, float angle){
        
        t.Rotate(0, 0, angle);

    } 
}
