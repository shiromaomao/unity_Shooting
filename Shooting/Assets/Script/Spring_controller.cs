using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring_controller : MonoBehaviour
{
	// Start is called before the first frame update
	//�U�����S�����߂�I�u�W�F�N�g
	public GameObject centerObject;

	Rigidbody rb;
	Transform centerObjectTransform;

    void Start()
    {
		
	}
    void Update()
    {

	}

    //�P�U�������镨�̂�Rigidbody��
    //�U�����S�ɐݒ肵���I�u�W�F�N�g��Transform���擾���Ă���
    void Awake()
	{
		rb = GetComponent<Rigidbody>();
		centerObjectTransform = centerObject.transform;
	}

	//�e����(������)���`���Ă���֐�
	void AddSpringForce(Vector3 centerObject_position, float r)
	{
		var diff = centerObject_position - transform.position ; //�΂˂̐L��=�U�����S�̈ʒu(x0)-���̂̈ʒu(x)
		var force = diff * r; //�e����(������) = k*(x0-x)
		rb.AddForce(force);//�e���͂�������
	}

	//0.02�b���Ƃɒe���͂��X�V���Ă���
	void FixedUpdate()
	{
		AddSpringForce(centerObjectTransform.position, 10);
	}
}
