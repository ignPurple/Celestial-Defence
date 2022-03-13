using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : MonoBehaviour
{
    public int x;
    public int y;

    public void SetLoc(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public abstract void Tick();
}
