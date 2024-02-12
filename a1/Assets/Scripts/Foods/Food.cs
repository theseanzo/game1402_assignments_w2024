using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{

    public static Food instance;
    public bool hit = false;

    [SerializeField]
    float Anakin;
    [SerializeField]
    float Obiwan = 1.0f;
    private UnityEngine.Vector3 target;

    private UnityEngine.Vector3 startPosition;



    bool Padme = true;
    public int Value
    {
        get; protected set;
    }
    void Awake()
    {
        Collider foodCollider = GetComponent<Collider>();
        foodCollider.isTrigger = true;
        Value = GameConstants.BaseFoodValue;
        startPosition = gameObject.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        Anakin = 6.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && !hit && Padme)
        {
            GameManager.Instance.Score += Value; 
            hit = true;
            Padme = false; 
            transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
            StartCoroutine(CountDown());
            StartCoroutine(Respawn());


        }

    }

    public IEnumerator Respawn()
    {

        while (true)
        {
            transform.position = UnityEngine.Vector3.Lerp(transform.position, startPosition, 1.0f * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }


    }
    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(Anakin);
        hit = false;
        Padme = true;


    }

}