using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavoriteManager : MonoBehaviour
{
    public List<GameObject> FavoriteList = new List<GameObject>();
    private static FavoriteManager instance;
    public static FavoriteManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<FavoriteManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
