using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZM.RedDotSystem
{
    public class RedDot_TaskBox2 : RedDotTreeNode
    {
        public override bool RefreshRedDotState()
        {
            redDotActive = RedDotDataMgr.Task_Box2_isRead == false;
            Debug.Log("RedDot_TaskBox2 RefreshRedDotState " + redDotActive);
            return base.RefreshRedDotState();
        }
    }
}
