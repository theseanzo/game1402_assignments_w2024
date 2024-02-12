using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    bool hit = false;
    [SerializeField] float spawnTimer = 5f;
    private Vector3 initialPosition;

    public int Value { get; protected set; }

    void Awake()
    {
        Collider foodCollider = GetComponent<Collider>();
        foodCollider.isTrigger = true;
        Value = GameConstants.BaseFoodValue;
        initialPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && !hit)
        {
            hit = true;
            GameManager.Instance.Score += Value;


            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(spawnTimer);
        transform.position = initialPosition;
        gameObject.SetActive(true);
        hit = false;
        UnityEngine.Debug.Log("Object respawned");
    }
}