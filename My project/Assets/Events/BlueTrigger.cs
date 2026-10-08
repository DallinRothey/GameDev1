using UnityEngine;
using UnityEngine.Events;
public class BlueTrigger : MonoBehaviour
{
    public UnityEvent<Color> SetBlue;
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
        SetBlue.Invoke(Color.blue);
    }
}
