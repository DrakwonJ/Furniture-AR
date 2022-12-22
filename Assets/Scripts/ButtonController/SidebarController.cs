using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SidebarController : MonoBehaviour
{
    [SerializeField] public GameObject targetObject { set; get; }
    private Button btn;
    public GameObject sidebar;
    public bool sidebarOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OpenSidebar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenSidebar()
    {
        if (sidebarOpen)
        {
            sidebar.SetActive(false);
            sidebarOpen = false;
        }
        else
        {
            sidebar.SetActive(true);
            sidebarOpen = true;
        }
    }
}
