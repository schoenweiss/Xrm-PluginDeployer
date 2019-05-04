namespace Xrm.PluginDeployer.Model
{
    public enum CrmEventType
    {
        Create,
        Update,
        Delete,
        Associate,
        Disassociate,
        SetState,
        SetStateDynamicEntity,
        RetrieveMultiple,
        Retrieve,
        Other,
        Close,
        AddMember,
        AddListMembers,
        RemoveMember
    }
}
