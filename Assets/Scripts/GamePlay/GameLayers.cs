using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayers : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LayerMask SolidObjects;
    [SerializeField] LayerMask DaPraInteragir;
    [SerializeField] LayerMask LongGrass;
    [SerializeField] LayerMask Player;
    [SerializeField] LayerMask Portal;

    public LayerMask SolidObjectsLayer { get => SolidObjects; }
    public LayerMask InteractableLayer { get => DaPraInteragir;  }
    public LayerMask LongGrassLayer { get => LongGrass; }
    public LayerMask PlayerLayer { get => Player; }
    public LayerMask PortalLayer { get => Portal; }
    public LayerMask TriggerableLayer { get => LongGrass | Portal; }

    public static GameLayers i { get; set; }

    private void Awake()
    {
        i = this;
    }
}
