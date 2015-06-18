using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float range = 10f;

    public int damage = 1;

    public GameObject collisionEffect;

    private float distance = 0f;

    void Update()
    {
        //Moves the bullet forward at Speed per second
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //Calculates distance based on formula d = vt;
        distance += Time.deltaTime * speed;

        //If the bullet has reached it's max distance, destroy itself.
        if (distance >= range)
            Destroy(gameObject);
	}

    void OnCollisionEnter(Collision other)
    {
        CharacterStats stats = other.collider.GetComponent<CharacterStats>();
        if (stats)
        {
            stats.RemoveHealth(damage);
            Destroy(gameObject);

            if (collisionEffect)
            {
                GameObject flash = Instantiate(collisionEffect, transform.position, collisionEffect.transform.rotation) as GameObject;
                Destroy(flash, 2f);
            }
        }
    }
}