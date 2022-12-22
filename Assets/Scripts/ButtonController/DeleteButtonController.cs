using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButtonController : MonoBehaviour
{
    [SerializeField] public GameObject targetObject { set; get; }
    private Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(DeleteFurniture);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteFurniture()
    {
        targetObject = InputManager.Instance.spawnObject;
        Destroy(targetObject);
        InputManager.Instance.spawnObject = null;
    }
}
