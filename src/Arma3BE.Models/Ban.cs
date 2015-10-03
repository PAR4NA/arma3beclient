using System;

namespace Arma3BE.Models
{
    public class Ban
    {
        public int Id { get; set; }
        public Guid? PlayerId { get; set; }
        public int Num { get; set; }
        public Guid ServerId { get; set; }
        public string GuidIp { get; set; }
        public int Minutes { get; set; }
        public int MinutesLeft { get; set; }
        public string Reason { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}