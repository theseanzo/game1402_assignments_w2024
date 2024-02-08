using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //use this to make objects uncollectable after collecting
    bool hit = false;
    //collectable respawning variables
    Shader transparentShader;
    Shader standardShader;
    Renderer matRender;
    [SerializeField]
    float respawnTime;

    public int Value
    {
        get; protected set;
    }
    void Awake()
    {
        Collider foodCollider = GetComponent<Collider>();
        foodCollider.isTrigger = true;
        Value = GameConstants.BaseFoodValue;
        //for material respawning
        matRender = GetComponent<Renderer>();
        transparentShader = Shader.Find("UI/Unlit/Transparent");
        standardShader = Shader.Find("Standard");
        respawnTime = 5f;
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
            Debug.Log("Nom");
            hit = true;
            GameManager.Instance.Score += Value; //recall that the value is set in each one of the food's children
            matRender.material.shader = transparentShader;
            Color alpha = matRender.material.color;
            alpha.a = 0f;
            matRender.material.color = alpha;
            //starts respanwing code
            StartCoroutine(FadeIn(respawnTime));
        }
        
    }
    
    IEnumerator FadeIn(float time)
    {
        Color objectAlpha = matRender.material.color;
        yield return new WaitForSeconds(time);
        for (float currentAlpha = 0f; currentAlpha <= 1f; currentAlpha += 0.1f)
        {
            objectAlpha.a = currentAlpha;
            matRender.material.color = objectAlpha;
            yield return new WaitForSeconds(1f);
        }
        //make it collectable again
        matRender.material.shader = standardShader;
        hit = false;
        Debug.Log("Coroutine Done");
    }
}
