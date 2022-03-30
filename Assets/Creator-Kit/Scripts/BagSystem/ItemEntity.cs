public class ItemEntity
{

    private string objId;
    private string objName;
    private int count;
    private string note;
    private int level;
    private bool isCanAdd;
    private int maxAdd;
    private bool isChecked;


    public static ItemEntity FillData(ObjectItem item)
    {
        ItemEntity itemEntity = new ItemEntity();
        itemEntity.ObjId = item.objId;
        itemEntity.ObjName = item.objName;
        itemEntity.Count = item.count;
        itemEntity.Note = item.note;
        itemEntity.Level = item.level;
        itemEntity.IsCanAdd = item.isCanAdd;
        itemEntity.MaxAdd = item.maxAdd;
        itemEntity.IsChecked = item.isChecked;
        return itemEntity;
    }

    public string ObjId
    {
        get
        {
            return objId;
        }

        set
        {
            objId = value;
        }
    }

    public string ObjName
    {
        get
        {
            return objName;
        }

        set
        {
            objName = value;
        }
    }

    public int Count
    {
        get
        {
            return count;
        }

        set
        {
            count = value;
        }
    }

    public string Note
    {
        get
        {
            return note;
        }

        set
        {
            note = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public bool IsCanAdd
    {
        get
        {
            return isCanAdd;
        }

        set
        {
            isCanAdd = value;
        }
    }

    public int MaxAdd
    {
        get
        {
            return maxAdd;
        }

        set
        {
            maxAdd = value;
        }
    }

    public bool IsChecked
    {
        get
        {
            return isChecked;
        }

        set
        {
            isChecked = value;
        }
    }
}