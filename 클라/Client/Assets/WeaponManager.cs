using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    public ItemSlot m_weapon;
    [SerializeField] UnityEngine.UI.Text atk;


    private void Start()
    {
    }

    private void Update()
    {
        if (m_weapon.Item != null)
        {
            BPlayer.MainPlayer.GetComponent<NetworkObject>().m_WeaponATK = ((Weapon)(m_weapon.Item)).OffensePower;
        }
        else
        {
            BPlayer.MainPlayer.GetComponent<NetworkObject>().m_WeaponATK = 0;
        }

        atk.text = ""+(BPlayer.MainPlayer.GetComponent<NetworkObject>().m_CurrentATK.Value + BPlayer.MainPlayer.GetComponent<NetworkObject>().m_WeaponATK);
    }
}
