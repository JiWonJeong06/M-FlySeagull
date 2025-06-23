using UnityEngine;

public class Scroll : MonoBehaviour
{
    public int scrollspeed;
    // Update is called once per frame

    void Update()
    {

        float totalSpeed = scrollspeed * Time.deltaTime * -1f;
        transform.Translate(totalSpeed, 0, 0);

        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
        
    }
}
