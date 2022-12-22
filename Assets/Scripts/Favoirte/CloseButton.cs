using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    private Button btn;
    public GameObject favorUI;
    public GameObject iconUI;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(CloseUI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseUI()
    {
        favorUI.SetActive(false);
        iconUI.SetActive(true);
    }
}
