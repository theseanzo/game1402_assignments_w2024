using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    bool hit = false;
    Coroutine respawn;
    GameObject oneFood; //Used in needing to access the position of the Food gameObject

    [Header("Food Respawn Speed")]
    [SerializeField]
    float respawningTime = 5.0f;

    Vector3 originalPosition;
    Vector3 lerpedPosition;
    float ugh = 0.0002f;

    public int Value
    {
        get; protected set;
    }
    void Awake()
    {
        Collider foodCollider = GetComponent<Collider>();
        foodCollider.isTrigger = true;
        Value = GameConstants.BaseFoodValue;
        originalPosition = this.transform.position;
        lerpedPosition = new Vector3(this.transform.position.x, this.transform.position.y -10, this.transform.position.z);
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
            oneFood = this.gameObject;
            oneFood.transform.position = lerpedPosition;
            respawn = StartCoroutine(RespawnFood(oneFood));
        }
    }

    IEnumerator RespawnFood(GameObject gb)
    {
        yield return new WaitForSeconds(respawningTime);
        gb.transform.position = Vector3.Lerp(originalPosition, lerpedPosition, Time.fixedDeltaTime * ugh);
        yield return null;
        hit = false;
        gb.GetComponent<Collider>().enabled = false;
    }
}

//HI SEAAAAAANNNNNNNN I couldn't get the lerp to "lerp" to make it move smoothly between positions. I tried I'm sorry :(
