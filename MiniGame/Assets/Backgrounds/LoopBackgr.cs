using UnityEngine;

public class LoopBackgr : MonoBehaviour
{
    public GameObject sBG,bg1,bg2;
    public GameObject[] nxBG;
    public float speed = 5f;
    public float bgWidth, hwidth;
    public Rigidbody2D player;
    float TWidth(GameObject obj)
    {
        Bounds bounds = new Bounds(obj.transform.position, Vector3.zero);
        foreach (var sr in obj.GetComponentsInChildren<SpriteRenderer>())
        {
            //cauti toti copii
            bounds.Encapsulate(sr.bounds);
        }
        return bounds.size.x;
    }
    void Start()
    {
        //incepi de la poz 0
        bg1 = Instantiate(sBG, Vector3.zero, Quaternion.identity);
        //masori lungimea
        bgWidth = TWidth(bg1);
        hwidth = bgWidth / 2f;
        //calculezi pozitia la al doilea
        bg1.transform.position =new Vector3(Camera.main.transform.position.x,0,0);
        bg2 = Instantiate(nxBG[Random.Range(0, nxBG.Length)], new Vector3(bgWidth, 0, 0), Quaternion.identity);
    }
        void Update()
    {
        //muti spre stanga daca se misca playerul
        if (player.linearVelocity.x > 0.1f)
        {
            bg1.transform.Translate(Vector3.left * speed * Time.deltaTime);
            bg2.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        //verifici daca iese de pe ecran
        if (bg1.transform.position.x + hwidth < Camera.main.transform.position.x -hwidth)
        {
            //stergi , calculezi noua pozitie si creezi unul nou
            Destroy(bg1);
            float newX = bg2.transform.position.x + bgWidth;
            bg1 = Instantiate(nxBG[Random.Range(0, nxBG.Length)], new Vector3(newX, 0, 0), Quaternion.identity);
        }

        if (bg2.transform.position.x + hwidth < Camera.main.transform.position.x -hwidth)
        {
            Destroy(bg2);
            float newX = bg1.transform.position.x + bgWidth;
            bg2 = Instantiate(nxBG[Random.Range(0, nxBG.Length)], new Vector3(newX, 0, 0), Quaternion.identity);
        }
    }
}
