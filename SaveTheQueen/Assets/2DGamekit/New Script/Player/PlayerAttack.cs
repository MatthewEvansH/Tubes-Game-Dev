using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private GameObject[] bullet;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKey(KeyCode.Z) && cooldownTimer > attackCooldown && playerMovement.CanAttackWithMelee()){
            AttackWithMelee();
        } 
        else if(Input.GetKey(KeyCode.X) && cooldownTimer > attackCooldown && playerMovement.CanAttackWithGun() && !playerMovement.Crouch()){
            AttackWithGunStand();
        }
        else if(playerMovement.Crouch() && Input.GetKey(KeyCode.C) && cooldownTimer > attackCooldown){
            AttackWithGunCrouch();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void AttackWithMelee()
    {
        anim.SetTrigger("AttackWithMelee");
        cooldownTimer = 0;
    }

    private void AttackWithGunStand()
    {
        anim.SetTrigger("AttackWithGunStand");
        cooldownTimer = 0;

        bullet[FindBullet()].transform.position = bulletPoint.position;
        bullet[FindBullet()].GetComponent<Bullet>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private void AttackWithGunCrouch()
    {
        anim.SetTrigger("AttackWithGunCrouch");
        cooldownTimer = 0;

        // bullet[0].transform.position = bulletPoint.position;
        // bullet[0].GetComponent<Bullet>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindBullet()
    {
        for (int i = 0; i < bullet.Length; i++)
        {
            if (!bullet[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
