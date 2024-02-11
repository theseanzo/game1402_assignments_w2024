using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private float respawnTimerDefault = 1f;
    MeshRenderer meshRenderer;
    Coroutine respawn;
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
            respawn = StartCoroutine(RespawnFood());
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
            color.a = color.a + (2.0f / (respawnTimerDefault * 100f));
            meshRenderer.material.color = color;
            respawnTimer = respawnTimer - Time.deltaTime;
            Debug.Log(respawnTimer);
            Debug.Log("ALPHA IS " + color.a);
            yield return new WaitForFixedUpdate();
            if(respawnTimer <= 0.01f)
            {
                Debug.Log("Respawn Timer Finished");
                respawnTimer = respawnTimerDefault;
                color.a = 1.0f;
                GetComponent<BoxCollider>().enabled = true;
                StopCoroutine(respawn);
            }
        }
    }
}
