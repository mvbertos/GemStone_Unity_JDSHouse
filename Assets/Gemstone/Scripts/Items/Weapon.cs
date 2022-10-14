using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    [SerializeField] private Transform atkPoint;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField]
    private LayerMask attackLayers;

    public override void Use()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll((Vector2)atkPoint.position, range, (Vector2)this.transform.forward, range, attackLayers);
        foreach (RaycastHit2D hit in hits)
        {
            Rigidbody2D rb2d = hit.collider.attachedRigidbody;
            if (rb2d && rb2d.TryGetComponent<Character>(out Character character) && owner != character)
            {
                character.Attributes.Health -= damage;
            }
        }
    }

    public void Aim()
    {
        //if it is with a fire weapon, it will reduce recoil
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(atkPoint.position, range);
    }
}
