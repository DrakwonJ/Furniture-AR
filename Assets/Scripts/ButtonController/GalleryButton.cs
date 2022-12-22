using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GalleryButton : MonoBehaviour
{
    [SerializeField] public GameObject targetObject { set; get; }
    private Button btn;

    public Image imageToShow;
    public string folderName = "ScreenShots";
    public string fileName = "MyScreenShot";
    public string extName = "png";
    private Texture2D _imageTexture;
    private string RootPath
    {
        get
        {
//#if UNITY_EDITOR || UNITY_STANDALONE
//            return Application.dataPath;
//#elif UNITY_ANDROID
                return $"/storage/emulated/0/DCIM/{Application.productName}/";
                //return Application.persistentDataPath;
//#endif
        }
    }
    private string FolderPath => $"{RootPath}/{folderName}";
    private string TotalPath => $"{FolderPath}/{fileName}_{DateTime.Now.ToString("MMdd_HHmmss")}.{extName}";
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ScreenshotShow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ScreenshotShow()
    {
        ReadScreenShotFile(imageToShow);
    }

    private void ReadScreenShotFile(Image imageShowing)
    {
        string folderPath = FolderPath;
        if(Directory.Exists(folderPath) == false)
        {
            Debug.Log($"{folderPath} 가 존재하지 않습니다.");
            return;
        }


    }
}
