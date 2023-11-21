using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Sounds
{
    public float offset;
    public GameObject bullet;
    public Transform shotpoint;
    private float TimeBtwShots;
    public float startTimeBtwShots;

    void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (TimeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shotpoint.position, Quaternion.Euler(0f, 0f, rotZ + offset - 90));
                TimeBtwShots = startTimeBtwShots;
                PlaySound(sounds[0]);
            }
        }
        else
        {
            TimeBtwShots -= Time.fixedDeltaTime;
        }
    }
}