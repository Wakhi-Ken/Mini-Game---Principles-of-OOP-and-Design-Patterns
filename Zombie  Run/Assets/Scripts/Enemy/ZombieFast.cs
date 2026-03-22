using UnityEngine;

public class ZombieFast : Enemy
{

    protected override void Start()
    {
        // Call the base class's Start method to ensure any initialization in the Enemy class is performed
        base.Start();
        speed = 7f;
      
    }
}