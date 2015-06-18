using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour
{
    public enum PowerupType
    {
        Recovery,
        Buff,
        Item
    }

    public PowerupType type;
    public GameObject pickupEffect;

    public int maxPower = 10;
    public int minPower = 2;
    private int power = 0;

    void Start()
    {
        //If there is a rigidbody, launch item up and in a random direction
        if(GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0, 1f), 1, Random.Range(0, 1f)) * 250);

        //Assign a random value for power, from minPower to maxPower
        power = Random.Range(minPower, maxPower + 1);

        //Scale based on power
        transform.localScale = transform.localScale * (power / (float)maxPower);

        //Keep collider (trigger) same size, indipendant of localScale
        SphereCollider col = GetComponent<SphereCollider>();
        col.radius = col.radius * ((float)maxPower / power);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (type == PowerupType.Recovery)
            {
                //Instantiate and destroy pickup effect
                GameObject obj = Instantiate(pickupEffect, other.transform.position, Quaternion.identity) as GameObject;
                obj.transform.parent = other.transform;
                Destroy(obj, 2f);

                //Recover player health
                other.GetComponent<CharacterStats>().AddHealth(power);

                //Destroy powerup gameobject
                Destroy(gameObject);
            }
        }
    }
}
