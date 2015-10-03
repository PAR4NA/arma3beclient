using System;

namespace Arma3BE.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public int Num { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public Guid ServerId { get; set; }
    }
}