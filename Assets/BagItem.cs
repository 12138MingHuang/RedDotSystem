using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagItem : MonoBehaviour
{
    public GameObject redDotObj;
    public Text countText;
    private BagData _bagData;
    
    public void SetData(BagData bagData)
    {
        _bagData = bagData;
        countText.text = "x" + _bagData.count;
        redDotObj.SetActive(!bagData.isRead);
    }
    
    public void OnButtonClick()
    {
        if (!_bagData.isRead)
        {
            _bagData.isRead = true;
            redDotObj.SetActive(false);
            ZM.RedDotSystem.RedDotSystem.Instance.UpdateRedDotState(ZM.RedDotSystem.RedDotDefine.BagRoot);
        }
    }
}
