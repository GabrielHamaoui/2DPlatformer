using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAI : MonoBehaviour
{

    [SerializeField]
    GameObject fireball;

    float fireRate;
    float nextShot;

    GameObject player;
    Transform target; // player position
    public Transform shootingPoint;
    Animator wizardAnim;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 3f;
        nextShot = Time.time;
        wizardAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToShoot();
    }

    void CheckIfTimeToShoot()
    {
        if (Time.time > nextShot)
        {
            wizardAnim.Play("Wizard_Fire");
            Instantiate(fireball, shootingPoint.position, Quaternion.identity);
            nextShot = Time.time + fireRate;            
        } else
        {
            wizardAnim.Play("Wizard_Idle");
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // they collide, if player on top, destroy object if not take damage
            if (target.position.y - transform.position.y > 0)
            {
                wizardAnim.Play("Gothic_Church_Death");
                Destroy(this.gameObject, 0.5f);
                GameStatus.AddScore(25);
            }
            else
            {
                GameStatus.Damage(10);
                // knockback too if possible
            }
        }
    }
}
