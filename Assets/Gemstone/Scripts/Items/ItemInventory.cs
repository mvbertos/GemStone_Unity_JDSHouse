using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    public enum Direction
    {
        VERTICAL,
        HORIZONTAL
    }

    [SerializeField] private ItemInvData itemData;
    public ItemInvData ItemData { get { return itemData; } }
    [SerializeField] private Direction side;
    public Direction Side { get { return side; } }
    [SerializeField][Range(1, 4)] private int size = 1;
    public int Size { get { return size; } }
}
[System.Serializable]
public class ItemInvData
{
    public string name;
    public string description;
    public int qnt;
    public Sprite spt;

    public ItemInvData() { }

    public ItemInvData(string name, string description, int qnt, Sprite spt)
    {
        this.name = name;
        this.description = description;
        this.qnt = qnt;
        this.spt = spt;
    }


}