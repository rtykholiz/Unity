using UnityEngine;
using TMPro;

public class MoveFingerObject : MonoBehaviour
{
    private Touch _touch;

    Vector3 _firstTouchPosition;
    RaycastHit _hit;

    private GameObject _targetGO;
    [SerializeField] private Rigidbody _targetGORigidbody;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    private float _timeStartTouch;


    private string virStr;

    private void Update()
    {

        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            switch (_touch.phase)
            {
                case TouchPhase.Began:
                    GetCubeTarget();
                    StopSetGravity();

                    break;

                case TouchPhase.Stationary:

                    MoveObjectFromFinger();
                    break;
                case TouchPhase.Moved:

                    MoveObjectFromFinger();
                    break;
                case TouchPhase.Ended:

                    break;
                default:

                    break;
            }
        }

        _timeStartTouch -= Time.deltaTime;


        //for test only
        _textMeshPro.text = _timeStartTouch.ToString();
    }

    //Обє'кт в який влучили
    private void GetCubeTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(_touch.position);

        if (Physics.Raycast(ray, out _hit))
        {
            _targetGO = _hit.collider.gameObject;
            _targetGORigidbody = _hit.collider.GetComponent<Rigidbody>();
            _timeStartTouch = 0.15f;
        }
        else
        {
            _targetGO = null;
            _targetGORigidbody = null;
        }
    }
    //Зупиняє гравітацію, 2-й клік активує гравітацію
    private void StopSetGravity()
    {
        if (_targetGO != null && _targetGORigidbody.useGravity == true)
        {
            _targetGORigidbody.useGravity = false;

        }
        else if (_targetGO != null && _targetGORigidbody.useGravity == false)
        {
            _targetGORigidbody.useGravity = true;
          
        }
   
    }


    //Переміщає об'єкт на позиція дотику чи мишки
    private void MoveObjectFromFinger()
    {
        if (_targetGO == null)
        {
            return;
        }

        if (_timeStartTouch <= 0)
        {

            Vector3 tarVec = Camera.main.ScreenToWorldPoint(new Vector3(_touch.position.x,
                _touch.position.y,
                Mathf.Abs(_targetGO.transform.position.z - Camera.main.transform.position.z)));

            _targetGO.transform.position = Vector3.Lerp(_targetGO.transform.position, tarVec, Time.deltaTime * 10f);
        }
    }
}
