using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;//Rigidbody of the target
    private GameManager gameManager;//Access the script of the game manager
    //Basic data types
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos= -2;
    public int pointValue;//To add different points in every objects

    public ParticleSystem explosionParticle;//for the particles
    
    // Start is called before the first frame update
    void Start()
    {
        //To access and get the component
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //If the obstacle spawned it will rotate and put it in the game scene with force 
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);//Add rotation
        transform.position = RandomSpawnPos();//To randomize the position
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() //If the user has pressed the object then it will run
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
    }
    private void OnTriggerEnter(Collider other)//If the obstacle reacher the sensor the game will be over
    {
        Destroy(gameObject);//Destroy the game object that passess the sensor
        if(!gameObject.CompareTag("Bad"))//If the game object doesnt have a "Bad" tag and it reaches the sensor, the game will be over
        {
            gameManager.GameOver();
        }
        
    }

    Vector3 RandomForce()//Randomize the strength putting it on the game scene
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()//Randomize the Rotation
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()//Randomize the position
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
        
}
