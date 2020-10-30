using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMaker : MonoBehaviour
{
    public static List<string> TMPList;
    [HideInInspector]public List<string> PopupList;

    [ListToPopup(typeof(PopupMaker), "myList")]
    public string Popup;
        
    [ContextMenu("create Number list")]
    public void CreateNumberList()
    {
        PopupList = new List<string> {"1","2","3"};
    }

    [ContextMenu("UpdateList")]
    public void UpdateList()
    {
        TMPList = PopupList;
    }
}
