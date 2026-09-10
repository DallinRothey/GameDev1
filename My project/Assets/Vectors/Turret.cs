using UnityEngine;

public class Turret : MonoBehaviour
{
    //shooting
    public GameObject target;
    public GameObject bullet;
    public float rate_of_fire = 0.2f;
    private float shoot_timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If there is time on the timer... 
        if (shoot_timer > 0)
        {
            shoot_timer -= Time.deltaTime; //Subtract delta time from it
        }
        else
        {
            //spawn bullets...
            shoot_timer = rate_of_fire;

            //create a new bullet
            GameObject new_bullet = Instantiate(bullet);

            //move the bullet to the turrets position
            new_bullet.transform.position = transform.position;

            //get the direction the bullet will travel in.
            Vector3 bullet_dir = (target.transform.position - transform.position).normalized;

            new_bullet.GetComponent<Bullet>().SetVelocity(bullet_dir);
        }
    }
}
