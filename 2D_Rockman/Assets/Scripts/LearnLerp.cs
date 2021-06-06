using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnLerp : MonoBehaviour
{
    // Start is called before the first frame update

    public float a = 0;
    public float b = 10;

    public float posCam = 0;
    public float posPla = 100;
    public Vector3 vCam = new Vector3(0, 0, 0);
    public Vector3 vPla = new Vector3(100, 100, 100);

    void Start()
    {
        //認識插值 Lerp
        //會從a與b之間取一個百分比的數字
        float r = Mathf.Lerp(a, b, 0.5f);
        print("a與b中間值：" + r); 
    }

    // Update is called once per frame
    void Update()
    {
        //因為是Update, 兩個數字會越來越靠近, 以此來寫Camera追蹤
        posCam = Mathf.Lerp(posCam, posPla, 0.5f);
        vCam = Vector3.Lerp(vCam, vPla, 0.5f); 
    }
}
