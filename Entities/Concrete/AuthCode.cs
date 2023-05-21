using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class AuthCode : IEntity
    {
        public AuthCode() { }

        public AuthCode(int id, string code, int creatorAccountId, bool isUsed, DateTime createDate)
        {
            Id = id;
            Code = code;
            CreatorAccountId = creatorAccountId;
            IsUsed = isUsed;
            CreateDate = createDate;
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public int CreatorAccountId { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
