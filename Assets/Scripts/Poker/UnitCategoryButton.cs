using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Poker;
using UnityEngine;
using UnityEngine.UI;

namespace Poker
{
    public class RerlicButton : MonoBehaviour
    {
        Model _model;
        string _rerlic;
        bool _isSelected = false;
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
            _rerlic = gameObject.name;
            _model = GameObject.Find("Model").GetComponent<Model>();
            _isSelected = _model.availableRerlic[_rerlic];
            if (_isSelected)
            {
                transform.DOLocalMoveX(10, 0.1f).SetRelative(true);
            }
        }
        void OnClick()
        {
            if (_isSelected)
            {
                _model.availableRerlic[_rerlic] = false;
                _isSelected = false;
                transform.DOLocalMoveX(-10, 0.1f).SetRelative(true);
            }
            else
            {
                _model.availableRerlic[_rerlic] = true;
                _isSelected = true;
                transform.DOLocalMoveX(10, 0.1f).SetRelative(true);
            }
        }
    }
}
