using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    public float testTimer;
    private float _testTimer;

    private Tween _rotateTween;

    private int _randomMethod = 0;
    private void Start()
    {
        //start speed
        if (speed == 0)
        {
            transform.DORotate(new Vector3(0, 0, UnityEngine.Random.Range(0, 360)), 0);
            speed = UnityEngine.Random.Range(0.1f, 0.95f);
        }
        _testTimer = testTimer;

        _check = false;
        if (Random.value > 0.5f)
        {
            _check = true;
        }

        _randomMethod = Random.Range(1,3);
        Debug.Log(gameObject.name + " - random is " + _randomMethod);
    }
    void Update()
    {
        switch (_randomMethod)
        {
            case 1:
                MoveMethod1();
                break;
            case 2: MoveMethod2();
                break;
            default: Debug.Log("Method not selected");
                break;
        }

        //If touched, GO will destroy gameobject
        if (Input.touchCount > 0)
        {
            OnTouchCheck();
        }
    }
    private void OnTouchCheck()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

        Touch _touch = Input.GetTouch(0);
        if (_touch.phase == TouchPhase.Began)
        {
            if (hit.collider != null)
            {
                Debug.Log("I'm hitting " + hit.collider.name);
                Destroy(hit.collider.gameObject);
            }
        }
    }

    private void MoveMethod1()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        if (testTimer > 0)
        {
            testTimer -= Time.deltaTime;
        }
        else
        {
            testTimer = Random.Range(3.5f, 7.5f);
            var ttime = Random.Range(0.75f, 2.5f);
            _rotateTween = transform.DORotate(new Vector3(0, 0, Random.Range(0, 360)), ttime);
        }
    }

    //Значення для переключання повороту
    private bool _check;
    public float _rotateSpeed, _rotateAngle;
    private void MoveMethod2()
    {
        
        //даний метод рухає об'єкт Z подобною хвилею

        transform.position += transform.up * speed * Time.deltaTime;

        if (testTimer > 0)
        {
            testTimer -= Time.deltaTime;
        }
        else
        {
            float zEuler = transform.rotation.z;
            if (_check)
            {
                zEuler += _rotateAngle;
                _rotateTween=  transform.DORotate(new Vector3(0, 0, zEuler), _rotateSpeed);
                _check = false;
            }
            else
            {
                zEuler -= _rotateAngle;
                _rotateTween = transform.DORotate(new Vector3(0, 0, zEuler), _rotateSpeed);
                _check = true;
            }

            testTimer = _testTimer;
        }
    }

   
}