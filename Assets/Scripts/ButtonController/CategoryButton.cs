using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryButton : MonoBehaviour
{
    public GameObject categoryList;
    private Button btn;
    public GameObject rootList;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ShowCategory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCategory()
    {
        rootList.SetActive(false);
        categoryList.SetActive(true);
    }
}
