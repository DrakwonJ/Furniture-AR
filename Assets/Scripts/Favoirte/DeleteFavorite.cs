using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteFavorite : MonoBehaviour
{
    private Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ClearFavorite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearFavorite()
    {
        FavoriteManager.Instance.FavoriteList.Clear();
        AndroidToast.I.ShowToastMessage("즐겨찾기가 초기화 되었습니다.");
    }
}
