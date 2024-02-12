using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    bool hit = false;
    bool pickedUp = false;
    MeshRenderer meshRenderer;
    [SerializeField]
        float respawnTimer = 5f;
    public int Value
    {
        get; protected set;
    }
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        Collider foodCollider = GetComponent<Collider>();
        foodCollider.isTrigger = true;
        Value = GameConstants.BaseFoodValue;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && !hit && !pickedUp)
        {
            hit = true;
            GameManager.Instance.Score += Value; //recall that the value is set in each one of the food's children
            pickedUp = true;
            StartCoroutine(RespawnFood());
        }
        
    }
    IEnumerator RespawnFood()
    {
        Debug.Log("Coroutine Started");
        StartCoroutine(alphaFade());
        yield return new WaitForSeconds(respawnTimer);
        pickedUp = false;
        alphaReset();
        Instantiate(this.gameObject, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);


    }
    IEnumerator alphaFade()
    {
        float alpha = 0.0f;
        meshRenderer.material.SetColor("_Color", Color.white * alpha);

        while (alpha < 1.0f && pickedUp == true)
        {
            alpha += 0.02f / respawnTimer;
            meshRenderer.material.SetColor("_Color", Color.white * alpha);
            yield return new WaitForFixedUpdate();
        }
    }
    public void alphaReset()
    {
        float alpha = 1.0f;
        meshRenderer.material.SetColor("_Color", Color.white * alpha);
    }

}
