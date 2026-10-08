using UnityEngine;
using UnityEngine.Events;
public class CubeDestroyTrigger : MonoBehaviour
{
    public GameObject CubePrefab;
    [HideInInspector] public UnityEvent OnTouch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject new_cube = Instantiate(CubePrefab);
            new_cube.transform.position = new Vector3(transform.position.x + Random.Range(-2.5f, 2.5f),
                Random.Range(0f, 5f),
                transform.position.z + Random.Range(-2.5f, 2.5f));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        OnTouch.Invoke();
    }
}
