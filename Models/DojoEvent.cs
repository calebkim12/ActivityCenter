using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityCenter.Models
{
    public class DojoEvent
    {
        [Key]
        public int DojoEventId {get; set;}
        [Required(ErrorMessage="An Event Name is required")]
        public string ActivityTitle {get; set;}
        [Required(ErrorMessage="A start time is required")]
        [NotInPast(ErrorMessage="Cannot create an activity in the past!")]
        [DataType(DataType.DateTime)]
        public DateTime ActivityStart {get; set;}
        [Required(ErrorMessage="An Activity duration is required")]
        [MinValue]
        public int ActivityDuration {get; set;}
        [Required(ErrorMessage="An Activity description is required")]
        public string ActivityDescription {get; set;}
        public User Coordinator {get; set;}
        public int UserID {get; set;}
        public List<Participate> Attendees {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
    }
}