using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GotoRoot : MonoBehaviour
{
    public GameObject categoryList;
    private Button btn;
    public GameObject rootList;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Backward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Backward()
    {
        categoryList.SetActive(false);
        rootList.SetActive(true);
    }
}
