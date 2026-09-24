using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //shooting
    public GameObject target;
    public GameObject bullet;
    public float rate_of_fire = 0.2f;
    public float spread = 5; //In degrees
    public float view_angle = 25; //In degrees
    private float shoot_timer = 0;
    private float dot_needed_to_see;
    private Vector3 dir_to_target = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //compute the dot needed to see the target
        //calculate once since Cos() is an expensive function.
        dot_needed_to_see = Mathf.Cos(view_angle / 2 * Mathf.Deg2Rad);
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
            dir_to_target = (target.transform.position - transform.position).normalized;

            //Creates the axis of rotation for adding spread
            Vector3 axis = Vector3.Cross(dir_to_target, Vector3.up);

            //Apply spread by rotating the bullet_dir along the axis vector
            //We rotate somewhere between 0 and spread.
            Vector3 spread_dir = Quaternion.AngleAxis(Random.Range(0, spread), axis) * dir_to_target;

            //Rotate the spread_dir along the bullet_dir, or the direction to the player
            //We rotate it 0-360 degrees so it will be somewhere in the cone.
            Vector3 final_dir = Quaternion.AngleAxis(Random.Range(0, 360), dir_to_target) * spread_dir;

            //Pass in the direction that the bullet will travel in
            new_bullet.GetComponent<Bullet>().SetVelocity(final_dir);
        }
    
        
    }
    private bool TargetInView()
    {
        return true;
    }
    private void OnDrawGizmos()
    {
        //Bullet's direction
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + dir_to_target * 2);

        #region Bullet Spread Cone
        /*//up direction
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * 2);
        //Cross product, acts as axis of rotation when applying spread.
        Gizmos.color = Color.cyan;
        Vector3 axis = Vector3.Cross(dir_to_target, Vector3.up);
        Gizmos.DrawLine(transform.position, transform.position + axis * 2);
        //Spread direction, rotates the bullet_dir vector around the axis by spread
        Gizmos.color = Color.yellow;
        Vector3 spread_dir = Quaternion.AngleAxis(spread, axis) * dir_to_target;
        Gizmos.DrawLine(transform.position, transform.position + spread_dir * 2);
        //Final direction, rotates the spread_dir around bullet_dir
        //Cone represented by multiple magenta lines + rotated dir
        Gizmos.color = Color.magenta;
        Vector3 final_dir;
        for (int i = 1; i <= 15; i ++)
        {
            final_dir = Quaternion.AngleAxis(22.5f * i, dir_to_target) * spread_dir;
            Gizmos.DrawLine(transform.position, transform.position + final_dir * 2);
        }*/
        #endregion

        #region Vision Cone

        Gizmos.color = Color.blue;
    Gizmos.DrawLine(transform.position, transform.position + transform.forward* 2);

        float half_angle = view_angle / 2;

        Vector3 right = Quaternion.AngleAxis(half_angle, Vector3.up) * transform.forward;
        Vector3 left = Quaternion.AngleAxis(-half_angle, Vector3.up) * transform.forward;

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + right * 10);
        Gizmos.DrawLine(transform.position, transform.position + left * 10);

        Vector3 flat_dir_to_target = new Vector3(dir_to_target.x, 0, dir_to_target.z).normalized;
        Gizmos.color = Color.orange;
        Gizmos.DrawLine(transform.position, transform.position + flat_dir_to_target * 2);

        #endregion
    }

    
}
