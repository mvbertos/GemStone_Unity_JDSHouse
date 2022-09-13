using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisInventory : MonoBehaviour
{
    private RectTransform rTransform;
    [SerializeField] private int width = 5;
    [SerializeField] private int height = 5;
    [SerializeField] private int gridSize = 2;

    ItemInventory itemInventory = null;

    Grid<ItemGrid> grid;
    private void Start()
    {
        this.rTransform = this.gameObject.GetComponent<RectTransform>();
        //Tilemap tilemap = new Tilemap(20, 60, 10, Vector3.zero);
        grid = new Grid<ItemGrid>(width, height, gridSize, this.transform.localPosition, (Grid<ItemGrid> g, int x, int y) => new ItemGrid(g, x, y));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && itemInventory != null)
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //get grid sequence
            ItemGrid[] itemGrid = new ItemGrid[itemInventory.Size];
            itemGrid[0] = grid.GetGridObject(position);

            //Check space
            if (itemGrid[0] != null)
            {
                for (int i = 1; i < itemInventory.Size; i++)
                {
                    Vector2 pos = itemGrid[0].GetPosition();
                    if (itemInventory.Side == ItemInventory.Direction.HORIZONTAL)
                    {
                        itemGrid[i] = grid.GetGridObject((int)pos.x + i, (int)pos.y);
                    }
                    else if (itemInventory.Side == ItemInventory.Direction.VERTICAL)
                    {
                        itemGrid[i] = grid.GetGridObject((int)pos.x, (int)pos.y + i);
                    }

                    if (itemGrid[i] == null)
                    {
                        Debug.Log("Not Enought Space");
                        return;
                    }
                }
            }

            //if has space
            //set value in all item grids
            foreach (var item in itemGrid)
            {
                item.ChangeValue(itemInventory.ItemData);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            itemInventory = Instantiate(Resources.Load<ItemInventory>("Prefabs/Weapons/WPN_BaseBallBat"), Vector3.zero, Quaternion.identity);
        }
    }
}

public class ItemGrid
{
    private Grid<ItemGrid> grid;
    private int x;
    private int y;
    private ItemInvData value;

    public ItemGrid(Grid<ItemGrid> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        value = new ItemInvData();
    }

    public Vector2 GetPosition()
    {
        return new Vector2(x, y);
    }

    public void ChangeValue(ItemInvData value)
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
