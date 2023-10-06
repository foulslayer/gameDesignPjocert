using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform _headerTransform;
    [SerializeField] private RectTransform _startButtonTransform;

    [SerializeField] private RectTransform _quitButtonTransform;

    [SerializeField] private Vector3 _headerEndPostion;
    [SerializeField] private Vector3 _startEndPostion;
    [SerializeField] private Vector3 _quitEndPostion;

    [SerializeField] private float _headerAnimationDuration;
    [SerializeField] private float _quitAnimationDuration;
     [SerializeField] private float _startAnimationDuration;
    
   void Awake()
   {
    _headerTransform.DOLocalMove(_headerEndPostion, _headerAnimationDuration);
    _startButtonTransform.DOLocalMove(_startEndPostion, _startAnimationDuration);
    _quitButtonTransform.DOLocalMove(_quitEndPostion, _quitAnimationDuration);
   }
}
