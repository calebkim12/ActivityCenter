using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityCenter.Models
{
    public class Participate
    {
        [Key]
        public int JoinId {get;set;}
        public int UserId {get;set;}
        public int DojoEventId {get;set;}
        public User AUser {get;set;}
        public DojoEvent DojoEvent {get;set;}
    }
}