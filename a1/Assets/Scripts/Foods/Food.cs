using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private float durationBeforeRespawn = 10f; // Duratioin before the collectible is going to respawn again.
    [SerializeField]
    private float appearTransitionTime = 5f; // Duration of the effect for reappear
    public int Value
    {
        get; protected set;
    }
    private bool isCollected = false;
    public int PickupValue { get; private set; }

    private void Awake()
    {
        var itemCollider = GetComponent<Collider>();
        itemCollider.isTrigger = true;
        PickupValue = GameConstants.BaseFoodValue; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && !isCollected)
        {
            isCollected = true;
            GameManager.Instance.Score += PickupValue;
            StartCoroutine(ReappearAfterDelay());
        }
    }

    IEnumerator ReappearAfterDelay()
    {
        SetItemVisibility(false);

        yield return new WaitForSeconds(durationBeforeRespawn);

        float timePassed = 0f;
        while (timePassed < appearTransitionTime)
        {
            timePassed += Time.deltaTime;
            float blend = timePassed / appearTransitionTime;
            AdjustItemTransparency(blend);
            yield return null;
        }

        SetItemVisibility(true);
        isCollected = false;
    }

    private void SetItemVisibility(bool isVisible)
    {
        var itemRenderer = GetComponent<Renderer>();
        itemRenderer.enabled = isVisible;
        GetComponent<Collider>().enabled = isVisible;
        if (isVisible) // Reset transparency when becoming visible
        {
            itemRenderer.material.color = new Color(itemRenderer.material.color.r, itemRenderer.material.color.g, itemRenderer.material.color.b, 1f);
        }
    }

    private void AdjustItemTransparency(float alpha)
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, alpha);
    }
}