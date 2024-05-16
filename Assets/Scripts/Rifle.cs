using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [Header("Rifle things")]
    public Camera cam;

    public float giveDamageOf = 10f;
    public float shootingRange = 100f;
    public float fireCharge = 15f;
    private float nextTimeToShoot = 0f;
    public Animator animator;
    public Playerscript player;
    public Transform hand;

    [Header("Rifle Ammunition and shooting")]
    private int maximumAmmunition = 32;
    public int mag = 10;
    private int presentAmmunition;
    private float reloadTime = 1.3f;
    private bool setReloading = false;

    [Header("Rifle Effects")]
    public ParticleSystem muzzleSpark;
    public GameObject goreEffect;


    private void Awake()
    {
        transform.SetParent(hand);
        presentAmmunition = maximumAmmunition;
    }

    private void Update()
    {

        if (setReloading)
            return;
        if(presentAmmunition <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToShoot)
        {
            animator.SetBool("Fire", true);
            animator.SetBool("Idle", false);
            nextTimeToShoot = Time.time + 1f / fireCharge;
            Shoot();
        }
        else if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Fire", true);
            animator.SetBool("Walk", true);

        }
        else if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Fire", false);
            animator.SetBool("Idleaim", false);
            animator.SetBool("Walk", true);
            animator.SetBool("Idle", false);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Fire", false);
            animator.SetBool("Walk", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Fire", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);
        
        }

    }

    private void Shoot()
    {
        // check for mag
        if(mag == 0)
        {
            //show ammo out
            return;

        }

        presentAmmunition--;

        if(presentAmmunition == 0)
        {
            mag--;
        }


        muzzleSpark.Play();
        RaycastHit hitInfo;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, shootingRange))
        {
            Debug.Log(hitInfo.transform.name);
            Zombie1 zombie1 = hitInfo.transform.GetComponent<Zombie1>();

            if(zombie1 != null)
            {
                zombie1.zombieHitDamage(giveDamageOf);
                GameObject goreEffectGo = Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(goreEffectGo, 1.0f);
            }

        }

    }
    IEnumerator Reload()
    {
        player.playerSpeed = 0f;
        player.playerSprint = 0f;
        setReloading = true;
        Debug.Log("reloading");
        animator.SetBool("Reloading", true);
        //play sound

        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("Reloading", false);
        presentAmmunition = maximumAmmunition;
        player.playerSpeed = 1.9f;
            player.playerSprint = 3f;
        setReloading = false;
    }
}
