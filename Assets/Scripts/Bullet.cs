using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Speed;
    Vector3 lastPos;
    
    
    public float impactForce = 10f;
    public float damage = 10f;
    

    void Start()
    {
        lastPos = transform.position;
    }
   

    void Update()
    {

        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        RaycastHit hit;

        Debug.DrawLine(lastPos, transform.position);
        if (Physics.Linecast(lastPos, transform.position, out hit))
        {
            print(hit.transform.name);
            if (hit.rigidbody)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
                Target target = hit.transform.GetComponent<Target>();
                target.TakeDamage(damage);
            }
            //Destroy(d, 10);

            Destroy(gameObject);
        }
        lastPos = transform.position;
        Destroy(gameObject, 3f);
    }
}