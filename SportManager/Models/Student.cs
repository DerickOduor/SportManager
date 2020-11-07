using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportManager.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; }
        [Display(Name = "Firstname")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Invalid firstname!")]
        public string Firstname { get; set; }
        [Display(Name = "Lastname")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Invalid lastname!")]
        public string Lastname { get; set; }
        [Display(Name = "E-mail address")]
        [RegularExpression("^(([^<>()\\[\\]\\.,;:\\s@\\\"]+(\\.[^<>()\\[\\]\\.,;:\\s@\\\"]+)*)|(\\\".+\\\"))@(([^<>()[\\]\\.,;:\\s@\\\"]+\\.)+[^<>()[\\]\\.,;:\\s@\\\"]{2,})$", ErrorMessage = "Invalid email!")]
        public string Email { get; set; }
        [Display(Name = "Phone")]
        [RegularExpression("^\\+(\\d{1,3}?)?(\\d{3}?)(\\d{2}?){2}\\d{2}$", ErrorMessage = "Invalid phone!")]
        public string Phone { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "One-Time Password")]
        public string Otp { get; set; }
        public DateTime OtpDate { get; set; }
        public bool Status { get; set; }
        public bool Authorized { get; set; }
        [Display(Name = "Account Verified")]
        public bool RegistrationVerified { get; set; }
        public bool ChangePassword { get; set; }
        public DateTime DateRegistered { get; set; }
        [Display(Name = "Profile")]
        public Guid ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
        [Display(Name = "Sport Discipine")]
        public Guid SportDiscipineId { get; set; }
        public virtual SportDiscipine SportDiscipine { get; set; }
        public virtual IEnumerable<StudentsParticipatingInEvent> StudentsParticipatingInEvent { get; set; }
    }
    public class Staff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Otp { get; set; }
        public DateTime OtpDate { get; set; }
        public bool Authorized { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
        public bool ChangePassword { get; set; }
        public bool RegistrationVerified { get; set; }
        public DateTime DateRegistered { get; set; }
        public Guid ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual SportDiscipinePatron SportDiscipinePatron { get; set; }
        public virtual IEnumerable<MakerChecker> MakerCheckers { get; set; }
    }

    public class Profile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<AccessRight> AccessRights { get; set; }
        public virtual IEnumerable<Staff> Staffs { get; set; }
    }

    public class AccessRight
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public Guid ParentMenuId { get; set; }
        public Guid ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }

    public class Menu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CssClass { get; set; }
        public string Link { get; set; }
        /// <summary>
        /// SUB-MENU OR MAINMENU
        /// </summary>
        public string MenuType { get; set; }
        /// <summary>
        /// STAFF OR STUDENT
        /// </summary>
        public string MenuUser { get; set; }
        public Guid ParentId { get; set; }
        public int Level { get; set; }
        public virtual IEnumerable<AccessRight> AccessRights { get; set; }
    }

    public class ErrorLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Error { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string RecepientAddress { get; set; }
        public string RecepientName { get; set; }
        public string MessageSubject { get; set; }
        public string MessageText { get; set; }
        /// <summary>
        /// EMAIL OR TEXT
        /// </summary>
        public string MessageType { get; set; }
        public bool Sent { get; set; }
        public DateTime MessageDate { get; set; }
    }

    public class Parameter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsPassword { get; set; }
    }

    public class Password
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string PasswordText { get; set; }
    }

    public class MakerChecker
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string SqlQuery { get; set; }
        public string Entity { get; set; }
        /// <summary>
        /// 1-CREATE
        /// 2-UPDATE
        /// 3-DELETE
        /// </summary>
        public int Action { get; set; }
        /// <summary>
        /// 0-PENDING
        /// 1-APPROVED
        /// 2-REJECTED
        /// </summary>
        public int Status { get; set; }
        public virtual Staff Maker { get; set; }
        public virtual Staff Checker { get; set; }
    }

    public class SportDiscipine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Date added")]
        public DateTime DateAdded { get; set; }
        [Display(Name = "Deleted")]
        public bool Deleted { get; set; }
        [Display(Name = "Status")]
        public bool Status { get; set; }
        [Display(Name = "Patron")]
        public virtual SportDiscipinePatron SportDiscipinePatron { get; set; }
        [Display(Name = "Students")]
        public virtual IEnumerable<Student> Students { get; set; }
        [Display(Name = "Teams")]
        public virtual IEnumerable<Team> Teams { get; set; }
        [Display(Name = "Store items")]
        public virtual IEnumerable<StoreItemInUse> StoreItemsInUse { get; set; }
    }

    public class Venue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }
        [Display(Name = "Available")]
        public bool Available { get; set; }
        [Display(Name = "Event sessions")]
        public virtual IEnumerable<EventSession> EventSessions { get; set; }
    }

    public class EventType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Event> Event { get; set; }
    }

    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime NewStartDate { get; set; }
        public DateTime NewEndDate { get; set; }
        public Guid EventTypeId { get; set; }
        public bool PostPoned { get; set; }
        public bool Cancelled { get; set; }
        public bool Ongoing { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual IEnumerable<Team> Teams { get; set; }
        public virtual IEnumerable<StoreItemInUse> StoreItemsInUse { get; set; }
        public virtual IEnumerable<SportDisciplinesInEvent> SportDisciplinesInEvent { get; set; }
        public virtual IEnumerable<EventSession> EventSessions { get; set; }
    }

    public class EventSession
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid VenueId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual Event Event { get; set; }
        public virtual Venue Venue { get; set; }
    }

    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid EventId { get; set; }
        public Guid SportDiscipineId { get; set; }
        public virtual Event Event { get; set; }
        public virtual SportDiscipine SportDiscipine { get; set; }
        public virtual IEnumerable<TeamMember> TeamMembers { get; set; }
    }

    public class TeamMember
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual Team Team { get; set; }
    }

    public class StoreItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public Guid StoreCategoryId { get; set; }
        public virtual StoreCategory StoreCategory { get; set; }
        public virtual IEnumerable<StoreItemInUse> StoreItemsInUse { get; set; }
    }

    public class StoreItemInUse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid StoreItemId { get; set; }
        public Guid EventId { get; set; }
        public Guid SportDiscipineId { get; set; }
        public int Count { get; set; }
        public bool Approved { get; set; }
        public bool Rejected { get; set; }
        public bool Returned { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateApproved { get; set; }
        public DateTime DateReturned { get; set; }
        public virtual StoreItem StoreItem { get; set; }
        public virtual Event Event { get; set; }
        public virtual SportDiscipine SportDiscipine { get; set; }
    }

    public class Store
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<StoreCategory> StoreCategories { get; set; }
    }

    public class SportDiscipinePatron
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid SportDiscipineId { get; set; }
        public virtual SportDiscipine SportDiscipine { get; set; }
        public Guid StaffId { get; set; }
        public virtual Staff Staff { get; set; }
    }

    public class StoreCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<StoreItem> StoreItems { get; set; }
    }

    public class SportDisciplinesInEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid SportDiscipineId { get; set; }
        public virtual Event Event { get; set; }
        public virtual SportDiscipine SportDiscipine { get; set; }
        public virtual IEnumerable<StudentsParticipatingInEvent> StudentsParticipatingInEvent { get; set; }
    }

    public class StudentsParticipatingInEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid SportDisciplinesInEventId { get; set; }
        public virtual Student Student { get; set; }
        public virtual SportDisciplinesInEvent SportDisciplinesInEvent { get; set; }
    }
}
