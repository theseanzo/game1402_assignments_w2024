using System.Collections;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 5f;
    [SerializeField] float fadeDelay = 10f;

    GameObject targetObject;

    public void Spawn(string prefabTag, Vector3 position)
    {
        StartCoroutine(Generate(prefabTag, position));
    }
    
    IEnumerator Generate(string prefabTag, Vector3 position)
    {
        GameObject prefabGameObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Foods/" + prefabTag + ".prefab", typeof(GameObject)); //load asset based on prefabTag
        yield return new WaitForSeconds(spawnDelay);

        targetObject = Instantiate(prefabGameObject, position, Quaternion.identity); //instantiate new prefab in the set position
        targetObject.GetComponent<BoxCollider>().enabled = false; //disable collider
    }
}
