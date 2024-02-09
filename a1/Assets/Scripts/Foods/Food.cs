using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private float respawnTimerDefault = 1f;
    MeshRenderer meshRenderer;
    bool hit = false;
    public int Value
    {
        get; protected set;
    }
    void Awake()
    {
        Collider foodCollider = GetComponent<Collider>();
        foodCollider.isTrigger = true;
        Value = GameConstants.BaseFoodValue;
        meshRenderer = GetComponent<MeshRenderer>();
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
        if (other.gameObject.GetComponent<PlayerController>() && !hit)
        {
            hit = true;
            GameManager.Instance.Score += Value; //recall that the value is set in each one of the food's children
            StartCoroutine(RespawnFood());
        }
        
    }

    IEnumerator RespawnFood()
    {
        float respawnTimer = respawnTimerDefault;
        GetComponent<BoxCollider>().enabled = false;
        hit = false;
        Color color = meshRenderer.material.color;
        color.a = 0.0f;
        while (respawnTimer > 0)
            {
            color.a = color.a + 0.001f;
            meshRenderer.material.color = color;
            respawnTimer = respawnTimer - 0.001f;
            Debug.Log(respawnTimer);
            yield return new WaitForFixedUpdate();
            if(respawnTimer <= 0.01f)
            {
                respawnTimer = respawnTimerDefault;
                color.a = 1.0f;
                Debug.Log("Respawn Timer Finished");
                GetComponent<BoxCollider>().enabled = true;
                StopCoroutine(RespawnFood());
            }
        }
    }
}
