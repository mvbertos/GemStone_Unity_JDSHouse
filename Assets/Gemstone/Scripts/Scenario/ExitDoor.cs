using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    public void Open()
    {
        SceneManager.LoadScene("Menu");
    }
}
