using System.Collections;
using UnityEngine;

public class Food: MonoBehaviour
{
    [SerializeField]
    private float timeBeforeRespawn = 10f; // Delay before the item starts respawning
    [SerializeField]
    private float reappearTransitionTime = 5f; // Duration for the reappear effect

    private bool isCollected = false;
    public int PickValue { get; protected set; }

    private void Awake()
    {
        var itemCollider = GetComponent<Collider>();
        itemCollider.isTrigger = true;
        PickValue = GameConstants.BaseFoodValue; // Assume this is a constant value defined elsewhere
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && !isCollected)
        {
            isCollected = true;
            GameManager.Instance.Score += PickValue;
            StartCoroutine(ReappearAfterDelay());
        }
    }

    IEnumerator ReappearAfterDelay()
    {
        SetItemVisibility(false);

        yield return new WaitForSeconds(timeBeforeRespawn);

        float timePassed = 0f;
        while (timePassed < reappearTransitionTime)
        {
            timePassed += Time.deltaTime;
            float blend = timePassed / reappearTransitionTime;
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