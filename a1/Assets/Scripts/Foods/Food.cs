using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private float respawnTimerDefault = 5f;
    MeshRenderer meshRenderer;
    Coroutine foodrespawn;
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
            GameManager.Instance.Score += Value;
            foodrespawn = StartCoroutine(RespawnFood());
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
            color.a = color.a + (1.0f / (respawnTimerDefault * 100f));
            meshRenderer.material.color = color;
            respawnTimer = respawnTimer - Time.deltaTime;
            Debug.Log(respawnTimer);
            Debug.Log(color.a);
            yield return new WaitForFixedUpdate();
            if (respawnTimer <= 0.01f)
            {
                Debug.Log("Respawn Finished");
                respawnTimer = respawnTimerDefault;
                color.a = 1.0f;
                GetComponent<BoxCollider>().enabled = true;
                StopCoroutine(foodrespawn);
            }
        }
    }
}