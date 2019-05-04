
using System.Collections;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    private Rigidbody rb;
    private float time, score;
    public float diffTime = 10, stayTime = 4;
    public GameObject gem;
    private GameObject clone;
    
    void Awake ()
    {
        time = Time.time;
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, +90, 0); 
        float now = Time.time;
        if (now - time > diffTime)
        {
            clone = Instantiate (gem, new Vector3(Random.Range(-4, 4), 0, Random.Range(-4, 4)), Quaternion.identity);
            Destroy(clone, stayTime);
            time = now;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SlowDown();
        }
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
//            rb.AddForce(new Vector3(0f, 300f, 0f));
            rb.velocity = new Vector3(0,5f,0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0f, 0f, 0.05f);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0f, 0f, -0.05f);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.05f, 0f, 0f);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.05f, 0f, 0f);
        }
    }
    
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Hand" || col.gameObject.name == "LittleHand")
        {
            Debug.Log("You're Dead :)");
        }
        else if (col.gameObject.name == "Gem(Clone)")
        {
            score ++;
            Debug.Log("Score :D  " + score);
            Destroy(col.gameObject);
        }
    }

    void SlowDown()
    {
        diffTime *= 2;
        stayTime *= 2;
        GameObject.Find("Hand").GetComponent<HandRotation>().speed /= 2;
        GameObject.Find("LittleHand").GetComponent<LittleHandRotation>().speed /= 2;
        StartCoroutine(GetFast());
    }

    private IEnumerator GetFast()
    {
        yield return new WaitForSeconds(3);
        diffTime /= 2;
        stayTime /= 2;
        GameObject.Find("Hand").GetComponent<HandRotation>().speed *= 2;
        GameObject.Find("LittleHand").GetComponent<LittleHandRotation>().speed *= 2;
    }

}
