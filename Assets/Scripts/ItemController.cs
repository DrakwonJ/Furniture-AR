using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    public Define.FurnitureType furnitureType;
    public bool is_fixed = false;
    public Sprite ItemImage;
    public Define.Material material;
}
