using UnityEngine;

public class Food : MonoBehaviour
{
    bool hit = false;
    GameObject food;
    Vector3 prefabPosition;
    public Spawner spawner;

    public int Value
    {
        get; protected set;
    }

    void Awake()
    {
        Collider foodCollider = GetComponent<Collider>();
        foodCollider.isTrigger = true;
        Value = GameConstants.BaseFoodValue;
        spawner = FindObjectOfType<Spawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && !hit)
        {
            hit = true;
            GameManager.Instance.Score += Value; //recall that the value is set in each one of the food's children
            food = this.gameObject;
            prefabPosition = food.transform.position;

            Destroy(this.gameObject);

            spawner.Spawn(food.tag, prefabPosition);
        }
    }
}
