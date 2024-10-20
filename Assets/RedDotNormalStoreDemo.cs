using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZM.RedDotSystem;

public class RedDotNormalStoreDemo : MonoBehaviour
{
    public GameObject storeWindow;
    public Button storeButton;

    public Button goldTabButton;
    public Button diamondTabButton;
    public Button closeButton;

    private void Awake()
    {
        storeButton.onClick.AddListener(OnStoreButtonClick);
        goldTabButton.onClick.AddListener(OnGoldTabButtonClick);
        diamondTabButton.onClick.AddListener(OnDiamondTabButtonClick);
        closeButton.onClick.AddListener(OnStoreCloseButtonClick);
        
        //自定义红点逻辑使用演示，以非继承的行hi是演示红点的使用方式
        RedDotTreeNode storeMainRoot = new RedDotTreeNode
        { 
                node = RedDotDefine.StoreRoot,
                logicHandler = OnStoreRedRotLogicHandler
        };
        RedDotTreeNode store_Gold_Node = new RedDotTreeNode
        {
            parentNode = RedDotDefine.StoreRoot,
            node = RedDotDefine.Store_Gold,
            logicHandler = OnStoreGoldRedDotLogicHandler
        };
        RedDotTreeNode store_Diamond_Node = new RedDotTreeNode
        {
            parentNode = RedDotDefine.StoreRoot,
            node = RedDotDefine.Store_Diamond,
            logicHandler = OnStoreDiamondRedDotLogicHandler
        };
        RedDotSystem.Instance.InitlizateRedDotTree(new List<RedDotTreeNode>
        {
            storeMainRoot,
            store_Gold_Node,
            store_Diamond_Node
        });
    }

    private void OnStoreRedRotLogicHandler(RedDotTreeNode redNode)
    {
        if (RedDotDataMgr.Store_Gold_isRead && RedDotDataMgr.Store_Diamond_isRead)
        {
            redNode.redDotActive = false;
        }
        else
        {
            redNode.redDotActive = true;
        }
        Debug.Log("OnStoreRedRotLogicHandler:" + redNode.redDotActive);
    }

    private void OnStoreGoldRedDotLogicHandler(RedDotTreeNode redNode)
    {
        redNode.redDotActive = RedDotDataMgr.Store_Gold_isRead == false;
        Debug.Log("OnStoreGoldRedDotLogicHandler:" + redNode.redDotActive);
    }

    private void OnStoreDiamondRedDotLogicHandler(RedDotTreeNode redNode)
    {
        redNode.redDotActive = RedDotDataMgr.Store_Diamond_isRead == false;
        Debug.Log("OnStoreDiamondRedDotLogicHandler:" + redNode.redDotActive);
    }

    #region 按钮事件
    
    private void OnStoreButtonClick()
    {
        storeWindow.SetActive(true);
    }

    private void OnGoldTabButtonClick()
    {
        RedDotDataMgr.Store_Gold_isRead = true;
        RedDotSystem.Instance.UpdateRedDotState(RedDotDefine.Store_Gold);
    }

    private void OnDiamondTabButtonClick()
    {
        RedDotDataMgr.Store_Diamond_isRead = true;
        RedDotSystem.Instance.UpdateRedDotState(RedDotDefine.Store_Diamond);
    }

    private void OnStoreCloseButtonClick()
    {
        storeWindow.SetActive(false);
    }
    
    #endregion
}
