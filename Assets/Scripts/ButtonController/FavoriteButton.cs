using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FavoriteButton : MonoBehaviour
{
    [SerializeField] public GameObject targetObject;
    private Button btn;
    public List<GameObject> favoritePrefab;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(AddFavoriteList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFavoriteList()
    {
        targetObject = InputManager.Instance.spawnObject;
        FavoriteManager.Instance.FavoriteList.Add(targetObject);
        AndroidToast.I.ShowToastMessage("즐겨찾기에 추가되었습니다.");
    }
}
