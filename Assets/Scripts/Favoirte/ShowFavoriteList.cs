using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFavoriteList : MonoBehaviour
{
    private Button btn;
    public GameObject favorlist;
    public GameObject iconList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(UpdateFavorList);
    }

    public void UpdateFavorList()
    {
        favorlist.SetActive(true);
        iconList.SetActive(false);
        FavoriteInven.Instance.SlotUpdate();
    }
}
