using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{

    public void OnDeSpawn()
    {
        PoolManager.Instance.Despawn(this);// if we are told by the manager to despawn we despawn
    }
}
