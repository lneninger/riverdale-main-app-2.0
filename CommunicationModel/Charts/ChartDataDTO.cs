using CommunicationModel.Commons;
using System;

namespace CommunicationModel
{
    public class ChartDataDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MainPhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string PostalAddress { get; set; }
        public Guid? PictureId { get; set; }
        public TemporaryFileUpdatedResult UploadedPicture { get; set; }
        public string Email { get; set; }
        public string WebSiteUrl { get; set; }
        public int FacebookLikes { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
    }
}
