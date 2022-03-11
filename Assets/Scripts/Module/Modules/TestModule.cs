using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestModule : Module
{
    public override void Tick() {
        GetComponent<SpriteRenderer>().color = UnityEngine.Random.ColorHSV();
    }
}
