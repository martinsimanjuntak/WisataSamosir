using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("tb_account")]
    public class Account
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("username"), MaxLength(25)]
        public string Username { get; set; }
        [Column("email"), MaxLength(25)]
        public string Email{ get; set; }
        [Column("password"), MaxLength(100)]
        public string Password { get; set; }
        public int Role_id { get; set; }
        public int Status_id { get; set; }
        [ForeignKey("Role_id")]
        public virtual Role Role { get; set; }
        [ForeignKey("Status_id")]
        public virtual Status Status { get; set; }

        public void UpdateAccount(string username, string email, string password, int role, int status)
        {
            this.Username = username;
            this.Email = email;
            this.Password = BCrypt.Net.BCrypt.HashPassword(password);
            this.Role_id = role;
            this.Status_id = status;
        }
    }
}
