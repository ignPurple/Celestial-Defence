using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWidthManager : MonoBehaviour
{
    public Spaceship spaceship;
    public float baseSize = 1.5f;

    void Start()
    {
        Camera.main.orthographicSize = this.baseSize;
    }

    void FixedUpdate()
    {
        int maxSize = 0;

        foreach (Module module in this.spaceship.GetSpaceshipGrid().GetModules())
        {
            int x = (int) Mathf.Abs(module.transform.position.x);
            int y = (int) Mathf.Abs(module.transform.position.y);
            maxSize = Mathf.Max(maxSize, x, y);
        }

        float currentSize = Camera.main.orthographicSize;
        Camera.main.orthographicSize = Mathf.Lerp(currentSize, this.baseSize + maxSize, Time.deltaTime);
    }
}
