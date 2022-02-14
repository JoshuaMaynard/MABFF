using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseInfection : MonoBehaviour
{
    public float amount;

    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Increase()
    {
        player.GetComponent<PlayerControls>().currentInfectionLevel += amount;

        if (player.GetComponent<PlayerControls>().currentInfectionLevel >= player.GetComponent<PlayerControls>().maxInfectionLevel)
        {
            player.GetComponent<PlayerControls>().LevelUp();
        }
        player.GetComponent<PlayerControls>().UpdateInfectionBar();



    }
}
