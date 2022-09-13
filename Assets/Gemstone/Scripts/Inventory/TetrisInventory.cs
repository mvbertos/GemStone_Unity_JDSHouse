using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisInventory : MonoBehaviour
{
    private RectTransform rTransform;
    [SerializeField] private int width = 5;
    [SerializeField] private int height = 5;
    [SerializeField] private int gridSize = 2;

    Grid<ItemGrid> grid;
    private void Start()
    {
        this.rTransform = this.gameObject.GetComponent<RectTransform>();
        //Tilemap tilemap = new Tilemap(20, 60, 10, Vector3.zero);
        grid = new Grid<ItemGrid>(width, height, gridSize, this.transform.localPosition, (Grid<ItemGrid> g, int x, int y) => new ItemGrid(g, x, y));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Debug.Log("Pos:"+this.transform.position+"Local Pos:"+this.transform.localPosition+"\n Mouse Viewport:"+ Camera.main.ScreenToViewportPoint(Input.mousePosition)+"Screen Point:"+Input.mousePosition);
            ItemGrid itemGrid = grid.GetGridObject(position);
            if (itemGrid != null)
                itemGrid.ChangeValue(new ItemInv("BaseBall", "ForFun", 1, null));
        }
    }
}

public class ItemGrid
{
    private Grid<ItemGrid> grid;
    private int x;
    private int y;
    private ItemInv value;

    public ItemGrid(Grid<ItemGrid> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        value = new ItemInv();
    }

    public void ChangeValue(ItemInv value)
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

public class ItemInv
{
    public string name;
    public string description;
    public int qnt;
    public Sprite spt;

    public ItemInv()
    {
    }

    public ItemInv(string name, string description, int qnt, Sprite spt)
    {
        this.name = name;
        this.description = description;
        this.qnt = qnt;
        this.spt = spt;
    }


}
