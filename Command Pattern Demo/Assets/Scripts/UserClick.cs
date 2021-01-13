using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Left click
        if (Input.GetMouseButtonDown(0))
        {
            // cast a ray
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            // detect a cube
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("Cube"))
                {
                    // Execute click command
                    ICommand click = new ClickCommand(hitInfo.collider.gameObject, 
                        new Color(Random.value, Random.value, Random.value));
                    click.Execute();
                    CommandManager.Instance.AddCommand(click);
                }
            }
        }
    }
}
