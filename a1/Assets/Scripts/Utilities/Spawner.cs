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

        Color materialColor = targetObject.GetComponent<Renderer>().material.color;
        targetObject.GetComponent<Renderer>().material.color = new Color(materialColor.r, materialColor.g, materialColor.b, 0); //set alpha to zero

        StartCoroutine(FadeInObject());

        yield return null;
    }

    IEnumerator FadeInObject()
    {
        while (targetObject.GetComponent<Renderer>().material.color.a < 1) //run while material alpha is < 1
        {
            Color materialColor = targetObject.GetComponent<Renderer>().material.color;
            float fadeAmount = materialColor.a + (fadeDelay * Time.deltaTime);

            targetObject.GetComponent<Renderer>().material.color = new Color(materialColor.r, materialColor.g, materialColor.b, fadeAmount); //increase alpha based on fadeAmount

            yield return null;
        }
    }
}
