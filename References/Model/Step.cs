using System;

namespace Xrm.PluginDeployer.Model
{
    public class Step
    {
        public Type Class { get; set; }
        public CrmEventType EventType { get; set; }
        public string PrimaryEntity { get; set; }
        public string SecondaryEntity { get; set; }
        public string[] FilteringAttributes { get; set; }
        public int ExecutionOrder { get; set; }
        public StageEnum Stage { get; set; }
        public bool PreImage { get; set; }
        public bool PostImage { get; set; }
        public string ImageName { get; set; }
        public string[] ImageAttributes { get; set; }
        public bool Offline { get; set; }

        public int Async => (this.Stage == StageEnum.PostOperationAsyncWithDelete || this.Stage == StageEnum.PostOperationAsyncWithoutDelete) ? 1 : 0;

        /// <summary>
        /// Returns Stage number according StageEnum
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public int StageValue
        {
            get
            {
                switch (Stage)
                {
                    case StageEnum.PostOperation: return 40;
                    case StageEnum.PostOperationAsyncWithDelete: return 40;
                    case StageEnum.PostOperationAsyncWithoutDelete: return 40;
                    case StageEnum.PreValidate: return 10;
                    case StageEnum.PreOperation: return 20;
                    default: throw new ArgumentException("Stage " + Stage.ToString() + " has not been mapeed");
                }
            }
        }

        /// <summary>
        /// Returns 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public string MessagePropertyName
        {
            get
            {
                switch (EventType)
                {
                    case CrmEventType.Associate:
                    case CrmEventType.Disassociate:
                    case CrmEventType.SetState:
                    case CrmEventType.SetStateDynamicEntity:
                    case CrmEventType.Close:
                        return "EntityMoniker";
                    case CrmEventType.Delete:
                    case CrmEventType.Update:
                        return "Target";
                    case CrmEventType.Create:
                        return "Id";
                    default: throw new ArgumentException("MessagePropertyName has not been maped for " + EventType);
                }
            }
        }


        /// <summary>
        /// Name of Step, used for logging
        /// </summary>
        public string Name => Class.FullName + ": " + EventType + " of " + PrimaryEntity;

        /// <summary>
        /// Returns unique name for Step
        /// </summary>
        public string UniqueName => Name + "/" + StageValue + "/" + ExecutionOrder + "/" + Async;
    }
}
