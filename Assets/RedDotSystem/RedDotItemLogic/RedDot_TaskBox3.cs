using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZM.RedDotSystem
{


    public class RedDot_TaskBox3 : RedDotTreeNode
    {
        public override bool RefreshRedDotState()
        {
            redDotActive = RedDotDataMgr.Task_Box3_isRead == false;
            Debug.Log("RedDot_TaskBox3 RefreshRedDotState " + redDotActive);
            return base.RefreshRedDotState();
        }
    }
}
