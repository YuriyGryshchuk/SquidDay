using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBase<TObject> : MonoBehaviour where TObject : Object
{
    [SerializeField] protected TObject _spawnObject;

    protected TObject Spawn()
    {
        return default;
    }
}
