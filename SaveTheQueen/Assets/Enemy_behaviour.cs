using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_behaviour : MonoBehaviour{
    [SerializeField]
    private int moveSpeed;

    public int moveX;

    Rigidbody2D rB;

    void Start(){
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        // if(!Movement.isDead){
            rB.velocity = new Vector2(moveX * moveSpeed, rB.velocity.y);
        // }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy"){
            Flip();
        }
        if (collision.gameObject.tag == "Player" ){
            //panggil collision.gameObject.GetComponet<namascript yg ngurangi damager.nama fungsi>();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log(collision.name);
        if (collision.gameObject.tag == "Batas"){
            Flip();
        }
    
    }


    public void Flip(){
        if (moveX > 0){
            moveX = -1;
            transform.eulerAngles = Vector3.zero;
        } else {
            moveX = 1;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    
}