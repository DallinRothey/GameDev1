using UnityEngine;
using UnityEngine.Events;
public class RedTrigger : MonoBehaviour
{
    public UnityEvent<Color> SetRed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        SetRed.Invoke(Color.red);
    }
}
