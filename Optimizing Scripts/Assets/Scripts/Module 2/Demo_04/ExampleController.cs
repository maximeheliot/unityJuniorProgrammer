using UnityEngine;
using UnityEngine.Profiling;

public class ExampleController : MonoBehaviour
{
    private Camera camera;
    private Transform myTransForm;

    // Start is called before the first frame update
    private void Start()
    {
        camera = Camera.main;

        myTransForm = transform;
    }

    // Update is called once per frame
    private void Update()
    {
        for (var i = 0; i < 10000; i++)
            TransformExample();
        // CameraExample();
    }

    private void TransformExample()
    {
        Profiler.BeginSample("TRANSFORM EXAMPLE");

        myTransForm.position = myTransForm.position;

        Profiler.EndSample();
    }

    private void CameraExample()
    {
        Profiler.BeginSample("CAMERA.MAIN EXAMPLE");

        camera.backgroundColor = Color.black;

        Profiler.EndSample();
    }
}