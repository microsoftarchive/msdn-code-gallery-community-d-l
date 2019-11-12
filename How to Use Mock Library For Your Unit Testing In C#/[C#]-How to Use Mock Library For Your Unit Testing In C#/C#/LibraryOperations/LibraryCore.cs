
namespace LibraryOperations
{
    public class LibraryCore
    {
        private readonly IMemberManager _memberManager;

        public LibraryCore(IMemberManager memberManager)
        {
            this._memberManager = memberManager;
        }

        public double CalculateMemberShipCost(int memberID)
        {
            double membershipCost = 0;
            Member member = _memberManager.GetMember(memberID);
            membershipCost = 10 + member.MaximumBookCanBorrow * 0.5;
            return membershipCost;
        }
    }
}
