namespace PaymentAPI.Models
{
    public class PaymentModel
    {
        public PaymentModel() { }

        public AccountInfoModel AccountInfo { get; set; }
        public List<OrderInfoModel> Orders { get; set; }
    }
}
