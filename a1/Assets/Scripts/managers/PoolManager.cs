using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    Dictionary<string, Stack<PoolObject>> stackDictionary = new Dictionary<string, Stack<PoolObject>>();
    // Start is called before the first frame update
    void Start()
    {
        PoolManager.Instance.Load();
    }


    private void Load()
    {
        PoolObject[] poolObjects = Resources.LoadAll<PoolObject>("PoolObjects");
        foreach(PoolObject poolObject in poolObjects)
        {
            Stack<PoolObject> objStack = new Stack<PoolObject>();
            objStack.Push(poolObject); // in a stack, we push something in and pop it out.
            stackDictionary.Add(poolObject.name, objStack); // we do this so that we know which stack to grab a particular object from.
        }
    }
    public PoolObject Spawn(string name)
    {
        //first we need to ref the correct stack
        Stack<PoolObject> objStack = stackDictionary[name];// grab the correct obj
        // two possible situations, if only one item left we will instatiate a new object (this is to make sure we allways have one object)
        // if more than one exists we simply pop one out
        if(objStack.Count == 1)
        {
            PoolObject poolObject = objStack.Peek();
            PoolObject objectClone = Instantiate(poolObject);
            objectClone.name = poolObject.name;
            return objectClone;
        }
        PoolObject oldPoolObject = objStack.Pop();
        oldPoolObject.gameObject.SetActive(true);
        return oldPoolObject;
    }
    public void Despawn(PoolObject poolObject)
    {
        Stack<PoolObject> objStack = stackDictionary[poolObject.name];
        poolObject.gameObject.SetActive(false);
        objStack.Push(poolObject);
    }
}
