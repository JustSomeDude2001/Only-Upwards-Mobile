using Lean.Transition;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGeneratorScript : MonoBehaviour
{

    [SerializeField]private GameObject player;
    float threshold = 15;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        threshold += gameObject.transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y >= threshold + gameObject.transform.position.y && player.transform.position.y- gameObject.transform.position.y >=71)
        {
            //Instantiate(gameObject, new Vector3(gameObject.transform.position.x, threshold - 15f, gameObject.transform.position.z),gameObject.transform.rotation) ;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 168f, gameObject.transform.position.z);
        }
        if(gameObject.transform.position.y-player.transform.position.y >= 71)
        {
            if(gameObject.transform.position.y >= player.transform.position.y + threshold)
            {

                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 168f, gameObject.transform.position.z);
            }
        }
    }
}
