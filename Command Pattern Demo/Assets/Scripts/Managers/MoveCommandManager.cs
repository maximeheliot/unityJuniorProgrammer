using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveCommandManager : MonoBehaviour
{
    private static MoveCommandManager _instance;

    public static MoveCommandManager Instance
    {
        get
        {
            if (_instance.Equals(null))
                Debug.LogError("The MoveCommandManager is NULL.");

            return _instance;
        }
    }

    private List<ICommand> _commandBuffer = new List<ICommand>();

    private void Awake()
    {
        _instance = this;
    }

    public void AddCommand(ICommand command)
    {
        _commandBuffer.Add(command);
    }

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
            yield return new WaitForEndOfFrame();
        }
        
        Debug.Log("Finished...");
    }

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
            yield return new WaitForEndOfFrame();
        }
        
        Debug.Log("Finished...");
    }
}
