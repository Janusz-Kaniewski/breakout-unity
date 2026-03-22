using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private SceneScript sceneScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneScript = GameObject.FindGameObjectWithTag("SceneScript").GetComponent<SceneScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        sceneScript.AddPoints();
        Destroy(this.gameObject);
    }
}
