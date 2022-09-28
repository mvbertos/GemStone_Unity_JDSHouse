using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TetrisInventory : MonoBehaviour
{
    private Canvas canvas;
    [SerializeField] private RectTransform rTransform;
    [SerializeField] private int gridSize = 2;

    Grid<ItemGrid> grid;
    private void Start()
    {
        //Tilemap tilemap = new Tilemap(20, 60, 10, Vector3.zero);
        canvas = this.GetComponent<Canvas>();

        int width = (int)((rTransform.rect.width / (20 * canvas.scaleFactor)) / 2);
        int height = (int)((rTransform.rect.height / (20 * canvas.scaleFactor)) / 2);
        Vector3 pos = new Vector3(rTransform.position.x - width, rTransform.position.y - height);
        Debug.Log("scale:" + canvas.scaleFactor + " Size:" + width + "/" + height);
        grid = new Grid<ItemGrid>(width, height, gridSize, pos, (Grid<ItemGrid> g, int x, int y) => new ItemGrid(g, x, y));
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Mouse0) && itemInventory != null)
    //     {

    //     }
    // }

    public bool AddItem(ItemInventory itmInventory, Vector3 worldPosition)
    {

        //get grid sequence
        ItemGrid[] itemGrid = new ItemGrid[itmInventory.data.spcRequired];
        itemGrid[0] = grid.GetGridObject(worldPosition);

        //Check space
        if (itemGrid[0] != null)
        {
            for (int i = 1; i < itmInventory.data.spcRequired; i++)
            {
                Vector2 pos = itemGrid[0].GetGridPosition();
                if (itmInventory.side == ItemInventory.Direction.HORIZONTAL)
                {
                    itemGrid[i] = grid.GetGridObject((int)pos.x + i, (int)pos.y);
                }
                else if (itmInventory.side == ItemInventory.Direction.VERTICAL)
                {
                    itemGrid[i] = grid.GetGridObject((int)pos.x, (int)pos.y + i);
                }

                if (itemGrid[i] != null && itemGrid[i].value.name != null)
                {
                    Debug.Log("Not Enought Space");
                    return false;
                }
            }
            //if has space
            //set value in all item grids
            foreach (var item in itemGrid)
            {
                Debug.Log("Item added successfully");
                item.ChangeValue(itmInventory.data);
                return true;
            }
        }
        Debug.Log("No Slot Available");
        return false;
    }

    public bool AddItem(ItemData data)
    {
        ItemInventory itmInventory = new ItemInventory(data, ItemInventory.Direction.HORIZONTAL, 1);

        for (int x = 1; x < rTransform.sizeDelta.x; x++)
        {
            for (int y = 1; y < rTransform.sizeDelta.y; y++)
            {
                ItemGrid itmGrid = grid.GetGridObject(x, y);
                
                //if has grid and enough space
                if (itmGrid.value.name == null)
                {
                    Debug.Log("picking:" + data.name);
                    if (AddItem(itmInventory, itmGrid.worldPosition))
                    {
                        //add new item
                        return true;
                    }
                }
            }
        }
        //if has not enough space or has no grid left
        //return
        return false;
    }
}

public class ItemGrid
{
    public Grid<ItemGrid> grid
    {
        private set;
        get;
    }

    private int x;
    private int y;
    public Vector3 worldPosition { get { return grid.GetWorldPosition(x, y); } }
    public ItemData value
    {
        private set;
        get;
    }

    public ItemGrid(Grid<ItemGrid> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        value = new ItemData();
    }

    public Vector2 GetGridPosition()
    {
        return new Vector2(x, y);
    }

    public void ChangeValue(ItemData value)
    {
        this.value = value;
        grid.TriggerGridObjectChanged(x, y);
    }

    public override string ToString()
    {
        string value = this.value.name == null ? "Null" : this.value.name;
        return value;
    }
}
