using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Food : MonoBehaviour
{
    bool hit = false;
    public int Value
    {
        get; protected set;
    }

    [SerializeField]
    float _respawnTime = 5f;

    [SerializeField]
    float _lerpTime = 0.5f;

    BoxCollider foodCollider;

    Vector3 _foodPosition = new Vector3();
    Vector3 _hidePosition = new Vector3(0f, 1.5f, 0f);

    Renderer _renderer;

    Color _materialTarget = new Color(1f, 1f, 1f, 1f);
    Color _transparentColor = new Color(0f, 0f, 0f, 0f);
    Color _lerpColor;

    void Awake()
    {
        foodCollider = GetComponent<BoxCollider>();
        foodCollider.isTrigger = true;
        Value = GameConstants.BaseFoodValue;
        _foodPosition = transform.position;
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerControls>() && !hit)
        {
            hit = true;
            GameManager.Instance.Score += Value; //recall that the value is set in each one of the food's children
            foodCollider.enabled =  false;
            _renderer.material.SetColor("_Color", _transparentColor);
            transform.position = transform.position - _hidePosition;
            StartCoroutine(SmoothMove());
            StartCoroutine(Respawn());
        } 
    }

    IEnumerator SmoothMove()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, _foodPosition, _lerpTime * Time.fixedDeltaTime);

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator Respawn()
    {
        hit = false;
        yield return new WaitForSeconds(_respawnTime);
        foodCollider.enabled = true;
    }
}
