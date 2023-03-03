using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UnitDeBataia : MonoBehaviour
{

    [SerializeField] bool IsPlayerUnit;

    Image Imagem;
    Vector3 PosicaoInicial;
    Color CorOriginal;
    
    public Pokemongol Pokemongol { get; set; }

    private void Awake()
    {
        Imagem = GetComponent<Image>();
        PosicaoInicial = Imagem.transform.localPosition;
        CorOriginal = Imagem.color;
    }
    public void Setup(Pokemongol pokemongol)
    {
        Pokemongol = pokemongol;
        if (IsPlayerUnit == true)
        {
            GetComponent<Image>().sprite = Pokemongol.Base.backSprite;
        }
        else
        {
            GetComponent<Image>().sprite = Pokemongol.Base.frontSprite;
        }
        PlayOpAnime();

        Imagem.color = CorOriginal;
    }

    public void PlayOpAnime()
    {
        //enemy493x ally-503.6x 
        if (IsPlayerUnit == true)
        {
            Imagem.transform.localPosition = new Vector3(-1479, PosicaoInicial.y);
        }
        else
        {
            Imagem.transform.localPosition = new Vector3(1420, PosicaoInicial.y);
        }
        Imagem.transform.DOLocalMoveX(PosicaoInicial.x, 1f);
    }
    public void PlayAttackAnime()
    {
        var Sequence = DOTween.Sequence();
        if(IsPlayerUnit == true)
        {
            Sequence.Append(Imagem.transform.DOLocalMoveX(PosicaoInicial.x + 50f, 0.25f));
        }
        else
        {
            Sequence.Append(Imagem.transform.DOLocalMoveX(PosicaoInicial.x - 50f, 0.25f));
        }
        Sequence.Append(Imagem.transform.DOLocalMoveX(PosicaoInicial.x, 0.25f));
    }
    public void PlayHitAnime()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Imagem.DOColor(Color.grey, 0.1f));
        sequence.Append(Imagem.DOColor(CorOriginal, 0.1f));
    }
    public void PlayDyingAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Imagem.transform.DOLocalMoveY(PosicaoInicial.y - 150, 0.5f));
        sequence.Join(Imagem.DOFade(0f, 0.5f));
    }
}
