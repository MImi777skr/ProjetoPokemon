using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayerTriggerable : MonoBehaviour
{
    // Start is called before the first frame update

    public interface IPlayerTriggerablevoid
    {
        void OnPlayerTriggered(Player player);
    }
}
