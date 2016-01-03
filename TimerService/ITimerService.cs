namespace UF.Training.TimerService
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract(Namespace = "http://uf.training.timerservice")]
    public interface ITimerService
    {
        [OperationContract]
        string Init();

        [OperationContract]
        string Start(string id);

        [OperationContract]
        string Stop(string id);

        [OperationContract]
        string Close(string id);

        [OperationContract]
        string LapStop(string id);

        [OperationContract]
        List<DateTime> GetTimes(string id);

    }
}