using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZM.RedDotSystem;

public class RedDotDataNumBagDemo : MonoBehaviour
{
    public GameObject bagWindow;
    public GameObject bagItem;

    public Button bagButton;
    public Button closeButton;
    
    public Transform[] itemCellArr;
    
    private bool _isCreate;

    private void Awake()
    {
        for (int i = 0; i < 15; i++)
        {
            RedDotDataMgr.bagDataList.Add(new BagData
            {
                id = i,
                count = i+1
            });
        }
        
        bagButton.onClick.AddListener(OnBagButtonClick);
        closeButton.onClick.AddListener(OnCloseButtonClick);
        //注册大厅背包数量红点
        RedDotTreeNode bagNode = new RedDotTreeNode
        {
            redDotType = RedDotType.RedDotDataNum,
            node = RedDotDefine.BagRoot,
            logicHandler = OnRedDotBagLogicHandler
        };
        RedDotSystem.Instance.InitlizateRedDotTree(new List<RedDotTreeNode>
        {
            bagNode
        });
    }

    private void OnRedDotBagLogicHandler(RedDotTreeNode redNode)
    {
        redNode.redDotCount = 0;
        foreach (var item in RedDotDataMgr.bagDataList)
        {
            if (!item.isRead)
            {
                redNode.redDotCount++;
            }
        }
        Debug.Log("redNode.redDotCount:" + redNode.redDotCount);
    }


    private void OnBagButtonClick()
    {
        bagWindow.SetActive(true);
        if (!_isCreate)
        {
            for (int i = 0; i < RedDotDataMgr.bagDataList.Count; i++)
            {
                GameObject obj = Instantiate(bagItem, itemCellArr[i]);
                obj.SetActive(true);
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localScale = Vector3.one;
                obj.transform.localRotation = Quaternion.identity;
                BagItem item = obj.GetComponent<BagItem>();
                item.SetData(RedDotDataMgr.bagDataList[i]);
            }
            _isCreate = true;
        }
    }

    private void OnCloseButtonClick()
    {
        bagWindow.SetActive(false);
    }
}
