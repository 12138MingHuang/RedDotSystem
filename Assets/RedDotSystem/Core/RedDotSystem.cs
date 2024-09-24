using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZM.RedDotSystem
{
    public enum RedDotType
    {
        /// <summary>
        /// 只显示红点
        /// </summary>
        Normal,
        
        /// <summary>
        /// 节点数字红点，子节点有几个红点，就显示几个数字
        /// </summary>
        RedDotNodeNum,
        
        /// <summary>
        /// 红点数据个数，根据数据的个数，显示红点数量
        /// </summary>
        RedDotDataNum,
    }

    public class RedDotSystem
    {
        private static RedDotSystem _instance;
        public static RedDotSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RedDotSystem();
                }
                return _instance;
            }
        }

        /// <summary>
        /// 红点字典
        /// </summary>
        private Dictionary<RedDotDefine, RedDotTreeNode> _redDotLogicDic = new Dictionary<RedDotDefine, RedDotTreeNode>();

        public void InitlizateRedDotTree(List<RedDotTreeNode> nodeList)
        {
            foreach (RedDotTreeNode item in nodeList)
            {
                // _redDotLogicDic.Add(item.Define, item);
            }
        }

        /// <summary>
        /// 更新红点状态
        /// </summary>
        /// <param name="redKey">红点key</param>
        public void UpdateRedDotState(RedDotDefine redKey)
        {
            if(redKey == RedDotDefine.None)
            {
                return;
            }
            RedDotTreeNode redDotNode = null;
            if (_redDotLogicDic.TryGetValue(redKey, out redDotNode))
            {
                redDotNode.RefreshRedDotState();
                UpdateRedDotState(redDotNode.parentNode);
            }
        }

        /// <summary>
        /// 注册红点状态变化事件
        /// </summary>
        /// <param name="redKey">红点类型</param>
        /// <param name="changeEvent">红点事件回调</param>
        public void RegisterRedDotChangeEvent(RedDotDefine redKey, System.Action<RedDotType, bool, int> changeEvent)
        {
            RedDotTreeNode redDotNode = null;
            if (_redDotLogicDic.TryGetValue(redKey, out redDotNode))
            {
                redDotNode.OnRedDotActiveChange += changeEvent;
            }
            else
            {
                Debug.LogError($"key:{redKey}红点不存在,请检查红点key是否正确");
            }
        }

        /// <summary>
        /// 注销红点状态变化事件
        /// </summary>
        /// <param name="redKey">红点类型</param>
        /// <param name="changeEvent">红点事件回调</param>
        public void UnRegisterRedDotChangeEvent(RedDotDefine redKey, System.Action<RedDotType, bool, int> changeEvent)
        {
            RedDotTreeNode redDotNode = null;
            if (_redDotLogicDic.TryGetValue(redKey, out redDotNode))
            {
                redDotNode.OnRedDotActiveChange -= changeEvent;
            }
            else
            {
                Debug.LogError($"key:{redKey}红点不存在,请检查红点key是否正确");
            }
        }

        /// <summary>
        /// 获取子节点红点数量
        /// </summary>
        /// <param name="redKey">红点类型</param>
        /// <returns>红点数量</returns>
        public int GetChildNodeRedDotCount(RedDotDefine redKey)
        {
            int childRedDotCount = 0;
            ComputeChildRedDotCount(redKey, ref childRedDotCount);
            return childRedDotCount;
        }

        /// <summary>
        /// 计算子节点红点数量
        /// </summary>
        /// <param name="redKey">子节点类型</param>
        /// <param name="childRedDotCount">红点数量</param>
        private void ComputeChildRedDotCount(RedDotDefine redKey, ref int childRedDotCount)
        {
            foreach (RedDotTreeNode item in _redDotLogicDic.Values)
            {
                if (item.parentNode == redKey)
                {
                    item.RefreshRedDotState();
                    if (item.redDotActive)
                    {
                        childRedDotCount += item.redDotCount;
                        if (item.redDotType != RedDotType.RedDotDataNum)
                            ComputeChildRedDotCount(item.node, ref childRedDotCount);
                    }
                }
            }
        }
    }
}