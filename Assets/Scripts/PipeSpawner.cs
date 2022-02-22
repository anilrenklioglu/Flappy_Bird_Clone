using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    [SerializeField] private float maxTime = 1f;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float height;
    
    void Start()
    {
        GameObject newPipe = Instantiate(pipe);
            
        newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        
    }
    
    void Update()
    {
        if (timer > maxTime)
        {

            GameObject newPipe = Instantiate(pipe);
            
            newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            
            Destroy(newPipe, 10f);

            timer = 0f;
        }

        timer += Time.deltaTime;
    }
}
