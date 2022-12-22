using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FavoriteCate : MonoBehaviour
{
    private Button btn;
    public GameObject content;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ShowCate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCate()
    {
        content.GetComponent<FavoriteInven>().SlotUpdate();
    }
}
