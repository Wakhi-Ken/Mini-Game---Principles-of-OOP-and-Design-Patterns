using UnityEngine;

public class ZombieTank : Enemy
{
    protected override void Start()
    {

        // Call the base class's Start method to ensure any initialization in the Enemy class is performed
        base.Start();
        speed = 5f;
        
    }


}