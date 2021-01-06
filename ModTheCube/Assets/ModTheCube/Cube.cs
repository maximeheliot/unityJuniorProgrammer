using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float positionRange;
    public float scaleRange;
    public float rotationSpeedRange;

    private Material _material;
    private float _timeLeft;
    private Color _targetColor;

    private int doRotationX;
    private int doRotationY;
    private int doRotationZ;
    private float speedRotationZ;
    private float speedRotationX;
    private float speedRotationY;
    
    void Start()
    {
        transform.position = new Vector3(RandomFloat(positionRange), RandomFloat(positionRange), RandomFloat(positionRange));
        transform.localScale = Vector3.one * RandomFloat(scaleRange);
        
        _material = Renderer.material;

        doRotationX = Toss();
        doRotationY = Toss();
        doRotationZ = Toss();

        speedRotationX = RandomFloat(rotationSpeedRange);
        speedRotationY = RandomFloat(rotationSpeedRange);
        speedRotationZ = RandomFloat(rotationSpeedRange);
    }
    
    void Update()
    {
        transform.Rotate(doRotationX * Time.deltaTime * speedRotationX, 
            doRotationY * Time.deltaTime * speedRotationY, 
            doRotationZ * Time.deltaTime * speedRotationZ);
        
        if (_timeLeft <= Time.deltaTime)
        {
            // transition complete
            // assign the target color
            _material.color = _targetColor;
 
            // start a new transition
            _targetColor = new Color(Random.value, Random.value, Random.value, Random.value);
            _timeLeft = 1.0f;
        }
        else
        {
            // transition in progress
            // calculate interpolated color
            _material.color = Color.Lerp(_material.color, _targetColor, Time.deltaTime / _timeLeft);
 
            // update the timer
            _timeLeft -= Time.deltaTime;
        }
    }

    private float RandomFloat(float rangeNumber)
    {
        return Random.Range(-rangeNumber, rangeNumber);
    }

    private int Toss()
    {
        return Random.Range(0, 2);
    }

    private float RandomColor()
    {
        return Random.value;
    }
}
