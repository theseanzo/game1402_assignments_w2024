using UnityEngine;

public class Food : MonoBehaviour
{
    GameObject food;
    Vector3 prefabPosition;
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
        }
    }
}
