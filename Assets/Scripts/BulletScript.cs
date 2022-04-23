using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // modificar la verlocidad de la bala
    public AudioClip Sound;
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction; 


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }


    private void FixedUpdate()
    {
        //derecha
        Rigidbody2D.velocity = Direction * Speed;
    }
    //recibira la direccion
    public void SetDirection(Vector2 direction){
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        JohnMovement jhon = collision.GetComponent<JohnMovement>();
        GruntScripts grunt = collision.GetComponent<GruntScripts>();
        if(jhon != null)
        {
            jhon.Hit();
        }
        if(grunt != null)
        {
            grunt.Hit();
        }
        DestroyBullet();
    }
    //colision de las balas 
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        JohnMovement jhon = collision.collider.GetComponent<JohnMovement>();
        GruntScripts grunt = collision.collider.GetComponent<GruntScripts>();
        if(jhon != null)
        {
            jhon.Hit();
        }
        if(grunt != null)
        {
            grunt.Hit();
        }
        DestroyBullet();
    }*/
}
