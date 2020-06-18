using Mirror;
using UnityEngine;
using UnityEngine.Networking;

public class TurnOffRemotePlayer : NetworkBehaviour
{
    private void Start()
    {
        string id = string.Format("{0}", this.netId);
        Player scr = this.GetComponent<Player>();

        if (this.isLocalPlayer == true)
        {
            scr.enabled = true;
            scr.SetPlayerCaptian(id);
            scr.SetTitle("Multi PLayr № " + id);
        }
        else
        {
            scr.SetPlayerCaptian(id);
            scr.enabled = false;
        }
    }

}
