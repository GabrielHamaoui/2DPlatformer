using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAI : MonoBehaviour
{

    [SerializeField]
    GameObject fireball;

    float fireRate;
    float nextShot;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 2f;
        nextShot = Time.time;
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
            Instantiate(fireball, transform.position, Quaternion.identity);
            nextShot = Time.time + fireRate;
        }
    }


}
