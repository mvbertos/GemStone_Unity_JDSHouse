using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class GenericGridTesting : MonoBehaviour
{
    private RectTransform rTransform;

    Grid<BoolGrid> grid;
    private void Start()
    {
        this.rTransform = this.gameObject.GetComponent<RectTransform>();
        //Tilemap tilemap = new Tilemap(20, 60, 10, Vector3.zero);
        grid = new Grid<BoolGrid>((int)rTransform.rect.width / 100, (int)rTransform.rect.height / 100, 100, this.transform.localPosition, (Grid<BoolGrid> g, int x, int y) => new BoolGrid(g, x, y));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Vector2 position = Input.mousePosition;
            // Debug.Log("Pos:"+this.transform.position+"Local Pos:"+this.transform.localPosition+"\n Mouse Viewport:"+ Camera.main.ScreenToViewportPoint(Input.mousePosition)+"Screen Point:"+Input.mousePosition);
            BoolGrid boolGrid = grid.GetGridObject(position);
            if (boolGrid != null)
                boolGrid.ChangeValue(true);
        }
    }
}

public class BoolGrid
{
    private Grid<BoolGrid> grid;
    private int x;
    private int y;
    private bool value;

    public BoolGrid(Grid<BoolGrid> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void ChangeValue(bool value)
    {
        this.value = value;
        grid.TriggerGridObjectChanged(x, y);
    }

    public override string ToString()
    {
        return value.ToString();
    }
}