using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZM.RedDotSystem
{
    public class RedDotTreeNode
    {
        /// <summary>
        /// 红点类型
        /// </summary>
        public RedDotType redDotType;
        
        /// <summary>
        /// 父节点
        /// </summary>
        public RedDotDefine parentNode;

        /// <summary>
        /// 当前节点
        /// </summary>
        public RedDotDefine node;
        
        /// <summary>
        /// 红点显示状态
        /// </summary>
        public bool redDotActive;
        
        /// <summary>
        /// 红点显示个数
        /// </summary>
        public int redDotCount;
        
        /// <summary>
        /// 红点逻辑处理器
        /// </summary>
        public System.Action<RedDotTreeNode> logicHandler;
        
        /// <summary>
        /// 红点状态改变事件
        /// </summary>
        public System.Action<RedDotType, bool, int> OnRedDotActiveChange;

        /// <summary>
        /// 刷新红点显示状态
        /// </summary>
        /// <returns></returns>
        public virtual bool RefreshRedDotState()
        {
            redDotCount = 0;
            if (redDotType == RedDotType.RedDotNodeNum)
            {
                //获取子节点显示的红点个数，区县市红点个数
                redDotCount = RedDotSystem.Instance.GetChildNodeRedDotCount(node);
                redDotActive = redDotCount > 0;
            }
            else
            {
                redDotCount = RefreshRedDotCount();
            }
            
            logicHandler?.Invoke(this);

            if (redDotType == RedDotType.RedDotDataNum)
            {
                redDotActive = redDotCount > 0;
            }
            
            OnRedDotActiveChange?.Invoke(redDotType, redDotActive, redDotCount);
            
            return redDotActive;
        }
        
        /// <summary>
        /// 刷新红点个数
        /// </summary>
        /// <returns></returns>
        public virtual int RefreshRedDotCount()
        {
            return 1;
        }
    }
}