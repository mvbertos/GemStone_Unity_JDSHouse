using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueBox : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        StartCoroutine(AutoDestroy(2));
    }

    public void SetText(string msg)
    {
        text.text = msg;
    }
    private IEnumerator AutoDestroy(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
