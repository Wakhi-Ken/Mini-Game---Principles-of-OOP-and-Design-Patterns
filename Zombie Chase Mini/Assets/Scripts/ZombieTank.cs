using UnityEngine;

public class ZombieTank : Enemy
{
    public override void Start()
    {
        base.Start();
        speed = 1.5f;
        health = 100f;
    }
}