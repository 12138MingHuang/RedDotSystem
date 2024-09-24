using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZM.RedDotSystem
{
    public class RedDotItem : MonoBehaviour
    {
        public RedDotDefine redKey;
        public GameObject redDotObj;
        public Text countText;

        private void Start()
        {
            RedDotSystem.Instance.RegisterRedDotChangeEvent(redKey, OnRedDotStateChangeEvent);
            RedDotSystem.Instance.UpdateRedDotState(redKey);
        }

        private void OnEnable()
        {
            RedDotSystem.Instance.UpdateRedDotState(redKey);
        }

        /// <summary>
        /// 红点状态改变回调
        /// </summary>
        /// <param name="type">红点类型</param>
        /// <param name="active">是否显示</param>
        /// <param name="count">显示红点数量</param>
        private void OnRedDotStateChangeEvent(RedDotType type, bool active, int count)
        {
            redDotObj.SetActive(active);
            if (type != RedDotType.Normal)
            {
                countText.text = count.ToString();
            }
            countText.gameObject.SetActive(type != RedDotType.Normal);
        }

        private void OnDestroy()
        {
            RedDotSystem.Instance.UnRegisterRedDotChangeEvent(redKey, OnRedDotStateChangeEvent);
        }
    }
}