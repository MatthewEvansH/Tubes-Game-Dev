using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set;}
    private Animator anim;
    private bool dead;

    // UNTUK INVUNERABILITY
    // [Header ("iFrames")]
    // [SerializeField] private float iFramesDuration;
    // [SerializeField] private int numberOfFlashes;
    // private SpriteRenderer spriteRend;

    void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        // spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth > 0){
            anim.SetTrigger("Hurt");
            // StartCoroutine(Invunerability()); //untuk invunerability
        } 
        else {
            if(!dead){
                anim.SetTrigger("Die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    // private IEnumerator Invunerability()
    // {
    //     Physics2D.IgnoreLayerCollision(13, 9, true); // 13 itu player dan 9 enemies layer (true = player invunerable)
    //     //durasi invunerability
    //     for(int i = 0; i < numberOfFlashes; i++){
    //         spriteRend.color = new Color(1, 0, 0, 0.5f); //change player sprite renderer to red colour untuk beberapa detik
    //         yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes) * 2);
    //         spriteRend.color = Color.white;
    //         yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes) * 2);
    //     }
    //     Physics2D.IgnoreLayerCollision(13, 9, false); // false = player vunerable
    // }

    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("Idle");
    }
}
