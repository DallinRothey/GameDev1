using System.Runtime.CompilerServices;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Cube : MonoBehaviour
{
    //components
    private MeshRenderer mesh_renderer;
    private Timer timer;
    //Timer Variables
    private float color_timer = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get Components
        mesh_renderer = GetComponent<MeshRenderer>();
        //start timer
        timer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            timer.SetPause(true);
        if (Input.GetKeyDown(KeyCode.Z))
            timer.SetPause(false);

        if(timer.IsFinished())
        {
            ChangeColor();
            timer.StartTimer(color_timer);
        }

    }
    private void ChangeColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        mesh_renderer.material.color = new Color(r, g, b);
    }
}
