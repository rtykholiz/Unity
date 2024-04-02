using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    public float testTimer;
    private float _testTimer;
    private void Start()
    {
        //Стартова швидкість
        if (speed == 0)
        {
            transform.DORotate(new Vector3(0, 0, UnityEngine.Random.Range(0, 360)), 0);
            speed = UnityEngine.Random.Range(0.1f, 0.95f);
        }
        _testTimer = testTimer;

        _check = false;
        if (UnityEngine.Random.value > 0.5f)
        {
            _check = true;
        } 
    }
    // Update is called once per frame
    void Update()
    {
        //Рухає персонажа (ворога), якщо true, то персонаж рухається за допомогою Perp
        //MoveMethod1();
        MoveMethod2();

        //Debug.Log(1.0f / Time.deltaTime);
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
            testTimer = UnityEngine.Random.Range(3.5f, 7.5f);
            var ttime = UnityEngine.Random.Range(0.75f, 2.5f);
            transform.DORotate(new Vector3(0, 0, UnityEngine.Random.Range(0, 360)), ttime);
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
                transform.DORotate(new Vector3(0, 0, zEuler), _rotateSpeed);
                _check = false;
            }
            else
            {
                zEuler -= _rotateAngle;
                transform.DORotate(new Vector3(0, 0, zEuler), _rotateSpeed);
                _check = true;
            }

            testTimer = _testTimer;
        }
    }
}