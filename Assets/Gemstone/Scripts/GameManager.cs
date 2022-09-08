using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool spawnNemesis = true;
    public static bool SpawnNemesis;

    private void Awake() {
        SpawnNemesis = spawnNemesis;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
