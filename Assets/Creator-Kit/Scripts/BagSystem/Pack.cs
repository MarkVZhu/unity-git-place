using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pack : MonoBehaviour
{
    //保存物品的List数组
    public List<ItemEntity> items = null;
    //背包最大容量
    public int maxItem = 32;

    // Use this for initialization
    void Start()
    {
        items = new List<ItemEntity>();
    }

    //拾取物品
    public ObjectItem getItem(ObjectItem item)
    {
        //使用中间过渡的实体类
        ItemEntity itemEntity = ItemEntity.FillData(item);

        //如果物品不可合并
        if (!itemEntity.IsCanAdd)
        {
            //背包有空余
            if (items.Count < maxItem)
            {
                //获得物品
                items.Add(itemEntity);
                item.count = 0;
            }
            else
            {
                //拾取失败
            }
        }
        else
        {
            //空背包时，直接添加
            if (items.Count < 1)
            {
                items.Add(itemEntity);
                item.count = 0;
            }
            else
            {
                //判断当前背包合并物品
                foreach (ItemEntity currItem in items)
                {
                    //相同物品，且可叠加，且分组未满
                    if (currItem.ObjId.Equals(itemEntity.ObjId) && currItem.Count < currItem.MaxAdd)
                    {
                        //数量叠加
                        currItem.Count = currItem.Count + itemEntity.Count;
                        //如果超出叠加范围
                        if (currItem.Count - currItem.MaxAdd > 0)
                        {
                            //拾取物品的剩余数量变更
                            item.count = currItem.Count - currItem.MaxAdd;
                            itemEntity.Count = item.count;
                            //背包里的数量为最大值
                            currItem.Count = currItem.MaxAdd;
                        }
                        else
                        {
                            // 未超出叠加最大值，拾取成功
                            item.count = 0;
                        }
                    }
                    else
                    {
                        //如果物品不是同类，或分组是满的，遍历下一个格子
                        continue;
                    }
                }
                //物品超出分组，有剩余格子则添加。否则剩余部分无法拾取
                if (item.count > 0 && items.Count < maxItem)
                {
                    items.Add(itemEntity);
                    item.count = 0;
                }
            }
        }
        return item;
    }

    //显示物品
    public void showPack()
    {
        string show = "物品：\n";
        int i = 0;
        foreach (ItemEntity currItem in items)
        {
            show += ++i + " [" + currItem.ObjName + "], 数量: " + currItem.Count + "\n";
        }
        Debug.Log(show);
    }
}