using UnityEngine;

public class CubePrefab : MonoBehaviour
{
    [HideInInspector] public CubeDestroyTrigger trigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trigger = GameObject.Find("CubeDestroyTrigger").GetComponent<CubeDestroyTrigger>();
        trigger.OnTouch.AddListener(OnDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        trigger.OnTouch.RemoveListener(OnDestroy);
        Destroy(gameObject);
    }
}
