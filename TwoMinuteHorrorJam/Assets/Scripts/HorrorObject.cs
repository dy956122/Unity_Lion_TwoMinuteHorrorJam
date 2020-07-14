using UnityEngine;

public class HorrorObject : MonoBehaviour, ITriggerEvent  // ITriggerEvent要按右鍵，實作類別，把中間throw 的部分刪掉
{
    /// <summary>
    /// 剛體
    /// </summary>
    private Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        rig.useGravity = false;                             // 取消地心引力                     
        rig.constraints = RigidbodyConstraints.FreezeAll;   // 凍結全部

    }

    /// <summary>
    /// 允許子類別覆寫觸發事件
    /// </summary>
    public virtual void TriggerEvent()
    {
        print("!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "玩家") TriggerEvent();
    }
}
