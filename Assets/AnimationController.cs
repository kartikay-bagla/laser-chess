using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public GameObject king;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume=0.5f;

    private Vector3 finalPos = new Vector3(0, 0.2f, 0);

    // Start is called before the first frame update
    void Start()
    {
        // king.GetComponent<KingController>().SetupObject(2);
        king.transform.position = new Vector3(0, 10f, 0);
        audioSource.PlayOneShot(clip, volume);
    }

    // Update is called once per frame
    void Update()
    {
        // Move king in a helix

        float r = (king.transform.position.y - 0.2f) * 0.3f;

        float x = Mathf.Cos(2 * Time.time) * r;
        float z = Mathf.Sin(2 * Time.time) * r;
        float y = Mathf.Max(king.transform.position.y - Time.deltaTime, 0.2f);
        king.transform.position = new Vector3(x, y, z);

        // Rotate king
        float angle = (king.transform.position.y - 0.2f ) * 270;

        float secondAngle = (king.transform.position.y - 0.2f) + Mathf.PerlinNoise(Time.time, 0);

        king.transform.rotation = Quaternion.Euler(secondAngle, angle, 0);
        
    }
}
