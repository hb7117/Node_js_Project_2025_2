using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protocols
{
    public class Packets
    {
        public class common
        {
            public int cmd;             //��� ���� ǥ��
            public string message;      //�޼���
        }

        public class req_data : common
        {
            public int id;               //id�� �޴´�.
            public string data;          //���� ������
        }
    }
}
