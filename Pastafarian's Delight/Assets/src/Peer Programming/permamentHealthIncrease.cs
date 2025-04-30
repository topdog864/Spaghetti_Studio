using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class permanentHealthIncrease : MonoBehaviour
{
    [Tooltip("Increases the player's max health by one")]
    public string playerTag = "Player";

    void Awake()
    {
        Collider2D col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag)) return;

        if (HealthSystem.Instance != null)
        {
            HealthSystem.Instance.MAX_HEALTH += 1;
            Debug.Log("Player max health increased to: " + HealthSystem.Instance.MAX_HEALTH);
        }
        else
        {
            Debug.LogError("HealthSystem.Instance is null! Cannot increase max health.");
        }

        Destroy(gameObject);
    }
}
