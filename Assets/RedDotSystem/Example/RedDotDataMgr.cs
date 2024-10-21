using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagData
{
    public int id;
    public int count;
    public bool isRead = false;
}

public class RedDotDataMgr
{
    //商城数据
    public static bool Store_Gold_isRead = false;
    public static bool Store_Diamond_isRead = false;
    //任务数据
    public static bool Task_Box1_isRead = false;
    public static bool Task_Box2_isRead = false;
    public static bool Task_Box3_isRead = false;
    
    //背包数据
    public static List<BagData> bagDataList = new List<BagData>();
}
