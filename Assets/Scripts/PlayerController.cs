using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class PlayerController : MonoBehaviour
{
    
    public float impactForce = 10f;
    public float damage = 10f;
    bool MoveMod;
    bool ShootMod;
    public LayerMask movementMask;
    Camera cam;
    PlayerMove move;
    public Animator animator;
    public Transform partRotate;
    public Transform targetLook;
    public GameObject bullet;
    public Transform firePos;
    private Transform target;


    void Start()
    {
        cam = Camera.main;
        move = GetComponent<PlayerMove>();
        MoveMod = true;


    }

    // Update is called once per frame
    void Update()
    {
        MoveMethod();
        Shoot();
    }

    public void MoveMethod()
    {
        if (MoveMod == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, movementMask))
                {
                    move.MoveToPoint(hit.point);
                }
            }
        }
    }
    public void Shoot()
    {
        if (ShootMod == true)
        { 
            
            if (Input.GetMouseButtonDown(0))
            {            
                Instantiate(bullet, firePos.position, firePos.rotation);
                
              
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit,100,movementMask))
                {
                   
                    targetLook.position= Vector3.Lerp(targetLook.position, hit.normal, Time.deltaTime * 40);
                }
                else
                {
                    targetLook.position = Vector3.Lerp(targetLook.position, targetLook.position, Time.deltaTime * 5);
                }
                animator.Play("Shoot");

                Vector3 dir = target.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = lookRotation.eulerAngles;
                partRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


            }



        }
    }
        private void OnTriggerEnter(Collider other)
        {
            MoveMod = false;
            ShootMod = true;
        }
}



   