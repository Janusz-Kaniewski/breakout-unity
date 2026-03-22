using UnityEngine;

public class BlocksManagerScript : MonoBehaviour
{
    public GameObject block;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //for (int i = 0; i < 20; i++)
        //{
        //    var randomx = Random.Range(-8, 8);
        //    var randomy = Random.Range(3, 0);

        //    Instantiate(block, new Vector3(randomx, randomy), new Quaternion(0, 0, 0, 0));
        //}

        for (int x = -8; x <= 8; x++)
        {
            for (int y = 3; y >= 0; y--)
            {
                Instantiate(block, new Vector3(x, y), new Quaternion(0, 0, 0, 0));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
