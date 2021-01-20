using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    private ObjectPool _objectPool;

    private Transform myTransform;

    // Start is called before the first frame update
    private void Start()
    {
        myTransform = transform;

        _objectPool = GetComponent<ObjectPool>();

        InvokeRepeating("Shoot", .33f, .33f);
    }

    private void Shoot()
    {
        GameObject bullet = _objectPool.GetAvailableObject();
        bullet.transform.position = myTransform.position;
        bullet.SetActive(true);
    }
}