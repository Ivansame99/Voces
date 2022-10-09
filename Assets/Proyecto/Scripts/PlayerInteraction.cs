using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    bool hasPush;
    //public GameObject platform;
    public GameObject box;
    private Vector3 boxPos;
    public GameObject[] obstacle;
    // Start is called before the first frame update
    void Start()
    {
        boxPos = box.transform.position;
        hasPush = false;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PushButton")
        {
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("A");
            }
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "End")
        {
            SceneManager.LoadScene("Victory");
        }

        if (other.gameObject.tag == "Obstacle")
        {
            for(int i=0; i<obstacle.Length;i++)
                obstacle[i].SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PushButton")
        {
            if (Input.GetKey(KeyCode.Space) /*&& !hasPush*/)
            {
                
                box.SetActive(true);
                box.GetComponent<Rigidbody>().velocity = new Vector3(0.0f,0.0f,0.0f);
                box.transform.position = boxPos;
                //platform.SetActive(false);
                //hasPush = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < obstacle.Length; i++)
            obstacle[i].SetActive(true);

        /*if (other.gameObject.tag == "PushButton")
        {
            if (hasPush) hasPush = false;
        }*/
    }
}
