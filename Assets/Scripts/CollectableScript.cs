using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CollectableScript : MonoBehaviour
{
    public Transform prefab;
    public PathCreator pathCreatorMiddle;
    public PathCreator pathCreatorLeft;
    public PathCreator pathCreatorRight;
    public float spacing = 3;

    const float minSpacing = .1f;
    // Start is called before the first frame update
    void Start()
    {
        VertexPath pathMiddle = pathCreatorMiddle.path;
        VertexPath pathLeft = pathCreatorLeft.path;
        VertexPath pathRight = pathCreatorRight.path;
        spacing = Mathf.Max(minSpacing, spacing);
        float dst = 0;
        float dst2 = 0;
        float dst3 = 0;

        while (dst < pathMiddle.length && dst2 < pathLeft.length && dst3 < pathRight.length)
        {
            Vector3 point = pathMiddle.GetPointAtDistance(dst) + new Vector3(0f,0.1f,0f);
            Instantiate(prefab, point, prefab.rotation);
            dst += Random.Range(3.0f, 10.0f);
            Vector3 point2 = pathLeft.GetPointAtDistance(dst2) + new Vector3(0f, 0.1f, 0f);
            Instantiate(prefab, point2, prefab.rotation);
            dst2 += Random.Range(3.0f, 10.0f);
            Vector3 point3 = pathRight.GetPointAtDistance(dst3) + new Vector3(0f, 0.1f, 0f);
            Instantiate(prefab, point3, prefab.rotation);
            dst3 += Random.Range(3.0f, 10.0f);
        }
 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
