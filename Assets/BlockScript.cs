using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private SceneScript sceneScript;
    private SpriteRenderer spriteRenderer;
    private BlocksManagerScript blocksManagerScript; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneScript = GameObject.FindGameObjectWithTag("SceneScript").GetComponent<SceneScript>();
        blocksManagerScript = GameObject.FindGameObjectWithTag("BlocksManager").GetComponent<BlocksManagerScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = new Color(Random.Range(0, 255) / 255.0f, Random.Range(0, 255) / 255.0f, Random.Range(0, 255) / 255.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        sceneScript.AddPoints();
        blocksManagerScript.DecreaseBlockCount();
        Destroy(this.gameObject);
    }
}
