using Core.Entities.Abstract;

namespace Entities.Models.RequestModels
{
    public class AuthCodeAddRequestModel : IAddModel
    {
        public AuthCodeAddRequestModel() { }

        public AuthCodeAddRequestModel(string code, int creatorAccountId, bool isUsed, DateTime createDate)
        {
            Code = code;
            CreatorAccountId = creatorAccountId;
            IsUsed = isUsed;
            CreateDate = createDate;
        }

        public string Code { get; set; }
        public int CreatorAccountId { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
