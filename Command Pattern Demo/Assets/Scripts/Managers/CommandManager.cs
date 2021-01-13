using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CommandManager : MonoBehaviour
{
    private static CommandManager _instance;

    public static CommandManager Instance
    {
        get
        {   if (_instance.Equals(null))
                Debug.LogError("The CommandManager is NULL.");
            
            return _instance;
        }
    }

    private List<ICommand> _commandBuffer = new List<ICommand>();

    private void Awake()
    {
        _instance = this;
    }
    
    // Create a method to "add" commands to the command buffer
    public void AddCommand(ICommand command)
    {
        _commandBuffer.Add(command);
    }
    
    // Create a play routine triggered by a play method that's going to play back all the commands
    // 1 second delay
    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }
    
    private IEnumerator PlayRoutine()
    {
        Debug.Log("Playing...");
        
        foreach (ICommand command in _commandBuffer)
        {
            command.Execute();
            yield return new WaitForSeconds(1.0f);
        }
        
        Debug.Log("Finished...");
    }
    
    // Create a rewind routine triggered by a rewind method that's going play in reverse, with a 1 second delay
    public void Rewind()
    {
        StartCoroutine(RewindRoutine());
    }
    
    private IEnumerator RewindRoutine()
    {
        Debug.Log("Rewinding...");
        
        foreach (ICommand command in Enumerable.Reverse(_commandBuffer))
        {
            command.Undue();
            yield return new WaitForSeconds(1.0f);
        }
        
        Debug.Log("Finished...");
    }
    
    // Done = Finished with changing colors. Turn them all white
    public void Done()
    {
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Cube"))
        {
            cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
     
    // Reset - Clear the command buffer
    public void Reset()
    {
        _commandBuffer.Clear();
    }
}
