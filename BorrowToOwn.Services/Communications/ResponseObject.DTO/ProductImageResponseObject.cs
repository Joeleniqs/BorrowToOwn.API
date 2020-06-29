namespace BorrowToOwn.Services.Communications.ResponseObject.DTO
{
    public class ProductImageResponseObject
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsCoverImage { get; set; }
    }
}
