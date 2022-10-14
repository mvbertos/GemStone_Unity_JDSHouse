using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueBox : MonoBehaviour
{
    float time;
    float timeLeft;
    [SerializeField] private TMP_Text text;
    private string[] messages = new string[1];
    private int messageIndex = 0;
    private void Start()
    {
        timeLeft = 1;
    }

    public void SetText(string msg, float time = 2)
    {
        text.text = msg;

        this.time = time;
        timeLeft = this.time;
    }

    public void SetText(string[] msg, float time = 2)
    {
        messageIndex = 0;
        messages = msg;
        SetText(messages[0], time);
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 1f)
        {
            float alpha = Mathf.Lerp(0, 1, timeLeft);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

            if (timeLeft <= 0)
            {
                if (messageIndex < messages.Length - 1)
                {
                    messageIndex++;
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                    SetText(messages[messageIndex]);
                }
                else
                {
                    GameObject.Destroy(this.gameObject);
                }
            }

        }

    }
}
