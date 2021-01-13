using UnityEngine;

public class Player : MonoBehaviour
{
    private ICommand moveUp, moveDown, moveLeft, moveRight;
    
    [SerializeField] private float _speed = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            // Move up command
            moveUp = new MoveUpCommand(this.transform, this._speed);
            moveUp.Execute();
            MoveCommandManager.Instance.AddCommand(moveUp);
        } 
        else if (Input.GetKey(KeyCode.S))
        {
            // Move down command
            moveDown = new MoveDownCommand(this.transform, this._speed);
            moveDown.Execute();
            MoveCommandManager.Instance.AddCommand(moveDown);
        } 
        else if (Input.GetKey(KeyCode.Q))
        {
            // Move left command
            moveLeft = new MoveLeftCommand(this.transform, this._speed);
            moveLeft.Execute();
            MoveCommandManager.Instance.AddCommand(moveLeft);
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            // Move right command
            moveRight = new MoveRightCommand(this.transform, this._speed);
            moveRight.Execute();
            MoveCommandManager.Instance.AddCommand(moveRight);
        }
    }
}
