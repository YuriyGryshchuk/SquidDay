using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupSpawner<IObject> : SpawnerBase<IObject> where IObject : Pickup
{
    
}
