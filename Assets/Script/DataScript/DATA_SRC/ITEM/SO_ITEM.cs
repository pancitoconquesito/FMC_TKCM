using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "item", menuName = "Item/item")]
public class SO_ITEM : ScriptableObject
{
    public int ID_ITEM;
    public InfoItem[] info;//0:español, 1:ingles
    //public InfoItem infoIngles;


}
