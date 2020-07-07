using UnityEngine;

public class Player : MonoBehaviour
{

    #region 基礎欄位
    [Header("移動速度"), Range(1, 1000)]
    public float speed = 10;

    [Header("旋轉速度"), Range(1, 1000)]
    public float turn = 5;


    /// <summary>
    /// 遊戲總時間：兩分鐘
    /// </summary>
    private float time = 120;

    /// <summary>
    /// 定義玩家事件委派
    /// </summary>
    public delegate void delegatePlayerEvent();

    /// <summary>
    /// 玩家時間到就死亡
    /// </summary>
    public event delegatePlayerEvent onDead;

    /// <summary>
    /// 玩家取得道具
    /// </summary>
    public event delegatePlayerEvent onItem;

    /// <summary>
    /// 玩家完成：走到終點
    /// </summary>
    public event delegatePlayerEvent onFinal;

    private Rigidbody rig;
    private Transform cam;

    #endregion 基礎欄位 結束

    #region 事件
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        cam = transform.GetChild(0);
    }

    private void FixedUpdate()
    {
        Move();
    }


    #endregion 事件 結束

    #region 方法
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        rig.AddForce(cam.forward * v * speed + cam.right * h * speed);

        float x = Input.GetAxis("Mouse X");
        cam.Rotate(0, x * turn, 0);
    }
    #endregion 方法 結束
}
