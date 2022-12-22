using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image furniImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Sprite furImage)
    {
        furniImage.sprite = furImage;
        Color color = furniImage.color;
        color.a = 1;
        furniImage.color = color;
    }

    public void DeleteItem()
    {
        furniImage.sprite = null;
        Color color = furniImage.color;
        color.a = 0;
        furniImage.color = color;

    }
}
