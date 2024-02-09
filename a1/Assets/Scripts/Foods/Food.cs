using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    bool _hit = false;
    public int Value
    {
        get; protected set;
    }

    [SerializeField]
    private float _respawnTime = GameConstants.BaseFoodRespawnTime;
    private bool _isRespawing = false;
    private float _fadeTime = 2.0f;
    private float _delayBeforeActive = 1.0f;

    private Material material;

    void Awake()
    {
        Collider foodCollider = GetComponent<Collider>();
        foodCollider.isTrigger = true;
        Value = GameConstants.BaseFoodValue;

        material = GetComponent<MeshRenderer>().material;
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
        if (other.gameObject.GetComponent<PlayerController>() && !_hit)
        {
            _hit = true;
            GameManager.Instance.Score += Value; //recall that the value is set in each one of the food's children
            
            // Fade out object instead of calling Destroy
            StartCoroutine(Respawn(OnRespawnComplete));
        }
    }

    IEnumerator Respawn(Action callback)
    {
        _isRespawing = true;
        Vector3 originalScale = transform.localScale;

        while(_isRespawing)
        {
            yield return Fade(Color.black, Vector3.zero);
            yield return new WaitForSeconds(_respawnTime);
            yield return Fade(Color.white, originalScale);

            // Add small delay before it can be collected again
            yield return new WaitForSeconds(_delayBeforeActive);
            
            _isRespawing = false;
            callback?.Invoke();
        }
    }

    IEnumerator Fade(Color targetColor, Vector3 targetScale)
    {
        Color initialColor = material.color;
        Vector3 initialScale = transform.localScale;

        float elapsedTime = 0.0f;
        while(elapsedTime < _fadeTime)
        {
            elapsedTime += Time.deltaTime;
            material.color = Color.Lerp(initialColor, targetColor, elapsedTime/ _fadeTime);
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime/ _fadeTime);
            yield return null;
        }
    }

    private void OnRespawnComplete()
    {
        _hit = false;
    }
}
