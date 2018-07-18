namespace Implementation
{
    public class Manager : IApprover
    {
        private IApprover _approver;

        public string Name { get; }

        public Manager(string name)
        {
            Name = name;
        }

        public void SetSuccessor(IApprover approver)
        {
            _approver = approver;
        }

        public RequestResult ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount <= 1000.00)
            {
                return new RequestResult {Approved = true, By = this, Notes = $"Your purchase of {purchase.Description} has been approved" };
            }

            return _approver.ProcessRequest(purchase);
        }
    }
}