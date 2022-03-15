using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : Bullet
{
    public override void Hit(Collider2D collider2D, GameObject hit)
    {
        Debug.Log("Hi! " + hit.tag);
    }
}
