﻿namespace Xrm.PluginDeployer.StepModel
{
    public enum StageEnum
    {
        PreValidate = 10,
        PreOperation = 20,
        PostOperation = 40,
        PostOperationAsyncWithDelete = 41,
        PostOperationAsyncWithoutDelete = 42,
    }
}
