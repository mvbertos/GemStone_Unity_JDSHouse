using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InputMovimentation : MonoBehaviour
{
    [SerializeField] Transform sight;
    InputMappings inputMappings;
    Rigidbody2D rb;
    //MOVEMENT
    [Range(0, 20)] public float speed = 5.0f;
    // [Range(0,20)]public float rotateSpeed = 10.0f;

    private void Awake()
    {
        inputMappings = new InputMappings();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        inputMappings.Enable();
    }

    void OnDisable()
    {
        inputMappings.Disable();
    }

    private void FixedUpdate()
    {
        Move(inputMappings.Player.Move.ReadValue<Vector2>(), speed);
        Rotate(inputMappings.Player.Look.ReadValue<Vector2>());
    }

    private void Rotate(Vector2 deltaMouse)
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetDir = mousePos - (Vector2)this.transform.position;

        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        
        sight.eulerAngles = new Vector3(0, 0, angle-90);

    }

    private void Move(Vector2 direction, float speed)
    {
        rb.velocity = direction * speed; //((sight.up * direction.y) + (sight.right * direction.x)) * speed;
    }
}
