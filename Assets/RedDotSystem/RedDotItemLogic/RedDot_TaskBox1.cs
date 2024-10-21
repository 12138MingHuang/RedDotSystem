using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZM.RedDotSystem
{

    public class RedDot_TaskBox1 : RedDotTreeNode
    {
        public override bool RefreshRedDotState()
        {
            redDotActive = RedDotDataMgr.Task_Box1_isRead == false;
            Debug.Log("RedDot_TaskBox1 RefreshRedDotState " + redDotActive);
            return base.RefreshRedDotState();
        }
    }
}
