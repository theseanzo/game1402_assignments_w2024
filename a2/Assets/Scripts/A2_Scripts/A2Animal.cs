using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class A2Animal : MonoBehaviour
{
    protected Rigidbody rb;
    [SerializeField]
    protected Transform animalTransform;
    protected Transform end;
    protected float speed = 0.50f;
    public bool Conditionmet = false;


    // Update is called once per frame


    private void FixedUpdate()
    {
      if (Conditionmet)
        {
            Vector3 nextPosition = Vector3.Lerp(animalTransform.position, end.position, speed * Time.deltaTime);

            animalTransform.position = nextPosition;





            if (animalTransform.position == end.position)
            {
                Conditionmet = false;
            }
        }

    }
    protected virtual void Move()
    {
        Conditionmet = true;
    }
}
