using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private Animator _animation;
    private CanvasGroup _canvas;

    public bool IsOpen {
        get { return _animation.GetBool("IsOpen"); }
        set { _animation.SetBool("IsOpen",value); }
    }


    public void Awake() {
        _animation = GetComponent<Animator>();
        _canvas = GetComponent<CanvasGroup>();
        var rect = GetComponent<RectTransform>();
        rect.offsetMax = rect.offsetMin = new Vector2(0, 0);

    }



    public void Update() {
        if (!_animation.GetCurrentAnimatorStateInfo(0).IsName("Open")) {
            _canvas.blocksRaycasts = _canvas.interactable = false;
        }else
            _canvas.blocksRaycasts = _canvas.interactable = true;
    }
}
