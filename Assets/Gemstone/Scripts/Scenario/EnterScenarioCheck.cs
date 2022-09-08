using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterScenarioCheck : MonoBehaviour
{
    public Action<Collider2D> OnEnterScenario;
    public Action<Collider2D> OnExitScenario;


    void OnTriggerEnter2D(Collider2D other)
    {
        OnEnterScenario?.Invoke(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        OnExitScenario?.Invoke(other);
    }
}
