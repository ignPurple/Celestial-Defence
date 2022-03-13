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
            int x = Mathf.Abs(module.x);
            int y = Mathf.Abs(module.y);
            maxSize = Mathf.Max(maxSize, x, y);
        }

        float currentSize = Camera.main.orthographicSize;
        Camera.main.orthographicSize = Mathf.Lerp(currentSize, this.baseSize + maxSize - 5, Time.deltaTime);
    }
}
