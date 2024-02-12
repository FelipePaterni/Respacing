using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTp : MonoBehaviour
{
    public Transform Destino;
  
    public bool IsY;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, 40f, transform.position.z);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("bb");
        if (IsY)
        {
            collision.transform.position = new Vector3(collision.transform.position.x, Destino.position.y, collision.transform.position.z);
            Debug.Log("cc");

        }
        else
        {
            collision.transform.position = new Vector3(Destino.position.x, collision.transform.position.y, collision.transform.position.z);
            Debug.Log("dd");
        }

    }
  

}
