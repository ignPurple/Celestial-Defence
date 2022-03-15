using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseModule : Module
{
    public Transform gunPivot;
    public Gun gun;
    public float rotationSpeed = 5f;

    public float tickDelay = 2f;
    private float delay;

    void Start()
    {
        this.delay = this.tickDelay;
    }

    public override void Tick()
    {
        this.RotateGun();

        if (this.delay > 0)
        {
            this.delay -= Time.deltaTime;
            return;
        }

        this.delay = this.tickDelay;

        gun.Shoot();
    }

    private void RotateGun() 
    {
        if (this.gunPivot == null)
        {
            return;
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Transform gunTransform = gunPivot.transform;
        Vector2 gunPos = gunPivot.position;
        float rotation = Mathf.Atan2(mousePos.y - gunPos.y, mousePos.x - gunPos.x) * Mathf.Rad2Deg - 90;
        gunTransform.rotation = Quaternion.Lerp(gunTransform.rotation, Quaternion.Euler(0, 0, rotation), rotationSpeed * Time.deltaTime);
    }
}
