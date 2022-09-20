using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory
{
    public enum Direction
    {
        VERTICAL,
        HORIZONTAL
    }

    public ItemData data { private set; get; }
    public Direction side { private set; get; }
    public int qnt { private set; get; }

    public ItemInventory(ItemData data, Direction side, int qnt)
    {
        this.data = data;
        this.side = side;
        this.qnt = qnt;
    }
}