using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTextr : MonoBehaviour
{
    public static Text name { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        name = GetComponent<Text>();
        name.text = "Text";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
