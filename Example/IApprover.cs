namespace Implementation
{
    public interface IApprover
    {
        string Name { get; }

        void SetSuccessor(IApprover approver);
        RequestResult ProcessRequest(Purchase purchase);
    }
}