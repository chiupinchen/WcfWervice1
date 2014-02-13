using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService7" in both code and config file together.
    [ServiceContract(Namespace="Chiupin.Chen.Com")]
    public interface IService7
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        Student GetStudent();

        [OperationContract]
        Person GetJuniorHighStudent(Person juniorHighStudent);
    }

    [DataContract]
    public class JuniorHighStudent: Person
    {
        [DataMember]
        public string Name;

        [DataMember]
        public int Age;
    }

    [DataContract]
    public class Student
    {
        [DataMember]
        public string Name;

        [DataMember]
        public int Age;

        [OnSerializing]
        void OnSerializing(StreamingContext streamingContext)
        {
        
        }

        [OnSerialized]
        void OnSerialized(StreamingContext streamingContext)
        {

        }

        [OnDeserializing]
        void OnDeSerializing(StreamingContext streamingContext)
        {

        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext streamingContext)
        {

        }
    }
}
