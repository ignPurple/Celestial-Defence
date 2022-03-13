using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    void FixedUpdate()
    {
        if (!GetComponent<Renderer>().isVisible) 
        {
            Destroy(this.gameObject);
        }
    }

    public abstract void Hit(Collider2D collider2D, GameObject hit);

    void OnTriggerEnter2D(Collider2D collider2D) 
    {
        this.Hit(collider2D, collider2D.gameObject);
    }
}
