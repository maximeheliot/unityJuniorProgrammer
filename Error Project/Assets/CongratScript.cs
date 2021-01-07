using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;
    
    private List<string> TextToDisplay = new List<string>();
    
    private float RotatingSpeed = 100.0f;
    private float TimeToNextText = 0.0f;

    private int CurrentText = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");

        Text.text = TextToDisplay[0];
        
        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;
            
            Text.text = TextToDisplay[CurrentText];
            
            CurrentText++;
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;
            }
        }
        
        SparksParticles.transform.Rotate(Vector3.forward, RotatingSpeed * Time.deltaTime);
    }
}