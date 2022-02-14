using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEquipment : MonoBehaviour
{
    // This is for changing equipment
    public GameObject player;
    public string gunClass;
    public float changePower;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ChangePower(collision.gameObject.GetComponent<PlayerControls>().anArrayOfGuns);
        ChangePower();
    }
    /*public void ChangePower()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (gunClass == items[i].GetComponent<GunInfo>().gunClass)
            {
                items[i].GetComponent<GunInfo>().gunPower = changePower;
            }
            Debug.Log(items[i].GetComponent<GunInfo>().gunPower);
        }
    }*/

    public void ChangePower()
    {
        for (int i = 0; i < player.GetComponent<PlayerControls>().anArrayOfGuns.Length; i++)
        {
            if (gunClass == player.GetComponent<PlayerControls>().anArrayOfGuns[i].GetComponent<GunInfo>().gunClass)
            {
                player.GetComponent<PlayerControls>().anArrayOfGuns[i].GetComponent<GunInfo>().gunPower = changePower;
            }
            Debug.Log(player.GetComponent<PlayerControls>().anArrayOfGuns[i].GetComponent<GunInfo>().gunPower);
        }
    }

    public void DoSomething()
    {
        Debug.Log("asdf");
    }
}
