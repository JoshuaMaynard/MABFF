using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Initial code by Joseph Arends
public class GunInfo : MonoBehaviour
{
    /// <summary>
    /// This contains all the information necessary for creating and updating guns
    /// </summary>
    /// 

    public string gunClass;
    public float gunPower;
    public string gunPowerType;

    public GameObject bulletType;
    public GameObject bulletSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gunPower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
