using UnityEngine;

public class ZombieFast : Enemy
{
    public override void Start()
    {
        base.Start();
        speed = 4f;
        health = 30f;
    }
}