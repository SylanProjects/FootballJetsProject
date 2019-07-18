using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupActivator : MonoBehaviour
{
    public PickupControl pickupControl;
    private bool active;
    private IPickupEffect currentEffect;

    private IPickupEffect effectHealth = new HealthPickup();
    private IPickupEffect effectStamina = new StaminaPickup();
    private List<IPickupEffect> effects;
    
    public void Start()
    {
        active = false;

        effects = new List<IPickupEffect>
        {
            effectHealth,
            effectStamina
        };
        pickupControl.pickupList.MakeAvailable(this);
    }
    public bool CheckIfActive()
    {
        return this.active;
    }
    public void Activate()
    {
        
        active = true;
        currentEffect = effects[Random.Range(0, effects.Count)];

        pickupControl.pickupList.MakeUnavailable(this);
        SpawnSprite();
    }
    private void SpawnSprite()
    {
        if(currentEffect == effectHealth)
        {
            InstantiatePrefab(pickupControl.pickupPrefabs.healthPrefab);
        }
        if (currentEffect == effectStamina)
        {
            InstantiatePrefab(pickupControl.pickupPrefabs.staminaPrefab);
        }
    }
    private void InstantiatePrefab(GameObject prefab)
    {
        /* Used to make the code a little bit easier to read since 
         * transform.position and transform.rotation don't change.
         */
        Instantiate(prefab, transform.position, transform.rotation);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && active)
        {
            currentEffect.ApplyEffect(collision.gameObject);
            // Deactivate
            active = false;
            pickupControl.pickupList.MakeAvailable(this);

        }

    }
    
}
