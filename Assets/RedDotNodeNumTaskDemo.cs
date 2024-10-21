using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZM.RedDotSystem;

public class RedDotNodeNumTaskDemo : MonoBehaviour
{
    public GameObject taskWindow;
    
    public Button taskButton;
    public Button box1Button;
    public Button box2Button;
    public Button box3Button;
    public Button taskCloseButton;

    private void Awake()
    {
        taskButton.onClick.AddListener(OnTaskButtonClick);
        box1Button.onClick.AddListener(OnBox1TabButtonClick);
        box2Button.onClick.AddListener(OnBox2TabButtonClick);
        box3Button.onClick.AddListener(OnBox3TabButtonClick);
        taskCloseButton.onClick.AddListener(OnTaskCloseButtonClick);
        
        RedDotTreeNode taskMainRoot = new RedDotTreeNode
        {
            node = RedDotDefine.TaskRoot,
            redDotType = RedDotType.RedDotNodeNum
        };
        RedDot_TaskBox1 task_box1 = new RedDot_TaskBox1
        {
            parentNode = RedDotDefine.TaskRoot,
            node = RedDotDefine.Task_Box1
        };
        RedDot_TaskBox2 task_box2 = new RedDot_TaskBox2
        {
            parentNode = RedDotDefine.TaskRoot,
            node = RedDotDefine.Task_Box2
        };
        RedDot_TaskBox3 task_box3 = new RedDot_TaskBox3
        {
            parentNode = RedDotDefine.TaskRoot,
            node = RedDotDefine.Task_Box3
        };
        RedDotSystem.Instance.InitlizateRedDotTree(new List<RedDotTreeNode>
        {
            taskMainRoot,
            task_box1,
            task_box2,
            task_box3
        });
    }

    

    #region 按钮事件
    
    private void OnTaskButtonClick()
    {
        taskWindow.SetActive(true);
    }

    private void OnBox1TabButtonClick()
    {
        RedDotDataMgr.Task_Box1_isRead = true;
        RedDotSystem.Instance.UpdateRedDotState(RedDotDefine.Task_Box1);
    }

    private void OnBox2TabButtonClick()
    {
        RedDotDataMgr.Task_Box2_isRead = true;
        RedDotSystem.Instance.UpdateRedDotState(RedDotDefine.Task_Box2);
    }

    private void OnBox3TabButtonClick()
    {
        RedDotDataMgr.Task_Box3_isRead = true;
        RedDotSystem.Instance.UpdateRedDotState(RedDotDefine.Task_Box3);
    }

    private void OnTaskCloseButtonClick()
    {
        taskWindow.SetActive(false);
    }

    #endregion
}
