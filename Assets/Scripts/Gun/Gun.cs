using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public Transform gunPivot;
    public Transform firePoint;

    public Bullet bulletType;
    public float bulletSpeed;
    public float bulletAmount;
    public float bulletSpread;

    public abstract void Shoot();

    protected Transform SpawnBullet(bool applyMovement = false) 
    {
        float rotation = gunPivot.rotation.eulerAngles.z;
        Debug.Log(rotation);
        rotation += Random.Range(-this.bulletSpread, this.bulletSpread);

        Transform bullet = Instantiate(this.bulletType.transform, this.firePoint.position, Quaternion.Euler(0, 0, rotation));
        if (applyMovement)
        {
            this.BulletMovement(bullet);
        }

        return bullet;
    }

    protected void BulletMovement(Transform bullet)
    {
        if (bullet.GetComponent<Bullet>() == null || bullet.GetComponent<Rigidbody2D>() == null)
        {
            return;
        }

        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = bullet.up * this.bulletSpeed;
    }
}
