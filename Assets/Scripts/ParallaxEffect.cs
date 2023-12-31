using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    Transform cam;
    Vector3 camstartPos;
    float distance;
    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;
    float fathestBack;

    [Range(0.01f,0.05f)]
    public float parallaxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        camstartPos = cam.position;
        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for(int i=0;i<backCount;i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(backCount);
    }
    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++)
        {
           if((backgrounds[i].transform.position.z - cam.position.z) > fathestBack)
           {

                fathestBack = backgrounds[i].transform.position.z - cam.position.z;
           }
        }


        for (int i = 0; i < backCount; i++)
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / fathestBack;
        }
    }
    private void LateUpdate()
    {
        distance = cam.position.x - camstartPos.x;
        transform.position = new Vector3(cam.position.x, transform.position.y, 0);
        for(int i=0;i<backgrounds.Length;i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}
