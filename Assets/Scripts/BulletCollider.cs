using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour {
    public float damage;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            EnemyController monster = collision.gameObject.GetComponent<EnemyController>();
            if (monster.isAlive)
            {
                Destroy(this.gameObject);
                monster.TakeDamage(damage);
            }
        }
    }
}
