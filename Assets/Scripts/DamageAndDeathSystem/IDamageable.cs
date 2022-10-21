using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public interface IDamageable
{
    public float Health { get; set; }

    //public bool Invincible { get; set; }

    //public bool Targetable { set; get; }

    public void Damage(float damage);

    public void OnObjectDestroyed();
    public void Damage(float damage, Vector2 knockback);
}
