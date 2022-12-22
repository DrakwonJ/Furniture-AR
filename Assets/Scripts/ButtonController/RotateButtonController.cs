using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RotateButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] public GameObject targetObject;
    public bool dirLeft;
    private Button btn;
    private bool _isClick = false;
    public float rotateSpeed = 100f;

    
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isClick)
        {
            if (dirLeft)
                InputManager.Instance.spawnObject.transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
            else
                InputManager.Instance.spawnObject.transform.Rotate(new Vector3(0, 0, -rotateSpeed * Time.deltaTime));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isClick = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isClick = false;
    }
}
