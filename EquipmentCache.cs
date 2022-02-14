using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class EquipmentCache : MonoBehaviour
{
    public enum InteractionType {NONE, PickUp}
    public enum EquipmentType {Grapple, JetPack, Viscosity, KeyCards, Weapon}
    public EquipmentType type;
    public InteractionType interactType;
    public string decriptionText;

    public UnityEvent customEvent;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 19;
    }

    public void Interact()
    {
        switch(interactType)
        {
            case InteractionType.PickUp:

                FindObjectOfType<InventorySystem>().PickUp(gameObject);

                gameObject.SetActive(false);

                Debug.Log("Pick up");
                break;
            default:
                Debug.Log("NULL Item");
                break;
        }

        customEvent.Invoke();
    }

}
