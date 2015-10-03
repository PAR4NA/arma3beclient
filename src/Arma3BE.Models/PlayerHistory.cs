using System;

namespace Arma3BE.Models
{
    public class PlayerHistory
    {
        public int Id { get; set; }
        public Guid PlayerId { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public DateTime Date { get; set; }
        public Guid ServerId { get; set; }
    }
}