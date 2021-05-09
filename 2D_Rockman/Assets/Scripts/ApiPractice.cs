
using UnityEngine;

public class ApiPractice : MonoBehaviour
{
    //非靜態API：需要物件
    //定義一個欄位-物件

    public Camera cam;
    public SpriteRenderer sprt;
    public Transform sprt2;
    public Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        cam.depth = Camera.main.depth;
        sprt.color = Color.black;
        cam.backgroundColor = new Color(1, 0, 0);
        sprt.flipY = true;


    }

    // Update is called once per frame
    void Update()
    {
        //非靜態方法
        sprt2.Rotate(0, 0, 1);
        rig.AddForce(new Vector2(0, 10));
    }
}
