using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCreator
{
    GameObject contImg;
    Sprite[] sprites;

    float baseX = 30.0f;
    float baseY = 1350.0f;
    string PATH = "CategoryData/";


    public void Setting(GameObject contentImages, string type)
    {

        if (type.CompareTo("FavoriteList") == 0)
            SettingFV(contentImages, type);

        contImg = contentImages;
        PATH += type;
        sprites = Resources.LoadAll<Sprite>(PATH);

        for (int i = 0; i < sprites.Length; i++)
        {
            GameObject newObj = new GameObject();
            newObj.name = "Sample" + i.ToString();
            newObj.transform.parent = contImg.transform.Find(type).gameObject.transform; // sprite 가 생성될 부모 이름

            ContentCreate(i, newObj);
        }
    }

    void ContentCreate(int i, GameObject newObj)
    {
        newObj.AddComponent<Image>();
        Image objImg = newObj.GetComponent<Image>();
        objImg.sprite = sprites[i];
        objImg.SetNativeSize();

        RectTransform objRect = newObj.GetComponent<RectTransform>();
        objRect.anchorMin = new Vector2(0, 0);
        objRect.anchorMax = new Vector2(0, 0);
        objRect.pivot = new Vector2(0, 0);
        objRect.localScale = new Vector3(1, 1, 1);

        float width = objRect.rect.width;
        float height = objRect.rect.height;
        if (width > height)
            objRect.sizeDelta = new Vector2(300.0f, height * 300 / width);
        else
            objRect.sizeDelta = new Vector2(width * 300 / height, 300.0f);

        int x = i % 3;
        int y = i / 3;
        objRect.anchoredPosition = new Vector2(baseX + x * 360, baseY - y * 400);

        newObj.AddComponent<Button>();
        Button objBtn = newObj.GetComponent<Button>();
    }


    void SettingFV(GameObject contentImages, string type)
    {

    }

}
