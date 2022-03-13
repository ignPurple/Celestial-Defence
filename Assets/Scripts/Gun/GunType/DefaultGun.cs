using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : Gun
{
    public override void Shoot()
    {
        for (int bullets = 0; bullets < this.bulletAmount; bullets++)
        {
            this.SpawnBullet(true);
        }
    }
}
