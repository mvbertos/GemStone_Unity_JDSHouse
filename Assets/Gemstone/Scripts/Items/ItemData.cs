using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string name;
    public string description;
    public int spcRequired;
    public Sprite spt;

    public ItemData() { }

    public ItemData(string name, string description, int spcRequired, Sprite spt)
    {
        this.name = name;
        this.description = description;
        this.spcRequired = spcRequired;
        this.spt = spt;
    }


}