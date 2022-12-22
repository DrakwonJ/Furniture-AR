using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    private Button btn;
    [SerializeField]
    public int _itemId;
    private Sprite _buttonTexture;
    [SerializeField]
    private GameObject FurniturePrefab;

    public int ItemId
    {
        set => _itemId = value;
    }
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.Instance.OnEntered(gameObject))
        {
            transform.DOScale(Vector3.one * 2, 0.2f);
        }
        else
        {
            transform.DOScale(Vector3.one, 0.2f);
        }
    }

    void SelectObject()
    {
        InputManager.Instance.placeObject = FurniturePrefab;
        //DataHandler.Instance.SetFurinute(_itemId);
    }
}
