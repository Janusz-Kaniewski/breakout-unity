using UnityEngine;

public class BlocksManagerScript : MonoBehaviour
{
    public GameObject block;
    private int blocksCount;
    private SceneScript sceneScript;

    private void ArrangeBlocks()
    {
        blocksCount = 0;
        
        for (int x = -7; x <= 7; x++)
        {
            for (int y = 3; y >= 1; y--)
            {
                Instantiate(block, new Vector3(x, y), new Quaternion(0, 0, 0, 0));
                blocksCount++;
            }
        }
    }

    public void DecreaseBlockCount()
    {
        blocksCount--;
        print($"Blocks decreased! Now: {blocksCount}");
    }

    public void ResetAndArrange()
    {
        var remainingBlocks = GameObject.FindGameObjectsWithTag("Block");

        for (int i = 0; i < remainingBlocks.Length; i++)
        {
            Destroy(remainingBlocks[i]);
        }

        ArrangeBlocks();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneScript = GameObject.FindGameObjectWithTag("SceneScript").GetComponent<SceneScript>();
        ArrangeBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        if (blocksCount == 0)
        {
            ArrangeBlocks();
            sceneScript.NextLevel();
        }
    }
}
