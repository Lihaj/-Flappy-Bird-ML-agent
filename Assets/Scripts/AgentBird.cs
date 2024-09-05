using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class AgentBird: Agent
{
    public float speed=5f;
    Rigidbody2D rb;

    public Score scoreText;
    public ColumnSpawner columnSpawner; 
    Vector2 initialPosition;

    public override void Initialize()
    {
        rb=GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    public override void OnEpisodeBegin()
    {
        columnSpawner.DestroyAllColumns();
        transform.position = initialPosition;
        scoreText.ScoreRest();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(rb.velocity.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float jump=actions.DiscreteActions[0];
        if(jump==1){
            rb.velocity=Vector2.up *speed;
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
        int x= Input.GetKey(KeyCode.Space) ? 1 : 0;
        // Debug.Log("user input" + x);
        discreteActions[0] =x;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Hole")){
            AddReward(10f);
            scoreText.ScoreUp();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
    
        if(other.gameObject.CompareTag("Ground")|| other.gameObject.CompareTag("Pipe")){
           
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            AddReward(-10f);
            EndEpisode();
         
        }
    }
}


