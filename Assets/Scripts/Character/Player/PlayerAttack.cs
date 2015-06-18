using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;

    public Transform muzzlePos;
    public GameObject bulletPrefab;
    public GameObject muzzleEffect;

    void Update()
    {

    }

    public void Attack(int id)
    {
        switch(id)
        {
            case 1:
                GameObject proj = Instantiate(bulletPrefab, muzzlePos.position, muzzlePos.rotation) as GameObject;
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), proj.GetComponent<Collider>());

                //Spawn a muzzle flash particle system and destroy after time.
                if (muzzleEffect)
                {
                    GameObject flash = Instantiate(muzzleEffect, muzzlePos.position, muzzlePos.rotation) as GameObject;
                    Destroy(flash, 1f);
                }
                break;
            case 2:
                anim.SetTrigger("Attack_2");
                break;
        }
    }
}
