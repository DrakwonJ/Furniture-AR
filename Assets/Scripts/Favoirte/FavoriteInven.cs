using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FavoriteInven : MonoBehaviour
{
    public GameObject go_SlotsParent;
    public Slot[] favorSlot;

    private static FavoriteInven instance;
    public static FavoriteInven Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<FavoriteInven>();
            }
            return instance;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SlotUpdate()
    {
        for (int i = 0; i < favorSlot.Length; i++)
            favorSlot[i].DeleteItem();
        for (int i = 0; i < FavoriteManager.Instance.FavoriteList.Count; i++)
        {
               favorSlot[i].AddItem(FavoriteManager.Instance.FavoriteList[i].GetComponent<ItemController>().ItemImage);
        }
    }
}
