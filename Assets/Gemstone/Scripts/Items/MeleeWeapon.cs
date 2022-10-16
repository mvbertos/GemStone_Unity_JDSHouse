using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private float radius;
    public override void Use()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(owner.Aim.position, radius, owner.Aim.right, range, attackLayers);
        foreach (RaycastHit2D hit in hits)
        {
            Rigidbody2D rb2d = hit.collider.attachedRigidbody;
            if (rb2d && rb2d.TryGetComponent<Character>(out Character character) && owner != character)
            {
                character.Attributes.Health -= damage;
                Instantiate(character.HurtParticleEffect, hit.point, Quaternion.identity);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (owner)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(owner.Aim.position + (owner.Aim.right * range), radius);
        }
    }
}
