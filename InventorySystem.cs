using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public GameObject ui_Equipment;
    public Image[] items_images;
    public GameObject ui_Description_Window;
    public Image description_Image;
    public Text description_Title;

    public void PickUp(GameObject item)
    {
        items.Add(item);
        Update_UI();
    }
    
    void Update_UI()
    {
        HideAll();

        for (int i=0; i<items.Count; i++)
        {
            
            items_images[i].gameObject.SetActive(true);
        }
    }

    void HideAll()
    {
        foreach (var i in items_images)
        {
            i.gameObject.SetActive(false);
        }
    }
}
